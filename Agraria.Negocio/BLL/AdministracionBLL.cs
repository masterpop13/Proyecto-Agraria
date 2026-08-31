using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class AdministracionBLL
    {
        private readonly AdministracionDAL dal = new AdministracionDAL();

        // Partidos
        public List<PartidoDTO> ListarPartidos() => dal.ListarPartidos();
        public void GuardarPartido(string nombre) => dal.InsertarPartido(nombre);
        public void ModificarPartido(int id, string nombre) => dal.ActualizarPartido(id, nombre);

        // Localidades
        public List<LocalidadDTO> ListarLocalidades() => dal.ListarLocalidades();
        public void GuardarLocalidad(string nombre, int idPartido, int codigoPostal = 0) => dal.InsertarLocalidad(nombre, idPartido, codigoPostal);
        public void ModificarLocalidad(int id, string nombre, int idPartido, int codigoPostal = 0) => dal.ActualizarLocalidad(id, nombre, idPartido, codigoPostal);

        // TipoEntorno
        public List<TipoEntornoDTO> ListarTipoEntorno() => dal.ListarTipoEntorno();
        public void GuardarTipoEntorno(string nombre) => dal.InsertarTipoEntorno(nombre);
        public void ModificarTipoEntorno(int id, string nombre) => dal.ActualizarTipoEntorno(id, nombre);

        // TipoMedida
        public List<TipoMedidaDTO> ListarTipoMedida() => dal.ListarTipoMedida();
        public void GuardarTipoMedida(string nombre) => dal.InsertarTipoMedida(nombre);
        public void ModificarTipoMedida(int id, string nombre) => dal.ActualizarTipoMedida(id, nombre);

        // Productos
        public List<ProductoDTO> ListarProductos() => dal.ListarProductos();
        public decimal? ObtenerPrecioPorNombre(string nombre) => dal.ObtenerPrecioUnitarioPorNombre(nombre);
        public string ObtenerDescripcionPorNombre(string nombre) => dal.ObtenerDescripcionPorNombre(nombre);
        public void GuardarProducto(string nombre, string descripcion, decimal precio) => dal.InsertarProducto(nombre, descripcion, precio);
        public void ModificarProducto(int idProducto, string nombre, string descripcion, decimal precio) => dal.ActualizarProducto(idProducto, nombre, descripcion, precio);


        ///proveedores
        ///

        public void InsertarProveedor(Proveedor proveedor)
        {
            AdministracionDAL.InsertarProveedor(proveedor);
        }

        public void ModificarProveedor(Proveedor proveedor)
        {
            AdministracionDAL.ModificarProveedor(proveedor);
        }

        public List<Proveedor> ListarProveedores()
        {
            return AdministracionDAL.ListarProveedores();
        }
    }
}
