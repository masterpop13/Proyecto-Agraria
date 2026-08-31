using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Agraria.Datos.DTO
{
    public class AvesDTO
    {
        [DisplayName("Codigo Registro")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = "";

        [DisplayName("Cant. Aves")]
        public int CantidadAves { get; set; }

        [DisplayName("F. Ingreso Aves")]
        public DateTime? FechaIngresoAves { get; set; }

        [DisplayName("Huevos")]
        public int CantidadHuevos { get; set; }

        [DisplayName("F. Ingreso Huevos")]
        public DateTime? FechaIngresoHuevos { get; set; }

        [DisplayName("Retiradas")]
        public int CantidadRetiradas { get; set; }

        [DisplayName("F. Retiradas")]
        public DateTime? FechaRetiradas { get; set; }

        public bool Estado { get; set; }

    }
}
