using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.DTO
{
    public class LecheDTO
    {
        [DisplayName("Codigo de Registro")]
        public int IdLeche { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Numero de Animal")]
        public string NumeroAnimal { get; set; }
        public string Sexo { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime? FechaIngreso { get; set; }
        [DisplayName("Numero de Ordeñe")]
        public DateTime? FechaOrdeñe { get; set; }
        [DisplayName("Litros de Leche")]
        public decimal? LitrosLeche { get; set; }
        [DisplayName("Fecha Animal Fallecido")]
        public DateTime? FechaFallecido { get; set; }
        public bool Estado { get; set; }
    }
}
