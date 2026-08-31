using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Agraria.Datos.DAL;
using global::Agraria.Datos.Entidades;

    namespace Agraria.Negocio.BLL
    {
        public class TabConfigBLL
        {
            public List<TabConfig> ObtenerTabs()
            {
                return TabConfigDAL.CargarTabs();
            }

            public void GuardarTabs(List<TabConfig> tabs)
            {
                TabConfigDAL.GuardarTabs(tabs);
            }
        public List<TabConfig> ObtenerTabs(string archivo = "tabs.json")
        {
            return TabConfigDAL.CargarTabs(archivo);
        }

        public void GuardarTabs(List<TabConfig> tabs, string archivo = "tabs.json")
        {
            TabConfigDAL.GuardarTabs(tabs, archivo);
        }
    }
    }


