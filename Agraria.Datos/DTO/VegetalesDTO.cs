using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Agraria.Datos.DTO
{
    public class VegetalesDTO
    {
        [DisplayName("Codigo de Registro")]
        public int IdProduccion { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }  // 🔹 Nuevo

        [DisplayName("Cant. de Plantines")]
        public int CantidadPlantines { get; set; }

        [DisplayName("Cant. de Cosechados")]
        public int Cantidad { get; set; }

        [DisplayName("Fecha de Cultivo")]
        public DateTime FechaCultivo { get; set; }

        [DisplayName("Fecha de Cosecha")]
        public DateTime FechaCosecha { get; set; }

        [DisplayName("Estado")]
        public bool Estado { get; set; }
    }
}
