using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Entidades
{
    public class UsuarioLogin
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        // Pregunta de seguridad
        public int IdPreguntaSeguridad { get; set; }
        public string RespuestaSeguridad { get; set; }
    }
}

