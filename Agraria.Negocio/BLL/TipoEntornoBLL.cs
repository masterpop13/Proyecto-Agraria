using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;


namespace Agraria.Negocio.BLL
{

    public class TipoEntornoBLL
    {
        public List<TipoEntornoDTO> Listar()
        {
            return TipoEntornoDAL.Listar();
        }
    }
}
