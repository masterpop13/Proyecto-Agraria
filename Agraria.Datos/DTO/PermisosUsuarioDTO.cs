using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class PermisosUsuarioDTO
    {
        public bool PuedeEntornoFormativo { get; set; }
        public bool PuedeAltaUsuario { get; set; }
        public bool PuedeVenta { get; set; }
        public bool PuedeInventario { get; set; }
        public bool PuedeIndustria { get; set; }
        public bool PuedeProduccionAnimal { get; set; }
        public bool PuedeProduccionVegetal { get; set; }
        public bool PuedeAdministracion { get; set; }
        public bool PuedePañol { get; set; } // ✅ nuevo
    }
}

