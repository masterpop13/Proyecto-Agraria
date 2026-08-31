using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class Aves
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int CantidadAves { get; set; }
        public DateTime? FechaIngresoAves { get; set; }
        public int CantidadHuevos { get; set; }
        public DateTime? FechaIngresoHuevos { get; set; }
        public int CantidadRetiradas { get; set; }
        public DateTime? FechaRetiradas { get; set; }
    }
}
