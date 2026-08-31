using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class EntornoFormativoBLL
    {
        private EntornoFormativoDAL dal = new EntornoFormativoDAL();

        public List<EntornoFormativoDTO> ObtenerEntornos()
        {
            return dal.ObtenerEntornos();
        }

        public void Guardar(EntornoFormativo entorno)
        {
            dal.Insertar(entorno);
        }
        public static void ModificarEntorno(EntornoFormativo entorno)
        {
            EntornoFormativoDAL.Modificar(entorno);
        }

        public static DataTable ObtenerTipoEntornos()
        {
            return EntornoFormativoDAL.ObtenerTipoEntornos();
        }
    }
}
