using Agraria.Datos;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Entidades;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Agraria.UserControls
{
    public partial class UcEngorde : UserControl
    {
        private readonly EngordeBLL _bll = new EngordeBLL();
        private readonly string _nombrePagina;
        private readonly UsuarioLoginDTO _usuarioLogeado;

        public UcEngorde(string nombrePagina, UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _nombrePagina = nombrePagina ?? "";
            _usuarioLogeado = usuarioLogeado;

            CargarCombos();
            CargarGrid();

            txtBuscarPorGrilla.TextChanged += TxtBuscarPorGrilla_TextChanged;
        }

        public void DeshabilitarControlesInternos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox txt)
                    txt.ReadOnly = true;
                else if (c is ComboBox combo)
                    combo.Enabled = false;
                else if (c is Button btn)
                    btn.Enabled = false;
                if (c.HasChildren)
                    DeshabilitarControlesInternosRecursivo(c);
            }
        }

        private void DeshabilitarControlesInternosRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt)
                    txt.ReadOnly = true;
                else if (c is ComboBox combo)
                    combo.Enabled = false;
                else if (c is Button btn)
                    btn.Enabled = false;
                if (c.HasChildren)
                    DeshabilitarControlesInternosRecursivo(c);
            }
        }

        // Cargar combos
        private void CargarCombos()
        {
            var boxes = BoxDAL.Listar();
            cmbBoxCarga.DataSource = boxes;
            cmbBoxCarga.DisplayMember = "Nombre";
            cmbBoxCarga.ValueMember = "IdBox";

            cmbPolloEnvio.DataSource = boxes.ToList();
            cmbPolloEnvio.DisplayMember = "Nombre";
            cmbPolloEnvio.ValueMember = "IdBox";

            cmbPolloActualizar.DataSource = boxes.ToList();
            cmbPolloActualizar.DisplayMember = "Nombre";
            cmbPolloActualizar.ValueMember = "IdBox";

            var alimentos = AlimentoDAL.Listar();
            cmbTipoAlimento.DataSource = alimentos;
            cmbTipoAlimento.DisplayMember = "Nombre";
            cmbTipoAlimento.ValueMember = "IdAlimento";
        }



        private void CargarGrid()
        {
            try
            {
                dtgRegistroPollos.AutoGenerateColumns = true;
                dtgRegistroPollos.DataSource = _bll.Listar(_nombrePagina); // ✅ ahora filtra por nombre
                dtgRegistroPollos.DefaultCellStyle.ForeColor = Color.Black;

                if (dtgRegistroPollos.Columns.Contains("FechaIngreso"))
                    dtgRegistroPollos.Columns["FechaIngreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
                if (dtgRegistroPollos.Columns.Contains("FechaActualizado"))
                    dtgRegistroPollos.Columns["FechaActualizado"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Filtro por IdBox
        private void TxtBuscarPorGrilla_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscarPorGrilla.Text, out int idBox))
                dtgRegistroPollos.DataSource = _bll.BuscarPorBox(idBox);
            else
                CargarGrid();
        }

        // Guardar ingreso inicial
        private void btnGuardarPollos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBoxCarga.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un Box válido.");
                    return;
                }

                if (!int.TryParse(txtCargabox.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    return;
                }

                int idBox = Convert.ToInt32(cmbBoxCarga.SelectedValue);
                DateTime fecha = dtpFechaCarga.Value.Date;

                // 👇 Orden correcto de parámetros (nombre, idBox, fecha, cantidad)
                _bll.GuardarIngresoPollos(_nombrePagina, idBox, fecha, cantidad);

                MessageBox.Show("Registro de Aves guardado correctamente.");
                CargarGrid();
                CargarCombos();   // si querés refrescar combos también
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar Aves: " + ex.Message);
            }
        }

        // Guardar actualización (engorde)
        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPolloActualizar.SelectedValue == null || cmbTipoAlimento.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione Box y Alimento válidos.");
                    return;
                }

                if (!int.TryParse(txtCantidadPollosEngorde.Text, out int cantidad) || cantidad < 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }
                if (!int.TryParse(txtEdadPollo.Text, out int semanas) || semanas < 0)
                {
                    MessageBox.Show("Semanas inválidas.");
                    return;
                }
                if (!decimal.TryParse(txtPesoPollo.Text, out decimal peso) || peso < 0)
                {
                    MessageBox.Show("Peso inválido.");
                    return;
                }
                if (!decimal.TryParse(txtAlimentoKlDia.Text, out decimal alimentoDia) || alimentoDia < 0)
                {
                    MessageBox.Show("Alimento/día inválido.");
                    return;
                }

                int idBox = Convert.ToInt32(cmbPolloActualizar.SelectedValue);
                int idAlimento = Convert.ToInt32(cmbTipoAlimento.SelectedValue);
                DateTime fechaAct = dtpFechaIngresoPollosEngorde.Value.Date;

                // 👇 Orden correcto (nombre, idBox, fecha, cantidad, semanas, peso, idAlimento, alimentoDia)
                _bll.GuardarRegistroEngorde(_nombrePagina, idBox, fechaAct, cantidad, semanas, peso, idAlimento, alimentoDia);

                MessageBox.Show("Registro actualizado correctamente.");
                CargarGrid();
                CargarCombos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar registro: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCantidadPollosEngorde.Clear();
            txtCantidadPollosEngorde2.Clear();
            txtEdadPollo.Clear();
            txtPesoPollo.Clear();
            txtAlimentoKlDia.Clear();
            // si preferís no mover la selección, podés comentar:
            // cmbBoxCarga.SelectedIndex = -1;
            // cmbPolloActualizar.SelectedIndex = -1;
            // cmbPolloEnvio.SelectedIndex = -1;
            // cmbTipoAlimento.SelectedIndex = -1;
        }

        // Imprimir (PDF con HTML)
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "ReporteEngorde.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Engorde.html");
                string html = File.ReadAllText(rutaPlantilla);

                html = html.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                html = html.Replace("@NOMBREPAGINA", _nombrePagina);

                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgRegistroPollos.Rows)
                {
                    if (row.IsNewRow) continue;

                    filas += "<tr>";
                    filas += $"<td>{row.Cells["IdEngorde"].Value}</td>";
                    filas += $"<td>{row.Cells["NombreBox"].Value}</td>";
                    filas += $"<td>{row.Cells["Nombre"].Value}</td>";
                    filas += $"<td>{(row.Cells["FechaIngreso"].Value == null ? "" : Convert.ToDateTime(row.Cells["FechaIngreso"].Value).ToString("dd/MM/yyyy"))}</td>";
                    filas += $"<td>{row.Cells["Cantidad"].Value}</td>";
                    filas += $"<td>{(row.Cells["FechaActualizado"].Value == null ? "" : Convert.ToDateTime(row.Cells["FechaActualizado"].Value).ToString("dd/MM/yyyy"))}</td>";
                    filas += $"<td>{row.Cells["Semanas"].Value}</td>";
                    filas += $"<td>{row.Cells["Peso"].Value}</td>";
                    filas += $"<td>{row.Cells["NombreAlimento"].Value}</td>";
                    filas += $"<td>{row.Cells["AlimentoPorDia"].Value}</td>";
                    filas += $"<td>{(((bool?)row.Cells["Estado"].Value) == true ? "Activo" : "Inactivo")}</td>";
                    filas += "</tr>";
                }

                html = html.Replace("@FILAS", filas);

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // (Opcional) Enviar a industria – cuando definas la lógica en DAL
        private void btnEnviarPolloEngordeIndustria_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPolloEnvio.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un Box válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idBox = Convert.ToInt32(cmbPolloEnvio.SelectedValue);
                int cantidadEnviar;

                if (!int.TryParse(txtCantidadPollosEngorde2.Text.Trim(), out cantidadEnviar) || cantidadEnviar <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de aves a enviar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Obtener la última cantidad disponible de ese Box
                int cantidadDisponible = _bll.ObtenerUltimaCantidadDisponible(idBox);

                if (cantidadDisponible <= 0)
                {
                    MessageBox.Show($"No hay aves disponibles en el Box {idBox}.", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cantidadEnviar > cantidadDisponible)
                {
                    MessageBox.Show($"Solo hay {cantidadDisponible} aves disponibles para enviar en el Box {idBox}.",
                                    "Cantidad excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Confirmación
                var confirmar = MessageBox.Show(
                    $"¿Desea enviar {cantidadEnviar} aves del Box {idBox} a Industria?",
                    "Confirmar envío",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmar != DialogResult.Yes)
                    return;

                // 🔹 Datos para tabla Articulo
                string nombreProducto = _nombrePagina; // nombre de la pestaña del TabControl
                DateTime fechaEgreso = dtpFechaEgresoPollosEngorde.Value.Date;
                int idTipoEntorno = 1; // Animal
                string responsable = _usuarioLogeado?.NombreUsuario ?? "UsuarioSistema";

                // 🔹 Insertar en Articulos
                Articulo articulo = new Articulo
                {
                    NombreProducto = nombreProducto,
                    Cantidad = cantidadEnviar,
                    IdTipoMedida = 2, // Unidad o cantidad
                    Precio = null,
                    FechaIngreso = fechaEgreso,
                    IdTipoEntorno = idTipoEntorno,
                    Responsable = responsable,
                    FechaEgreso = fechaEgreso,
                    Estado = true
                };

                ArticuloDAL.Insertar(articulo);

                // 🔹 Actualizar Engorde: marcar como enviado si agotó stock
                if (cantidadEnviar == cantidadDisponible)
                {
                    EngordeDAL.MarcarComoInactivo(idBox);
                }

                MessageBox.Show("aves enviados correctamente a Industria.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar aves a industria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }


        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);

        }

        private void SoloNumerosYComa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosYComa(txtCantidadPollosEngorde, e, errorProvider1);
        }

        private void UcEngorde_Load(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
        }
    }
}
