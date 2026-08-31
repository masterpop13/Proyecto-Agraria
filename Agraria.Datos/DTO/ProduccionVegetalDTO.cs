using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class ProduccionVegetalDTO
    {
        [DisplayName("Produccion")]
        public int IdProduccion { get; set; }

        [DisplayName("Plantines")]
        public int CantidadPlantines { get; set; }

        [DisplayName("Atados")]
        public int CantidadAtados { get; set; }

        [DisplayName("Fecha de Cultivo")]
        public DateTime FechaCultivo { get; set; }

        [DisplayName("Fecha de Cosecha")]
        public DateTime FechaCosecha { get; set; }
        public bool Estado { get; set; }
    }
}
