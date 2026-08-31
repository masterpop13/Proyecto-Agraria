using System.Collections.Generic;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;

namespace Agraria.Negocio.BLL
{
    public class BoxCarneBLL
    {
        public List<BoxCarneDTO> ListarBoxes()
        {
            return BoxCarneDAL.ListarBoxes();
        }
    }
}
