using Agraria.Datos.DTO;
using Agraria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public static class EngordeDAL
    {
        public static void GuardarIngresoPollos(string nombre, int idBox, DateTime fechaIngreso, int cantidad)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"INSERT INTO Engorde (IdBox, Nombre, FechaIngreso, Cantidad, Estado)
                               VALUES (@idBox, @n, @f, @c, 1)";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@idBox", idBox);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@f", fechaIngreso);
                cmd.Parameters.AddWithValue("@c", cantidad);
                cmd.ExecuteNonQuery();
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static void GuardarRegistroEngorde(string nombre, int idBox, DateTime fechaActualizado,
                                                  int cantidad, int semanas, decimal peso,
                                                  int idAlimento, decimal alimentoDia)
        {
            try
            {
                ConexionBD.ConectarBD();
                // Si preferís UPDATE sobre el último activo:
                // Se inserta un nuevo “snapshot” de estado (histórico simple).
                string sql = @"INSERT INTO Engorde
                               (IdBox, Nombre, FechaActualizado, Cantidad, Semanas, Peso, IdAlimento, AlimentoPorDia, Estado)
                               VALUES (@idBox, @n, @f, @c, @s, @p, @idAli, @alimDia, 1)";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@idBox", idBox);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@f", fechaActualizado);
                cmd.Parameters.AddWithValue("@c", cantidad);
                cmd.Parameters.AddWithValue("@s", semanas);
                cmd.Parameters.AddWithValue("@p", peso);
                cmd.Parameters.AddWithValue("@idAli", idAlimento);
                cmd.Parameters.AddWithValue("@alimDia", alimentoDia);
                cmd.ExecuteNonQuery();
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static List<EngordeDTO> Listar(string nombrePagina)
        {
            var lista = new List<EngordeDTO>();
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
SELECT e.IdEngorde,
       b.Nombre AS NombreBox,
       e.Nombre,
       e.FechaIngreso,
       e.Cantidad,
       e.FechaActualizado,
       e.Semanas,
       e.Peso,
       a.Nombre AS NombreAlimento,
       e.AlimentoPorDia,
       e.Estado
FROM Engorde e
INNER JOIN Box b ON e.IdBox = b.IdBox
LEFT JOIN Alimento a ON e.IdAlimento = a.IdAlimento
WHERE e.Nombre = @nombre
ORDER BY e.IdEngorde DESC";

                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@nombre", nombrePagina);

                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new EngordeDTO
                    {
                        IdEngorde = Convert.ToInt32(dr["IdEngorde"]),
                        NombreBox = dr["NombreBox"]?.ToString() ?? "",
                        Nombre = dr["Nombre"]?.ToString() ?? "",
                        FechaIngreso = dr["FechaIngreso"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaIngreso"]),
                        Cantidad = dr["Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Cantidad"]),
                        FechaActualizado = dr["FechaActualizado"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaActualizado"]),
                        Semanas = dr["Semanas"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Semanas"]),
                        Peso = dr["Peso"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Peso"]),
                        NombreAlimento = dr["NombreAlimento"]?.ToString() ?? "",
                        AlimentoPorDia = dr["AlimentoPorDia"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["AlimentoPorDia"]),
                        Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"])
                    });
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return lista;
        }

        public static List<EngordeDTO> BuscarPorBox(int idBox)
        {
            var lista = new List<EngordeDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
SELECT e.IdEngorde,
       b.Nombre AS NombreBox,
       e.Nombre,
       e.FechaIngreso,
       e.Cantidad,
       e.FechaActualizado,
       e.Semanas,
       e.Peso,
       a.Nombre AS NombreAlimento,
       e.AlimentoPorDia,
       e.Estado
FROM Engorde e
INNER JOIN Box b ON e.IdBox = b.IdBox
LEFT JOIN Alimento a ON e.IdAlimento = a.IdAlimento
WHERE e.IdBox = @idBox
ORDER BY e.IdEngorde DESC";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@idBox", idBox);
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new EngordeDTO
                    {
                        IdEngorde = Convert.ToInt32(dr["IdEngorde"]),
                        NombreBox = dr["NombreBox"]?.ToString() ?? "",
                        Nombre = dr["Nombre"]?.ToString() ?? "",
                        FechaIngreso = dr["FechaIngreso"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaIngreso"]),
                        Cantidad = dr["Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Cantidad"]),
                        FechaActualizado = dr["FechaActualizado"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaActualizado"]),
                        Semanas = dr["Semanas"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Semanas"]),
                        Peso = dr["Peso"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Peso"]),
                        NombreAlimento = dr["NombreAlimento"]?.ToString() ?? "",
                        AlimentoPorDia = dr["AlimentoPorDia"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["AlimentoPorDia"]),
                        Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"])
                    });
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        public static int ObtenerUltimaCantidadDisponible(int idBox)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
            SELECT TOP 1 Cantidad
            FROM Engorde
            WHERE IdBox = @idBox AND Estado = 1
            ORDER BY IdEngorde DESC";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@idBox", idBox);
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

      

        public static void MarcarComoInactivo(int idBox)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"UPDATE Engorde SET Estado = 0 WHERE IdBox = @idBox AND Estado = 1";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@idBox", idBox);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }


      
        // Listar Engorde por Nombre (página)
        public static DataTable ListarPorNombre(string nombrePagina)
        {
            ConexionBD.ConectarBD();
            var dt = new DataTable();
            string sql = @"
                SELECT e.IdEngorde, b.Nombre AS NombreBox, e.Nombre, e.FechaIngreso, e.Cantidad,
                       e.FechaActualizado, e.Semanas, e.Peso, a.Nombre AS NombreAlimento,
                       e.AlimentoPorDia, e.Estado
                FROM Engorde e
                LEFT JOIN Box b ON b.IdBox = e.IdBox
                LEFT JOIN Alimento a ON a.IdAlimento = e.IdAlimento
                WHERE e.Nombre = @n";
            using (var da = new SqlDataAdapter(sql, ConexionBD.ConexionSQL))
            {
                da.SelectCommand.Parameters.AddWithValue("@n", nombrePagina);
                da.Fill(dt);
            }
            ConexionBD.CierraBD();
            return dt;
        }

        // Totales Engorde por página
        // totalActual = SUM(Cantidad) con FechaIngreso y Estado=1
        // totalProducido = Cantidad del último registro con FechaActualizado y Estado=1
       
        public static (int total, decimal producido) TotalesEngorde(string nombrePagina)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"SELECT 
                        ISNULL(SUM(CantidadAnimales), 0) AS TotalAnimales,
                        ISNULL(SUM(PesoActual), 0) AS TotalPeso
                       FROM Engorde
                       WHERE Estado = 1 AND Nombre = @n";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int totalAnimales = Convert.ToInt32(dr["TotalAnimales"]);
                            decimal totalPeso = Convert.ToDecimal(dr["TotalPeso"]);
                            return (totalAnimales, totalPeso);
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
            int totalActual = 0;
            int totalProducido = 0;

            try
            {
                ConexionBD.ConectarBD();

                // Actual: SUM(Cantidad) con Estado=1 y FechaIngreso no nula
                string sqlTotal = @"
                    SELECT ISNULL(SUM(Cantidad),0)
                    FROM Engorde
                    WHERE Nombre = @n AND Estado = 1 AND FechaIngreso IS NOT NULL
                ";
                using (var cmd = new SqlCommand(sqlTotal, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    totalActual = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Producido: SUM(Cantidad) con Estado=1 y FechaActualizado no nula
                string sqlProd = @"
                    SELECT ISNULL(SUM(Cantidad),0)
                    FROM Engorde
                    WHERE Nombre = @n AND Estado = 1 AND FechaActualizado IS NOT NULL
                ";
                using (var cmd = new SqlCommand(sqlProd, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    totalProducido = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return (totalActual, (decimal)totalProducido);
        }

    }
}
