using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Agraria.Datos.Entidades
{
    public class Engorde
    {
        public int IdEngorde { get; set; }
        public int IdBox { get; set; }
        public string Nombre { get; set; } = "";
        public DateTime? FechaIngreso { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaActualizado { get; set; }
        public int Semanas { get; set; }
        public decimal Peso { get; set; }
        public int IdAlimento { get; set; }
        public decimal AlimentoPorDia { get; set; }
        public bool Estado { get; set; }
    }
}
