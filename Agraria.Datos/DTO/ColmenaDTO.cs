using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Agraria.Datos.DTO
{
    public class ColmenaDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = "";

        [DisplayName("Cant. Colmenas")]
        public int CantidadColmenas { get; set; }

        [DisplayName("F.Ingreso Colmenas")]
        public DateTime? FechaIngresoColmenas { get; set; }

        [DisplayName("Cant. Miel")]
        public int CantidadMiel { get; set; }

        [DisplayName("F.Ingreso Miel")]
        public DateTime? FechaIngresoMiel { get; set; }

        [DisplayName("Retiradas")]
        public int CantidadRetiradas { get; set; }

        [DisplayName("F.Retiro")]
        public DateTime? FechaRetiradas { get; set; }

        [DisplayName("Estado")]
        public bool Estado { get; set; }
    }
}
