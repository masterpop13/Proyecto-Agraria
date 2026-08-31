using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Agraria.Datos.Entidades;
using Agraria.Datos.DTO;

namespace Agraria.Datos.DAL
{
    public class ProductosDAL
    {
        public static List<ProductoDTO> ListarProductos()
        {
            var lista = new List<ProductoDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT idProducto, Nombre, Descripcion FROM Productos";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ProductoDTO
                        {
                            IdProducto = Convert.ToInt32(dr["idProducto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        public static ProductoDTO? ObtenerProductoPorId(int idProducto)
        {
            ProductoDTO? producto = null;

            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT idProducto, Nombre, Descripcion FROM Productos WHERE idProducto = @id";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@id", idProducto);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            producto = new ProductoDTO
                            {
                                IdProducto = Convert.ToInt32(dr["idProducto"]),
                                Nombre = dr["Nombre"]?.ToString() ?? string.Empty,
                                Descripcion = dr["Descripcion"]?.ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return producto;
        }

    }
}
