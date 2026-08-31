using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Agraria.Datos.DTO
{
    public class AbmUsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Partido { get; set; }

        [DisplayName("Codigo Postal")]
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
       
        public string PreguntaSeguridad { get; set; }
        public string RespuestaSeguridad { get; set; }
        public bool Estado { get; set; }


        public AbmUsuarioDTO() { }

        public AbmUsuarioDTO(
            int id,
            string nombre,
            string apellido,
            int documento,
            string telefono,
            string direccion,
            string localidad,
            string partido,
            string codigoPostal,
            string email,
            string nombreUsuario,
            string contraseña,
            
            string preguntaSeguridad,
            string respuestaSeguridad,
            bool estado)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Telefono = telefono;
            Direccion = direccion;
            Localidad = localidad;
            Partido = partido;
            CodigoPostal = codigoPostal;
            Email = email;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            
            PreguntaSeguridad = preguntaSeguridad;
            RespuestaSeguridad = respuestaSeguridad;
            Estado = estado;
        }
    }
}
