using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Entidades
{
    public class RegistroFertilidadLeche
    {
        public int IdRegistro { get; set; }
        public string Nombre { get; set; }
        public string NumeroMadre { get; set; }
        public string NumeroPadre { get; set; }
        public DateTime? FechaMonta { get; set; }
        public DateTime? FechaParto { get; set; }
        public int IdTipo { get; set; }
        public int CantidadHembras { get; set; }
        public int CantidadMachos { get; set; }
        public int TotalNacidos { get; set; }
        public bool Estado { get; set; }
    }
}
