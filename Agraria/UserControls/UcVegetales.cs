using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Agraria.UserControls
{
    public partial class UcVegetales : UserControl
    {
        private readonly VegetalesBLL _bll = new VegetalesBLL();
        private readonly string _nombrePagina;
        private readonly UsuarioLoginDTO _usuario;

        public UcVegetales(string nombrePagina, UsuarioLoginDTO usuarioLogeado)
        {


            InitializeComponent();

            // Asociar eventos
            btnGuardar.Click += btnGuardar_Click;
            btnGuardarPlantin.Click += btnGuardarPlantin_Click;
            btnEnviarArticulos.Click += btnEnviarArticulos_Click;
            btnResetearPlantines.Click += btnResetearPlantines_Click;
            btnImprimir.Click += btnImprimir_Click;
            Load += UcVegetales_Load;
            _nombrePagina = nombrePagina ?? "";
            _usuario = usuarioLogeado;



        }

        private void UcVegetales_Load(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
            ConfigurarDataGridView();
            CargarGrid();
            CargarComboCantidad();
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



        private string ObtenerNombrePagina()
        {
            var tabPage = this.Parent as TabPage;
            return tabPage != null ? tabPage.Text : "Vegetal";
        }

        private void ConfigurarDataGridView()
        {
            dtgCosecha.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgCosecha.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCosecha.ReadOnly = true;
            dtgCosecha.AllowUserToAddRows = false;
            dtgCosecha.DefaultCellStyle.ForeColor = Color.Black;

        }

        private void CargarGrid()
        {
            string nombrePagina = ObtenerNombrePagina();
            dtgCosecha.DataSource = _bll.ObtenerPorNombre(nombrePagina);
        }

        private void CargarComboCantidad()
        {
            string nombrePagina = ObtenerNombrePagina();
            var lista = _bll.ObtenerPorNombre(nombrePagina)
                            .Where(x => x.Estado)
                            .Select(x => x.Cantidad)
                            .Distinct()
                            .OrderBy(x => x)
                            .ToList();
            cmbCantidad.DataSource = lista;
        }

        private void LimpiarCampos()
        {
            txtAgregarPlantines.Text = "0";
            txtAgregarAtadoCosechado.Text = "0";
            cmbCantidad.SelectedIndex = -1;
            dtpFechaCultivo.Value = DateTime.Now;
            dtpFechaPlantado.Value = DateTime.Now;
            dtpFechaEgreso.Value = DateTime.Now;
        }

        private void btnGuardarPlantin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtAgregarPlantines.Text, out int plantines) || plantines <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de plantines (>0).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var entidad = new Vegetales
                {
                    Nombre = ObtenerNombrePagina(),
                    CantidadPlantines = plantines,
                    Cantidad = 0,
                    FechaCultivo = dtpFechaCultivo.Value.Date,
                    FechaCosecha = DateTime.Now,
                    Estado = true
                };

                _bll.Guardar(entidad);
                MessageBox.Show("Plantines guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                CargarComboCantidad();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar plantines: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtAgregarAtadoCosechado.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida (>0).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var entidad = new Vegetales
                {
                    Nombre = ObtenerNombrePagina(),
                    CantidadPlantines = 0,
                    Cantidad = cantidad,
                    FechaCultivo = DateTime.Now,
                    FechaCosecha = dtpFechaPlantado.Value.Date,
                    Estado = true
                };

                _bll.Guardar(entidad);
                MessageBox.Show("Cantidad guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                CargarComboCantidad();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cantidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cmbCantidad.Text, out int cantidadEnviar) || cantidadEnviar <= 0)
                {
                    MessageBox.Show("Seleccione una cantidad válida para enviar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show($"¿Enviar {cantidadEnviar} de {ObtenerNombrePagina()} a Industria?",
                                              "Confirmar envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                _bll.EnviarAIndustria(cantidadEnviar, dtpFechaEgreso.Value, ObtenerNombrePagina(), 2, _usuario?.NombreUsuario ?? "Invitado");

                MessageBox.Show("Envío realizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                CargarComboCantidad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar a industria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetearPlantines_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = ObtenerNombrePagina();

                // Validar que existan plantines activos antes de resetear
                var cantidadActivos = _bll.ObtenerPlantinesActivosPorNombre(nombre);
                if (cantidadActivos <= 0)
                {
                    MessageBox.Show("No hay plantines activos para resetear.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _bll.CambiarEstado(nombre, false);
                MessageBox.Show("Se reseteó el estado de los registros activos con plantines.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                CargarComboCantidad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al resetear plantines: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //  Campo de clase (arriba del todo, fuera del método)


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Configuración del diálogo
                SaveFileDialog savefile = new SaveFileDialog();
                string nombrePagina = ObtenerNombrePagina(); // mismo criterio que usabas
                savefile.FileName = $"ReporteVegetales_{nombrePagina}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                // 2) Cargar plantilla
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Vegetales.html");
                string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                // 3) Reemplazos
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOMBREPAGINA", nombrePagina);

                // 4) Construir filas (null-safe como en tu botón que funciona)
                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgCosecha.Rows)
                {
                    if (row.IsNewRow) continue;

                    filas += "<tr>";
                    filas += $"<td>{row.Cells["Nombre"].Value ?? "-"}</td>";

                    // FechaCultivo
                    if (row.Cells["FechaCultivo"].Value is DateTime fc)
                        filas += $"<td>{fc:dd/MM/yyyy}</td>";
                    else
                        filas += "<td>-</td>";

                    // FechaCosecha
                    if (row.Cells["FechaCosecha"].Value is DateTime fco)
                        filas += $"<td>{fco:dd/MM/yyyy}</td>";
                    else
                        filas += "<td>-</td>";

                    filas += $"<td>{row.Cells["CantidadPlantines"].Value ?? 0}</td>";
                    filas += $"<td>{row.Cells["Cantidad"].Value ?? 0}</td>";

                    bool estado = row.Cells["Estado"].Value != null
                                  && row.Cells["Estado"].Value != DBNull.Value
                                  && Convert.ToBoolean(row.Cells["Estado"].Value);
                    filas += $"<td>{(estado ? "Activo" : "Inactivo")}</td>";
                    filas += "</tr>";
                }

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

                // 5) Mostrar diálogo y generar PDF
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new iTextSharp.text.Phrase(""));

                        // Logo opcional (igual que el otro)
                        if (Properties.Resources.agr != null)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }

                        using (StringReader sr = new StringReader(PaginaHTML_Texto))
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


        private void UcVegetales_Load_1(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarGrid();
            CargarComboCantidad();
        }

        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }


        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);

        }
    }
}
