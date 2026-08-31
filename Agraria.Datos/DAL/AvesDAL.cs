using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Agraria.Datos.Entidades;
using Agraria.Datos.DTO;

namespace Agraria.Datos.DAL
{
    public static class AvesDAL
    {
        public static void InsertIngresoAves(string nombre, int cantidad, DateTime fecha)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
INSERT INTO Aves (Nombre, CantidadAves, FechaIngresoAves, CantidadHuevos, CantidadRetiradas)
VALUES (@n, @c, @f, 0, 0)";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@c", cantidad);
                cmd.Parameters.AddWithValue("@f", fecha);
                cmd.ExecuteNonQuery();
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static void InsertHuevos(string nombre, int huevos, DateTime fecha)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
INSERT INTO Aves (Nombre, CantidadAves, FechaIngresoAves, CantidadHuevos, FechaIngresoHuevos, CantidadRetiradas)
VALUES (@n, 0, NULL, @h, @f, 0)";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@h", huevos);
                cmd.Parameters.AddWithValue("@f", fecha);
                cmd.ExecuteNonQuery();
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static void InsertRetiroAves(string nombre, int retiradas, DateTime fecha)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
INSERT INTO Aves (Nombre, CantidadAves, FechaIngresoAves, CantidadHuevos, CantidadRetiradas, FechaRetiradas)
VALUES (@n, 0, NULL, 0, @r, @f)";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@r", retiradas);
                cmd.Parameters.AddWithValue("@f", fecha);
                cmd.ExecuteNonQuery();
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static List<AvesDTO> ListarPorNombre(string nombre)
        {
            var lista = new List<AvesDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
SELECT Id, Nombre, CantidadAves, FechaIngresoAves,
       CantidadHuevos, FechaIngresoHuevos,
       CantidadRetiradas, FechaRetiradas,
       Estado
FROM Aves
WHERE Nombre = @n
ORDER BY Id DESC";

                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);

                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new AvesDTO
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString() ?? "",
                        CantidadAves = dr["CantidadAves"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadAves"]),
                        FechaIngresoAves = dr["FechaIngresoAves"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaIngresoAves"]),
                        CantidadHuevos = dr["CantidadHuevos"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadHuevos"]),
                        FechaIngresoHuevos = dr["FechaIngresoHuevos"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaIngresoHuevos"]),
                        CantidadRetiradas = dr["CantidadRetiradas"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadRetiradas"]),
                        FechaRetiradas = dr["FechaRetiradas"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaRetiradas"]),
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


        public static (int totalAvesActuales, int totalHuevos) ObtenerTotalesPorNombre(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
SELECT 
    ISNULL(SUM(CantidadAves),0) AS Ingresadas,
    ISNULL(SUM(CantidadRetiradas),0) AS Retiradas,
    ISNULL(SUM(CantidadHuevos),0) AS Huevos
FROM Aves
WHERE Nombre = @n AND Estado = 1";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);
                using var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ingresadas = Convert.ToInt32(dr["Ingresadas"]);
                    int retiradas = Convert.ToInt32(dr["Retiradas"]);
                    int huevos = Convert.ToInt32(dr["Huevos"]);
                    return (ingresadas - retiradas, huevos);
                }
                return (0, 0);
            }
            finally { ConexionBD.CierraBD(); }
        }
        public static void EnviarHuevosAIndustria(string nombreProducto, int cantidad, DateTime fecha, int idTipoEntorno, string responsable, int idTipoMedida = 2)
        {
            if (cantidad <= 0)
                throw new ArgumentException("Cantidad debe ser mayor a 0.");

            try
            {
                ConexionBD.ConectarBD();

                // 🔹 Verificar si hay huevos disponibles
                string sqlCheck = "SELECT ISNULL(SUM(CantidadHuevos),0) FROM Aves WHERE Nombre = @n AND Estado = 1";
                using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, ConexionBD.ConexionSQL))
                {
                    cmdCheck.Parameters.AddWithValue("@n", nombreProducto);
                    int huevosDisponibles = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (huevosDisponibles <= 0)
                        throw new Exception("No hay huevos disponibles para enviar.");

                    if (cantidad > huevosDisponibles)
                        throw new Exception($"Cantidad a enviar ({cantidad}) supera los huevos disponibles ({huevosDisponibles}).");
                }

                using (SqlTransaction tr = ConexionBD.ConexionSQL.BeginTransaction())
                {
                    try
                    {
                        // 🔹 Insertar en Articulo (no tocamos aves)
                        string insertArticulo = @"
                INSERT INTO Articulo
                    (NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado)
                VALUES
                    (@nombre, @cantidad, @idTipoMedida, NULL, @fechaIngreso, @idTipoEntorno, @responsable, @fechaEgreso, 1)";
                        using (SqlCommand cmd = new SqlCommand(insertArticulo, ConexionBD.ConexionSQL, tr))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                            cmd.Parameters.AddWithValue("@cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@idTipoMedida", idTipoMedida);
                            cmd.Parameters.AddWithValue("@fechaIngreso", fecha);
                            cmd.Parameters.AddWithValue("@idTipoEntorno", idTipoEntorno);
                            cmd.Parameters.AddWithValue("@responsable", (object?)responsable ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@fechaEgreso", fecha);
                            cmd.ExecuteNonQuery();
                        }

                        // 🔹 Restar cantidad de huevos sin tocar CantidadAves
                        string sqlUpdate = @"
                    DECLARE @restante INT = @cantidad;

                    -- Recorremos huevos activos
                    WHILE @restante > 0
                    BEGIN
                        DECLARE @id INT, @stock INT;

                        SELECT TOP 1 @id = Id, @stock = CantidadHuevos
                        FROM Aves
                        WHERE Nombre=@n AND Estado=1 AND CantidadHuevos>0
                        ORDER BY FechaIngresoHuevos ASC;

                        IF @id IS NULL BREAK;

                        IF @stock <= @restante
                        BEGIN
                            UPDATE Aves
                            SET CantidadHuevos = 0, Estado = 0
                            WHERE Id = @id;
                            SET @restante = @restante - @stock;
                        END
                        ELSE
                        BEGIN
                            UPDATE Aves
                            SET CantidadHuevos = CantidadHuevos - @restante
                            WHERE Id = @id;
                            SET @restante = 0;
                        END
                    END
                ";

                        using (SqlCommand cmdUpd = new SqlCommand(sqlUpdate, ConexionBD.ConexionSQL, tr))
                        {
                            cmdUpd.Parameters.AddWithValue("@n", nombreProducto);
                            cmdUpd.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdUpd.ExecuteNonQuery();
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
            finally { ConexionBD.CierraBD(); }
        }

        public static int ObtenerTotalHuevosActivos(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = "SELECT ISNULL(SUM(CantidadHuevos),0) FROM Aves WHERE Nombre = @n AND Estado = 1";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static (int total, int huevos) TotalesHuevos(string nombrePagina)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"SELECT 
                        ISNULL(SUM(CantidadGallinas), 0) AS TotalGallinas,
                        ISNULL(SUM(CantidadHuevos), 0) AS TotalHuevos
                       FROM Aves
                       WHERE Estado = 1 AND Nombre = @n";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int totalGallinas = Convert.ToInt32(dr["TotalGallinas"]);
                            int totalHuevos = Convert.ToInt32(dr["TotalHuevos"]);
                            return (totalGallinas, totalHuevos);
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

        public static (int total, int huevos) TotalesPorPagina(string nombrePagina)
        {
            int totalAves = 0;
            int totalHuevos = 0;

            try
            {
                ConexionBD.ConectarBD();

                // Aves activas
                string sqlAves = @"
                    SELECT ISNULL(SUM(CantidadAves), 0)
                    FROM Aves
                    WHERE Nombre = @n AND (Estado = 1 OR Estado IS NULL)
                ";
                using (var cmd = new SqlCommand(sqlAves, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    totalAves = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Huevos producidos (registros activos)
                string sqlHuevos = @"
                    SELECT ISNULL(SUM(CantidadHuevos), 0)
                    FROM Aves
                    WHERE Nombre = @n AND (Estado = 1 OR Estado IS NULL)
                ";
                using (var cmd = new SqlCommand(sqlHuevos, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    totalHuevos = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return (totalAves, totalHuevos);
        }

    }
}
