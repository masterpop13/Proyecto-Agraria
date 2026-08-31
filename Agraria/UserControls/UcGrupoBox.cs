using Agraria.Datos.Entidades;
using Agraria.Helpers;
using Agraria.Negocio.BLL;
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

namespace Agraria.UserControls
    {
    public partial class UcGrupoBox : UserControl
    {
        private readonly string _nombrePagina;
        private readonly VegetalesBLL _bll = new VegetalesBLL();
        private System.Windows.Forms.Timer timerActualizacion;
        public string NombrePagina => _nombrePagina;


        public UcGrupoBox(string nombrePagina)
        {
            InitializeComponent();
            _nombrePagina = nombrePagina ?? string.Empty;
            _nombrePagina = string.Empty;
            // Dejalo listo para apilarlo en PanelDeGrupoBox
            this.Dock = DockStyle.Top;

            ActualizarIndicadores();
            timerActualizacion = new System.Windows.Forms.Timer();
            timerActualizacion.Interval = 3000; // cada 3 segundos
            timerActualizacion.Tick += (s, e) => ActualizarIndicadores();
            timerActualizacion.Start();

            this._nombrePagina = nombrePagina;

            CargarImagenGuardada();

        }


        private void UcGrupoBox_Load(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
            // Mostrar nombre de la página en el título del GroupBox
            gpbDatos.Text = string.IsNullOrWhiteSpace(_nombrePagina)
                ? "Datos Vegetales"
                : $"Datos Vegetales - {_nombrePagina}";

            ActualizarIndicadores();

            txtActualCosechados.Enabled = false;
            txtCantidadPlantines.Enabled = false;
        }

        /// <summary>
        /// Actualiza los contadores desde BLL, filtrando por el nombre de la página.
        /// - txtCantidadPlantines  => suma activa de CantidadPlantines
        /// - txtActualCosechados   => suma activa de Cantidad (cosechada)
        /// </summary>
        public void ActualizarIndicadores()
        {
            try
            {
                int plantines = _bll.ObtenerPlantinesActivosPorNombre(_nombrePagina);
                int cantidad = _bll.ObtenerCantidadActivaPorNombre(_nombrePagina);

                txtCantidadPlantines.Text = plantines.ToString();
                txtActualCosechados.Text = cantidad.ToString();
            }
            catch (Exception ex)
            {
                // No rompas la UI por un error de DB; mostramos info básica
                txtCantidadPlantines.Text = "0";
                txtActualCosechados.Text = "0";
#if DEBUG
                MessageBox.Show("Error al actualizar indicadores: " + ex.Message, "UcGrupoBox", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
            }
        }

        private void btnCambiarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string carpeta = Path.Combine(Application.StartupPath, "ImagenesGrupoBox");
                    Directory.CreateDirectory(carpeta);

                    string destino = Path.Combine(carpeta, $"{_nombrePagina}.jpg");
                    File.Copy(ofd.FileName, destino, true);

                    pbCambiarImagen.Image = Image.FromFile(destino);
                }
            }
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (pbCambiarImagen.Image == null)
                {
                    MessageBox.Show("No hay ninguna imagen para quitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string carpeta = Path.Combine(Application.StartupPath, "ImagenesGrupoBox");
                string destino = Path.Combine(carpeta, $"{_nombrePagina}.jpg");

                // Eliminar la imagen del PictureBox
                pbCambiarImagen.Image.Dispose();
                pbCambiarImagen.Image = null;

                // Eliminar el archivo físico si existe
                if (File.Exists(destino))
                {
                    File.Delete(destino);
                }

                MessageBox.Show("Imagen eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al quitar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void CargarImagenGuardada()
        {
            string ruta = Path.Combine(Application.StartupPath, "ImagenesGrupoBox", $"{_nombrePagina}.jpg");
            if (File.Exists(ruta))
            {
                pbCambiarImagen.Image = Image.FromFile(ruta);
            }
        }

        private void gpbDatos_Enter(object sender, EventArgs e)
        {

        }
    }
}

