using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class Inventario : Form
    {
        private UsuarioLoginDTO usuarioLogeado;
        private ArticuloBLL articuloBLL = new ArticuloBLL();
        private TipoEntornoBLL tipoEntornoBLL = new TipoEntornoBLL();
        private TipoMedidaBLL tipoMedidaBLL = new TipoMedidaBLL();
        private AlimentoBLL alimentoBLL = new AlimentoBLL();
        private int idArticuloSeleccionado = 0;
        private ProveedorBLL proveedorBLL = new ProveedorBLL();
        private int IdAlimentoSeleccionado = 0;
        private bool esInvitado = false;




        public Inventario(Form formularioMenu, UsuarioLoginDTO usuario)
        {
            InitializeComponent();
            this.usuarioLogeado = usuario;
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.AdaptMdiChild(this);
            CargarCombos();
            CargarArticulos();
            CargarCombosAlimentos();
            CargarAlimentos();
            dtgAlimentos.DefaultCellStyle.ForeColor = Color.Black;
            dtgArticulos.DefaultCellStyle.ForeColor = Color.Black;
        }

        public Inventario(bool invitado = false)
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

        private void CargarArticulos(string filtro = "")
        {
            dtgArticulos.DataSource = articuloBLL.ListarArticulos(filtro);

            if (dtgArticulos.Columns["IdTipoMedida"] != null)
                dtgArticulos.Columns["IdTipoMedida"].Visible = false;

            if (dtgArticulos.Columns["IdTipoEntorno"] != null)
                dtgArticulos.Columns["IdTipoEntorno"].Visible = false;

            dtgArticulos.Columns["FechaEgreso"].Visible = false;
            dtgArticulos.Columns["Estado"].Visible = false;
        }

        private void CargarCombos()
        {
            cmbEntornoFormativo.DataSource = tipoEntornoBLL.Listar();
            cmbEntornoFormativo.DisplayMember = "Nombre";
            cmbEntornoFormativo.ValueMember = "IdTipoEntorno";
            cmbEntornoFormativo.SelectedIndex = -1;

            cmbKgUnidad.DataSource = tipoMedidaBLL.Listar();
            cmbKgUnidad.DisplayMember = "Nombre";
            cmbKgUnidad.ValueMember = "IdTipoMedida";
            cmbKgUnidad.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                    string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                    cmbKgUnidad.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                    cmbEntornoFormativo.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtResponsableCargo.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos antes de continuar.",
                                    "Campos incompletos",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                Articulo articulo = new Articulo
                {
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    Cantidad = decimal.Parse(txtCantidad.Text),
                    IdTipoMedida = (int)cmbKgUnidad.SelectedValue,
                    Precio = string.IsNullOrWhiteSpace(txtPrecio.Text) ? (decimal?)null : decimal.Parse(txtPrecio.Text),
                    FechaIngreso = dtpFechaIngreso.Value.Date,
                    IdTipoEntorno = (int)cmbEntornoFormativo.SelectedValue,
                    Responsable = txtResponsableCargo.Text.Trim(),
                    FechaEgreso = DateTime.Now.Date,
                    Estado = true
                };

                articuloBLL.AgregarArticulo(articulo);

                MessageBox.Show("Artículo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarArticulos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar artículo: " + ex.Message);
            }
        }

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (idArticuloSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un artículo para modificar.");
                    return;
                }

                Articulo articulo = new Articulo
                {
                    IdArticulo = idArticuloSeleccionado,
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    Cantidad = decimal.Parse(txtCantidad.Text),
                    IdTipoMedida = (int)cmbKgUnidad.SelectedValue,
                    Precio = string.IsNullOrWhiteSpace(txtPrecio.Text) ? (decimal?)null : decimal.Parse(txtPrecio.Text),
                    FechaIngreso = dtpFechaIngreso.Value.Date,
                    IdTipoEntorno = (int)cmbEntornoFormativo.SelectedValue,
                    Responsable = txtResponsableCargo.Text.Trim(),
                    FechaEgreso = DateTime.Now.Date,
                    Estado = true
                };

                articuloBLL.Modificar(articulo);
                MessageBox.Show("Artículo modificado correctamente.");
                CargarArticulos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar artículo: " + ex.Message);
            }
        }

        private void dtgArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgArticulos.Rows[e.RowIndex];

                idArticuloSeleccionado = Convert.ToInt32(row.Cells["IdArticulo"].Value);
                txtNombreProducto.Text = row.Cells["NombreProducto"].Value.ToString();
                txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value?.ToString();
                txtResponsableCargo.Text = row.Cells["Responsable"].Value?.ToString();

                cmbKgUnidad.SelectedValue = Convert.ToInt32(row.Cells["IdTipoMedida"].Value);
                cmbEntornoFormativo.SelectedValue = Convert.ToInt32(row.Cells["IdTipoEntorno"].Value);

                if (row.Cells["FechaIngreso"].Value != DBNull.Value)
                    dtpFechaIngreso.Value = Convert.ToDateTime(row.Cells["FechaIngreso"].Value);
            }
        }

        private void txtFiltrarNombre_TextChanged(object sender, EventArgs e)
        {
            CargarArticulos(txtFiltrarNombre.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtResponsableCargo.Clear();
            txtFiltrarNombre.Clear();
            cmbKgUnidad.SelectedIndex = -1;
            cmbEntornoFormativo.SelectedIndex = -1;
            dtpFechaIngreso.Value = DateTime.Now;
            idArticuloSeleccionado = 0;
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
        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTextoNumeroEspacio(e);
        }
        private void SoloNumerosYComa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosYComa(txtPrecio, e, errorProvider1);
        }


        // ========================================
        // NUEVA SECCIÓN ALIMENTOS PROVEEDORES
        // ========================================

        private void CargarCombosAlimentos()
        {
            cmbMedidaProveedor.DataSource = tipoMedidaBLL.Listar();
            cmbMedidaProveedor.DisplayMember = "Nombre";
            cmbMedidaProveedor.ValueMember = "IdTipoMedida";
            cmbMedidaProveedor.SelectedIndex = -1;

            cmbTipoEntorno2.DataSource = tipoEntornoBLL.Listar();
            cmbTipoEntorno2.DisplayMember = "Nombre";
            cmbTipoEntorno2.ValueMember = "IdTipoEntorno";
            cmbTipoEntorno2.SelectedIndex = -1;

            cmbProveedores.DataSource = proveedorBLL.Listar();
            cmbProveedores.DisplayMember = "RazonSocial";
            cmbProveedores.ValueMember = "IdProveedor";
            cmbProveedores.SelectedIndex = -1;
        }


        private void CargarAlimentos()
        {
            dtgAlimentos.AutoGenerateColumns = true;
            dtgAlimentos.DataSource = alimentoBLL.Listar();
        }

        private void btnAgregarAlimentos_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreAlimentoProveedor.Text) ||
                    string.IsNullOrWhiteSpace(txtCantidadProveedor.Text) ||
                    cmbMedidaProveedor.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtPrecioProveedor.Text) ||
                    cmbTipoEntorno2.SelectedIndex == -1 ||
                    cmbProveedores.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor complete todos los campos antes de agregar el alimento.");
                    return;
                }

                Alimento alimento = new Alimento
                {
                    Nombre = txtNombreAlimentoProveedor.Text.Trim(),
                    Cantidad = decimal.Parse(txtCantidadProveedor.Text),
                    IdTipoMedida = (int)cmbMedidaProveedor.SelectedValue,
                    Precio = decimal.Parse(txtPrecioProveedor.Text),
                    FechaIngreso = dtpFechaIngresoAlimento.Value.Date,
                    IdTipoEntorno = (int)cmbTipoEntorno2.SelectedValue,
                    IdProveedor = (int)cmbProveedores.SelectedValue,
                    Estado = true
                };

                alimentoBLL.Agregar(alimento);
                MessageBox.Show("Alimento agregado correctamente.");
                CargarAlimentos();
                btnLimpiarAlimentos_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar alimento: " + ex.Message);
            }
        }

        private void btnLimpiarAlimentos_Click(object sender, EventArgs e)
        {
            txtNombreAlimentoProveedor.Clear();
            txtCantidadProveedor.Clear();
            txtPrecioProveedor.Clear();
            cmbMedidaProveedor.SelectedIndex = -1;
            cmbTipoEntorno2.SelectedIndex = -1;
            cmbProveedores.SelectedIndex = -1;
            dtpFechaIngresoAlimento.Value = DateTime.Now;
        }

        // ================================
        // BOTÓN IMPRIMIR ARTÍCULOS
        // ================================
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "ReporteArticulos.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Articulos.html");
                string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                // Crear filas HTML desde el DataGridView
                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgArticulos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        filas += "<tr>";
                        filas += $"<td>{row.Cells["NombreProducto"].Value}</td>";
                        filas += $"<td>{row.Cells["Cantidad"].Value}</td>";
                        filas += $"<td>{row.Cells["Precio"].Value}</td>";
                        filas += $"<td>{(row.Cells["FechaIngreso"].Value == DBNull.Value ? "-" : Convert.ToDateTime(row.Cells["FechaIngreso"].Value).ToString("dd/MM/yyyy"))}</td>";
                        filas += $"<td>{row.Cells["Responsable"].Value}</td>";
                        filas += $"<td>{((bool)row.Cells["Estado"].Value ? "Activo" : "Inactivo")}</td>";
                        filas += "</tr>";
                    }
                }

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        // Logo
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

                    MessageBox.Show("Reporte de artículos generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================
        // BOTÓN IMPRIMIR ALIMENTOS
        // ================================
        private void btnImprimirAlimentos_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "ReporteAlimentos.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "AlimentosProveedor.html");
                string PaginaHTML_Texto = File.ReadAllText(rutaPlantilla);

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                // Crear filas HTML desde el DataGridView
                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgAlimentos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        filas += "<tr>";
                        filas += $"<td>{row.Cells["Nombre"].Value}</td>";
                        filas += $"<td>{row.Cells["Cantidad"].Value}</td>";
                        filas += $"<td>{row.Cells["IdTipoMedida"].Value}</td>";
                        filas += $"<td>{row.Cells["Precio"].Value}</td>";
                        filas += $"<td>{Convert.ToDateTime(row.Cells["FechaIngreso"].Value):dd/MM/yyyy}</td>";
                        filas += $"<td>{row.Cells["IdTipoEntorno"].Value}</td>";
                        filas += $"<td>{row.Cells["IdProveedor"].Value}</td>";
                        filas += $"<td>{((bool)row.Cells["Estado"].Value ? "Activo" : "Inactivo")}</td>";
                        filas += "</tr>";
                    }
                }

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        // Logo
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

                    MessageBox.Show("Reporte de alimentos generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dtgAlimentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgAlimentos.Rows[e.RowIndex];
                IdAlimentoSeleccionado = Convert.ToInt32(row.Cells["IdAlimento"].Value);
                txtNombreAlimentoProveedor.Text = row.Cells["Nombre"].Value.ToString();
                txtCantidadProveedor.Text = row.Cells["Cantidad"].Value.ToString();
                txtPrecioProveedor.Text = row.Cells["Precio"].Value.ToString();

                cmbMedidaProveedor.SelectedValue = Convert.ToInt32(row.Cells["IdTipoMedida"].Value);
                cmbTipoEntorno2.SelectedValue = Convert.ToInt32(row.Cells["IdTipoEntorno"].Value);
                cmbProveedores.SelectedValue = Convert.ToInt32(row.Cells["IdProveedor"].Value);

                if (row.Cells["FechaIngreso"].Value != DBNull.Value)
                    dtpFechaIngresoAlimento.Value = Convert.ToDateTime(row.Cells["FechaIngreso"].Value);
            }
        }

        private void btnModificarAlimentos_Click(object sender, EventArgs e)
        {




                try

                { 
               
                
                if (IdAlimentoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un artículo para modificar.");
                return;
            }





            Alimento alimento = new Alimento
                {
                    IdAlimento = IdAlimentoSeleccionado,
                    Nombre = txtNombreAlimentoProveedor.Text.Trim(),
                    Cantidad = decimal.Parse(txtCantidadProveedor.Text),
                    IdTipoMedida = (int)cmbMedidaProveedor.SelectedValue,
                    Precio = decimal.Parse(txtPrecioProveedor.Text),
                    FechaIngreso = dtpFechaIngresoAlimento.Value.Date,
                    IdTipoEntorno = (int)cmbTipoEntorno2.SelectedValue,
                    IdProveedor = (int)cmbProveedores.SelectedValue,
                    Estado = true
                };

                alimentoBLL.Modificar(alimento);

                MessageBox.Show("Alimento modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar grilla
                CargarAlimentos();
                LimpiarCamposAlimentos();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar alimento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarCamposAlimentos()
        {
            txtNombreAlimentoProveedor.Clear();
            txtCantidadProveedor.Clear();
            txtPrecioProveedor.Clear();
            cmbMedidaProveedor.SelectedIndex = -1;
            cmbTipoEntorno2.SelectedIndex = -1;
            cmbProveedores.SelectedIndex = -1;
            dtpFechaIngresoAlimento.Value = DateTime.Now;
        }




    }
}
