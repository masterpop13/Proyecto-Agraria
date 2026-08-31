using Agraria.Datos.DTO;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class Industria : Form
    {
        private readonly ProductosBLL productosBLL = new ProductosBLL();
        private readonly IndustriaBLL industriaBLL = new IndustriaBLL();
        private ArticuloBLL articuloBLL = new ArticuloBLL();
        private bool esInvitado = false;

        // Lista temporal de insumos seleccionados antes de guardar
        private List<Tuple<int, string, int>> insumosSeleccionados = new List<Tuple<int, string, int>>();

        public Industria(Form formulariomenu)
        {
            InitializeComponent();
        }

        private void Industria_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.AdaptMdiChild(this);
            CargarCombos();
            CargarGridIndustria();

            // Configuración de los DataGridView
            dtgArticulosIndustria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgInsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgArticulosIndustria.Columns["IdIndustria"].Visible = false;
            txtRecetas.Enabled = false;
            txtDetalle.Enabled = false;

        }

        public Industria(bool invitado = false)
        {
            InitializeComponent();
            esInvitado = invitado;

            if (esInvitado)
                DeshabilitarControles();
        }

        private void DeshabilitarControles()
        {
            DeshabilitarControlesRecursivo(this);
        }

        private void DeshabilitarControlesRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt)
                    txt.ReadOnly = true;

                else if (c is ComboBox combo)
                    combo.Enabled = false;

                else if (c is Button btn && btn.Name != "btnCerrar")
                    btn.Enabled = false;

                // ✅ Recorre los hijos del control actual (GroupBox, Panel, etc.)
                if (c.HasChildren)
                    DeshabilitarControlesRecursivo(c);
            }
        }


        private void CargarComboInsumos()
        {
            var lista = articuloBLL.ObtenerInsumosAgrupados(); // este método debe agrupar por NombreProducto y sumar stock
            cmbInsumos.DataSource = lista;
            cmbInsumos.DisplayMember = "NombreProducto";
            cmbInsumos.ValueMember = "IdInsumoRepresentativo";
            cmbInsumos.SelectedIndex = -1;
        }

        private void CargarCombos()
        {
            // 🔹 Productos
            var productos = productosBLL.ListarProductos();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
            cmbProducto.SelectedIndex = -1;

            // 🔹 Insumos agrupados
            CargarComboInsumos();
        }

        private void CargarGridIndustria()
        {
            dtgArticulosIndustria.DataSource = industriaBLL.ListarIndustria();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem is ProductoDTO producto)
            {
                txtRecetas.Text = producto.Descripcion ?? "";
            }
        }

        private void cmbInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInsumos.SelectedItem is InsumoDTO insumo)
            {
                txtCantidadInsumos.Text = insumo.StockTotal.ToString("0.##");
                txtDetalle.Text = insumo.NombreTipoMedida; // 🔹 mostrar el nombre del TipoMedida
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AsegurarColumnasDtgInsumos();

            if (!(cmbInsumos.SelectedItem is Agraria.Datos.DTO.InsumoDTO ins))
            {
                MessageBox.Show("Seleccione un insumo válido.");
                return;
            }

            // cantidad a usar (del textbox txtCantidadInsumos)
            if (!decimal.TryParse(txtCantidadInsumos.Text, out decimal cantUsar) || cantUsar <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida a utilizar.");
                return;
            }

            // 🔹 Calcular cuánto ya se seleccionó de este insumo
            decimal cantidadYaSeleccionada = insumosSeleccionados
                .Where(x => x.Item1 == ins.IdInsumoRepresentativo)
                .Sum(x => (decimal)x.Item3);

            // 🔹 Calcular el stock restante
            decimal stockRestante = ins.StockTotal - cantidadYaSeleccionada;

            if (cantUsar > stockRestante)
            {
                MessageBox.Show($"Stock insuficiente. Disponible restante: {stockRestante}");
                return;
            }

            // 🔹 Agregar el insumo a la lista temporal
            insumosSeleccionados.Add(new Tuple<int, string, int>(
                ins.IdInsumoRepresentativo,
                ins.NombreProducto,
                (int)cantUsar // guardamos como int ya que el Tuple estaba definido con int
            ));

            // 🔹 Refrescar la grilla de insumos
            dtgInsumos.DataSource = null;
            dtgInsumos.DataSource = insumosSeleccionados.Select(x => new
            {
                IdInsumo = x.Item1,
                NombreInsumo = x.Item2,
                Cantidad = x.Item3
            }).ToList();
        }

        private void AsegurarColumnasDtgInsumos()
        {
            if (dtgInsumos.Columns.Count == 0)
            {
                dtgInsumos.AutoGenerateColumns = false;

                dtgInsumos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IdInsumo",
                    HeaderText = "ID",
                    DataPropertyName = "IdInsumo",
                    Visible = false // ocultamos el ID en la grilla
                });

                dtgInsumos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NombreInsumo",
                    HeaderText = "Insumo",
                    DataPropertyName = "NombreInsumo",
                    ReadOnly = true
                });

                dtgInsumos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Cantidad",
                    HeaderText = "Cantidad",
                    DataPropertyName = "Cantidad",
                    ReadOnly = true
                });
            }
        }



        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgInsumos.CurrentRow != null)
            {
                int idInsumo = Convert.ToInt32(dtgInsumos.CurrentRow.Cells["IdInsumo"].Value);
                insumosSeleccionados = insumosSeleccionados.Where(x => x.Item1 != idInsumo).ToList();

                // Refrescar grilla
                dtgInsumos.DataSource = null;
                dtgInsumos.DataSource = insumosSeleccionados.Select(x => new
                {
                    IdInsumo = x.Item1,
                    NombreInsumo = x.Item2,
                    Cantidad = x.Item3
                }).ToList();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidadProduccion.Text, out int cantidadProduccion) || cantidadProduccion <= 0)
            {
                MessageBox.Show("Ingrese una cantidad de producción válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (insumosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un insumo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = (int)cmbProducto.SelectedValue;
            DateTime fechaProduccion = dtpFecha.Value;

            bool primerRegistro = true;  // 🔹 Flag para que solo el primero tenga la cantidad

            foreach (var insumo in insumosSeleccionados)
            {
                var entidad = new Agraria.Datos.Entidades.Industria
                {
                    IdRegistroIndustria = 0, // autoincrement
                    IdIndustria = 1,         // puede ser un correlativo si agrupás
                    IdProducto = idProducto,
                    CantidadProduccion = primerRegistro ? cantidadProduccion : 0, // 🔹 Solo en el primero
                    FechaProduccion = fechaProduccion,
                    IdInsumos = insumo.Item1,
                    CantidadInsumos = insumo.Item3
                };

                industriaBLL.GuardarIndustria(entidad);

                primerRegistro = false; // 🔹 Los siguientes registros ya quedan con 0
            }

            MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 🔹 Refrescar pantallas
            insumosSeleccionados.Clear();
            dtgInsumos.DataSource = null;
            CargarGridIndustria();
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgArticulosIndustria.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para imprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "ReporteIndustria.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                // Ruta de la plantilla HTML
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "industria.html");
                string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                // Reemplazar la fecha actual
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                // Reemplazar el nombre de la pestaña o página (si tu control tiene esa info)
                string nombrePagina = ObtenerNombrePagina();
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOMBREPAGINA", nombrePagina);

                // Generar las filas de la tabla desde el DataGridView
                StringBuilder filas = new StringBuilder();

                foreach (DataGridViewRow row in dtgArticulosIndustria.Rows)
                {
                    if (row.IsNewRow) continue;

                    filas.Append("<tr>");
                    filas.AppendFormat("<td>{0}</td>", row.Cells["IdRegistroIndustria"]?.Value ?? "");
                    filas.AppendFormat("<td>{0}</td>", row.Cells["NombreProducto"]?.Value ?? "");
                    filas.AppendFormat("<td>{0}</td>", row.Cells["CantidadProduccion"]?.Value ?? "");
                    filas.AppendFormat("<td>{0:dd/MM/yyyy}</td>", row.Cells["FechaProduccion"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["NombreInsumo"]?.Value ?? "");
                    filas.AppendFormat("<td>{0}</td>", row.Cells["CantidadInsumos"]?.Value ?? "");
                    filas.Append("</tr>");
                }

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas.ToString());

                // Guardar y generar el PDF
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        // Logo opcional
                        if (Properties.Resources.agr != null)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }

                        // Parsear la plantilla HTML
                        using (StringReader sr = new StringReader(PaginaHTML_Texto))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte de Industria generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este método opcional devuelve el nombre de la pestaña actual del TabControl
        private string ObtenerNombrePagina()
        {
            try
            {
                if (Parent is TabPage tab)
                    return tab.Text;
            }
            catch { }
            return "Industria";
        }



        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);

        }
        private void Solotexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTexto(e);

        }

        private void TextoyNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.TextoYNumero(e);

        }


        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }

        private void solonumeroypunto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosYPunto((TextBox)sender, e, errorProvider1);
        }

        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTextoNumeroEspacio(e);
        }

        private void dtgArticulosIndustria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
