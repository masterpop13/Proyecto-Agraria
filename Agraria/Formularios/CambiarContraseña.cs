using Agraria.Datos.DAL;
using Agraria.Entidades;
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
    public partial class CambiarContraseña : Form
    {
        private readonly UsuarioLoginBLL usuarioLoginBLL;

        public CambiarContraseña()
        {
            InitializeComponent();
            usuarioLoginBLL = new UsuarioLoginBLL();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            UsuarioLogin usuario = new UsuarioLogin()
            {
                NombreUsuario = txtNombreUsuario.Text,
                IdPreguntaSeguridad = Convert.ToInt32(cmbPreguntaSeguridad.SelectedValue),
                RespuestaSeguridad = txtRespuestaSeguridad.Text
            };

            // Ahora sí pasás el objeto
            bool valido = usuarioLoginBLL.VerificarPreguntaSeguridad(usuario);

            if (valido)
            {
                txtNuevaContraseña.Visible = true;
                txtConfirmarNuevaContraseña.Visible = true;
                btnGuardar.Visible = true;
                btnConfirmar.Visible = false;
                txtNombreUsuario.Enabled = false;
                txtRespuestaSeguridad.Enabled = false;
                cmbPreguntaSeguridad.Enabled = false;
            }
            else
            {
                MessageBox.Show("Datos incorrectos, intente nuevamente.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNuevaContraseña.Text == txtConfirmarNuevaContraseña.Text)
            {
                UsuarioLogin usuario = new UsuarioLogin()
                {
                    NombreUsuario = txtNombreUsuario.Text,
                    Contraseña = txtNuevaContraseña.Text
                };

                // Ahora usás la sobrecarga correcta
                bool ok = usuarioLoginBLL.CambiarContraseña(usuario);

                if (ok)
                {
                    MessageBox.Show("Contraseña actualizada con éxito.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña.");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.");
            }
        }


        private void CambiarContraseña_Load(object sender, EventArgs e)
        {
            PreguntaSeguridadBLL bll = new PreguntaSeguridadBLL();
            var preguntas = bll.ObtenerPreguntas();

            cmbPreguntaSeguridad.DataSource = preguntas;
            cmbPreguntaSeguridad.DisplayMember = "TextoPregunta"; // lo que ve el usuario
            cmbPreguntaSeguridad.ValueMember = "IdPregunta";      // el valor interno
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


    }
}
