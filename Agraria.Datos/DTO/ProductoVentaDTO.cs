using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class ProductoVentaDTO
    {
        [Browsable(false)]
        public int IdProducto { get; set; }

        [DisplayName("Numero del Producto")]
        public string NombreProducto { get; set; }
        [DisplayName("Precio Unitario")]
        public decimal PrecioUnitario { get; set; }
        [DisplayName("Stock Disponible")]
        public int StockDisponible { get; set; } // SUM(Industria.CantidadProduccion) > 0
    }
}