using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class RegistroCompraDTO
    {
        [Browsable(false)]
        public int IdRegistro { get; set; }

        [DisplayName("Numero de Factura")]
        public int IdNumeroFactura { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}