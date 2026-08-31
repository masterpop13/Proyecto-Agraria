using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Entidades
{
    public class RegistroCompra
    {
        public int IdRegistro { get; set; }
        public int IdNumeroFactura { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }     // suma sin descuento
        public decimal Descuento { get; set; }  // porcentaje 0..100
        public decimal Total { get; set; }      // ya con descuento aplicado
    }
}