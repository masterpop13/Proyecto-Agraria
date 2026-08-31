using Agraria.Datos;
using Agraria.Datos.DTO;
using Agraria.Entidades;
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
    public partial class UcColmenas : UserControl
    {
        private readonly ColmenasBLL _bll = new ColmenasBLL();
        private readonly string _nombrePagina;
        private readonly UsuarioLoginDTO _usuario;

        public UcColmenas(string nombrePagina, UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _nombrePagina = nombrePagina ?? "";
            _usuario = usuarioLogeado;


            CargarGrid();
            CargarComboEnviar();

            // eventos
            btnGuardarColmena.Click += btnGuardarColmena_Click;
            btnCantidadMiel.Click += btnCantidadMiel_Click;
            btnQuitarColmena.Click += btnQuitarColmena_Click;
            btnEnviarIndustria.Click += btnEnviarIndustria_Click;
            btnImprimir.Click += btnImprimir_Click;
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

        private void CargarGrid()
        {
            dtgDatosMiel.AutoGenerateColumns = true;
            dtgDatosMiel.DataSource = _bll.ListarPorNombre(_nombrePagina);
            dtgDatosMiel.DefaultCellStyle.ForeColor = Color.Black;
        }


        private void CargarComboEnviar()
        {
            var tot = _bll.TotalesColmenas(_nombrePagina);
            cmbEnviarIndustria.Items.Clear();
            cmbEnviarIndustria.Items.Add(tot.miel);
            cmbEnviarIndustria.SelectedIndex = 0;
            cmbEnviarIndustria.Enabled = tot.miel > 0;

        }

        // Helpers para limpiar
        private void LimpiarIngresoColmenas()
        {
            txtColmena.Clear();
            dtpFechaColmena.Value = DateTime.Now;
        }
        private void LimpiarIngresoMiel()
        {
            txtCantidadMiel.Clear();
            dtpFechaCosechaMiel.Value = DateTime.Now;
        }
        private void LimpiarRetiro()
        {
            txtRetiroColmena.Clear();
            dtpFechaRetiroColmena.Value = DateTime.Now;
        }
        private void LimpiarEnvio()
        {
            cmbEnviarIndustria.Text = "";
            dtpFechaEnvioIndustria.Value = DateTime.Now;
        }

        // ---------- Botones ----------
        private void btnGuardarColmena_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtColmena.Text.Trim(), out int cant) || cant <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de colmenas (>0).");
                    return;
                }
                _bll.GuardarIngresoColmenas(_nombrePagina, cant, dtpFechaColmena.Value.Date);
                MessageBox.Show("Ingreso de colmenas guardado.");
                CargarGrid();
                LimpiarIngresoColmenas();
                CargarComboEnviar();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnCantidadMiel_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCantidadMiel.Text.Trim(), out int cant) || cant <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de miel (>0).");
                    return;
                }
                _bll.GuardarIngresoMiel(_nombrePagina, cant, dtpFechaCosechaMiel.Value.Date);
                MessageBox.Show("Registro de miel guardado.");
                CargarGrid();
                LimpiarIngresoMiel();
                CargarComboEnviar();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnQuitarColmena_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtRetiroColmena.Text.Trim(), out int cant) || cant <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida a retirar (>0).");
                    return;
                }

                int disponibles = _bll.ObtenerDisponibles(_nombrePagina);

                if (disponibles <= 0)
                {
                    MessageBox.Show($"No hay colmenas activas disponibles para retirar en '{_nombrePagina}'.",
                        "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cant > disponibles)
                {
                    MessageBox.Show($"No puede retirar {cant} colmenas. Solo hay {disponibles} disponibles actualmente.",
                        "Cantidad excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Guarda el retiro (solo inserta en la tabla)
                _bll.GuardarRetiroColmenas(_nombrePagina, cant, dtpFechaRetiroColmena.Value.Date);

                MessageBox.Show($"Retiro de {cant} colmenas registrado correctamente. Quedan {disponibles - cant} activas.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                LimpiarRetiro();
                CargarComboEnviar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al retirar colmenas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEnviarIndustria_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cmbEnviarIndustria.Text, out int cantidadEnviar) || cantidadEnviar <= 0)
                {
                    MessageBox.Show("Seleccione una cantidad válida de miel para enviar.");
                    return;
                }

                var tot = _bll.TotalesColmenas(_nombrePagina);
                if (cantidadEnviar > tot.miel)
                {
                    MessageBox.Show($"No puede enviar {cantidadEnviar}. Disponible: {tot.miel}");
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Enviar {cantidadEnviar} de miel de '{_nombrePagina}' a Industria?",
                    "Confirmar envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                //  Usa directamente el usuario logeado actual
                string responsable = _usuario?.NombreUsuario ?? "Invitado";
                int idTipoEntorno = 1;
                int idTipoMedida = 1;
                DateTime fecha = dtpFechaEnvioIndustria.Value.Date;

                Articulo articulo = new Articulo
                {
                    NombreProducto = _nombrePagina,
                    Cantidad = cantidadEnviar,
                    IdTipoMedida = idTipoMedida,
                    FechaIngreso = fecha,
                    FechaEgreso = fecha,
                    IdTipoEntorno = idTipoEntorno,
                    Responsable = responsable,   // ✅ Guarda el nombre del usuario logeado
                    Estado = true
                };

                ArticuloDAL.Insertar(articulo);
                _bll.MarcarMielEnviada(_nombrePagina, cantidadEnviar);

                MessageBox.Show("Miel enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                CargarComboEnviar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar miel a industria: " + ex.Message);
            }
        }


        // ---------- Imprimir ----------
        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                var savefile = new SaveFileDialog
                {
                    FileName = "ReporteColmenas.pdf",
                    Filter = "PDF files (*.pdf)|*.pdf"
                };

                // Plantilla
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Colmenas.html");
                string html = File.ReadAllText(rutaPlantilla);
                html = html.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                html = html.Replace("@NOMBREPAGINA", _nombrePagina);

                // Filas
                var sb = new StringBuilder();
                foreach (DataGridViewRow row in dtgDatosMiel.Rows)
                {
                    if (row.IsNewRow) continue;
                    string nombre = row.Cells["Nombre"]?.Value?.ToString() ?? "";
                    string fCol = row.Cells["FechaIngresoColmenas"]?.Value is DateTime fc ? fc.ToString("dd/MM/yyyy") : "";
                    string fMiel = row.Cells["FechaIngresoMiel"]?.Value is DateTime fm ? fm.ToString("dd/MM/yyyy") : "";
                    string fRet = row.Cells["FechaRetiradas"]?.Value is DateTime fr ? fr.ToString("dd/MM/yyyy") : "";
                    string cCol = row.Cells["CantidadColmenas"]?.Value?.ToString() ?? "0";
                    string cMiel = row.Cells["CantidadMiel"]?.Value?.ToString() ?? "0";
                    string cRet = row.Cells["CantidadRetiradas"]?.Value?.ToString() ?? "0";
                    string estado = (row.Cells["Estado"]?.Value is bool b && b) ? "Activo" : "Inactivo";

                    sb.Append("<tr>");
                    sb.Append($"<td>{nombre}</td>");
                    sb.Append($"<td>{fCol}</td>");
                    sb.Append($"<td>{cCol}</td>");
                    sb.Append($"<td>{fMiel}</td>");
                    sb.Append($"<td>{cMiel}</td>");
                    sb.Append($"<td>{fRet}</td>");
                    sb.Append($"<td>{cRet}</td>");
                    sb.Append($"<td>{estado}</td>");
                    sb.Append("</tr>");
                }
                html = html.Replace("@FILAS", sb.ToString());

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using var stream = new FileStream(savefile.FileName, FileMode.Create);
                    var pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                    var writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Logo opcional
                    try
                    {
                        if (Properties.Resources.agr != null)
                        {
                            var img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }
                    }
                    catch { /* opcional */ }

                    using var sr = new StringReader(html);
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("Reporte generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void UcColmenas_Load(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
