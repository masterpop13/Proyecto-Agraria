using Agraria.DTO;
using Agraria.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public static class LecheDAL
    {
        public static void Insertar(Leche leche)
        {
            ConexionBD.ConectarBD();

            string query = @"
                INSERT INTO Leche (Nombre, NumeroAnimal, FechaIngreso, Sexo, FechaOrdeñe, LitrosLeche, FechaFallecido, Estado)
                VALUES (@Nombre, @NumeroAnimal, @FechaIngreso, @Sexo, @FechaOrdeñe, @LitrosLeche, @FechaFallecido, @Estado)";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@Nombre", leche.Nombre);
                cmd.Parameters.AddWithValue("@NumeroAnimal", leche.NumeroAnimal);
                cmd.Parameters.AddWithValue("@FechaIngreso", (object)leche.FechaIngreso ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Sexo", (object)leche.Sexo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaOrdeñe", (object)leche.FechaOrdeñe ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LitrosLeche", (object)leche.LitrosLeche ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFallecido", (object)leche.FechaFallecido ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", leche.Estado);
                cmd.ExecuteNonQuery();
            }

            ConexionBD.CierraBD();
        }
        public static List<LecheDTO> Listar(string nombrePagina)
        {
            List<LecheDTO> lista = new List<LecheDTO>();

            try
            {
                ConexionBD.ConectarBD();

                string query = "SELECT * FROM Leche WHERE Nombre = @nombre";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombrePagina);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LecheDTO leche = new LecheDTO
                            {
                                IdLeche = dr["IdLeche"] != DBNull.Value ? Convert.ToInt32(dr["IdLeche"]) : 0,
                                Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                                NumeroAnimal = dr["NumeroAnimal"] != DBNull.Value ? dr["NumeroAnimal"].ToString() : string.Empty,
                                Sexo = dr["Sexo"] != DBNull.Value ? dr["Sexo"].ToString() : string.Empty,
                                FechaIngreso = dr["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(dr["FechaIngreso"]) : (DateTime?)null,
                                FechaOrdeñe = dr["FechaOrdeñe"] != DBNull.Value ? Convert.ToDateTime(dr["FechaOrdeñe"]) : (DateTime?)null,
                                LitrosLeche = dr["LitrosLeche"] != DBNull.Value ? Convert.ToDecimal(dr["LitrosLeche"]) : (decimal?)null,
                                FechaFallecido = dr["FechaFallecido"] != DBNull.Value ? Convert.ToDateTime(dr["FechaFallecido"]) : (DateTime?)null,
                                Estado = dr["Estado"] != DBNull.Value ? Convert.ToBoolean(dr["Estado"]) : false
                            };

                            lista.Add(leche);
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


        public static void ActualizarEstado(string numeroAnimal, bool nuevoEstado, DateTime fechaFallecido)
        {
            ConexionBD.ConectarBD();
            string query = @"
                UPDATE Leche 
                SET Estado = @Estado, FechaFallecido = @FechaFallecido 
                WHERE NumeroAnimal = @NumeroAnimal";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@NumeroAnimal", numeroAnimal);
                cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@FechaFallecido", fechaFallecido);
                cmd.ExecuteNonQuery();
            }

            ConexionBD.CierraBD();
        }

        public static DataTable BuscarPorNumeroAnimal(string numero, string nombrePagina)
        {
            ConexionBD.ConectarBD();
            DataTable dt = new DataTable();

            string query = "SELECT * FROM Leche WHERE NumeroAnimal LIKE '%' + @Numero + '%' AND Nombre = @nombre";
            using (SqlDataAdapter da = new SqlDataAdapter(query, ConexionBD.ConexionSQL))
            {
                da.SelectCommand.Parameters.AddWithValue("@Numero", numero);
                da.SelectCommand.Parameters.AddWithValue("@nombre", nombrePagina);
                da.Fill(dt);
            }

            ConexionBD.CierraBD();
            return dt;
        }


        public static void MarcarEnviados(string nombrePagina)
        {
            ConexionBD.ConectarBD();

            string query = @"
        UPDATE Leche
        SET Estado = 0
        WHERE Nombre = @nombre 
          AND Estado = 1 
          AND ISNULL(LitrosLeche, 0) > 0";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@nombre", nombrePagina);
                cmd.ExecuteNonQuery();
            }

            ConexionBD.CierraBD();
        }


        public static (int total, decimal litros) TotalesLeche(string nombrePagina)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"SELECT 
                        ISNULL(SUM(CantidadVacas), 0) AS TotalVacas,
                        ISNULL(SUM(CantidadLitros), 0) AS TotalLitros
                       FROM Leche
                       WHERE Estado = 1 AND Nombre = @n";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int totalVacas = Convert.ToInt32(dr["TotalVacas"]);
                            decimal totalLitros = Convert.ToDecimal(dr["TotalLitros"]);
                            return (totalVacas, totalLitros);
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

        public static (int total, decimal litros) TotalesPorPagina(string nombrePagina)
        {
            int animalesActivos = 0;
            decimal litros = 0m;

            try
            {
                ConexionBD.ConectarBD();

                // Animales activos: COUNT DISTINCT por NumeroAnimal
                string sqlAnimales = @"
                    SELECT COUNT(DISTINCT NumeroAnimal)
                    FROM Leche
                    WHERE Nombre = @n AND Estado = 1 AND NumeroAnimal IS NOT NULL
                ";
                using (var cmd = new SqlCommand(sqlAnimales, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    animalesActivos = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Litros producidos: SUM(LitrosLeche) activos
                string sqlLitros = @"
                    SELECT ISNULL(SUM(LitrosLeche), 0)
                    FROM Leche
                    WHERE Nombre = @n AND Estado = 1 AND LitrosLeche IS NOT NULL
                ";
                using (var cmd = new SqlCommand(sqlLitros, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    var v = cmd.ExecuteScalar();
                    litros = v == null || v == DBNull.Value ? 0m : Convert.ToDecimal(v);
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return (animalesActivos, litros);
        }

    }
}
