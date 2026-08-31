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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agraria.UserControls
{
    public partial class UcCarne : UserControl
    {
        private readonly string _nombrePagina;
        private readonly UsuarioLoginDTO _usuarioLogeado;

        private readonly CarneBLL _carneBll = new CarneBLL();
        private readonly RegistroFertilidadCarneBLL _fertilidadBll = new RegistroFertilidadCarneBLL();
        private readonly BoxCarneBLL _boxBll = new BoxCarneBLL();

        public UcCarne(string nombrePagina, UsuarioLoginDTO usuarioLogeado)
        {
            InitializeComponent();
            _nombrePagina = nombrePagina ?? "";
            _usuarioLogeado = usuarioLogeado;

            cmbBoxProduccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEnviarIndustria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDardeBajaAnimal.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbMadreMonta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPadreMonta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMadreNacimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPadreNacimiento.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarCombos();
            CargarCombosAnimales(); // ✅ agregado
            CargarGrillas();
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

        // ===================== CARGAS =====================

        private void CargarCombos()
        {
            // Boxes
            var boxes = _boxBll.ListarBoxes(); // devuelve List<BoxCarneDTO> { IdBoxCarne, Nombre }
            cmbBoxProduccion.DataSource = boxes.ToList();
            cmbBoxProduccion.DisplayMember = "Nombre";
            cmbBoxProduccion.ValueMember = "IdBoxCarne";

            cmbEnviarIndustria.DataSource = boxes.ToList();
            cmbEnviarIndustria.DisplayMember = "Nombre";
            cmbEnviarIndustria.ValueMember = "IdBoxCarne";

            cmbDardeBajaAnimal.DataSource = boxes.ToList();
            cmbDardeBajaAnimal.DisplayMember = "Nombre";
            cmbDardeBajaAnimal.ValueMember = "IdBoxCarne";

            // Padres/Madres por sexo (solo números activos)
            cmbMadreMonta.DataSource = _carneBll.ListarMadres(_nombrePagina); // hembras activas
            cmbMadreMonta.DisplayMember = "NumeroAnimal";
            cmbMadreMonta.ValueMember = "NumeroAnimal";

            cmbPadreMonta.DataSource = _carneBll.ListarPadres(_nombrePagina); // machos activos
            cmbPadreMonta.DisplayMember = "NumeroAnimal";
            cmbPadreMonta.ValueMember = "NumeroAnimal";

            cmbMadreNacimiento.DataSource = _carneBll.ListarMadres(_nombrePagina);
            cmbMadreNacimiento.DisplayMember = "NumeroAnimal";
            cmbMadreNacimiento.ValueMember = "NumeroAnimal";

            cmbPadreNacimiento.DataSource = _carneBll.ListarPadres(_nombrePagina);
            cmbPadreNacimiento.DisplayMember = "NumeroAnimal";
            cmbPadreNacimiento.ValueMember = "NumeroAnimal";
        }
        private void CargarGrillas()
        {
            try
            {
                // 🔹 Producción de carne
                dtgProduccionCarne.DataSource = _carneBll.ListarCarne(_nombrePagina);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }

            // 🔹 Monta y nacimientos (usando DTO tipado)
            dtgMontaNacimientos.AutoGenerateColumns = true;
            dtgMontaNacimientos.DataSource = _fertilidadBll.ListarRegistrosFertilidad(_nombrePagina);
            dtgMontaNacimientos.DefaultCellStyle.ForeColor = Color.Black;

            // 🔹 Si existe otra grilla de producción, también la llenamos
            var tieneProduccionGrid = this.Controls.Find("dtgProduccionCarne", true).FirstOrDefault() as DataGridView;
            if (tieneProduccionGrid != null)
            {
                tieneProduccionGrid.AutoGenerateColumns = true;
                tieneProduccionGrid.DataSource = _carneBll.ListarCarne(_nombrePagina);
                tieneProduccionGrid.DefaultCellStyle.ForeColor = Color.Black;
            }
        }


        // ===================== VALIDACIONES =====================

        private bool ValidarNumeroUnico(string numeroAnimal)
        {
            if (string.IsNullOrWhiteSpace(numeroAnimal))
            {
                MessageBox.Show("Debe ingresar un número de animal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_carneBll.ExisteNumeroAnimal(numeroAnimal))
            {
                MessageBox.Show("El número de animal ya existe. Ingrese otro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ===================== BOTONES: PRODUCCIÓN =====================

        private void btnGuardarProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBoxProduccion.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un Box válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var numero = txtNumeroAnimal.Text.Trim();
                if (!ValidarNumeroUnico(numero)) return;

                int idBox = Convert.ToInt32(cmbBoxProduccion.SelectedValue);
                string sexo = rbHembra.Checked ? "Hembra" : (rbMacho.Checked ? "Macho" : "");
                if (string.IsNullOrEmpty(sexo))
                {
                    MessageBox.Show("Seleccione el sexo (Macho/Hembra).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaIngreso = dtpFechaNacimiento.Value.Date; // Si tenés dtpIngresoAnimal, usalo aquí
                _carneBll.GuardarProduccion(_nombrePagina, idBox, numero, sexo, fechaIngreso);

                MessageBox.Show("Producción guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillas();
                LimpiarProduccion();
                CargarCombos();
                CargarCombosAnimales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarProduccion()
        {
            txtNumeroAnimal.Clear();
            if (cmbBoxProduccion.Items.Count > 0) cmbBoxProduccion.SelectedIndex = 0;
            rbHembra.Checked = false;
            rbMacho.Checked = false;
        }

        // ===================== BOTONES: RETIRAR (BAJA LÓGICA) =====================

        private void btnRetirarAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDardeBajaAnimal.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un Box válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idBox = Convert.ToInt32(cmbDardeBajaAnimal.SelectedValue);

                // 🔹 Se reemplaza el textbox por comboBox
                string numero = cmbBajaAnimal.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(numero))
                {
                    MessageBox.Show("Seleccione el número de animal a retirar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool existe = _carneBll.ExisteAnimalPorNombre(_nombrePagina, numero);
                if (!existe)
                {
                    MessageBox.Show($"El animal #{numero} no existe o pertenece a otra sección.",
                                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaRetiro = dtpFechaFallecimiento.Value.Date;
                _carneBll.RetirarAnimal(_nombrePagina, idBox, numero, fechaRetiro);

                MessageBox.Show("Animal retirado (baja lógica) correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrillas();
                CargarCombosAnimales(); // 🔄 refrescar combos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al retirar animal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ===================== BOTÓN: ENVIAR A INDUSTRIA =====================

        private void btnEnviarCerdoIndustria_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEnviarIndustria.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un Box válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cantidad = 1;
                int idBox = Convert.ToInt32(cmbEnviarIndustria.SelectedValue);
                DateTime fechaEgreso = dtpFechaEgresoEnviarIndustria.Value.Date;
                string responsable = _usuarioLogeado?.NombreUsuario ?? "UsuarioSistema";

                // 🔹 Reemplazo de textbox por comboBox
                string numero = cmbCantidadEnviarIndustria.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(numero))
                {
                    MessageBox.Show("Seleccione el número del animal a enviar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!_carneBll.AnimalActivoExiste(_nombrePagina, numero))
                {
                    MessageBox.Show($"El animal #{numero} no existe activo en la base.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _carneBll.MarcarEnviado(_nombrePagina, numero, fechaEgreso);

                MessageBox.Show("Animal enviado a industria correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillas();
                CargarCombosAnimales(); // 🔄 refrescar combos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar a industria: " + ex.Message);
            }
        }




        // ===================== BOTONES: REGISTROS (MONTA / NACIMIENTO) =====================

        private void btnGuardarRegistroMonta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMadreMonta.SelectedValue == null || cmbPadreMonta.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione madre y padre válidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string madre = cmbMadreMonta.SelectedValue.ToString();
                string padre = cmbPadreMonta.SelectedValue.ToString();
                DateTime fechaMonta = dtpFechaMonta.Value.Date;
                DateTime fechaParto = dtpPosibleParto.Value.Date;

                _fertilidadBll.GuardarMonta(_nombrePagina, madre, padre, fechaMonta, fechaParto);

                MessageBox.Show("Registro de monta guardado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillas();
                LimpiarMonta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar monta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarMonta()
        {
            if (cmbMadreMonta.Items.Count > 0) cmbMadreMonta.SelectedIndex = 0;
            if (cmbPadreMonta.Items.Count > 0) cmbPadreMonta.SelectedIndex = 0;
        }

        private void btnGuardarRegistroNacimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMadreNacimiento.SelectedValue == null || cmbPadreNacimiento.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione madre y padre válidos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtTotalNacidos.Text.Trim(), out int total) || total < 0 ||
                    !int.TryParse(txtCantidadHembras.Text.Trim(), out int hembras) || hembras < 0 ||
                    !int.TryParse(txtCantidadMachos.Text.Trim(), out int machos) || machos < 0)
                {
                    MessageBox.Show("Cantidades inválidas (números enteros >= 0).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string madre = cmbMadreNacimiento.SelectedValue.ToString();
                string padre = cmbPadreNacimiento.SelectedValue.ToString();
                DateTime fechaParto = dtpFechaNacimiento.Value.Date;

                _fertilidadBll.GuardarNacimiento(_nombrePagina, madre, padre, fechaParto, hembras, machos, total);

                MessageBox.Show("Registro de nacimiento guardado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillas();
                LimpiarNacimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar nacimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarNacimiento()
        {
            txtTotalNacidos.Clear();
            txtCantidadHembras.Clear();
            txtCantidadMachos.Clear();
            if (cmbMadreNacimiento.Items.Count > 0) cmbMadreNacimiento.SelectedIndex = 0;
            if (cmbPadreNacimiento.Items.Count > 0) cmbPadreNacimiento.SelectedIndex = 0;
        }

        // ===================== IMPRESIONES =====================

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var grid = this.Controls.Find("dtgProduccionCarne", true).FirstOrDefault() as DataGridView;
                if (grid == null || grid.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para imprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog savefile = new SaveFileDialog
                {
                    FileName = "ProduccionCarne.pdf",
                    Filter = "PDF files (*.pdf)|*.pdf"
                };

                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Carne.html");
                string html = File.ReadAllText(rutaPlantilla);
                html = html.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                html = html.Replace("@PAGINA", _nombrePagina);

                StringBuilder filas = new StringBuilder();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;

                    filas.Append("<tr>");
                    filas.AppendFormat("<td>{0}</td>", row.Cells["IdCarne"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["Nombre"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["NombreBox"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["NumeroAnimal"]?.Value);
                    filas.AppendFormat("<td>{0:dd/MM/yyyy}</td>", row.Cells["FechaIngreso"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["Sexo"]?.Value);
                    filas.AppendFormat("<td>{0:dd/MM/yyyy}</td>", row.Cells["FechaRetiro"]?.Value);
                    filas.AppendFormat("<td>{0:dd/MM/yyyy}</td>", row.Cells["FechaEnvioIndustria"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", ((bool?)row.Cells["Estado"]?.Value) == true ? "Activo" : "Inactivo");
                    filas.Append("</tr>");
                }
                html = html.Replace("@FILAS", filas.ToString());

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        var pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        if (Properties.Resources.agr != null)
                        {
                            var img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }

                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte de Producción generado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirMonta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgMontaNacimientos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para imprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog savefile = new SaveFileDialog
                {
                    FileName = "MontaNacimientoCarne.pdf",
                    Filter = "PDF files (*.pdf)|*.pdf"
                };

                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "NacimientoCarne.html");
                string html = File.ReadAllText(rutaPlantilla);
                html = html.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                html = html.Replace("@PAGINA", _nombrePagina);

                StringBuilder filas = new StringBuilder();
                foreach (DataGridViewRow row in dtgMontaNacimientos.Rows)
                {
                    if (row.IsNewRow) continue;

                    filas.Append("<tr>");
                    filas.AppendFormat("<td>{0}</td>", row.Cells["IdRegistro"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["NumeroMadre"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["NumeroPadre"]?.Value);
                    filas.AppendFormat("<td>{0:dd/MM/yyyy}</td>", row.Cells["FechaMonta"]?.Value);
                    filas.AppendFormat("<td>{0:dd/MM/yyyy}</td>", row.Cells["FechaParto"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["CantidadHembras"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["CantidadMachos"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", row.Cells["TotalNacidos"]?.Value);
                    filas.AppendFormat("<td>{0}</td>", ((bool?)row.Cells["Estado"]?.Value) == true ? "Activo" : "Inactivo");
                    filas.Append("</tr>");
                }
                html = html.Replace("@FILAS", filas.ToString());

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        var pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        if (Properties.Resources.agr != null)
                        {
                            var img = iTextSharp.text.Image.GetInstance(Properties.Resources.agr, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }

                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte de Monta/Nacimiento generado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== FILTRO EXTRA (OPCIONAL) =====================

        private void txtBuscarPorGrilla_TextChanged(object sender, EventArgs e)
        {
            var grid = this.Controls.Find("dtgProduccionCarne", true).FirstOrDefault() as DataGridView;
            if (grid == null) return;

            string filtro = (sender as TextBox)?.Text?.Trim() ?? "";

            // 🔹 Obtener la lista completa desde la BLL
            var listaCompleta = _carneBll.ListarCarne(_nombrePagina);

            if (string.IsNullOrEmpty(filtro))
            {
                grid.DataSource = listaCompleta;
                return;
            }

            // 🔹 Filtrar usando LINQ sobre la lista tipada
            var listaFiltrada = listaCompleta
                .Where(c => c.NumeroAnimal != null &&
                            c.NumeroAnimal.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            // 🔹 Mostrar el resultado filtrado
            grid.DataSource = listaFiltrada;
        }

        private void CargarCombosAnimales()
        {
            try
            {
                var listaAnimales = _carneBll.ListarAnimalesActivos(_nombrePagina);

                cmbBajaAnimal.DataSource = listaAnimales.ToList();
                cmbBajaAnimal.DisplayMember = "NumeroAnimal";
                cmbBajaAnimal.ValueMember = "NumeroAnimal";

                cmbCantidadEnviarIndustria.DataSource = listaAnimales.ToList();
                cmbCantidadEnviarIndustria.DisplayMember = "NumeroAnimal";
                cmbCantidadEnviarIndustria.ValueMember = "NumeroAnimal";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos de animales: " + ex.Message);
            }
        }


        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTextoNumeroEspacio(e);
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
            Validaciones.SoloNumerosYComa(txtCantidadMachos, e, errorProvider1);
        }

        private void UcCarne_Load(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
        }

        private void gbREgistroNacimientoCerdos_Enter(object sender, EventArgs e)
        {

        }
    }
}
