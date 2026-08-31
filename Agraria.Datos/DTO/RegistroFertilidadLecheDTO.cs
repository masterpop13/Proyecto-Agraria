using System;
using System.ComponentModel;

namespace Agraria.Datos.DTO
{
    public class RegistroFertilidadLecheDTO
    {
        [DisplayName("Código de Registro")]
        public int IdRegistro { get; set; }

        public string Nombre { get; set; }

        [DisplayName("Número de Madre")]
        public string NumeroMadre { get; set; }

        [DisplayName("Número de Padre")]
        public string NumeroPadre { get; set; }

        [DisplayName("Fecha de Monta")]
        public DateTime? FechaMonta { get; set; }

        [DisplayName("Fecha de Parto")]
        public DateTime? FechaParto { get; set; }

        [DisplayName("Tipo de Animal")]
        public string TipoAnimal { get; set; }

        [DisplayName("Nacimientos Hembras")]
        public int CantidadHembras { get; set; }

        [DisplayName("Nacimientos Machos")]
        public int CantidadMachos { get; set; }

        [DisplayName("Total Nacidos")]
        public int TotalNacidos { get; set; }

        public bool Estado { get; set; }
    }
}
