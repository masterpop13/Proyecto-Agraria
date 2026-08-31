using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
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
    public partial class AbmUsuario : Form
    {
        public AbmUsuarioBLL AbmUsuarioBLL = new AbmUsuarioBLL();
        private bool esInvitado = false;

        public AbmUsuario(Form formulariomenu)
        {
            InitializeComponent();
            CargarUsuariosEnGrid();
            CargarComboBoxes();
        }


        public AbmUsuario(bool invitado = false)
        {

            InitializeComponent();
            CargarUsuariosEnGrid();
            CargarComboBoxes();
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

                else if (c is CheckBox chk)
                    chk.Enabled = false;

                else if (c is DataGridView dgv)
                {
                    dgv.Enabled = false;               // deshabilita el control completo
                    dgv.ReadOnly = true;               // evita edición directa
                    dgv.AllowUserToAddRows = false;    // evita agregar filas
                    dgv.AllowUserToDeleteRows = false; // evita borrar filas
                }

                // 🔁 Recorre los hijos (Paneles, GroupBox, TabPage, etc.)
                if (c.HasChildren)
                    DeshabilitarControlesRecursivo(c);
            }
        }

        private void dtgAbmUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarTextbox(e.RowIndex);

                // 🔹 Obtener el Id del usuario seleccionado
                int idUsuario = Convert.ToInt32(dtgAbmUsuario.Rows[e.RowIndex].Cells["Id"].Value);

                // 🔹 Consultar los permisos desde la BLL
                var permisos = AbmUsuarioBLL.ObtenerPermisosPorUsuario(idUsuario);

                // 🔹 Asignar los valores a los CheckBox
                chkEntornoFormativo.Checked = permisos.PuedeEntornoFormativo;
                chkAltaUsuario.Checked = permisos.PuedeAltaUsuario;
                chkVenta.Checked = permisos.PuedeVenta;
                chkInventario.Checked = permisos.PuedeInventario;
                chkIndustria.Checked = permisos.PuedeIndustria;
                chkProduccionAnimal.Checked = permisos.PuedeProduccionAnimal;
                chkProduccionVegetal.Checked = permisos.PuedeProduccionVegetal;
                chkAdministracion.Checked = permisos.PuedeAdministracion;
                chkPañol.Checked = permisos.PuedePañol; // ✅ nuevo

            }
        }


        private void CargarUsuariosEnGrid()
        {
            List<AbmUsuarioDTO> usuarios = AbmUsuarioBLL.CargarTodoslosUsuarios();
            dtgAbmUsuario.DataSource = usuarios;

            dtgAbmUsuario.Columns["Id"].Visible = false;
            dtgAbmUsuario.Columns["Contraseña"].Visible = false;
            dtgAbmUsuario.Columns["PreguntaSeguridad"].Visible = false;
            dtgAbmUsuario.Columns["RespuestaSeguridad"].Visible = false;
            dtgAbmUsuario.Columns["Documento"].Visible = false;
            dtgAbmUsuario.Columns["Telefono"].Visible = false;
            dtgAbmUsuario.Columns["Direccion"].Visible = false;
            dtgAbmUsuario.Columns["NombreUsuario"].Visible = false;

            dtgAbmUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarTextbox(int index)
        {
            if (index < 0 || index >= dtgAbmUsuario.Rows.Count) return;

            var fila = dtgAbmUsuario.Rows[index];

            txtID.Text = fila.Cells["Id"].Value?.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
            txtDocumento.Text = fila.Cells["Documento"].Value?.ToString();
            txtDireccion.Text = fila.Cells["Direccion"].Value?.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
            cmbPartido.Text = fila.Cells["Partido"].Value?.ToString();
            cmbLocalidad.Text = fila.Cells["Localidad"].Value?.ToString();
            txtCodigoPostal.Text = fila.Cells["CodigoPostal"].Value?.ToString();
            txtEmail.Text = fila.Cells["Email"].Value?.ToString();
            txtNombreUsuario.Text = fila.Cells["NombreUsuario"].Value?.ToString();
            txtContraseña.Text = fila.Cells["Contraseña"].Value?.ToString();
            cmbPreguntaSeguridad.Text = fila.Cells["PreguntaSeguridad"].Value?.ToString();
            txtRespuestaSeguridad.Text = fila.Cells["RespuestaSeguridad"].Value?.ToString();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var usuario = new Agraria.Datos.Entidades.AbmUsuario
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = int.Parse(txtDocumento.Text),
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                IdLocalidad = new LocalidadDTO { NombreLocalidad = cmbLocalidad.Text },
                IdPartido = new PartidoDTO { NombrePartido = cmbPartido.Text },

                // ✅ Ahora agregamos la pregunta seleccionada
                IdPreguntaSeguridad = new PreguntaSeguridadDTO { TextoPregunta = cmbPreguntaSeguridad.Text },

                Email = txtEmail.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = txtContraseña.Text,
                RespuestaSeguridad = txtRespuestaSeguridad.Text,
                Estado = true
            };

            int nuevoId = AbmUsuarioBLL.InsertarUsuarioYObtenerId(usuario);

            AbmUsuarioBLL.GuardarPermisos(
                nuevoId,
                chkEntornoFormativo.Checked,
                chkAltaUsuario.Checked,
                chkVenta.Checked,
                chkInventario.Checked,
                chkIndustria.Checked,
                chkProduccionAnimal.Checked,
                chkProduccionVegetal.Checked,
                chkAdministracion.Checked,
                chkPañol.Checked
            );


            MessageBox.Show("Usuario creado con permisos asignados.");
            CargarUsuariosEnGrid();
            LimpiarCampos();
        }


        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Agraria.Datos.Entidades.AbmUsuario usuario = new Agraria.Datos.Entidades.AbmUsuario
            {
                Id = (string.IsNullOrEmpty(txtID.Text)) ? 0 : int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = int.Parse(txtDocumento.Text),
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                IdPartido = new PartidoDTO { NombrePartido = cmbPartido.Text },
                IdLocalidad = new LocalidadDTO { NombreLocalidad = cmbLocalidad.Text },
                IdPreguntaSeguridad = new PreguntaSeguridadDTO { TextoPregunta = cmbPreguntaSeguridad.Text },
                Email = txtEmail.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = txtContraseña.Text,
                RespuestaSeguridad = txtRespuestaSeguridad.Text,
                Estado = true
            };

            AbmUsuarioBLL.ModificarUsuario(usuario);


            // 🔐 Actualizar permisos (upsert)
            AbmUsuarioBLL.ActualizarPermisos(
                usuario.Id,
                chkEntornoFormativo.Checked,
                chkAltaUsuario.Checked,
                chkVenta.Checked,
                chkInventario.Checked,
                chkIndustria.Checked,
                chkProduccionAnimal.Checked,
                chkProduccionVegetal.Checked,
                chkAdministracion.Checked,
                chkPañol.Checked
            );

            MessageBox.Show("Usuario modificado y permisos actualizados.");
            MessageBox.Show("Usuario modificado correctamente.");
            CargarUsuariosEnGrid();
            LimpiarCampos();
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            if (dtgAbmUsuario.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dtgAbmUsuario.SelectedRows[0].Cells["Id"].Value);
            if ((bool)dtgAbmUsuario.SelectedRows[0].Cells["Estado"].Value)
            {
                MessageBox.Show("Este usuario ya está dado de alta.");
                return;
            }

            AbmUsuarioBLL.CambiarEstadoUsuario(id, true);
            MessageBox.Show("Usuario dado de alta.");
            CargarUsuariosEnGrid();
        }

        private void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            if (dtgAbmUsuario.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dtgAbmUsuario.SelectedRows[0].Cells["Id"].Value);
            if (!(bool)dtgAbmUsuario.SelectedRows[0].Cells["Estado"].Value)
            {
                MessageBox.Show("Este usuario ya está dado de baja.");
                return;
            }

            AbmUsuarioBLL.CambiarEstadoUsuario(id, false);
            MessageBox.Show("Usuario dado de baja.");
            CargarUsuariosEnGrid();
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            cmbLocalidad.SelectedIndex = -1;
            cmbPartido.SelectedIndex = -1;
            txtCodigoPostal.Clear();
            txtEmail.Clear();
            txtNombreUsuario.Clear();
            txtContraseña.Clear();
            cmbPreguntaSeguridad.SelectedIndex = -1;
            txtRespuestaSeguridad.Clear();
        }

        private void txtBuscarNombreDni_TextChanged(object sender, EventArgs e)
        {
            string textoBuscado = txtBuscarApellido.Text.Trim();
            dtgAbmUsuario.DataSource = AbmUsuarioBLL.BuscarUsuarioPorNombreODni(textoBuscado);
        }

        private void CargarComboBoxes()
        {
            cmbPartido.DataSource = AbmUsuarioBLL.CargarPartidos();
            cmbPartido.DisplayMember = "NombrePartido";
            cmbPartido.ValueMember = "IdPartido";
            cmbPartido.SelectedIndex = -1;

            cmbLocalidad.DataSource = AbmUsuarioBLL.CargarLocalidades();
            cmbLocalidad.DisplayMember = "NombreLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";
            cmbLocalidad.SelectedIndex = -1;

            cmbPreguntaSeguridad.DataSource = AbmUsuarioBLL.CargarPreguntasSeguridad();
            cmbPreguntaSeguridad.DisplayMember = "TextoPregunta";
            cmbPreguntaSeguridad.ValueMember = "IdPregunta";
            cmbPreguntaSeguridad.SelectedIndex = -1;
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.SelectedValue != null && cmbPartido.SelectedValue is int idPartido)
            {
                cmbLocalidad.DataSource = AbmUsuarioBLL.CargarLocalidadesPorPartido(idPartido);
                cmbLocalidad.DisplayMember = "NombreLocalidad";
                cmbLocalidad.ValueMember = "IdLocalidad";
                cmbLocalidad.SelectedIndex = -1;
            }
        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                cmbLocalidad.SelectedIndex == -1 ||
                cmbPartido.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                cmbPreguntaSeguridad.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtRespuestaSeguridad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void pbExitAbmUsuarios_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
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

        private void AbmUsuario_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.AdaptMdiChild(this);
        }
    }
}
