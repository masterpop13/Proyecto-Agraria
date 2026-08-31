using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Agraria.Datos.DAL;

namespace Agraria.Negocio.BLL
{
    public class TipoAnimalBLL
    {
        public DataTable Listar()
        {
            return TipoAnimalDAL.Listar();
        }
    }
}
