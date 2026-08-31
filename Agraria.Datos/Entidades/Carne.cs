using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class Carne
    {
        public int IdCarne { get; set; }
        public string Nombre { get; set; }
        public int IdBoxCarne { get; set; }
        public string NumeroAnimal { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public DateTime? FechaEnvioIndustria { get; set; }
        public bool Estado { get; set; }
    }
}
