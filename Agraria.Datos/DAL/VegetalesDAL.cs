using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
    {
        public class VegetalesDAL
        {
            public static void Insertar(Vegetales entidad)
            {
                try
                {
                    ConexionBD.ConectarBD();
                    string query = @"INSERT INTO Vegetales 
                                (Nombre, CantidadPlantines, Cantidad, FechaCultivo, FechaCosecha, Estado)
                                VALUES (@nombre, @plantines, @cantidad, @cultivo, @cosecha, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                    {
                        cmd.Parameters.AddWithValue("@nombre", entidad.Nombre);
                        cmd.Parameters.AddWithValue("@plantines", entidad.CantidadPlantines);
                        cmd.Parameters.AddWithValue("@cantidad", entidad.Cantidad);
                        cmd.Parameters.AddWithValue("@cultivo", entidad.FechaCultivo);
                        cmd.Parameters.AddWithValue("@cosecha", entidad.FechaCosecha);
                        cmd.Parameters.AddWithValue("@estado", entidad.Estado ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }
                finally { ConexionBD.CierraBD(); }
            }

            public static List<VegetalesDTO> ObtenerPorNombre(string nombre)
            {
                var lista = new List<VegetalesDTO>();
                try
                {
                    ConexionBD.ConectarBD();
                    string query = @"SELECT IdProduccion, Nombre, CantidadPlantines, Cantidad, 
                                        FechaCultivo, FechaCosecha, Estado
                                 FROM Vegetales
                                 WHERE Nombre = @nombre
                                 ORDER BY IdProduccion DESC";

                    using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new VegetalesDTO
                                {
                                    IdProduccion = Convert.ToInt32(dr["IdProduccion"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    CantidadPlantines = Convert.ToInt32(dr["CantidadPlantines"]),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    FechaCultivo = Convert.ToDateTime(dr["FechaCultivo"]),
                                    FechaCosecha = Convert.ToDateTime(dr["FechaCosecha"]),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                });
                            }
                        }
                    }
                }
                finally { ConexionBD.CierraBD(); }
                return lista;
            }

            public static void CambiarEstadoPorNombre(string nombre, bool estado)
            {
                try
                {
                    ConexionBD.ConectarBD();
                    string query = "UPDATE Vegetales SET Estado = @estado WHERE Nombre = @nombre  AND Estado = 1 AND CantidadPlantines > 0 ";

                    using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                    {
                        cmd.Parameters.AddWithValue("@estado", estado ? 1 : 0);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally { ConexionBD.CierraBD(); }
            }
        
    


    public static List<VegetalesDTO> ObtenerTodo()
        {
            var lista = new List<VegetalesDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string query = @"SELECT IdProduccion, CantidadPlantines, Cantidad, FechaCultivo, FechaCosecha, Estado
                                 FROM Vegetales ORDER BY IdProduccion DESC";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new VegetalesDTO
                        {
                            IdProduccion = Convert.ToInt32(dr["IdProduccion"]),
                            CantidadPlantines = Convert.ToInt32(dr["CantidadPlantines"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            FechaCultivo = Convert.ToDateTime(dr["FechaCultivo"]),
                            FechaCosecha = Convert.ToDateTime(dr["FechaCosecha"]),
                            Estado = Convert.ToBoolean(dr["Estado"])
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

        public static void EnviarAIndustria(int cantidad, DateTime fechaEgreso, string nombreVegetal, int idTipoEntorno, string responsable)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");

            try
            {
                ConexionBD.ConectarBD();
                using (SqlTransaction tr = ConexionBD.ConexionSQL.BeginTransaction())
                {
                    try
                    {
                        int restante = cantidad;

                        // ✅ Buscar por Cantidad (cosechados), no CantidadPlantines
                        string selectSql = @"
                    SELECT IdProduccion, Cantidad
                    FROM Vegetales
                    WHERE Estado = 1 AND Nombre = @nombre AND Cantidad > 0
                    ORDER BY FechaCosecha ASC";

                        List<(int id, int cant)> registros = new List<(int, int)>();
                        using (SqlCommand cmdSel = new SqlCommand(selectSql, ConexionBD.ConexionSQL, tr))
                        {
                            cmdSel.Parameters.AddWithValue("@nombre", nombreVegetal);
                            using (SqlDataReader dr = cmdSel.ExecuteReader())
                            {
                                while (dr.Read())
                                    registros.Add((Convert.ToInt32(dr["IdProduccion"]), Convert.ToInt32(dr["Cantidad"])));
                            }
                        }

                        if (registros.Count == 0)
                            throw new Exception("No se encontraron registros activos con cantidad para enviar.");

                        foreach (var reg in registros)
                        {
                            if (restante <= 0) break;

                            int cantidadAUsar = Math.Min(reg.cant, restante);
                            restante -= cantidadAUsar;

                            // ✅ Actualizamos Cantidad y damos de baja si queda en 0
                            string updateSql = @"
                        UPDATE Vegetales
                        SET Estado = CASE 
                                        WHEN Cantidad - @usado <= 0 THEN 0 
                                        ELSE Estado 
                                     END,
                            Cantidad = CASE 
                                        WHEN Cantidad - @usado < 0 THEN 0 
                                        ELSE Cantidad - @usado 
                                     END
                        WHERE IdProduccion = @id";

                            using (SqlCommand cmdUpd = new SqlCommand(updateSql, ConexionBD.ConexionSQL, tr))
                            {
                                cmdUpd.Parameters.AddWithValue("@usado", cantidadAUsar);
                                cmdUpd.Parameters.AddWithValue("@id", reg.id);
                                cmdUpd.ExecuteNonQuery();
                            }
                        }

                        // ✅ Insertamos en Articulo
                        string insertSql = @"
                    INSERT INTO Articulo 
                        (NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado)
                    VALUES 
                        (@nombre, @cantidad, 2, NULL, @fechaIngreso, @idTipoEntorno, @responsable, @fechaEgreso, 1)";

                        using (SqlCommand cmdIns = new SqlCommand(insertSql, ConexionBD.ConexionSQL, tr))
                        {
                            cmdIns.Parameters.AddWithValue("@nombre", nombreVegetal);
                            cmdIns.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdIns.Parameters.AddWithValue("@fechaIngreso", fechaEgreso);
                            cmdIns.Parameters.AddWithValue("@idTipoEntorno", idTipoEntorno);
                            cmdIns.Parameters.AddWithValue("@responsable", responsable ?? (object)DBNull.Value);
                            cmdIns.Parameters.AddWithValue("@fechaEgreso", fechaEgreso);
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



        public static int ObtenerPlantinesActivosPorNombre(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT ISNULL(SUM(CantidadPlantines),0) FROM Vegetales WHERE Estado = 1 AND Nombre = @nombre";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static int ObtenerCantidadActivaPorNombre(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT ISNULL(SUM(Cantidad),0) FROM Vegetales WHERE Estado = 1 AND Nombre = @nombre";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

    }
}
