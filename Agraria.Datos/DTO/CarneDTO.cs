using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class CarneDTO
    {
        [DisplayName("Codigo de Registro")]
        public int IdCarne { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Numero de Box")]
        public string NombreBox { get; set; }
        [DisplayName("Numero de Animal")]
        public string NumeroAnimal { get; set; }
        public string Sexo { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime? FechaIngreso { get; set; }
        [DisplayName("Numero de Retiro")]
        public DateTime? FechaRetiro { get; set; }

        [DisplayName("Fecha de Envio a Industria")]
        public DateTime? FechaEnvioIndustria { get; set; }
        public bool Estado { get; set; }
    }
}


