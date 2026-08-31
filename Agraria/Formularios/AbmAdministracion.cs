using Agraria.Datos.DAL;
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


namespace Agraria.Formularios
{
    public partial class AbmAdministracion : Form
    {
        private readonly AdministracionBLL bll = new AdministracionBLL();
        private PerfilBLL perfilBLL = new PerfilBLL();
        private int idProveedorSeleccionado = 0;
        private bool esInvitado = false;

        public AbmAdministracion(Form formulariomenu)
        {
            InitializeComponent();
            // Eventos de combos:
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;

            cmbTipoEntorno.SelectedIndexChanged += cmbTipoEntorno_SelectedIndexChanged;

            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;

            cmbKgUnidad.SelectedIndexChanged += cmbKgUnidad_SelectedIndexChanged;

            // Botones:
            btnGuardarUsuario.Click += btnGuardarUsuario_Click;
            btnModificarUsuario.Click += btnModificarUsuario_Click;

            btnGuardarEntorno.Click += btnGuardarEntorno_Click;
            btnModificarEntorno.Click += btnModificarEntorno_Click;

            btnGuardarProducto.Click += btnGuardarProducto_Click;
            btnModificarProducto.Click += btnModificarProducto_Click;

            btnGuardarUnidad.Click += btnGuardarUnidad_Click;
            btnModificarUnidad.Click += btnModificarUnidad_Click;
        }

        public AbmAdministracion(bool invitado = false)
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



        private void AbmAdministracion_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.AdaptMdiChild(this);
            CargarCombosBase();
            CargarProveedores();
            dtgProveedores.DefaultCellStyle.ForeColor = Color.Black;
            cmbLocalidad.SelectedIndexChanged += cmbLocalidad_SelectedIndexChanged;
            cmbPartido.Enabled = false;
            txtPartido.Enabled = false;

        }

        // ================= CARGAS =================
        private void CargarCombosBase()
        {
            cmbPartido.DataSource = bll.ListarPartidos();
            cmbPartido.DisplayMember = "NombrePartido";
            cmbPartido.ValueMember = "IdPartido";
            cmbPartido.SelectedIndex = -1;

            cmbLocalidad.DataSource = bll.ListarLocalidades();
            cmbLocalidad.DisplayMember = "NombreLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";
            cmbLocalidad.SelectedIndex = -1;

            txtCodigoPostal.Clear();

            // Tipo Entorno
            var entornos = bll.ListarTipoEntorno();
            cmbTipoEntorno.DataSource = entornos;
            cmbTipoEntorno.DisplayMember = "Nombre";
            cmbTipoEntorno.ValueMember = "IdTipoEntorno";
            cmbTipoEntorno.SelectedIndex = -1;

            // Productos (Nombre y Descripción)
            var productos = bll.ListarProductos();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
            cmbProducto.SelectedIndex = -1;

            // Tipo Medida
            var medidas = bll.ListarTipoMedida();
            cmbKgUnidad.DataSource = medidas;
            cmbKgUnidad.DisplayMember = "Nombre";
            cmbKgUnidad.ValueMember = "IdTipoMedida";
            cmbKgUnidad.SelectedIndex = -1;


            cmbPartido.Enabled = false;
            txtPartido.Enabled = false;
        }



        // ================= COMBOS -> TEXTBOX =================

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocalidad.SelectedItem is LocalidadDTO localidad)
            {
                txtLocalidad.Text = localidad.NombreLocalidad;
                txtCodigoPostal.Text = localidad.CodigoPostal.ToString();

                // 🔹 Habilitar Partido una vez seleccionada una localidad
                cmbPartido.Enabled = true;
                txtPartido.Enabled = true;

                // 🔹 Buscar el partido correspondiente
                var partidos = bll.ListarPartidos();
                var partido = partidos.FirstOrDefault(p => p.IdPartido == localidad.IdPartido);
                if (partido != null)
                {
                    cmbPartido.SelectedValue = partido.IdPartido;
                    txtPartido.Text = partido.NombrePartido;
                }
            }
            else
            {
                // 🔹 Si se deselecciona, volver a anular
                cmbPartido.Enabled = false;
                txtPartido.Enabled = false;
                txtPartido.Clear();
            }
        }
        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.SelectedItem is PartidoDTO p)
            {
                txtPartido.Text = p.NombrePartido;
            }
        }



        private void cmbTipoEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoEntorno.SelectedItem is TipoEntornoDTO te)
            {
                txtTipoEntorno.Text = te.Nombre;
            }
        }

        private void cmbKgUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKgUnidad.SelectedItem is TipoMedidaDTO tm)
            {
                txtKgUnidad.Text = tm.Nombre;
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al elegir un producto, precargar nombre, precio y receta
            if (cmbProducto.SelectedItem is ProductoDTO pr)
            {
                txtProducto.Text = pr.Nombre;
                // precio desde Productos (PrecioUnitario)
                var precio = bll.ObtenerPrecioPorNombre(pr.Nombre);
                txtPrecioProducto.Text = precio.HasValue ? precio.Value.ToString("0.##") : "0";
                // receta/descripción
                txtReceta.Text = bll.ObtenerDescripcionPorNombre(pr.Nombre) ?? "";
            }
        }

        // ================= GUARDAR / MODIFICAR =================
        // ► Usuarios (en realidad, por lo que pediste: guardamos Partidos y Localidades)
        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPartido.Text) ||
                    string.IsNullOrWhiteSpace(txtLocalidad.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigoPostal.Text))
                {
                    MessageBox.Show("Complete todos los campos antes de guardar.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔸 Guardar o reutilizar Partido
                int idPartido;
                if (cmbPartido.SelectedItem is PartidoDTO partidoSel)
                {
                    idPartido = partidoSel.IdPartido;
                }
                else
                {
                    bll.GuardarPartido(txtPartido.Text.Trim());
                    var nuevoPartido = bll.ListarPartidos().FirstOrDefault(p => p.NombrePartido == txtPartido.Text.Trim());
                    idPartido = nuevoPartido?.IdPartido ?? 0;
                }

                // 🔸 Guardar Localidad asociada
                int codigoPostal = int.TryParse(txtCodigoPostal.Text, out var cp) ? cp : 0;
                bll.GuardarLocalidad(txtLocalidad.Text.Trim(), idPartido, codigoPostal);

                MessageBox.Show("Localidad y Partido guardados correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCombosBase();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLocalidad.SelectedItem is not LocalidadDTO localidadSel)
                {
                    MessageBox.Show("Seleccione una Localidad para modificar.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPartido;
                if (cmbPartido.SelectedItem is PartidoDTO partidoSel)
                {
                    idPartido = partidoSel.IdPartido;
                    bll.ModificarPartido(idPartido, txtPartido.Text.Trim());
                }
                else
                {
                    // Si no hay partido seleccionado, intenta mantener el actual
                    idPartido = localidadSel.IdPartido;
                }

                int codigoPostal = int.TryParse(txtCodigoPostal.Text, out var cp) ? cp : 0;

                bll.ModificarLocalidad(localidadSel.IdLocalidad, txtLocalidad.Text.Trim(), idPartido, codigoPostal);

                MessageBox.Show("Localidad modificada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCombosBase();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ► Tipo Entorno
        private void btnGuardarEntorno_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTipoEntorno.Text))
                {
                    MessageBox.Show("Escriba un nombre de entorno.", "Atención");
                    return;
                }
                bll.GuardarTipoEntorno(txtTipoEntorno.Text.Trim());
                MessageBox.Show("Tipo de entorno guardado.", "Éxito");
                CargarCombosBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar entorno: " + ex.Message, "Error");
            }
        }

        private void btnModificarEntorno_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cmbTipoEntorno.SelectedItem is TipoEntornoDTO te))
                {
                    MessageBox.Show("Seleccione un entorno.", "Atención");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTipoEntorno.Text))
                {
                    MessageBox.Show("Escriba un nombre.", "Atención");
                    return;
                }

                bll.ModificarTipoEntorno(te.IdTipoEntorno, txtTipoEntorno.Text.Trim());
                MessageBox.Show("Tipo de entorno modificado.", "Éxito");
                CargarCombosBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar entorno: " + ex.Message, "Error");
            }
        }

        // ► Productos (Nombre, PrecioUnitario, Descripción)
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProducto.Text))
                {
                    MessageBox.Show("Ingrese un nombre de producto.", "Atención");
                    return;
                }
                if (!decimal.TryParse(txtPrecioProducto.Text, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Precio inválido.", "Atención");
                    return;
                }

                bll.GuardarProducto(txtProducto.Text.Trim(), txtReceta.Text?.Trim(), precio);
                MessageBox.Show("Producto guardado.", "Éxito");
                CargarCombosBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producto: " + ex.Message, "Error");
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cmbProducto.SelectedItem is ProductoDTO pr))
                {
                    MessageBox.Show("Seleccione un producto.", "Atención");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtProducto.Text))
                {
                    MessageBox.Show("Nombre de producto inválido.", "Atención");
                    return;
                }
                if (!decimal.TryParse(txtPrecioProducto.Text, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Precio inválido.", "Atención");
                    return;
                }

                bll.ModificarProducto(pr.IdProducto, txtProducto.Text.Trim(), txtReceta.Text?.Trim(), precio);
                MessageBox.Show("Producto modificado.", "Éxito");
                CargarCombosBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar producto: " + ex.Message, "Error");
            }
        }

        // ► Tipo Medida
        private void btnGuardarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKgUnidad.Text))
                {
                    MessageBox.Show("Ingrese un nombre de unidad (Kg/Unidad/etc).", "Atención");
                    return;
                }
                bll.GuardarTipoMedida(txtKgUnidad.Text.Trim());
                MessageBox.Show("Unidad guardada.", "Éxito");
                CargarCombosBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar unidad: " + ex.Message, "Error");
            }
        }

        private void btnModificarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cmbKgUnidad.SelectedItem is TipoMedidaDTO tm))
                {
                    MessageBox.Show("Seleccione una unidad.", "Atención");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtKgUnidad.Text))
                {
                    MessageBox.Show("Ingrese el nuevo nombre de la unidad.", "Atención");
                    return;
                }

                bll.ModificarTipoMedida(tm.IdTipoMedida, txtKgUnidad.Text.Trim());
                MessageBox.Show("Unidad modificada.", "Éxito");
                CargarCombosBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar unidad: " + ex.Message, "Error");
            }
        }







        ///////////////////proveedores ////////////////////////////////////////////////////
        ///

        private void CargarProveedores()
        {
            dtgProveedores.DataSource = bll.ListarProveedores();
            dtgProveedores.Columns["IdProveedor"].Visible = false;
        }
        /*
                private void LimpiarCampos()
                {
                    txtRazonSocial.Clear();
                    txtTelefono.Clear();
                    txtEmail.Clear();
                    txtDireccion.Clear();
                    idProveedorSeleccionado = 0;
                }
        */

        private void LimpiarCampos()
        {
            // 🧾 Datos de Proveedores
            txtRazonSocial.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            // 🧍‍♂️ Datos de Usuario
            txtLocalidad.Clear();
            txtPartido.Clear();
            if (cmbLocalidad.Items.Count > 0) cmbLocalidad.SelectedIndex = -1;
            if (cmbPartido.Items.Count > 0) cmbPartido.SelectedIndex = -1;


            // 🌱 Datos de Entorno
            txtTipoEntorno.Clear();
            if (cmbTipoEntorno.Items.Count > 0) cmbTipoEntorno.SelectedIndex = -1;

            // 🧪 Datos de Producto
            txtProducto.Clear();
            txtReceta.Clear();
            txtPrecioProducto.Clear();
            if (cmbProducto.Items.Count > 0) cmbProducto.SelectedIndex = -1;

            // ⚖️ Datos de Unidad de Medida
            txtKgUnidad.Clear();
            if (cmbKgUnidad.Items.Count > 0) cmbKgUnidad.SelectedIndex = -1;

            // 🧹 Limpieza de variables de control
            idProveedorSeleccionado = 0;
        }




        // ✅ Guardar nuevo proveedor
        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRazonSocial.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Proveedor proveedor = new Proveedor
                {
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                bll.InsertarProveedor(proveedor);

                MessageBox.Show("Proveedor guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Modificar proveedor existente
        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (idProveedorSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un proveedor para modificar.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Proveedor proveedor = new Proveedor
                {
                    IdProveedor = idProveedorSeleccionado,
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                bll.ModificarProveedor(proveedor);

                MessageBox.Show("Proveedor modificado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar proveedor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Cargar datos al hacer clic en una fila
        private void dtgProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgProveedores.Rows[e.RowIndex];
                idProveedorSeleccionado = Convert.ToInt32(row.Cells["IdProveedor"].Value);
                txtRazonSocial.Text = row.Cells["RazonSocial"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            }
        }

        private void btnLimpiarLocalidadPartido_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnLimpiarTipoPerfil_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnLimpiarEntornos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnLimpiarIndustria_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnLimpiarAlimentos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnLimpiarProveedores_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
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
            Validaciones.SoloNumerosYComa(txtPrecioProducto, e, errorProvider1);
        }

        private void btnImprimirProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                // Configurar el diálogo para guardar el PDF
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "ReporteProveedores.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                // Ruta a la plantilla HTML
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Proveedores.html");
                string html = File.ReadAllText(rutaPlantilla);

                // Reemplazar etiquetas dinámicas
                html = html.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                html = html.Replace("@TITULO", "REPORTE DE PROVEEDORES");

                // Construir filas de la tabla
                string filas = string.Empty;
                foreach (DataGridViewRow row in dtgProveedores.Rows)
                {
                    if (row.IsNewRow) continue;

                    filas += "<tr>";
                    if (dtgProveedores.Columns.Contains("IdProveedor"))
                        filas += $"<td>{row.Cells["IdProveedor"].Value}</td>";
                    else
                        filas += "<td>-</td>"; // o dejar vacío

                    filas += $"<td>{row.Cells["RazonSocial"].Value}</td>";
                    filas += $"<td>{row.Cells["Telefono"].Value}</td>";
                    filas += $"<td>{row.Cells["Email"].Value}</td>";
                    filas += $"<td>{row.Cells["Direccion"].Value}</td>";
                    filas += "</tr>";
                }


                // Insertar las filas en el HTML
                html = html.Replace("@FILAS", filas);

                // Guardar y generar el PDF
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Reporte de proveedores generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
