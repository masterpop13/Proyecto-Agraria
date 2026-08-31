using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using Agraria.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Formularios
{
    public partial class ProduccionVegetal : Form
    {
        private readonly ProduccionVegetalBLL _bll = new ProduccionVegetalBLL();
        
        private TabConfigBLL tabConfigBLL = new TabConfigBLL();
        private List<TabConfig> tabsPersistidos = new List<TabConfig>();
        private readonly UsuarioLoginDTO _usuarioLogeado;
        private readonly bool _esInvitado;

        public ProduccionVegetal(UsuarioLoginDTO usuarioLogeado, bool esInvitado)
        {
            InitializeComponent();
            _usuarioLogeado = usuarioLogeado;
            _esInvitado = esInvitado;
        }

        private void ProduccionVegetal_Load(object sender, EventArgs e)
        {

            ResolutionAdapter.AdaptMdiChild(this);
            // 🔹 Cargar las páginas guardadas previamente
            tabsPersistidos = tabConfigBLL.ObtenerTabs();

            foreach (var tab in tabsPersistidos)
            {
                CrearPagina(tab.Nombre, tab.TipoUserControl);
            }

            if (_esInvitado)
            {
                DeshabilitarControles();

                // 🔹 Si usás UserControls dinámicos, desactivalos también:
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is UcVegetales uc)
                    {
                        uc.DeshabilitarControlesInternos();
                    }
                }
            }


        }

        public ProduccionVegetal(bool invitado = false)
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

        // 🔹 Botón para agregar nueva página
        private void btnAgregarPagina_Click(object sender, EventArgs e)
        {
            using (var frm = new Agraria.UserControls.FrmSeleccionUC())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string nombre = frm.PageTitle;
                    string tipoUC = frm.ControlSeleccionado;

                    // Crear la página y su GrupoBox asociado
                    CrearPagina(nombre, tipoUC);

                    // Guardar en lista y persistir
                    tabsPersistidos.Add(new TabConfig { Nombre = nombre, TipoUserControl = tipoUC });
                    tabConfigBLL.GuardarTabs(tabsPersistidos);
                }
            }
        }

        // 🔹 Botón para quitar página y su grupo asociado
        private void btnQuitarPagina_Click(object sender, EventArgs e)
        {
            if (tbVegetales.SelectedTab != null)
            {
                var tab = tbVegetales.SelectedTab;
                string nombre = tab.Text;

                // 🔸 Quitar del TabControl
                tbVegetales.TabPages.Remove(tab);

                // 🔸 Quitar de la lista persistida
                tabsPersistidos.RemoveAll(t => t.Nombre == nombre);
                tabConfigBLL.GuardarTabs(tabsPersistidos);

                // 🔸 Eliminar el UcGrupoBox asociado
                var controlAEliminar = PanelDeGrupoBox.Controls
                    .OfType<UcGrupoBox>()
                    .FirstOrDefault(c => c.NombrePagina.Equals(nombre, StringComparison.OrdinalIgnoreCase));

                if (controlAEliminar != null)
                {
                    PanelDeGrupoBox.Controls.Remove(controlAEliminar);
                    controlAEliminar.Dispose();
                }

                PanelDeGrupoBox.Refresh();
            }
        }

        // 🔹 Crear página + agregar control visual + agregar UcGrupoBox correspondiente
        private void CrearPagina(string nombre, string tipoUC)
        {
            TabPage page = new TabPage(nombre);
            UserControl? uc = null; // ✅ nullable permitido

            switch (tipoUC)
            {
                case "Solo Vegetales":
                    uc = new UcVegetales(nombre, _usuarioLogeado);
                    PanelDeGrupoBox.Controls.Add(new UcGrupoBox(nombre) { Dock = DockStyle.Top });
                    break;

            }

            if (uc != null)
            {
                uc.Dock = DockStyle.Fill;
                page.Controls.Add(uc);
                tbVegetales.TabPages.Add(page);
            }
        }


        // 🔹 Guardar automáticamente al cerrar
        private void ProduccionVegetal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabsPersistidos != null && tabsPersistidos.Count > 0)
            {
                tabConfigBLL.GuardarTabs(tabsPersistidos);
            }
        }
    }
}
