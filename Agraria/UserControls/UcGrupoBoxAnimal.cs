using Agraria.Helpers;
using Agraria.Negocio.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agraria.UserControls
{
    public partial class UcGrupoBoxAnimal : UserControl
    {
        private readonly string _nombrePagina;

        private readonly ColmenasBLL _bllColmenas = new ColmenasBLL();
        private readonly CarneBLL _bllCarne = new CarneBLL();
        private readonly EngordeBLL _bllEngorde = new EngordeBLL();
        private readonly LecheBLL _bllLeche = new LecheBLL();
        private readonly AvesBLL _bllHuevos = new AvesBLL();

        private System.Windows.Forms.Timer timerActualizacion;

        public string NombrePagina => _nombrePagina;

        public UcGrupoBoxAnimal(string nombrePagina)
        {
            InitializeComponent();
            _nombrePagina = nombrePagina ?? string.Empty;

            this.Dock = DockStyle.Top;

            // Título inicial (se ajusta de nuevo en cada actualización)
            gpbDatos.Text = $"Datos - {_nombrePagina}";

            // Timer cada 3s
            timerActualizacion = new System.Windows.Forms.Timer();
            timerActualizacion.Interval = 3000;
            timerActualizacion.Tick += (s, e) => ActualizarIndicadores();
            timerActualizacion.Start();

            // Imagen por página si existe
            CargarImagenGuardada();

            // Primer refresco
            ActualizarIndicadores();
        }

        private void UcGrupoBoxAnimal_Load(object sender, EventArgs e)
        {

            ActualizarIndicadores();
        }

        // ===========================================================
        //  Detecta el tipo de sección por el título de la pestaña
        //  (tolerante a acentos, plurales y errores comunes)
        // ===========================================================
        private enum TipoSeccion { Colmenas, Carne, Engorde, Leche, Huevos }

        private static string Normalizar(string input)
        {
            if (input == null) return string.Empty;
            string s = input.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(s.Length);
            foreach (var ch in s)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString();
        }

        private static TipoSeccion DetectarTipoPorNombre(string nombrePagina)
        {
            string s = Normalizar(nombrePagina);

            // Colmenas (cubrir "abeja" y error "aveja")
            if (s.Contains("colmena") || s.Contains("abeja") || s.Contains("aveja"))
                return TipoSeccion.Colmenas;

            // Leche / Ordeñe
            if (s.Contains("leche") || s.Contains("ordene") || s.Contains("ordene") /*variantes*/)
                return TipoSeccion.Leche;

            // Engorde / Pollos
            if (s.Contains("engorde") || s.Contains("pollo") || s.Contains("pollos") || s.Contains("broiler"))
                return TipoSeccion.Engorde;

            // Carne / Bovino / Cerdo
            if (s.Contains("carne") || s.Contains("cerdo") || s.Contains("cerdos") ||
                s.Contains("bovino") || s.Contains("vaca") || s.Contains("novillo") || s.Contains("ternero"))
                return TipoSeccion.Carne;

            // Huevos / Aves / Gallinas (default animal)
            if (s.Contains("huevo") || s.Contains("huevos") || s.Contains("aves") ||
                s.Contains("gallina") || s.Contains("gallinas"))
                return TipoSeccion.Huevos;

            // Fallback razonable: Huevos/Aves
            return TipoSeccion.Huevos;
        }

        // ===========================================================
        //  ACTUALIZA LOS DATOS SEGÚN TIPO (usando _nombrePagina)
        // ===========================================================
        private void ActualizarIndicadores()
        {
            try
            {
                // Limpiar y resetear visibilidad en cada actualización
                txtCantidadActual.Text = "0";
                txtCantidadProducida.Text = "0";
                txtCantidadProducida.Visible = true;
                lblActualCosechados.Visible = true;

                var tipo = DetectarTipoPorNombre(_nombrePagina);

                switch (tipo)
                {
                    case TipoSeccion.Colmenas:
                        {
                            // Colmenas: actual = Colmenas activas, producida = Miel (Kg)
                            var c = _bllColmenas.TotalesColmenas(_nombrePagina); // (int colmenas, int miel)
                            txtCantidadActual.Text = c.colmenas.ToString();
                            txtCantidadProducida.Text = c.miel.ToString();

                            gpbDatos.Text = $"Datos Colmenas - {_nombrePagina}";
                            lblCantidadAtados.Text = "Colmenas Activas";
                            lblActualCosechados.Text = "Miel (Kg)";
                            break;
                        }

                    case TipoSeccion.Carne:
                        {
                            // Carne: actual = animales activos (Estado=true)
                            var carne = _bllCarne.TotalesCarne(_nombrePagina);   // (int total, decimal producido) si tu DAL/BLL lo exponen
                            txtCantidadActual.Text = carne.total.ToString();

                            gpbDatos.Text = $"Datos Carne - {_nombrePagina}";
                            lblCantidadAtados.Text = "Animales Activos";
                            // ocultar producido si no lo usás
                            txtCantidadProducida.Visible = false;
                            lblActualCosechados.Visible = false;
                            break;
                        }

                    case TipoSeccion.Engorde:
                        {
                            // Engorde: actual = Cantidad con FechaIngreso (Estado=true)
                            //          producida = Cantidad con FechaActualizado (Estado=true)
                            var e = _bllEngorde.TotalesEngorde(_nombrePagina);   // (int total, decimal producido)
                            txtCantidadActual.Text = e.total.ToString();
                            txtCantidadProducida.Text = e.producido.ToString("0.##");

                            gpbDatos.Text = $"Datos Engorde - {_nombrePagina}";
                            lblCantidadAtados.Text = "Animales en Engorde";
                            lblActualCosechados.Text = "Producido";
                            break;
                        }

                    case TipoSeccion.Leche:
                        {
                            // Leche: actual = animales activos (Estado=true)
                            //        producida = litros (sum LitrosLeche Estado=true)
                            var l = _bllLeche.TotalesLeche(_nombrePagina);       // (int total, decimal litros)
                            txtCantidadActual.Text = l.total.ToString();
                            txtCantidadProducida.Text = l.litros.ToString("0.00");

                            gpbDatos.Text = $"Datos Leche - {_nombrePagina}";
                            lblCantidadAtados.Text = "Animales Activos";
                            lblActualCosechados.Text = "Litros Producidos";
                            break;
                        }

                    case TipoSeccion.Huevos:
                    default:
                        {
                            // Huevos: actual = CantidadAves (Estado=true)
                            //         producida = CantidadHuevos (Estado=true)
                            var h = _bllHuevos.TotalesHuevos(_nombrePagina);     // (int total, int huevos)
                            txtCantidadActual.Text = h.total.ToString();
                            txtCantidadProducida.Text = h.huevos.ToString();

                            gpbDatos.Text = $"Datos Aves - {_nombrePagina}";
                            lblCantidadAtados.Text = "Aves Activas";
                            lblActualCosechados.Text = "Huevos";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show("Error al actualizar indicadores: " + ex.Message,
                                "UcGrupoBoxAnimal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
                txtCantidadActual.Text = "0";
                txtCantidadProducida.Text = "0";
                // por si quedó oculto de un render previo
                txtCantidadProducida.Visible = true;
                lblActualCosechados.Visible = true;
            }
        }

        // ===========================================================
        //  Imagen por página
        // ===========================================================
        private void btnCambiarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string carpeta = Path.Combine(Application.StartupPath, "ImagenesGrupoBoxAnimal");
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

                string carpeta = Path.Combine(Application.StartupPath, "ImagenesGrupoBoxAnimal");
                string destino = Path.Combine(carpeta, $"{_nombrePagina}.jpg");

                pbCambiarImagen.Image.Dispose();
                pbCambiarImagen.Image = null;

                if (File.Exists(destino))
                    File.Delete(destino);

                MessageBox.Show("Imagen eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al quitar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarImagenGuardada()
        {
            string ruta = Path.Combine(Application.StartupPath, "ImagenesGrupoBoxAnimal", $"{_nombrePagina}.jpg");
            if (File.Exists(ruta))
            {
                pbCambiarImagen.Image = Image.FromFile(ruta);
            }
        }

        private void UcGrupoBoxAnimal_Load_1(object sender, EventArgs e)
        {
            ResolutionAdapter2.AdaptUserControl(this);
        }
    }
}
