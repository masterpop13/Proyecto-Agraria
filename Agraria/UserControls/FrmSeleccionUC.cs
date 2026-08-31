using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UserControls
{
    public partial class FrmSeleccionUC : Form
    {
        public string ControlSeleccionado { get; private set; } // "UcVentas", "UcProduccion", "UcReportes"
        public string PageTitle { get; private set; }            // Título que escribe el usuario

        public FrmSeleccionUC()
        {
            InitializeComponent();
        }

        private void cmbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOpciones.SelectedItem != null)
            {
                // Si el usuario no escribió un título aún, autocompletar con el tipo seleccionado
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) || (txtTitulo.Tag as string) == "autofill")
                {
                    txtTitulo.Tag = "autofill";
                    txtTitulo.Text = cmbOpciones.SelectedItem.ToString();
                }
            }
        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            // Si el usuario escribe manualmente, quitar la marca de autofill
            txtTitulo.Tag = null;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbOpciones.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de página.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Ingrese un nombre para la página.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ControlSeleccionado = cmbOpciones.SelectedItem.ToString();
            PageTitle = txtTitulo.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmSeleccionUC_Load(object sender, EventArgs e)
        {
            // Limpiar cualquier valor anterior
            cmbOpciones.Items.Clear();

            // Agregá aquí las opciones que querés mostrar en el combo
            cmbOpciones.Items.Add("Solo Vegetales");
            cmbOpciones.Items.Add("Aves Productoras de Huevos");
            cmbOpciones.Items.Add("Productores de Miel");
            cmbOpciones.Items.Add("Aves para Engorde");
            cmbOpciones.Items.Add("Productores de Leche");
            cmbOpciones.Items.Add("Productores de Carne");

            cmbOpciones.SelectedIndex = -1; // Nada seleccionado por defecto
        }
    }
}