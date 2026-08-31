using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos;

namespace Agraria.Negocio.BLL
{
    public class AbmUsuarioBLL
    {

        private readonly AbmUsuarioDAL _abmUsuarioDAL;

        public AbmUsuarioBLL()
        {
            _abmUsuarioDAL = new AbmUsuarioDAL();
        }


        public List<AbmUsuarioDTO> CargarTodoslosUsuarios()
        {
            return _abmUsuarioDAL.ObtenerUsuarios();
        }


        public void InsertarUsuario(AbmUsuario usuario)
        {
            _abmUsuarioDAL.InsertarUsuario(usuario);
        }
       
        public void ModificarUsuario(AbmUsuario usuarioModificado)
        {
            _abmUsuarioDAL.ModificarUsuario(usuarioModificado);
        }

        public void CambiarEstadoUsuario(int id, bool estado)
        {
            _abmUsuarioDAL.CambiarEstadoUsuario(id, estado);
        }

        public List<AbmUsuarioDTO> BuscarUsuarioPorNombreODni(string textoBusqueda)
        {
            return _abmUsuarioDAL.BuscarUsuarioPorNombreODni(textoBusqueda);
        }

        public List<PartidoDTO> CargarPartidos()
        {
            return _abmUsuarioDAL.CargarPartidos();
        }

        public List<LocalidadDTO> CargarLocalidades()
        {
            return _abmUsuarioDAL.CargarLocalidades();
        }

        public List<PreguntaSeguridadDTO> CargarPreguntasSeguridad()
        {
            return _abmUsuarioDAL.CargarPreguntasSeguridad();
        }

        public int InsertarUsuarioYObtenerId(AbmUsuario usuario)
        {
            return _abmUsuarioDAL.InsertarUsuarioYObtenerId(usuario);
        }

        public void GuardarPermisos(int idUsuario, bool entorno, bool altaUsuario, bool venta, bool inventario, bool industria, bool prodAnimal, bool prodVegetal, bool admin, bool pañol)
        {
            _abmUsuarioDAL.InsertarPermisos(idUsuario, entorno, altaUsuario, venta, inventario, industria, prodAnimal, prodVegetal, admin, pañol);
        }


        public PermisosUsuarioDTO ObtenerPermisosPorUsuario(int idUsuario)
        {
            return _abmUsuarioDAL.ObtenerPermisosPorUsuario(idUsuario);
        }


        public bool HayUsuariosRegistrados()
        {
            return _abmUsuarioDAL.HayUsuariosRegistrados();
        }

        public void CrearUsuarioAdminInicial()
        {
            _abmUsuarioDAL.CrearUsuarioAdminInicial();
        }

        public List<LocalidadDTO> CargarLocalidadesPorPartido(int idPartido)
        {
            return _abmUsuarioDAL.CargarLocalidadesPorPartido(idPartido);
        }

        public void ActualizarPermisos(int idUsuario,
    bool entorno, bool altaUsuario, bool venta, bool inventario,
    bool industria, bool prodAnimal, bool prodVegetal, bool admin, bool panol)
        {
            _abmUsuarioDAL.UpsertPermisos(idUsuario, entorno, altaUsuario, venta, inventario,
                                          industria, prodAnimal, prodVegetal, admin, panol);
        }


    }
}
