using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Entidades
{
    public class Leche
    {
        public int IdLeche { get; set; }
        public string Nombre { get; set; }
        public string NumeroAnimal { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaOrdeñe { get; set; }
        public decimal? LitrosLeche { get; set; }
        public DateTime? FechaFallecido { get; set; }
        public bool Estado { get; set; }
    }
}
