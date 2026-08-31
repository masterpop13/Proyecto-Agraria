using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Runtime.InteropServices;


namespace Agraria.Formularios
{
    public partial class Login : Form
    {
        private readonly UsuarioLoginBLL usuarioLoginBLL;

        /// <summary>
        /// //// habilitar movimiento del formulario
        /// </summary>

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// // hasta aqui
        /// </summary>

        public Login()
        {
            InitializeComponent();
            usuarioLoginBLL = new UsuarioLoginBLL();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            try
            {
                var usuarioBLL = new AbmUsuarioBLL();

                // ✅ Si no hay usuarios, crear el admin por única vez
                if (!usuarioBLL.HayUsuariosRegistrados())
                {
                    usuarioBLL.CrearUsuarioAdminInicial();

                    MessageBox.Show(
                        "Se ha creado un usuario administrador inicial.\n\n" +
                        "Usuario: admin\nContraseña: 123\n\n" +
                        "Por favor, inicie sesión con estas credenciales y cambie la contraseña desde su perfil.",
                        "Usuario Administrador Creado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar usuario administrador inicial: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnAceptarLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string pass = txtContraseña.Text.Trim();

            var user = usuarioLoginBLL.Autenticar(usuario, pass);

            if (user != null)
            {
                MessageBox.Show("Bienvenido " + user.NombreUsuario);

                Inicio inicio = new Inicio(user); // paso el usuario logeado
                inicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lblOlvidarContraseña_Click(object sender, EventArgs e)
        {
            Formularios.CambiarContraseña cambiar = new CambiarContraseña();
            cambiar.ShowDialog();
        }

        private void lblInvitado_Click(object sender, EventArgs e)
        {
            Inicio frmInicio = new Inicio(true);
            frmInicio.Show();

            // Cierra el login si querés
            this.Hide();

            MessageBox.Show("Entraste en modo invitado.\nPodés navegar pero no modificar datos.",
                "Modo Invitado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }


        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTextoNumeroEspacio(e);
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }



    }
}
