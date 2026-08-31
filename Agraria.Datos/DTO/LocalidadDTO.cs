using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class LocalidadDTO
    {
        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public int CodigoPostal { get; set; }
        public int IdPartido { get; set; }
    }
}
