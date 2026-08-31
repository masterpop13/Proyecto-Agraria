using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class Vegetales
    {
        public int IdProduccion { get; set; }
        public string Nombre { get; set; }   // 🔹 Nuevo
        public int CantidadPlantines { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCultivo { get; set; }
        public DateTime FechaCosecha { get; set; }
        public bool Estado { get; set; }
    }
}
