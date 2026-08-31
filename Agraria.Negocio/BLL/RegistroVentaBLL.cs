using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos;
using Agraria.Datos.DTO;
using Agraria.Entidades;

namespace Agraria.Negocio.BLL
{
    public class RegistroVentaBLL
    {
        private readonly RegistroVentaDAL dal = new RegistroVentaDAL();

        public List<ProductoVentaDTO> ListarProductosVenta(string filtroNombre = "")
            => dal.ListarProductosVenta(filtroNombre);

        public void GuardarVenta(RegistroCompra cab, List<DetalleCompra> detalles)
            => dal.InsertarRegistroCompra(cab, detalles);

        public List<RegistroCompraDTO> ListarRegistroCompras(DateTime? desde, DateTime? hasta)
            => dal.ListarRegistroCompras(desde, hasta);

        public List<DetalleCompraDTO> ListarDetallePorFactura(int idNumeroFactura)
            => dal.ListarDetallePorFactura(idNumeroFactura);
    }
}
