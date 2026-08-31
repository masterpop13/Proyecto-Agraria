using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class DetalleCompraDTO
    {
        [Browsable(false)]
        public int IdDetalle { get; set; }

        [DisplayName("Numero de Factura")]
        public int IdNumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        [DisplayName(" Codigo del Producto")]
        [Browsable(false)]
        public int IdProducto { get; set; }
        [DisplayName("Nombre del Producto")]
        public string NombreProducto { get; set; }
        [DisplayName("Precio Unitario")]
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
    }
}
