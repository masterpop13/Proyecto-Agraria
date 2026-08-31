using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class RegistroFertilidadCarneDTO
    {
        [DisplayName("Codigo Registro")]
        public int IdRegistro { get; set; }
        [DisplayName("Numero de Madre")]
        public string NumeroMadre { get; set; }
        [DisplayName("Numero de Padre")]
        public string NumeroPadre { get; set; }
        [DisplayName("Fecha de Monta")]
        public DateTime? FechaMonta { get; set; }
        [DisplayName("Fecha de Parto")]
        public DateTime? FechaParto { get; set; }
        [DisplayName("Hembras Nacidas")]
        public int CantidadHembras { get; set; }
        [DisplayName("Machos Nacidos")]
        public int CantidadMachos { get; set; }
        [DisplayName("Total de Nacidos")]
        public int TotalNacidos { get; set; }
        public bool Estado { get; set; }
    }
}
