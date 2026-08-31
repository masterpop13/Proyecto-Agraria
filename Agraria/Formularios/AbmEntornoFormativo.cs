using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class AbmEntornoFormativo : Form
    {
        EntornoFormativoBLL entornoBLL = new EntornoFormativoBLL();
        private bool esInvitado = false;

        public AbmEntornoFormativo(Form formulariomenu)
        {
            InitializeComponent();
        }

        public AbmEntornoFormativo(bool invitado = false)
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

        private void pbExitEntornoFormativo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbmEntornoFormativo_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.AdaptMdiChild(this);
            CargarEntornos();
            CargarTipoEntorno();

        }

        private void CargarEntornos()
        {
            dtgEntorno.DataSource = entornoBLL.ObtenerEntornos();
            dtgEntorno.Columns["IdEntorno"].Visible = false;
        }

        private void CargarTipoEntorno()
        {
            cmbTipoEntorno.DataSource = EntornoFormativoBLL.ObtenerTipoEntornos();
            cmbTipoEntorno.DisplayMember = "Nombre";
            cmbTipoEntorno.ValueMember = "IdTipoEntorno";
        }
   

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EntornoFormativo entorno = new EntornoFormativo
                {
                    Nombre = txtNombreEntorno.Text,
                    IdTipoEntorno = (int)cmbTipoEntorno.SelectedValue,
                    Responsable = txtProfesorResponsable.Text,
                    Año = txtAño.Text,
                    Division = txtDivision.Text,
                    Grupo = txtGrupo.Text,
                    Fecha = dtpFecha.Value,
                    Observaciones = txtObservacion.Text
                };

                entornoBLL.Guardar(entorno);
                CargarEntornos();
                LimpiarCampos();

                // 🔹 Enviar mensaje de urgencia si está marcado
                if (chkUrgencia.Checked)
                {
                    string mensaje = $"🚨 URGENCIA - El entorno de {entorno.Nombre}  ( Del Grupo {entorno.Grupo} Division {entorno.Division}) -  Tiene las siguientes observaciones : {entorno.Observaciones}";
                    UrgenciaBLL urgenciaBLL = new UrgenciaBLL();
                    urgenciaBLL.Agregar(mensaje);

                    MessageBox.Show("Se registró una urgencia. El mensaje estará disponible durante el día.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar entorno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dtgEntorno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgEntorno.Rows[e.RowIndex];
                txtNombreEntorno.Text = row.Cells["Nombre"].Value.ToString();
                cmbTipoEntorno.Text = row.Cells["IdTipoEntorno"].Value.ToString();
                txtProfesorResponsable.Text = row.Cells["Responsable"].Value.ToString();
                txtAño.Text = row.Cells["Año"].Value.ToString();
                txtDivision.Text = row.Cells["Division"].Value.ToString();
                txtGrupo.Text = row.Cells["Grupo"].Value.ToString();
                dtpFecha.Text = row.Cells["Fecha"].Value.ToString();
                txtObservacion.Text = row.Cells["Observaciones"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreEntorno.Clear();
            cmbTipoEntorno.SelectedIndex = -1;
            txtProfesorResponsable.Clear();
            txtAño.Clear();
            txtDivision.Clear();
            txtGrupo.Clear();
            txtObservacion.Clear();
        }

        private void txtBuscarEntorno_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarEntorno.Text.Trim().ToLower();
            var lista = entornoBLL.ObtenerEntornos();

            if (!string.IsNullOrEmpty(filtro))
                lista = lista.Where(x => x.IdTipoEntorno.ToLower().Contains(filtro)).ToList();

            dtgEntorno.DataSource = lista;
        }

        private void PanelDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgEntorno.CurrentRow != null)
            {
                try
                {
                    var entorno = new EntornoFormativo
                    {
                        IdEntorno = Convert.ToInt32(dtgEntorno.CurrentRow.Cells["IdEntorno"].Value),
                        Nombre = txtNombreEntorno.Text,
                        IdTipoEntorno = Convert.ToInt32(cmbTipoEntorno.SelectedValue),
                        Responsable = txtProfesorResponsable.Text,
                        Año = txtAño.Text,
                        Division = txtDivision.Text,
                        Grupo = txtGrupo.Text,
                        Fecha = dtpFecha.Value,
                        Observaciones = txtObservacion.Text
                    };

                    EntornoFormativoBLL.ModificarEntorno(entorno);

                    MessageBox.Show("Registro modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarEntornos(); // refresca la grilla
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgEntorno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
