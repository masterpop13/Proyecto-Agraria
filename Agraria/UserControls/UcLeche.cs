using Agraria.Datos.DTO;
using Agraria.Entidades;
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
    public partial class UcLeche : UserControl
    {
        private readonly string _nombrePagina;
        private readonly LecheBLL _bllLeche = new LecheBLL();
        private readonly RegistroFertilidadLecheBLL _bllFertilidad = new RegistroFertilidadLecheBLL();
        private readonly TipoAnimalBLL _bllTipo = new TipoAnimalBLL();
        private readonly UsuarioLoginDTO _usuarioLogeado;

        public UcLeche(string nombrePagina, UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _nombrePagina = nombrePagina;
            _usuarioLogeado = usuarioLogeado;
            CargarCombos();
            CargarGrillaProduccion();
            CargarGrillaNacimientos();
            CargarComboLitrosLeche();

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

        private void CargarCombos()
        {
            // 🔹 Cargar tipos de animal
            var tipos = _bllTipo.Listar();
            cmbTipo.DataSource = tipos;
            cmbTipo.DisplayMember = "Nombre";
            cmbTipo.ValueMember = "IdTipo";

            // 🔹 Cargar tipos de animal
            var tipos2 = _bllTipo.Listar();
            cmbTipo2.DataSource = tipos2;
            cmbTipo2.DisplayMember = "Nombre";
            cmbTipo2.ValueMember = "IdTipo";

            // 🔹 Obtener lista de LecheDTO filtrada por la página
            var listaLeche = _bllLeche.Listar(_nombrePagina);

            // 🔹 Filtrar hembras y machos activos
            var hembras = listaLeche
                .Where(l => l.Sexo == "Hembra" && l.Estado)
                .ToList();

            var machos = listaLeche
                .Where(l => l.Sexo == "Macho" && l.Estado)
                .ToList();

            // 🔹 Cargar combos con los números de animal
            cmbNumeroMadre.DataSource = hembras.Select(h => h.NumeroAnimal).ToList();
            cmbNumeroPadre.DataSource = machos.Select(m => m.NumeroAnimal).ToList();
            cmbMadreNacimiento.DataSource = hembras.Select(h => h.NumeroAnimal).ToList();
            cmbPadreNacimiento.DataSource = machos.Select(m => m.NumeroAnimal).ToList();
            cmbAnimalOrdeñe.DataSource = hembras.Select(h => h.NumeroAnimal).ToList();
            cmbRetiroAnimal.DataSource = listaLeche
                .Where(l => l.Estado)
                .Select(l => l.NumeroAnimal)
                .ToList();
        }


        private void CargarGrillaProduccion()
        {
            dtgRegistrosProduccion.DataSource = _bllLeche.Listar(_nombrePagina);
            dtgRegistrosProduccion.DefaultCellStyle.ForeColor = Color.Black;
        }


        private void CargarGrillaNacimientos()
        {
            dtgNacimientos.DataSource = _bllFertilidad.Listar(_nombrePagina);
            dtgNacimientos.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void txtBuscarRegistroProduccion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarRegistroProduccion.Text))
                CargarGrillaProduccion();
            else
                dtgRegistrosProduccion.DataSource = _bllLeche.BuscarPorNumeroAnimal(txtBuscarRegistroProduccion.Text, _nombrePagina);
        }

        private void txtBuscarRegistroNacimiento_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarRegistroNacimiento.Text))
                CargarGrillaNacimientos();
            else
                dtgNacimientos.DataSource = _bllFertilidad.Buscar(txtBuscarRegistroNacimiento.Text, _nombrePagina);
        }

        private void btnGuardarAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                Leche leche = new Leche
                {
                    Nombre = _nombrePagina,
                    NumeroAnimal = txtNumeroAnimal.Text.Trim(),
                    FechaIngreso = dtpIngresoAnimal.Value.Date,
                    Sexo = rbHembra.Checked ? "Hembra" : "Macho",
                    Estado = true
                };
                _bllLeche.Insertar(leche);
                MessageBox.Show("Animal guardado correctamente.");
                CargarCombos();
                CargarGrillaProduccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnGuardarLeche_Click(object sender, EventArgs e)
        {
            try
            {
                Leche leche = new Leche
                {
                    Nombre = _nombrePagina,
                    NumeroAnimal = cmbAnimalOrdeñe.Text,
                    FechaOrdeñe = dtpFechaOrdeñe.Value.Date,
                    LitrosLeche = decimal.Parse(txtLitroLeche.Text),
                    Estado = true
                };
                _bllLeche.Insertar(leche);
                MessageBox.Show("Registro de ordeñe guardado correctamente.");
                CargarGrillaProduccion();
                CargarComboLitrosLeche();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar ordeñe: " + ex.Message);
            }
        }

        private void btnRetiroAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                _bllLeche.ActualizarEstado(cmbRetiroAnimal.Text, false, dtpFechaRetiro.Value.Date);
                MessageBox.Show("Animal retirado correctamente.");
                CargarCombos();
                CargarGrillaProduccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al retirar animal: " + ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteLeche_{_nombrePagina}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "RegistroLeche.html");
                string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOMBREPAGINA", _nombrePagina);

                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgRegistrosProduccion.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        filas += "<tr>";
                        filas += $"<td>{_nombrePagina}</td>";
                        filas += $"<td>{row.Cells["NumeroAnimal"].Value ?? "-"}</td>";
                        filas += $"<td>{row.Cells["Sexo"].Value ?? "-"}</td>";
                        filas += $"<td>{(row.Cells["FechaIngreso"].Value is DateTime fi ? fi.ToString("dd/MM/yyyy") : "-")}</td>";
                        filas += $"<td>{(row.Cells["FechaOrdeñe"].Value is DateTime fo ? fo.ToString("dd/MM/yyyy") : "-")}</td>";
                        filas += $"<td>{row.Cells["LitrosLeche"].Value ?? 0}</td>";
                        filas += $"<td>{(row.Cells["FechaFallecido"].Value is DateTime fe ? fe.ToString("dd/MM/yyyy") : "-")}</td>";
                        bool estado = row.Cells["Estado"].Value != null && Convert.ToBoolean(row.Cells["Estado"].Value);
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

                        // Logo (usa Properties.Resources.logo o similar)
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
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }

        private void btnEnviarLeche_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLitroLecheEnviado.SelectedItem == null)
                {
                    MessageBox.Show("No hay leche disponible para enviar.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal cantidad = Convert.ToDecimal(cmbLitroLecheEnviado.SelectedItem);
                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad de leche debe ser mayor que 0.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fecha = dtpFechaEnviado.Value.Date;
                string responsable = _usuarioLogeado?.NombreUsuario ?? "UsuarioSistema";


                var confirmar = MessageBox.Show(
                    $"¿Desea enviar {cantidad} litros de leche de '{_nombrePagina}' a Industria?",
                    "Confirmar Envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmar != DialogResult.Yes) return;

                // 🔹 Insertar en Articulo
                ArticuloBLL articuloBLL = new ArticuloBLL();
                articuloBLL.InsertarDesdeLeche(_nombrePagina, cantidad, fecha, responsable);

                // 🔹 Marcar registros de leche como enviados (Estado = false)
                _bllLeche.MarcarEnviados(_nombrePagina);

                MessageBox.Show("Leche enviada correctamente a Industria.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Actualizar combo y grilla
                CargarComboLitrosLeche();
                CargarGrillaProduccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar leche a industria: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGuardarRegistroMontaOvina_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNumeroMadre.SelectedIndex == -1 || cmbNumeroPadre.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione madre y padre válidos.");
                    return;
                }

                RegistroFertilidadLeche registro = new RegistroFertilidadLeche
                {
                    Nombre = _nombrePagina,
                    NumeroMadre = cmbNumeroMadre.Text,
                    NumeroPadre = cmbNumeroPadre.Text,
                    FechaMonta = dtpFechaMonta.Value.Date,
                    FechaParto = dtpPosibleParto.Value.Date,
                    IdTipo = Convert.ToInt32(cmbTipo.SelectedValue),
                    Estado = true
                };

                _bllFertilidad.Insertar(registro);
                MessageBox.Show("Registro de monta guardado correctamente.");
                CargarGrillaNacimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar registro: " + ex.Message);
            }
        }

        private void btnRegistroNacimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMadreNacimiento.SelectedIndex == -1 || cmbPadreNacimiento.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione madre y padre válidos.");
                    return;
                }

                RegistroFertilidadLeche registro = new RegistroFertilidadLeche
                {
                    Nombre = _nombrePagina,
                    NumeroMadre = cmbMadreNacimiento.Text,
                    NumeroPadre = cmbPadreNacimiento.Text,
                    FechaParto = dtpFechaParto.Value.Date,
                    CantidadHembras = int.Parse(txtCantidadHembras.Text),
                    CantidadMachos = int.Parse(txtCantidadMachos.Text),
                    TotalNacidos = int.Parse(txtTotalNacidos.Text),
                    IdTipo = Convert.ToInt32(cmbTipo2.SelectedValue),
                    Estado = true
                };

                _bllFertilidad.Insertar(registro);
                MessageBox.Show("Nacimiento registrado correctamente.");
                CargarGrillaNacimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar nacimiento: " + ex.Message);
            }
        }

        private void btnImprimirNacimiento_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = $"ReporteNacimientos_{_nombrePagina}.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                // Ruta de la plantilla HTML
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "NacimientoAnimal.html");
                string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                // Reemplazo de variables
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOMBREPAGINA", _nombrePagina);

                // Construir las filas de la tabla desde el DataGridView
                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgNacimientos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        filas += "<tr>";
                        filas += $"<td>{_nombrePagina}</td>";
                        filas += $"<td>{row.Cells["NumeroMadre"].Value ?? "-"}</td>";
                        filas += $"<td>{row.Cells["NumeroPadre"].Value ?? "-"}</td>";
                        filas += $"<td>{(row.Cells["FechaMonta"].Value is DateTime fm ? fm.ToString("dd/MM/yyyy") : "-")}</td>";
                        filas += $"<td>{(row.Cells["FechaParto"].Value is DateTime fp ? fp.ToString("dd/MM/yyyy") : "-")}</td>";
                        filas += $"<td>{row.Cells["TipoAnimal"].Value ?? "-"}</td>";
                        filas += $"<td>{row.Cells["CantidadHembras"].Value ?? 0}</td>";
                        filas += $"<td>{row.Cells["CantidadMachos"].Value ?? 0}</td>";
                        filas += $"<td>{row.Cells["TotalNacidos"].Value ?? 0}</td>";

                        bool estado = row.Cells["Estado"].Value != null && Convert.ToBoolean(row.Cells["Estado"].Value);
                        filas += $"<td>{(estado ? "Activo" : "Inactivo")}</td>";
                        filas += "</tr>";
                    }
                }

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

                // Generar el PDF
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new iTextSharp.text.Phrase(""));

                        // Logo superior izquierdo
                        if (Properties.Resources.agr != null)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }

                        // Convertir HTML en PDF
                        using (StringReader sr = new StringReader(PaginaHTML_Texto))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte de nacimientos generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboLitrosLeche()
        {
            try
            {
                var (animalesActivos, litros) = _bllLeche.TotalesLeche(_nombrePagina);

                cmbLitroLecheEnviado.Items.Clear();

                if (litros > 0)
                {
                    cmbLitroLecheEnviado.Items.Add(litros);
                    cmbLitroLecheEnviado.SelectedIndex = 0;
                    cmbLitroLecheEnviado.Enabled = true;
                }
                else
                {
                    cmbLitroLecheEnviado.Items.Add(0);
                    cmbLitroLecheEnviado.SelectedIndex = 0;
                    cmbLitroLecheEnviado.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combo de leche: " + ex.Message);
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

        private void dtgRegistrosProduccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UcLeche_Load(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
        }

        private void rbHembra_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
