using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.Entidades;
using Agraria.Datos.DTO;

namespace Agraria.Negocio.BLL
{
    public class ProductosBLL
    {
        public List<ProductoDTO> ListarProductos()
        {
            return ProductosDAL.ListarProductos();
        }

        public ProductoDTO ObtenerProducto(int idProducto)
        {
            return ProductosDAL.ObtenerProductoPorId(idProducto);
        }
    }
}