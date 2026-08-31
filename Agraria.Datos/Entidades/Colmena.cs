using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class Colmena
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int CantidadColmenas { get; set; }
        public DateTime? FechaIngresoColmenas { get; set; }
        public int CantidadMiel { get; set; }
        public DateTime? FechaIngresoMiel { get; set; }
        public int CantidadRetiradas { get; set; }
        public DateTime? FechaRetiradas { get; set; }
        public bool Estado { get; set; }
    }
}
