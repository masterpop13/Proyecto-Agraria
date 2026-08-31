using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class TipoMedidaBLL
    {
        public List<TipoMedidaDTO> Listar()
        {
            return TipoMedidaDAL.Listar();
        }
    }
}
