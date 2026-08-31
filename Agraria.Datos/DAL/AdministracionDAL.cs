using Agraria.Datos.DAL; 
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DAL
{
    public class AdministracionDAL
    {
        // ======== PARTIDOS ========
        public List<PartidoDTO> ListarPartidos()
        {
            var lista = new List<PartidoDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT IdPartido, NombrePartido FROM Partido ORDER BY NombrePartido";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new PartidoDTO
                        {
                            IdPartido = Convert.ToInt32(dr["IdPartido"]),
                            NombrePartido = dr["NombrePartido"].ToString()
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        public void InsertarPartido(string nombrePartido)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "INSERT INTO Partido (NombrePartido) VALUES (@n)";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePartido);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public void ActualizarPartido(int idPartido, string nombrePartido)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "UPDATE Partido SET NombrePartido=@n WHERE IdPartido=@id";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePartido);
                    cmd.Parameters.AddWithValue("@id", idPartido);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        // ======== LOCALIDADES ========
        public List<LocalidadDTO> ListarLocalidades()
        {
            var lista = new List<LocalidadDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT IdLocalidad, NombreLocalidad, CodigoPostal, IdPartido FROM Localidad ORDER BY NombreLocalidad";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new LocalidadDTO
                        {
                            IdLocalidad = Convert.ToInt32(dr["IdLocalidad"]),
                            NombreLocalidad = dr["NombreLocalidad"].ToString(),
                            CodigoPostal = Convert.ToInt32(dr["CodigoPostal"]),
                            IdPartido = Convert.ToInt32(dr["IdPartido"])
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        public void InsertarLocalidad(string nombreLocalidad, int idPartido, int codigoPostal = 0)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "INSERT INTO Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (@n, @cp, @idp)";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombreLocalidad);
                    cmd.Parameters.AddWithValue("@cp", codigoPostal);
                    cmd.Parameters.AddWithValue("@idp", idPartido);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public void ActualizarLocalidad(int idLocalidad, string nombreLocalidad, int idPartido, int codigoPostal = 0)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "UPDATE Localidad SET NombreLocalidad=@n, CodigoPostal=@cp, IdPartido=@idp WHERE IdLocalidad=@id";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombreLocalidad);
                    cmd.Parameters.AddWithValue("@cp", codigoPostal);
                    cmd.Parameters.AddWithValue("@idp", idPartido);
                    cmd.Parameters.AddWithValue("@id", idLocalidad);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        // ======== TIPO ENTORNO ========
        public List<TipoEntornoDTO> ListarTipoEntorno()
        {
            var lista = new List<TipoEntornoDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT IdTipoEntorno, Nombre FROM TipoEntorno ORDER BY Nombre";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoEntornoDTO
                        {
                            IdTipoEntorno = Convert.ToInt32(dr["IdTipoEntorno"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        public void InsertarTipoEntorno(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "INSERT INTO TipoEntorno (Nombre) VALUES (@n)";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public void ActualizarTipoEntorno(int id, string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "UPDATE TipoEntorno SET Nombre=@n WHERE IdTipoEntorno=@id";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        // ======== TIPO MEDIDA ========
        public List<TipoMedidaDTO> ListarTipoMedida()
        {
            var lista = new List<TipoMedidaDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT IdTipoMedida, Nombre FROM TipoMedida ORDER BY Nombre";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoMedidaDTO
                        {
                            IdTipoMedida = Convert.ToInt32(dr["IdTipoMedida"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        public void InsertarTipoMedida(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "INSERT INTO TipoMedida (Nombre) VALUES (@n)";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public void ActualizarTipoMedida(int id, string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "UPDATE TipoMedida SET Nombre=@n WHERE IdTipoMedida=@id";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        // ======== PRODUCTOS ========
        public List<ProductoDTO> ListarProductos()
        {
            var lista = new List<ProductoDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT idProducto, Nombre, Descripcion, PrecioUnitario FROM Productos ORDER BY Nombre";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ProductoDTO
                        {
                            IdProducto = Convert.ToInt32(dr["idProducto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString()
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        public decimal? ObtenerPrecioUnitarioPorNombre(string nombreProducto)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT TOP 1 PrecioUnitario FROM Productos WHERE Nombre = @n";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombreProducto);
                    var o = cmd.ExecuteScalar();
                    if (o == null || o == DBNull.Value) return null;
                    return Convert.ToDecimal(o);
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public string ObtenerDescripcionPorNombre(string nombreProducto)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT TOP 1 Descripcion FROM Productos WHERE Nombre = @n";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombreProducto ?? string.Empty);
                    var o = cmd.ExecuteScalar();
                    return (o?.ToString()) ?? string.Empty; // 👈 evita nulos
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public void InsertarProducto(string nombre, string descripcion, decimal precioUnitario)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "INSERT INTO Productos (idProducto, Nombre, Descripcion, PrecioUnitario) VALUES (@id, @n, @d, @p)";
                // Nota: Tu tabla Productos NO es IDENTITY, así que necesitas un id. Generamos uno nuevo.
                int nuevoId = ObtenerSiguienteIdProducto();
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@id", nuevoId);
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.Parameters.AddWithValue("@d", (object)descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p", precioUnitario);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public void ActualizarProducto(int idProducto, string nombre, string descripcion, decimal precioUnitario)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "UPDATE Productos SET Nombre=@n, Descripcion=@d, PrecioUnitario=@p WHERE idProducto=@id";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.Parameters.AddWithValue("@d", (object)descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p", precioUnitario);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        private int ObtenerSiguienteIdProducto()
        {
            try
            {
                string q = "SELECT ISNULL(MAX(idProducto),0) + 1 FROM Productos";
                using (var cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    var o = cmd.ExecuteScalar();
                    return Convert.ToInt32(o);
                }
            }
            catch { return 1; }
        }


        ////////////////////////////////////////Provedores///////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////
        ///
        public static void InsertarProveedor(Proveedor proveedor)
        {
            ConexionBD.ConectarBD();

            string sql = @"INSERT INTO Proveedores (RazonSocial, Telefono, Email, Direccion)
                           VALUES (@RazonSocial, @Telefono, @Email, @Direccion)";
            using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                cmd.ExecuteNonQuery();
            }

            ConexionBD.CierraBD();
        }

        public static void ModificarProveedor(Proveedor proveedor)
        {
            ConexionBD.ConectarBD();

            string sql = @"UPDATE Proveedores 
                           SET RazonSocial = @RazonSocial, 
                               Telefono = @Telefono, 
                               Email = @Email, 
                               Direccion = @Direccion
                           WHERE IdProveedor = @IdProveedor";

            using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                cmd.ExecuteNonQuery();
            }

            ConexionBD.CierraBD();
        }

        public static List<Proveedor> ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            ConexionBD.ConectarBD();

            string sql = "SELECT IdProveedor, RazonSocial, Telefono, Email, Direccion FROM Proveedores";
            using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Proveedor
                    {
                        IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                        RazonSocial = dr["RazonSocial"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Email = dr["Email"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    });
                }
            }

            ConexionBD.CierraBD();
            return lista;
        }
    }
}
