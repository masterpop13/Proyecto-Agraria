using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos
{
    public class ArticuloDAL
    {
        public void InsertarArticulo(Articulo articulo)
        {
            try
            {
                ConexionBD.ConectarBD();

                string query = @"INSERT INTO Articulo 
                                (NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado) 
                                VALUES (@NombreProducto, @Cantidad, @IdTipoMedida, @Precio, @FechaIngreso, @IdTipoEntorno, @Responsable, @FechaEgreso, @Estado)";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@NombreProducto", articulo.NombreProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", articulo.Cantidad);
                    cmd.Parameters.AddWithValue("@IdTipoMedida", articulo.IdTipoMedida);
                    cmd.Parameters.AddWithValue("@Precio", (object?)articulo.Precio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaIngreso", articulo.FechaIngreso);
                    cmd.Parameters.AddWithValue("@IdTipoEntorno", articulo.IdTipoEntorno);
                    cmd.Parameters.AddWithValue("@Responsable", (object)articulo.Responsable ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaEgreso", articulo.FechaEgreso);
                    cmd.Parameters.AddWithValue("@Estado", articulo.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public void Modificar(Articulo articulo)
        {
            try
            {
                ConexionBD.ConectarBD();

                string query = @"UPDATE Articulo SET 
                                NombreProducto=@NombreProducto, Cantidad=@Cantidad, IdTipoMedida=@IdTipoMedida,
                                Precio=@Precio, FechaIngreso=@FechaIngreso, IdTipoEntorno=@IdTipoEntorno,
                                Responsable=@Responsable, FechaEgreso=@FechaEgreso, Estado=@Estado
                                WHERE IdArticulo=@IdArticulo";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@IdArticulo", articulo.IdArticulo);
                    cmd.Parameters.AddWithValue("@NombreProducto", articulo.NombreProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", articulo.Cantidad);
                    cmd.Parameters.AddWithValue("@IdTipoMedida", articulo.IdTipoMedida);
                    cmd.Parameters.AddWithValue("@Precio", (object?)articulo.Precio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaIngreso", articulo.FechaIngreso);
                    cmd.Parameters.AddWithValue("@IdTipoEntorno", articulo.IdTipoEntorno);
                    cmd.Parameters.AddWithValue("@Responsable", (object)articulo.Responsable ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaEgreso", articulo.FechaEgreso);
                    cmd.Parameters.AddWithValue("@Estado", articulo.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public List<ArticuloDTO> ObtenerArticulos(string filtroNombre = "")
        {
            List<ArticuloDTO> lista = new List<ArticuloDTO>();

            try
            {
                ConexionBD.ConectarBD();

                string query = @"SELECT 
                            a.IdArticulo, 
                            a.NombreProducto, 
                            a.Cantidad, 
                            a.IdTipoMedida,            -- 👈 Agregado
                            m.Nombre AS TipoMedida, 
                            a.Precio, 
                            a.FechaIngreso, 
                            a.IdTipoEntorno,           -- 👈 Agregado
                            e.Nombre AS TipoEntorno, 
                            a.Responsable, 
                            a.FechaEgreso, 
                            a.Estado
                        FROM Articulo a
                        INNER JOIN TipoMedida m ON a.IdTipoMedida = m.IdTipoMedida
                        INNER JOIN TipoEntorno e ON a.IdTipoEntorno = e.IdTipoEntorno
                        WHERE a.NombreProducto LIKE @Filtro";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtroNombre + "%");

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new ArticuloDTO
                        {
                            IdArticulo = (int)dr["IdArticulo"],
                            NombreProducto = dr["NombreProducto"].ToString(),
                            Cantidad = (decimal)dr["Cantidad"],
                            IdTipoMedida = (int)dr["IdTipoMedida"],   // 👈 Guardamos ID
                            TipoMedida = dr["TipoMedida"].ToString(),
                            Precio = dr["Precio"] == DBNull.Value ? (decimal?)null : (decimal)dr["Precio"],
                            FechaIngreso = (DateTime)dr["FechaIngreso"],
                            IdTipoEntorno = (int)dr["IdTipoEntorno"], // 👈 Guardamos ID
                            TipoEntorno = dr["TipoEntorno"].ToString(),
                            Responsable = dr["Responsable"] == DBNull.Value ? "" : dr["Responsable"].ToString(),
                            FechaEgreso = (DateTime)dr["FechaEgreso"],
                            Estado = (bool)dr["Estado"]
                        });
                    }
                    dr.Close();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return lista;
        }

        public static int ObtenerStock(int idArticulo)
        {
            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT Cantidad FROM Articulo WHERE IdArticulo = @id";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@id", idArticulo);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public List<InsumoDTO> ObtenerInsumosAgrupados()
        {
            var lista = new List<InsumoDTO>();
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
            SELECT 
                MIN(a.IdArticulo) AS IdInsumoRepresentativo,
                a.NombreProducto,
                SUM(a.Cantidad) AS StockTotal,
                a.IdTipoMedida,
                tm.Nombre AS NombreTipoMedida
            FROM Articulo a
            INNER JOIN TipoMedida tm ON a.IdTipoMedida = tm.IdTipoMedida
            WHERE a.Estado = 1
            GROUP BY a.NombreProducto, a.IdTipoMedida, tm.Nombre
            ORDER BY a.NombreProducto";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new InsumoDTO
                        {
                            IdInsumoRepresentativo = Convert.ToInt32(dr["IdInsumoRepresentativo"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            StockTotal = Convert.ToDecimal(dr["StockTotal"]),
                            IdTipoMedida = Convert.ToInt32(dr["IdTipoMedida"]),
                            NombreTipoMedida = dr["NombreTipoMedida"].ToString()
                        });
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
            return lista;
        }

        public static void Insertar(Articulo articulo)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
        INSERT INTO Articulo 
        (NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado)
        VALUES (@n, @c, @idMedida, @p, @fIn, @idEnt, @r, @fEg, @e)";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    // Asignamos fechas válidas directamente antes del insert
                    DateTime fechaFinal = articulo.FechaEgreso != default(DateTime)
                        ? articulo.FechaEgreso
                        : DateTime.Now;

                    // FechaIngreso y FechaEgreso serán iguales
                    cmd.Parameters.AddWithValue("@n", articulo.NombreProducto);
                    cmd.Parameters.AddWithValue("@c", articulo.Cantidad);
                    cmd.Parameters.AddWithValue("@idMedida", articulo.IdTipoMedida);
                    cmd.Parameters.AddWithValue("@p", articulo.Precio ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fIn", fechaFinal);
                    cmd.Parameters.AddWithValue("@idEnt", articulo.IdTipoEntorno);
                    cmd.Parameters.AddWithValue("@r", articulo.Responsable ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fEg", fechaFinal);
                    cmd.Parameters.AddWithValue("@e", articulo.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static void InsertarDesdeLeche(string nombreProducto, decimal cantidad, DateTime fechaEnviado, string responsable)
        {
            ConexionBD.ConectarBD();

            string query = @"
        INSERT INTO Articulo
        (NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado)
        VALUES (@NombreProducto, @Cantidad, @IdTipoMedida, NULL, @FechaIngreso, @IdTipoEntorno, @Responsable, @FechaEgreso, 1)";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@NombreProducto", nombreProducto);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@IdTipoMedida", 3); // litros
                cmd.Parameters.AddWithValue("@FechaIngreso", fechaEnviado);
                cmd.Parameters.AddWithValue("@IdTipoEntorno", 1); // entorno animal
                cmd.Parameters.AddWithValue("@Responsable", responsable ?? "UsuarioSistema");
                cmd.Parameters.AddWithValue("@FechaEgreso", fechaEnviado);
                cmd.ExecuteNonQuery();
            }

            ConexionBD.CierraBD();
        }



    }
}
