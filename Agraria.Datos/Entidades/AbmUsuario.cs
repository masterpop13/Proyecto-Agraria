using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.Entidades
{

    public class AbmUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public LocalidadDTO IdLocalidad { get; set; }
        public PartidoDTO IdPartido { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public PerfilDTO IdPerfil { get; set; }
        public PreguntaSeguridadDTO IdPreguntaSeguridad { get; set; }
        public string RespuestaSeguridad { get; set; }
        public bool Estado { get; set; }

        public AbmUsuario(
            int id,
            string nombre,
            string apellido,
            int documento,
            string telefono,
            string direccion,
            LocalidadDTO localidad,
            PartidoDTO partido,
            string email,
            string nombreUsuario,
            string contraseña,
            PerfilDTO perfil,
            PreguntaSeguridadDTO preguntaSeguridad,
            string respuestaSeguridad,
            bool estado)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Telefono = telefono;
            Direccion = direccion;
            IdLocalidad = localidad;
            IdPartido = partido;
            Email = email;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            IdPerfil = perfil;
            IdPreguntaSeguridad = preguntaSeguridad;
            RespuestaSeguridad = respuestaSeguridad;
            Estado = estado;
        }

        public AbmUsuario() { }
    }


}
