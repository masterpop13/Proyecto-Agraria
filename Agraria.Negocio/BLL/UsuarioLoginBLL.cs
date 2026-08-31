using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using Agraria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class UsuarioLoginBLL
    {
        private readonly UsuarioLoginDAL dal = new UsuarioLoginDAL();

        public UsuarioLoginDTO Autenticar(string usuario, string contraseña)
        {
            return dal.Login(usuario, contraseña);
        }

        public bool CambiarContraseña(UsuarioLogin usuario)
        {
            return dal.ActualizarContraseña(usuario);
        }

        public bool VerificarPreguntaSeguridad(UsuarioLogin usuario)
        {
            return dal.ValidarPreguntaSeguridad(usuario);
        }



    }
}
