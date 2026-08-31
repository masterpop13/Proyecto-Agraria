using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class Pañol : Form
    {
        private readonly ArticulosPañolBLL bll = new ArticulosPañolBLL();
        private readonly TipoMedidaBLL medidaBLL = new TipoMedidaBLL();
        private readonly TipoEntornoBLL entornoBLL = new TipoEntornoBLL();
        private int idSeleccionado = 0;
        private bool esInvitado = false;

        public Pañol(Form formulariomenu)
        {
            InitializeComponent();
        }


        public Pañol(bool invitado = false)
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

        private void Pañol_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.AdaptMdiChild(this);
            CargarCombos();
            CargarGrilla();
        }

        private void CargarCombos()
        {
            cmbKgUnidad.DataSource = medidaBLL.Listar();
            cmbKgUnidad.DisplayMember = "Nombre";
            cmbKgUnidad.ValueMember = "IdTipoMedida";
            cmbKgUnidad.SelectedIndex = -1;

            cmbEntornoFormativo.DataSource = entornoBLL.Listar();
            cmbEntornoFormativo.DisplayMember = "Nombre";
            cmbEntornoFormativo.ValueMember = "IdTipoEntorno";
            cmbEntornoFormativo.SelectedIndex = -1;
        }

        private void CargarGrilla(string filtro = "")
        {
            dtgArticulos.DataSource = bll.Listar(filtro);
            dtgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un artículo para dar de baja.");
                return;
            }

            bll.CambiarEstado(idSeleccionado, false);
            MessageBox.Show("Artículo dado de baja.");
            CargarGrilla();
        }

        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un artículo para dar de alta.");
                return;
            }

            bll.CambiarEstado(idSeleccionado, true);
            MessageBox.Show("Artículo dado de alta.");
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                cmbKgUnidad.SelectedIndex == -1 ||
                cmbEntornoFormativo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtResponsableCargo.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            ArticulosPañol art = new ArticulosPañol
            {
                NombreProducto = txtNombreProducto.Text.Trim(),
                Cantidad = int.Parse(txtCantidad.Text),
                IdUnidad = (int)cmbKgUnidad.SelectedValue,
                FechaIngreso = dtpFechaIngreso.Value.Date,
                IdEntorno = (int)cmbEntornoFormativo.SelectedValue,
                Responsable = txtResponsableCargo.Text.Trim(),
                Estado = true
            };

            bll.Agregar(art);
            MessageBox.Show("Artículo agregado correctamente.");
            CargarGrilla();
            LimpiarCampos();
        }

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un artículo para modificar.");
                return;
            }

            ArticulosPañol art = new ArticulosPañol
            {
                IdArtPañol = idSeleccionado,
                NombreProducto = txtNombreProducto.Text.Trim(),
                Cantidad = int.Parse(txtCantidad.Text),
                IdUnidad = (int)cmbKgUnidad.SelectedValue,
                FechaIngreso = dtpFechaIngreso.Value.Date,
                IdEntorno = (int)cmbEntornoFormativo.SelectedValue,
                Responsable = txtResponsableCargo.Text.Trim(),
                Estado = true
            };

            bll.Modificar(art);
            MessageBox.Show("Artículo modificado correctamente.");
            CargarGrilla();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Clear();
            txtCantidad.Clear();
            cmbKgUnidad.SelectedIndex = -1;
            dtpFechaIngreso.Value = DateTime.Now;
            cmbEntornoFormativo.SelectedIndex = -1;
            txtResponsableCargo.Clear();
            idSeleccionado = 0;
        }

        private void dtgArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dtgArticulos.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(row.Cells["IdArtPañol"].Value);
            txtNombreProducto.Text = row.Cells["NombreProducto"].Value.ToString();
            txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
            cmbKgUnidad.Text = row.Cells["Unidad"].Value.ToString();
            dtpFechaIngreso.Value = Convert.ToDateTime(row.Cells["FechaIngreso"].Value);
            cmbEntornoFormativo.Text = row.Cells["Entorno"].Value.ToString();
            txtResponsableCargo.Text = row.Cells["Responsable"].Value.ToString();
        }


        private void txtFiltrarNombre_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(txtFiltrarNombre.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "ArticulosPañol.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                string ruta = Path.Combine(Application.StartupPath, "Recursos", "ArticulosPañol.html");
                string html = File.ReadAllText(ruta);
                html = html.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgArticulos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        filas += "<tr>";
                        filas += $"<td>{row.Cells["NombreProducto"].Value}</td>";
                        filas += $"<td>{row.Cells["Cantidad"].Value}</td>";
                        filas += $"<td>{row.Cells["Unidad"].Value}</td>";
                        filas += $"<td>{Convert.ToDateTime(row.Cells["FechaIngreso"].Value):dd/MM/yyyy}</td>";
                        filas += $"<td>{row.Cells["Entorno"].Value}</td>";
                        filas += $"<td>{row.Cells["Responsable"].Value}</td>";
                        filas += $"<td>{((bool)row.Cells["Estado"].Value ? "Activo" : "Inactivo")}</td>";
                        filas += "</tr>";
                    }
                }

                html = html.Replace("@FILAS", filas);

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("PDF generado correctamente.", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
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

    }
}
