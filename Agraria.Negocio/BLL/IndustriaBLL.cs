using Agraria.Datos;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class IndustriaBLL
    {
        public void GuardarIndustria(Industria entidad)
        {
            IndustriaDAL.InsertarIndustria(entidad);
        }

        public List<IndustriaDTO> ListarIndustria()
        {
            return IndustriaDAL.ObtenerRegistrosIndustria();
        }


    }
}
