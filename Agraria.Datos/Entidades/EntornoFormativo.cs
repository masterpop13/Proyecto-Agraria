using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class EntornoFormativo
    {
        public int IdEntorno { get; set; }               // Clave primaria de la tabla Entorno
        public string Nombre { get; set; }
        public int IdTipoEntorno { get; set; }    // FK a TipoEntorno
        public string Responsable { get; set; }
        public string Año { get; set; }
        public string Division { get; set; }
        public string Grupo { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
    }
}

