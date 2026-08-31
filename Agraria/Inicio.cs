using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Formularios;
using Agraria.Helpers;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Agraria
{
    public partial class Inicio : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private List<Form> formulariosAbiertos = new List<Form>();
        private System.Windows.Forms.Timer timer;
        private UsuarioLoginDTO usuarioLogeado;
        UrgenciaBLL urgenciaBLL = new UrgenciaBLL();
        private bool esInvitado = false;

        //habilitar movimiento del formulario
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        ///  hasta aqui
        /// </summary>
        /// <param name="usuario"></param>
        public Inicio(UsuarioLoginDTO usuario)
        {
            InitializeComponent();
           // random = new Random();
            // Crear e inicializar el Timer para el horario
          // timer = new System.Windows.Forms.Timer();
           // timer.Interval = 1000; // 1 segundo
            //timer.Tick += Timer_Tick;
           // timer.Start();
            usuarioLogeado = usuario;
            esInvitado = false;

        }
        public Inicio(bool modoInvitado)
        {
            InitializeComponent();
            esInvitado = modoInvitado;
            usuarioLogeado = null;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Formularios.Login login = new Formularios.Login();
            login.ShowDialog();
        }

        private void btnUsuarioAlta_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.AbmUsuario(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }


        }

        private void CerrarTodosLosFormularios()
        {
            foreach (var formulario in formulariosAbiertos)
            {
                if (formulario != null && !formulario.IsDisposed)
                {
                    formulario.Close();
                }
            }

            formulariosAbiertos.Clear();
        }

        private void pbCerrarAgraria_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void btnEntornoFormativo_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.AbmEntornoFormativo(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.RegistroVenta(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }


        private void btnProduccionAnimal_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.ProduccionAnimal(usuarioLogeado, esInvitado);


            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            //  Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }

        private void btnProduccionVegetal_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.ProduccionVegetal(usuarioLogeado, esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.Adapt(this);
            lblUsuario.Visible = true;

            if (usuarioLogeado != null)
            {
                lblUsuario.Text = "Bienvenido/a, " + usuarioLogeado.NombreUsuario;
                AplicarPermisos();
            }
            else
            {
                lblUsuario.Text = "Bienvenido/a, Invitado";
                ActivarModoInvitado();
            }
        }



        private void btnIndustria_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.Industria(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.Inventario(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }
        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.AbmAdministracion(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }


        private void pbUrgencias_Click(object sender, EventArgs e)
        {
            UrgenciaBLL urgenciaBLL = new UrgenciaBLL();
            var mensajes = urgenciaBLL.ObtenerMensajesDelDia();

            if (mensajes.Count == 0)
            {
                MessageBox.Show("No hay mensajes de urgencia pendientes para hoy.",
                    "Urgencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbUrgencias.Visible = false;
                return;
            }

            string texto = string.Join("\n\n", mensajes);
            MessageBox.Show(texto, "🚨 Urgencias del día 🚨", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }




        private void AplicarPermisos()
        {
            btnEntornoFormativo.Enabled = usuarioLogeado.PuedeEntornoFormativo;
            btnUsuarioAlta.Enabled = usuarioLogeado.PuedeAltaUsuario;
            btnVenta.Enabled = usuarioLogeado.PuedeVenta;
            btnInventario.Enabled = usuarioLogeado.PuedeInventario;
            btnIndustria.Enabled = usuarioLogeado.PuedeIndustria;
            btnProduccionAnimal.Enabled = usuarioLogeado.PuedeProduccionAnimal;
            btnProduccionVegetal.Enabled = usuarioLogeado.PuedeProduccionVegetal;
            btnAdministracion.Enabled = usuarioLogeado.PuedeAdministracion;
        }

        private void ActivarModoInvitado()
        {
            // ✅ Deja los botones visibles pero los formularios internos deshabilitados
            // Ejemplo de comportamiento:
            btnEntornoFormativo.Enabled = true;
            btnUsuarioAlta.Enabled = true;
            btnVenta.Enabled = true;
            btnInventario.Enabled = true;
            btnIndustria.Enabled = true;
            btnProduccionAnimal.Enabled = true;
            btnProduccionVegetal.Enabled = true;
            btnAdministracion.Enabled = true;

            // Deshabilitar acciones internas: formularios, botones dentro, etc.
            lblUsuario.Text = "Modo Invitado: solo visualización";

            // Si usás PictureBox, paneles o formularios hijos:
            // puedes ocultar los botones de guardar, modificar, eliminar, etc.
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnPañol_Click(object sender, EventArgs e)
        {
            CerrarTodosLosFormularios();

            // ✅ Pasamos el parámetro esInvitado al mismo formulario MDI
            var cargaForm = new Formularios.Pañol(esInvitado);

            cargaForm.MdiParent = this;
            cargaForm.Dock = DockStyle.Fill;
            cargaForm.Show();

            formulariosAbiertos.Add(cargaForm);
            activeForm = cargaForm;

            // ✅ Esto se mantiene igual
            if (pbUrgencias.Visible = urgenciaBLL.HayMensajes())
            {
                lblUrgencia.Visible = true;
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
