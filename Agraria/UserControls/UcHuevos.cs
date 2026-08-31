using Agraria.Datos.DTO;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UserControls
{
    public partial class UcHuevos : UserControl
    {
        private readonly AvesBLL _bll = new AvesBLL();
        private readonly string _nombrePagina;
        public string UsuarioResponsable { get; set; } = "Sistema"; // setéalo desde el form padre si querés
        private readonly UsuarioLoginDTO _usuarioLogeado;

        public UcHuevos(string nombrePagina, UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _nombrePagina = nombrePagina ?? "";
            cmbEnviarIndustria.DropDownStyle = ComboBoxStyle.DropDownList; // ✅ Solo lista
            cmbEnviarIndustria.AutoCompleteMode = AutoCompleteMode.None;   // ❌ Desactiva autocomplete


            _usuarioLogeado = usuarioLogeado;
            CargarGrid();
            CargarComboEnviar();
        }

        private void CargarGrid()
        {
            dtgRegistro.AutoGenerateColumns = true;
            dtgRegistro.DataSource = _bll.ListarPorNombre(_nombrePagina);
            dtgRegistro.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void CargarComboEnviar()
        {
            var totales = _bll.Totales(_nombrePagina);
            cmbEnviarIndustria.Items.Clear();
            cmbEnviarIndustria.Items.Add(totales.totalHuevos);
            cmbEnviarIndustria.SelectedIndex = 0;
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

        // -------------------------------------------------
        // GUARDAR AVES
        private void bnGuardarAvess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIngresoAvess.Text.Trim(), out int cant) || cant <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de aves (>0).");
                    return;
                }

                _bll.GuardarIngresoAves(_nombrePagina, cant, dtpFechaIngresoAvess.Value.Date);
                MessageBox.Show("Ingreso de aves guardado.");
                CargarGrid();
                CargarComboEnviar();
                LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // -------------------------------------------------
        // GUARDAR HUEVOS
        private void btnGuardarHuevos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtHuevosRecolectadoss.Text.Trim(), out int huevos) || huevos <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de huevos (>0).");
                    return;
                }

                _bll.GuardarHuevos(_nombrePagina, huevos, dtpRegistrosHuevos.Value.Date);
                MessageBox.Show("Registro de huevos guardado.");
                CargarGrid();
                CargarComboEnviar();
                LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // -------------------------------------------------
        // RETIRAR AVES
        private void btnRetirarAves_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtAvesRetiradas.Text.Trim(), out int retiradas) || retiradas <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de aves retiradas (>0).",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Obtener totales actuales
                var totales = _bll.Totales(_nombrePagina);
                int avesDisponibles = totales.totalAvesActuales;

                // 🔹 Validar que no supere las aves disponibles
                if (retiradas > avesDisponibles)
                {
                    MessageBox.Show(
                        $"No puede retirar más aves ({retiradas}) de las disponibles ({avesDisponibles}).",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // 🔹 Confirmar la operación
                var confirm = MessageBox.Show(
                    $"¿Desea retirar {retiradas} aves de '{_nombrePagina}'?\nActualmente dispone de {avesDisponibles} aves.",
                    "Confirmar retiro",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (confirm != DialogResult.Yes)
                    return;

                // 🔹 Guardar en base
                _bll.GuardarRetiroAves(_nombrePagina, retiradas, dtpAvesRetiradass.Value.Date);

                MessageBox.Show("Retiro de aves guardado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Actualizar interfaz
                CargarGrid();
                CargarComboEnviar();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al retirar aves: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // -------------------------------------------------
        // ENVIAR HUEVOS A INDUSTRIA
        private void btnEnviarHuevosIndustria_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cmbEnviarIndustria.Text, out int cantidadEnviar) || cantidadEnviar <= 0)
                {
                    MessageBox.Show("Seleccione una cantidad válida para enviar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var totales = _bll.Totales(_nombrePagina);
                if (totales.totalHuevos <= 0)
                {
                    MessageBox.Show("No hay huevos disponibles para enviar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cantidadEnviar > totales.totalHuevos)
                {
                    MessageBox.Show($"No puede enviar más huevos ({cantidadEnviar}) de los disponibles ({totales.totalHuevos}).",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Desea enviar {cantidadEnviar} huevos de '{_nombrePagina}' a Industria?",
                    "Confirmar envío",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (confirm != DialogResult.Yes)
                    return;

                DateTime fechaEgreso = dtpFechaEgresoHuevos.Value.Date;
                string responsable = _usuarioLogeado?.NombreUsuario ?? "UsuarioSistema";
                int idTipoEntorno = 1;
                int idTipoMedida = 2;

                // 🔹 Enviar y dar de baja solo los huevos enviados
                _bll.EnviarHuevosAIndustria(_nombrePagina, cantidadEnviar, fechaEgreso, idTipoEntorno, responsable, idTipoMedida);

                MessageBox.Show("Huevos enviados correctamente a Industria.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Actualizar vista sin tocar las aves
                CargarGrid();
                CargarComboEnviar();
                LimpiarCampos(afectaAves: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar huevos a industria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------
        // IMPRIMIR REPORTE
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteHuevos_{_nombrePagina}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                // Cargar plantilla HTML
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Huevos.html");
                string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                // Reemplazar variables
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOMBREPAGINA", _nombrePagina);

                // Crear filas HTML con datos del DataGridView
                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgRegistro.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        filas += "<tr>";

                        filas += $"<td>{_nombrePagina}</td>";
                        filas += $"<td>{(row.Cells["FechaIngresoAves"].Value is DateTime fiA ? fiA.ToString("dd/MM/yyyy") : "-")}</td>";
                        filas += $"<td>{row.Cells["CantidadAves"].Value ?? 0}</td>";
                        filas += $"<td>{(row.Cells["FechaIngresoHuevos"].Value is DateTime fiH ? fiH.ToString("dd/MM/yyyy") : "-")}</td>";
                        filas += $"<td>{row.Cells["CantidadHuevos"].Value ?? 0}</td>";
                        filas += $"<td>{(row.Cells["FechaRetiradas"].Value is DateTime frA ? frA.ToString("dd/MM/yyyy") : "-")}</td>";
                        filas += $"<td>{row.Cells["CantidadRetiradas"].Value ?? 0}</td>";

                        bool estado = false;
                        if (row.Cells["Estado"].Value != null)
                            bool.TryParse(row.Cells["Estado"].Value.ToString(), out estado);

                        filas += $"<td>{(estado ? "Activo" : "Inactivo")}</td>";
                        filas += "</tr>";
                    }
                }

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new iTextSharp.text.Phrase(""));

                        // Logo opcional
                        if (Properties.Resources.agr != null)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }

                        // Parsear HTML al PDF
                        using (StringReader sr = new StringReader(PaginaHTML_Texto))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte de huevos generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // -------------------------------------------------
        // LIMPIAR CAMPOS
        private void LimpiarCampos(bool afectaAves = true)
        {
            if (afectaAves)
                txtIngresoAvess.Clear();

            txtHuevosRecolectadoss.Clear();
            txtAvesRetiradas.Clear();
        }

        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }


        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);

        }

        private void UcHuevos_Load(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
        }
    }
}
