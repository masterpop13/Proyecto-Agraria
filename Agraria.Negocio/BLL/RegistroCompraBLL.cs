using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;

namespace Agraria.Negocio.BLL
{
    public class RegistroCompraBLL
    {
        public List<RegistroCompraDTO> ObtenerRegistros(DateTime? desde = null, DateTime? hasta = null)
        {
            return RegistroCompraDAL.ObtenerRegistros(desde, hasta);
        }

        public List<DetalleCompraDTO> ObtenerDetalles(int idFactura)
        {
            return RegistroCompraDAL.ObtenerDetallesPorFactura(idFactura);
        }
    }
}
