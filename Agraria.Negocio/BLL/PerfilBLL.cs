using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.Entidades;

namespace Agraria.Negocio.BLL
{
    public class PerfilBLL
    {
        public List<Perfil> ListarPerfiles()
        {
            return PerfilDAL.ObtenerPerfiles();
        }

        public void GuardarPerfil(string nombre)
        {
            PerfilDAL.InsertarPerfil(nombre);
        }

        public void ModificarPerfil(int id, string nombre)
        {
            PerfilDAL.ModificarPerfil(id, nombre);
        }
    }
}
