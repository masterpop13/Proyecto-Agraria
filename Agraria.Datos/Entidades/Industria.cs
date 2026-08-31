using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class Industria
    {
        public int IdRegistroIndustria { get; set; }
        public int IdIndustria { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProduccion { get; set; }
        public DateTime FechaProduccion { get; set; }
        public int IdInsumos { get; set; }
        public int CantidadInsumos { get; set; }
    }
}
