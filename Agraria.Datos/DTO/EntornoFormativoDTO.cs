using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class EntornoFormativoDTO
    {
        public int IdEntorno { get; set; }

        [DisplayName("Nombre del Entorno")]
        public string Nombre { get; set; }

        [DisplayName("Tipo de Entorno")]
        public string IdTipoEntorno { get; set; } // Nombre del tipo
        [DisplayName("Profesor Responsable")]
        public string Responsable { get; set; }
        public string Año { get; set; }
        public string Division { get; set; }
        public string Grupo { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }


       public EntornoFormativoDTO () { }

    }

  
}
