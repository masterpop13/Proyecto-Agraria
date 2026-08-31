using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public static class CarneDAL
    {
        public static bool ExisteNumeroAnimal(string numero)
        {
            ConexionBD.ConectarBD();
            string sql = "SELECT COUNT(*) FROM Carne WHERE NumeroAnimal = @n";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@n", numero);
            int count = (int)cmd.ExecuteScalar();
            ConexionBD.CierraBD();
            return count > 0;
        }

        public static bool AnimalActivoExiste(string numero)
        {
            ConexionBD.ConectarBD();
            string sql = "SELECT COUNT(*) FROM Carne WHERE NumeroAnimal = @n AND Estado = 1";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@n", numero);
            int count = (int)cmd.ExecuteScalar();
            ConexionBD.CierraBD();
            return count > 0;
        }

        public static void GuardarProduccion(string nombre, int idBox, string numeroAnimal, string sexo, DateTime fecha)
        {
            ConexionBD.ConectarBD();
            string sql = @"INSERT INTO Carne (Nombre, IdBoxCarne, NumeroAnimal, FechaIngreso, Sexo, Estado)
                           VALUES (@n, @idb, @num, @f, @s, 1)";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@idb", idBox);
            cmd.Parameters.AddWithValue("@num", numeroAnimal);
            cmd.Parameters.AddWithValue("@f", fecha);
            cmd.Parameters.AddWithValue("@s", sexo);
            cmd.ExecuteNonQuery();
            ConexionBD.CierraBD();
        }

        public static void EnviarAnimalIndustria(string nombre, int idBox, string numero, DateTime fechaEgreso, int cantidad, string responsable)
        {
            try
            {
                ConexionBD.ConectarBD();

                using (SqlTransaction tr = ConexionBD.ConexionSQL.BeginTransaction())
                {
                    try
                    {
                        // 🔹 1. Validar existencia del animal activo
                        string checkSql = "SELECT COUNT(*) FROM Carne WHERE NumeroAnimal = @n AND Estado = 1";
                        using (SqlCommand cmdCheck = new SqlCommand(checkSql, ConexionBD.ConexionSQL, tr))
                        {
                            cmdCheck.Parameters.AddWithValue("@n", numero);
                            int existe = (int)cmdCheck.ExecuteScalar();

                            if (existe == 0)
                                throw new Exception($"El animal #{numero} no existe activo en la base.");
                        }

                        // 🔹 2. Dar de baja el animal (Estado = 0)
                        string updateSql = @"
                        UPDATE Carne 
                        SET Estado = 0, FechaEnvioIndustria = @fechaEgreso 
                        WHERE NumeroAnimal = @numero AND Estado = 1";

                        using (SqlCommand cmdUpd = new SqlCommand(updateSql, ConexionBD.ConexionSQL, tr))
                        {
                            cmdUpd.Parameters.AddWithValue("@fechaEgreso", fechaEgreso);
                            cmdUpd.Parameters.AddWithValue("@numero", numero);
                            cmdUpd.ExecuteNonQuery();
                        }

                        // 🔹 3. Insertar registro en Articulo
                        string insertSql = @"
                        INSERT INTO Articulo 
                            (NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado)
                        VALUES 
                            (@nombre, @cantidad, 2, NULL, @fecha, 1, @responsable, @fecha, 1)";

                        using (SqlCommand cmdIns = new SqlCommand(insertSql, ConexionBD.ConexionSQL, tr))
                        {
                            cmdIns.Parameters.AddWithValue("@nombre", nombre);
                            cmdIns.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdIns.Parameters.AddWithValue("@fecha", fechaEgreso); // 👈 Mismo valor para ingreso y egreso
                            cmdIns.Parameters.AddWithValue("@responsable", responsable ?? (object)DBNull.Value);
                            cmdIns.ExecuteNonQuery();
                        }

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static List<CarneDTO> ListarCarne(string nombrePagina)
        {
            var lista = new List<CarneDTO>();
            ConexionBD.ConectarBD();
            string sql = @"SELECT c.IdCarne, c.Nombre, b.Nombre AS NombreBox, c.NumeroAnimal, c.Sexo, 
                                  c.FechaIngreso, c.FechaRetiro, c.FechaEnvioIndustria, c.Estado
                           FROM Carne c
                           INNER JOIN BoxCarne b ON c.IdBoxCarne = b.IdBoxCarne
                           WHERE c.Nombre = @n
                           ORDER BY c.IdCarne DESC";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@n", nombrePagina);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new CarneDTO
                {
                    IdCarne = Convert.ToInt32(dr["IdCarne"]),
                    Nombre = dr["Nombre"].ToString(),
                    NombreBox = dr["NombreBox"].ToString(),
                    NumeroAnimal = dr["NumeroAnimal"].ToString(),
                    Sexo = dr["Sexo"].ToString(),
                    FechaIngreso = dr["FechaIngreso"] == DBNull.Value ? null : Convert.ToDateTime(dr["FechaIngreso"]),
                    FechaRetiro = dr["FechaRetiro"] == DBNull.Value ? null : Convert.ToDateTime(dr["FechaRetiro"]),
                    FechaEnvioIndustria = dr["FechaEnvioIndustria"] == DBNull.Value ? null : Convert.ToDateTime(dr["FechaEnvioIndustria"]),
                    Estado = Convert.ToBoolean(dr["Estado"])
                });
            }
            ConexionBD.CierraBD();
            return lista;
        }



        public static List<CarneDTO> ListarMadres(string nombre)
        {
            var lista = new List<CarneDTO>();
            ConexionBD.ConectarBD();
            string sql = "SELECT NumeroAnimal FROM Carne WHERE Sexo = 'Hembra' AND Estado = 1 AND Nombre = @n";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@n", nombre);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(new CarneDTO { NumeroAnimal = dr["NumeroAnimal"].ToString() });
            ConexionBD.CierraBD();
            return lista;
        }

        public static List<CarneDTO> ListarPadres(string nombre)
        {
            var lista = new List<CarneDTO>();
            ConexionBD.ConectarBD();
            string sql = "SELECT NumeroAnimal FROM Carne WHERE Sexo = 'Macho' AND Estado = 1 AND Nombre = @n";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@n", nombre);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(new CarneDTO { NumeroAnimal = dr["NumeroAnimal"].ToString() });
            ConexionBD.CierraBD();
            return lista;
        }

        public static (int hembras, int machos) ContarActivosPorSexo(string nombre)
        {
            int hembras = 0, machos = 0;
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
                SELECT LOWER(LTRIM(RTRIM(Sexo))) AS Sexo, COUNT(*) AS Cnt
                FROM Carne
                WHERE Estado = 1
                  AND Nombre = @n
                  AND NumeroAnimal IS NOT NULL
                GROUP BY LOWER(LTRIM(RTRIM(Sexo)))";

                using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string sexo = dr["Sexo"]?.ToString() ?? "";
                            int cnt = Convert.ToInt32(dr["Cnt"]);
                            if (sexo == "hembra") hembras = cnt;
                            else if (sexo == "macho") machos = cnt;
                        }
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }

            return (hembras, machos);

        }

        // Lista de la tabla Carne filtrada por Nombre de página
        public static List<CarneDTO> ListarPorNombre(string nombrePagina)
        {
            List<CarneDTO> lista = new List<CarneDTO>();

            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
            SELECT c.IdCarne, c.Nombre, bc.Nombre AS NombreBox, c.NumeroAnimal, 
                   c.FechaIngreso, c.Sexo, c.FechaRetiro, c.FechaEnvioIndustria, c.Estado
            FROM Carne c
            LEFT JOIN BoxCarne bc ON bc.IdBoxCarne = c.IdBoxCarne
            WHERE c.Nombre = @n";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CarneDTO carne = new CarneDTO
                            {
                                IdCarne = dr["IdCarne"] != DBNull.Value ? Convert.ToInt32(dr["IdCarne"]) : 0,
                                Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                                NombreBox = dr["NombreBox"] != DBNull.Value ? dr["NombreBox"].ToString() : string.Empty,
                                NumeroAnimal = dr["NumeroAnimal"] != DBNull.Value ? dr["NumeroAnimal"].ToString() : string.Empty,
                                Sexo = dr["Sexo"] != DBNull.Value ? dr["Sexo"].ToString() : string.Empty,
                                FechaIngreso = dr["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(dr["FechaIngreso"]) : (DateTime?)null,
                                FechaRetiro = dr["FechaRetiro"] != DBNull.Value ? Convert.ToDateTime(dr["FechaRetiro"]) : (DateTime?)null,
                                FechaEnvioIndustria = dr["FechaEnvioIndustria"] != DBNull.Value ? Convert.ToDateTime(dr["FechaEnvioIndustria"]) : (DateTime?)null,
                                Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"])
                            };

                            lista.Add(carne);
                        }
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return lista;
        }




        // ¿Existe animal activo por número en esta página?
        public static bool AnimalActivoExiste(string nombrePagina, string numeroAnimal)
        {
            ConexionBD.ConectarBD();
            string sql = @"SELECT COUNT(*) 
                           FROM Carne 
                           WHERE Nombre=@n AND NumeroAnimal=@num AND Estado=1";
            using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@n", nombrePagina);
                cmd.Parameters.AddWithValue("@num", numeroAnimal);
                int c = Convert.ToInt32(cmd.ExecuteScalar());
                ConexionBD.CierraBD();
                return c > 0;
            }
        }

        // Marcar enviado (baja lógica) SOLO el registro de ese número y página
        public static void MarcarEnviado(string nombrePagina, string numeroAnimal, DateTime fechaEgreso)
        {
            ConexionBD.ConectarBD();
            string sql = @"UPDATE Carne 
                           SET Estado = 0, FechaEnvioIndustria = @f
                           WHERE Nombre=@n AND NumeroAnimal=@num AND Estado=1";
            using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@n", nombrePagina);
                cmd.Parameters.AddWithValue("@num", numeroAnimal);
                cmd.Parameters.AddWithValue("@f", fechaEgreso);
                cmd.ExecuteNonQuery();
            }
            ConexionBD.CierraBD();
        }


        public static bool ExisteAnimalPorNombre(string nombrePagina, string numero)
        {
            ConexionBD.ConectarBD();

            string sql = @"SELECT COUNT(*) 
                   FROM Carne 
                   WHERE Nombre = @nombre 
                   AND NumeroAnimal = @numero 
                   AND Estado = 1";

            using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@nombre", nombrePagina);
                cmd.Parameters.AddWithValue("@numero", numero);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                ConexionBD.CierraBD();
                return count > 0;
            }
        }

        public static void RetirarAnimal(string nombrePagina, int idBox, string numero, DateTime fechaRetiro)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
            UPDATE Carne
            SET Estado = 0, FechaRetiro = @fecha
            WHERE Nombre = @nombre 
              AND NumeroAnimal = @numero 
              AND Estado = 1";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombrePagina);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@fecha", fechaRetiro);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al retirar animal en DAL: " + ex.Message);
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }


        public static (int total, decimal producido) TotalesCarne(string nombrePagina)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"SELECT 
                        ISNULL(SUM(CantidadAnimales), 0) AS TotalAnimales,
                        ISNULL(SUM(CantidadCarne), 0) AS TotalCarne
                       FROM Carne
                       WHERE Estado = 1 AND Nombre = @n";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int totalAnimales = Convert.ToInt32(dr["TotalAnimales"]);
                            decimal totalCarne = Convert.ToDecimal(dr["TotalCarne"]);
                            return (totalAnimales, totalCarne);
                        }
                    }
                }
                return (0, 0);
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }


        public static (int total, decimal producido) TotalesPorPagina(string nombrePagina)
        {
            int activos = 0;
            int enviadosIndustria = 0;

            try
            {
                ConexionBD.ConectarBD();

                // Animales activos (Estado=1)
                string sqlActivos = @"
                    SELECT COUNT(*)
                    FROM Carne
                    WHERE Nombre = @n AND Estado = 1 AND NumeroAnimal IS NOT NULL
                ";
                using (var cmd = new SqlCommand(sqlActivos, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    activos = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // (Opcional) Producido: cantidad enviada a industria (conteo de envíos)
                string sqlProd = @"
                    SELECT COUNT(*)
                    FROM Carne
                    WHERE Nombre = @n AND FechaEnvioIndustria IS NOT NULL
                ";
                using (var cmd = new SqlCommand(sqlProd, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    enviadosIndustria = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return (activos, (decimal)enviadosIndustria);
        }

    


    public static List<CarneDTO> ListarAnimalesActivos(string nombrePagina)
        {
            List<CarneDTO> lista = new List<CarneDTO>();

            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
            SELECT NumeroAnimal
            FROM Carne
            WHERE Nombre = @nombre
              AND Estado = 1
              AND NumeroAnimal IS NOT NULL
            ORDER BY NumeroAnimal";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombrePagina);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CarneDTO
                            {
                                NumeroAnimal = dr["NumeroAnimal"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar animales activos: " + ex.Message);
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return lista;
        }



    }
}
