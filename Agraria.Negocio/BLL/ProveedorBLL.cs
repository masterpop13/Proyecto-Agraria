using Agraria.Datos.DAL;
using Agraria.Datos.Entidades;
using System.Collections.Generic;

namespace Agraria.Negocio.BLL
{
    public class ProveedorBLL
    {
        public List<Proveedor> Listar()
        {
            return ProveedorDAL.Listar();
        }
    }
}
