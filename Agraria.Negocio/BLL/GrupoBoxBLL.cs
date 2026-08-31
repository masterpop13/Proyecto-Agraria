using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.Entidades;

namespace Agraria.Negocio.BLL
{
    public class GrupoBoxBLL
    {
        public void Guardar(List<GrupoBoxInfo> lista)
        {
            GrupoBoxDAL.Guardar(lista);
        }

        public List<GrupoBoxInfo> ObtenerTodos()
        {
            return GrupoBoxDAL.Cargar();
        }
    }
}
