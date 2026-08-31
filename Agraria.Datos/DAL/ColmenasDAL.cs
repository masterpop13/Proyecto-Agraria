using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DAL
{
    public static class ColmenasDAL
    {
        public static void InsertarIngresoColmenas(string nombre, int cantidad, DateTime fecha)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"INSERT INTO Colmenas
                               (Nombre, CantidadColmenas, FechaIngresoColmenas, Estado)
                               VALUES (@n, @c, @f, 1)";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@c", cantidad);
                cmd.Parameters.AddWithValue("@f", fecha);
                cmd.ExecuteNonQuery();
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static void InsertarIngresoMiel(string nombre, int cantidad, DateTime fecha)
        {
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"INSERT INTO Colmenas
                               (Nombre, CantidadMiel, FechaIngresoMiel, Estado)
                               VALUES (@n, @c, @f, 1)";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@c", cantidad);
                cmd.Parameters.AddWithValue("@f", fecha);
                cmd.ExecuteNonQuery();
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static void EnviarMielAIndustria(string nombre, int cantidad, DateTime fechaEgreso, int idTipoEntorno, string responsable, int idTipoMedida)
        {
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a 0.");

            try
            {
                ConexionBD.ConectarBD();
                using var tr = ConexionBD.ConexionSQL.BeginTransaction();

                // Traer registros con miel activa (Estado=1, CantidadMiel>0)
                var sel = new SqlCommand(@"
SELECT Id, CantidadMiel
FROM Colmenas
WHERE Nombre = @n AND Estado = 1 AND CantidadMiel > 0
ORDER BY FechaIngresoMiel ASC, Id ASC", ConexionBD.ConexionSQL, tr);
                sel.Parameters.AddWithValue("@n", nombre);

                var toConsume = new List<(int Id, int Cant)>();
                using (var dr = sel.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        toConsume.Add((Convert.ToInt32(dr["Id"]), Convert.ToInt32(dr["CantidadMiel"])));
                    }
                }

                int restante = cantidad;
                foreach (var r in toConsume)
                {
                    if (restante <= 0) break;

                    int consumir = Math.Min(r.Cant, restante);

                    // bajar cantidad
                    var upd = new SqlCommand(@"
UPDATE Colmenas
SET CantidadMiel = CantidadMiel - @c,
    Estado = CASE WHEN (CantidadMiel - @c) <= 0 THEN 0 ELSE 1 END
WHERE Id = @id", ConexionBD.ConexionSQL, tr);
                    upd.Parameters.AddWithValue("@c", consumir);
                    upd.Parameters.AddWithValue("@id", r.Id);
                    upd.ExecuteNonQuery();

                    restante -= consumir;
                }

                if (restante > 0)
                {
                    tr.Rollback();
                    throw new Exception("No hay stock suficiente de miel activa para enviar esa cantidad.");
                }

                // Insertar movimiento a Articulo
                var ins = new SqlCommand(@"
INSERT INTO Articulo
(NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado)
VALUES (@nombre, @cantidad, @idTipoMedida, NULL, @fecha, @idEntorno, @resp, @fecha, 1)", ConexionBD.ConexionSQL, tr);
                ins.Parameters.AddWithValue("@nombre", nombre);
                ins.Parameters.AddWithValue("@cantidad", cantidad);
                ins.Parameters.AddWithValue("@idTipoMedida", idTipoMedida);
                ins.Parameters.AddWithValue("@fecha", fechaEgreso);
                ins.Parameters.AddWithValue("@idEntorno", idTipoEntorno);
                ins.Parameters.AddWithValue("@resp", (object?)responsable ?? DBNull.Value);
                ins.ExecuteNonQuery();

                tr.Commit();
            }
            catch
            {
                throw;
            }
            finally { ConexionBD.CierraBD(); }
        }

        // ✅ NUEVO: Obtener lista de registros de Colmenas por nombre (para TotalesColmenas)
        public static List<Colmena> ObtenerPorNombre(string nombre)
        {
            List<Colmena> lista = new List<Colmena>();

            try
            {
                ConexionBD.ConectarBD();

                string sql = @"SELECT Id, Nombre, CantidadColmenas, CantidadRetiradas, CantidadMiel, Estado 
                               FROM Colmenas WHERE Nombre=@n";
                using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@n", nombre);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Colmena
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            CantidadColmenas = Convert.ToInt32(dr["CantidadColmenas"]),
                            CantidadRetiradas = Convert.ToInt32(dr["CantidadRetiradas"]),
                            CantidadMiel = Convert.ToInt32(dr["CantidadMiel"]),
                            Estado = Convert.ToBoolean(dr["Estado"])
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }

            return lista;
        }

        // Lista por Nombre (página)
        public static List<ColmenaDTO> ListarPorNombre(string nombrePagina)
        {
            List<ColmenaDTO> lista = new List<ColmenaDTO>();

            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
            SELECT Id, Nombre, FechaIngresoColmenas, CantidadColmenas,
                   FechaIngresoMiel, CantidadMiel,
                   FechaRetiradas, CantidadRetiradas, Estado
            FROM Colmenas
            WHERE Nombre = @n";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var colmena = new ColmenaDTO
                            {
                                Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                                Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                                CantidadColmenas = dr["CantidadColmenas"] != DBNull.Value ? Convert.ToInt32(dr["CantidadColmenas"]) : 0,
                                FechaIngresoColmenas = dr["FechaIngresoColmenas"] != DBNull.Value ? Convert.ToDateTime(dr["FechaIngresoColmenas"]) : (DateTime?)null,
                                CantidadMiel = dr["CantidadMiel"] != DBNull.Value ? Convert.ToInt32(dr["CantidadMiel"]) : 0,
                                FechaIngresoMiel = dr["FechaIngresoMiel"] != DBNull.Value ? Convert.ToDateTime(dr["FechaIngresoMiel"]) : (DateTime?)null,
                                CantidadRetiradas = dr["CantidadRetiradas"] != DBNull.Value ? Convert.ToInt32(dr["CantidadRetiradas"]) : 0,
                                FechaRetiradas = dr["FechaRetiradas"] != DBNull.Value ? Convert.ToDateTime(dr["FechaRetiradas"]) : (DateTime?)null,
                                Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"])
                            };

                            lista.Add(colmena);
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


        // Totales por página


        // Marcar miel enviada
        public static void MarcarMielEnviada(string nombrePagina, int cantidadAEnviar)
        {
            ConexionBD.ConectarBD();

            string sql = @"
                DECLARE @restante INT = @cant;

                WHILE @restante > 0
                BEGIN
	                DECLARE @id INT, @stock INT;

	                SELECT TOP 1 @id = Id, @stock = ISNULL(CantidadMiel,0)
	                FROM Colmenas
	                WHERE Nombre=@n AND Estado=1 AND ISNULL(CantidadMiel,0) > 0
	                ORDER BY FechaIngresoMiel ASC;

	                IF @id IS NULL BREAK;

	                IF @stock <= @restante
	                BEGIN
		                UPDATE Colmenas
		                SET CantidadMiel = 0, Estado = CASE WHEN CantidadColmenas IS NULL OR CantidadColmenas=0 THEN 0 ELSE Estado END
		                WHERE Id=@id;

		                SET @restante = @restante - @stock;
	                END
	                ELSE
	                BEGIN
		                UPDATE Colmenas
		                SET CantidadMiel = CantidadMiel - @restante
		                WHERE Id=@id;

		                SET @restante = 0;
	                END
                END";
            using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@n", nombrePagina);
                cmd.Parameters.AddWithValue("@cant", cantidadAEnviar);
                cmd.ExecuteNonQuery();
            }
            ConexionBD.CierraBD();
        }

        public static int ObtenerColmenasDisponibles(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"SELECT ISNULL(SUM(CantidadColmenas), 0)
                       FROM Colmenas
                       WHERE Nombre = @n AND Estado = 1";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    int disponibles = Convert.ToInt32(cmd.ExecuteScalar());
                    return disponibles;
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static int ObtenerTotalesActivos(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"
            SELECT 
                ISNULL(SUM(CantidadColmenas), 0) AS TotalColmenas,
                ISNULL(SUM(CantidadRetiradas), 0) AS TotalRetiradas
            FROM Colmenas
            WHERE Nombre = @n AND Estado = 1";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int colmenas = Convert.ToInt32(dr["TotalColmenas"]);
                            int retiradas = Convert.ToInt32(dr["TotalRetiradas"]);
                            return colmenas - retiradas;
                        }
                    }
                }

                return 0;
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static void InsertarRetiroColmenas(string nombre, int cantidad, DateTime fecha)
        {
            try
            {
                ConexionBD.ConectarBD();

                string sql = @"INSERT INTO Colmenas
                       (Nombre, CantidadRetiradas, FechaRetiradas, Estado)
                       VALUES (@n, @c, @f, 1)";
                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.Parameters.AddWithValue("@c", cantidad);
                    cmd.Parameters.AddWithValue("@f", fecha);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

            public static (int colmenas, int miel) TotalesPorPagina(string nombrePagina)
        {
            int colmenasActivas = 0;
            int mielActiva = 0;

            try
            {
                ConexionBD.ConectarBD();

                // Colmenas activas = SUM(Colmenas) - SUM(Retiradas) con Estado=1
                string sqlCol = @"
                    SELECT ISNULL(SUM(CantidadColmenas),0) - ISNULL(SUM(CantidadRetiradas),0)
                    FROM Colmenas
                    WHERE Nombre = @n AND Estado = 1
                ";
                using (var cmd = new SqlCommand(sqlCol, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    colmenasActivas = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Miel disponible (activa)
                string sqlMiel = @"
                    SELECT ISNULL(SUM(CantidadMiel),0)
                    FROM Colmenas
                    WHERE Nombre = @n AND Estado = 1
                ";
                using (var cmd = new SqlCommand(sqlMiel, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@n", nombrePagina);
                    mielActiva = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            if (colmenasActivas < 0) colmenasActivas = 0; // por seguridad
            return (colmenasActivas, mielActiva);
        }



    
    }
}
