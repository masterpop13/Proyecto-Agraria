using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Agraria.Datos.DTO
{
    public class EngordeDTO
    {
        [DisplayName("Codigo Registro")]
        public int IdEngorde { get; set; }

        [DisplayName("Box")]
        public string NombreBox { get; set; } = "";

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = "";

        [DisplayName("Fecha Ingreso")]
        public DateTime? FechaIngreso { get; set; }

        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        [DisplayName("Fecha Actualizado")]
        public DateTime? FechaActualizado { get; set; }

        [DisplayName("Semanas")]
        public int Semanas { get; set; }

        [DisplayName("Peso (kg)")]
        public decimal Peso { get; set; }

        [DisplayName("Alimento")]
        public string NombreAlimento { get; set; } = "";

        [DisplayName("Alim. por Día (kg)")]
        public decimal AlimentoPorDia { get; set; }

        [DisplayName("Estado")]
        public bool Estado { get; set; }
    }
}

