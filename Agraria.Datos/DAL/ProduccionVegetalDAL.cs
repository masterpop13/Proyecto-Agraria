using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Agraria.Datos.Entidades;
using Agraria.Datos.DTO;

namespace Agraria.Datos.DAL
{
    public class ProduccionVegetalDAL
    {
        public static void Insertar(ProduccionVegetal prod)
        {
            try
            {
                ConexionBD.ConectarBD();

                string query = @"INSERT INTO ProduccionVegetal 
                         (CantidadPlantines, FechaCultivo, FechaCosecha, CantidadAtados, Estado)
                         VALUES (@plantines, @cultivo, @cosecha, @atados, @estado)";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@plantines", prod.CantidadPlantines);
                    cmd.Parameters.AddWithValue("@cultivo", prod.FechaCultivo);
                    cmd.Parameters.AddWithValue("@cosecha", prod.FechaCosecha);
                    cmd.Parameters.AddWithValue("@atados", prod.CantidadAtados);
                    cmd.Parameters.AddWithValue("@estado", prod.Estado ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }


        public static List<ProduccionVegetalDTO> ObtenerTodo()
        {
            var lista = new List<ProduccionVegetalDTO>();
            try
            {
                ConexionBD.ConectarBD();


                string query = @"SELECT IdProduccion, CantidadPlantines, FechaCultivo, FechaCosecha, CantidadAtados, Estado
                 FROM ProduccionVegetal
                 ORDER BY IdProduccion DESC";


                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ProduccionVegetalDTO
                        {
                            IdProduccion = Convert.ToInt32(dr["IdProduccion"]),
                            CantidadPlantines = Convert.ToInt32(dr["CantidadPlantines"]),
                            FechaCultivo = Convert.ToDateTime(dr["FechaCultivo"]),   
                            FechaCosecha = Convert.ToDateTime(dr["FechaCosecha"]),
                            CantidadAtados = Convert.ToInt32(dr["CantidadAtados"]),
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

        public static int SumarPlantinesActivos()
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT ISNULL(SUM(CantidadPlantines),0) FROM ProduccionVegetal WHERE Estado = 1";
                using (SqlCommand cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static int SumarAtadosActivos()
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT ISNULL(SUM(CantidadAtados),0) FROM ProduccionVegetal WHERE Estado = 1";
                using (SqlCommand cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static List<int> ObtenerCantidadesAtadosDistinct()
        {
            var lista = new List<int>();
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT DISTINCT CantidadAtados FROM ProduccionVegetal WHERE Estado = 1 ORDER BY CantidadAtados";
                using (SqlCommand cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(Convert.ToInt32(dr["CantidadAtados"]));
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
            return lista;
        }

        /// <summary>
        /// Marca como Estado = 0 (enviado) tantas filas (completas) como sea necesario
        /// para cubrir la cantidad de atados solicitada. Luego inserta un Articulo en inventario.
        /// Nota: este método marca registros completos; no "partea" un registro.
        /// </summary>
        public static void EnviarAIndustria(int cantidadAtados, DateTime fechaEgreso, int idTipoEntorno = 2, string responsable = "Producción Vegetal")
        {
            if (cantidadAtados <= 0) throw new ArgumentException("Cantidad debe ser mayor a 0.");

            try
            {
                ConexionBD.ConectarBD();
                using (SqlTransaction tr = ConexionBD.ConexionSQL.BeginTransaction())
                {
                    try
                    {
                        int idProduccion = 0;

                        // 🔹 Buscar automáticamente el primer registro activo
                        using (SqlCommand cmdSel = new SqlCommand(
                            "SELECT TOP 1 IdProduccion FROM ProduccionVegetal WHERE Estado = 1 ORDER BY FechaCosecha ASC",
                            ConexionBD.ConexionSQL, tr))
                        {
                            object result = cmdSel.ExecuteScalar();
                            if (result == null)
                                throw new Exception("No se encontró registro activo para actualizar.");

                            idProduccion = Convert.ToInt32(result);
                        }

                        // 🔹 Dar de baja ese registro
                        using (SqlCommand cmdUpd = new SqlCommand("UPDATE ProduccionVegetal SET Estado = 0 WHERE IdProduccion = @id", ConexionBD.ConexionSQL, tr))
                        {
                            cmdUpd.Parameters.AddWithValue("@id", idProduccion);
                            cmdUpd.ExecuteNonQuery();
                        }

                        // 🔹 Insertar en Articulo
                        string insertArticulo = @"
                    INSERT INTO Articulo 
                        (NombreProducto, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, Responsable, FechaEgreso, Estado)
                    VALUES 
                        (@nombre, @cantidad, 2, NULL, @fechaIngreso, @idTipoEntorno, @responsable, @fechaEgreso, 1)";

                        using (SqlCommand cmdIns = new SqlCommand(insertArticulo, ConexionBD.ConexionSQL, tr))
                        {
                            cmdIns.Parameters.AddWithValue("@nombre", "Acelga");
                            cmdIns.Parameters.AddWithValue("@cantidad", cantidadAtados);
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


        /// <summary>
        /// Busca un registro con Estado = 1 (activo). 
        /// Si su CantidadPlantines > 0 lo marca Estado = 0 y retorna true.
        /// Si no hay registro activo o CantidadPlantines == 0 retorna false.
        /// </summary>
        public static bool ResetearPlantinesActivos()
        {
            try
            {
                ConexionBD.ConectarBD();

                // 1) Obtener un registro activo (TOP 1)
                string sel = "SELECT TOP 1 IdProduccion, CantidadPlantines FROM ProduccionVegetal WHERE Estado = 1";
                int id = 0;
                int cantidad = 0;

                using (SqlCommand cmd = new SqlCommand(sel, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        // No hay registros activos
                        return false;
                    }

                    id = Convert.ToInt32(dr["IdProduccion"]);
                    cantidad = Convert.ToInt32(dr["CantidadPlantines"]);
                }

                // 2) Si cantidad <= 0 -> no hacer nada
                if (cantidad <= 0)
                    return false;

                // 3) Dar de baja ese registro (Estado = 0)
                string upd = "UPDATE ProduccionVegetal SET Estado = 0 WHERE IdProduccion = @id";
                using (SqlCommand cmdUpd = new SqlCommand(upd, ConexionBD.ConexionSQL))
                {
                    cmdUpd.Parameters.AddWithValue("@id", id);
                    cmdUpd.ExecuteNonQuery();
                }

                return true;
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }
    }
}
