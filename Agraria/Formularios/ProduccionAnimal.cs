using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Helpers;
using Agraria.Negocio.BLL;
using Agraria.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class ProduccionAnimal : Form
    {

        private readonly TabConfigBLL tabConfigBLL = new TabConfigBLL();
        private List<TabConfig> tabsPersistidos = new List<TabConfig>();
        private readonly string archivoPersistencia = "tabs_animales.json"; // archivo independiente

        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;

        public ProduccionAnimal(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;

        }



        private void ProduccionAnimal_Load(object sender, EventArgs e)
        {

            ResolutionAdapter.AdaptMdiChild(this);
            // 🔹 Cargar pestañas guardadas
            tabsPersistidos = tabConfigBLL.ObtenerTabs(archivoPersistencia);

            foreach (var tab in tabsPersistidos)
            {
                CrearPagina(tab.Nombre, tab.TipoUserControl);
            }
            if (_esInvitado)
            {
                DeshabilitarControles();

                // 🔹 Deshabilita automáticamente todos los UserControls relevantes
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is UcVegetales ucVegetales)
                        ucVegetales.DeshabilitarControlesInternos();

                    else if (ctrl is UcCarne ucCarne)
                        ucCarne.DeshabilitarControlesInternos();

                    else if (ctrl is UcColmenas ucColmenas)
                        ucColmenas.DeshabilitarControlesInternos();

                    else if (ctrl is UcEngorde ucEngorde)
                        ucEngorde.DeshabilitarControlesInternos();

                    else if (ctrl is UcHuevos ucHuevos)
                        ucHuevos.DeshabilitarControlesInternos();

                    else if (ctrl is UcLeche ucLeche)
                        ucLeche.DeshabilitarControlesInternos();
                }
            }




        }

        public ProduccionAnimal(bool invitado = false)
        {
            InitializeComponent();
            _esInvitado = invitado;

            if (_esInvitado)
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

        private void BloquearControlesSoloLectura(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                    txt.ReadOnly = true;
                else if (ctrl is Button btn)
                    btn.Enabled = false;
                else if (ctrl is ComboBox cmb)
                    cmb.Enabled = false;
                else if (ctrl is DataGridView dgv)
                    dgv.ReadOnly = true;

                // 🔁 Si el control tiene hijos, entrar recursivamente
                if (ctrl.HasChildren)
                    BloquearControlesSoloLectura(ctrl);
            }
        }

        // =====================================================
        // 🔹 BOTÓN AGREGAR PÁGINA
        // =====================================================
        private void btnAgregarPagina_Click(object sender, EventArgs e)
        {
            using (var frm = new Agraria.UserControls.FrmSeleccionUC())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string nombre = frm.PageTitle;
                    string tipoUC = frm.ControlSeleccionado;

                    CrearPagina(nombre, tipoUC);

                    // Guardar configuración
                    tabsPersistidos.Add(new TabConfig { Nombre = nombre, TipoUserControl = tipoUC });
                    tabConfigBLL.GuardarTabs(tabsPersistidos, archivoPersistencia);
                }
            }
        }

        // =====================================================
        // 🔹 BOTÓN QUITAR PÁGINA
        // =====================================================
        private void btnQuitarPagina_Click(object sender, EventArgs e)
        {
            if (tbcDatosAnimales.SelectedTab != null)
            {
                var tab = tbcDatosAnimales.SelectedTab;
                string nombre = tab.Text;

                // Quitar del TabControl
                tbcDatosAnimales.TabPages.Remove(tab);

                // Quitar de la lista
                tabsPersistidos.RemoveAll(t => t.Nombre == nombre);
                tabConfigBLL.GuardarTabs(tabsPersistidos, archivoPersistencia);

                // 👇 Ya NO hay UcGrupoBoxAnimal que quitar del panel, así que no hacemos nada más aquí.
            }
        }

        // =====================================================
        // 🔹 CREAR NUEVA PÁGINA (sin UcGrupoBoxAnimal)
        // =====================================================
        private void CrearPagina(string nombre, string tipoUC)
        {
            TabPage page = new TabPage(nombre);
            UserControl uc = null;

            switch (tipoUC)
            {
                case "Aves Productoras de Huevos":
                    uc = new UcHuevos(nombre, _usuarioLogeado);
                    break;

                case "Productores de Miel":
                    uc = new UcColmenas(nombre, _usuarioLogeado);
                    break;

                case "Aves para Engorde":
                    uc = new UcEngorde(nombre, _usuarioLogeado);
                    break;

                case "Productores de Leche":
                    uc = new UcLeche(nombre, _usuarioLogeado);
                    break;

                case "Productores de Carne":
                    uc = new UcCarne(nombre, _usuarioLogeado);
                    break;

                    // Si agregás más UCs en el futuro, continuá el switch.
            }

            if (uc != null)
            {
                uc.Dock = DockStyle.Fill;
                page.Controls.Add(uc);
                tbcDatosAnimales.TabPages.Add(page);
            }
        }
    }
}
