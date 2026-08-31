using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DAL
{
    public class EntornoFormativoDAL
    {
        public List<EntornoFormativoDTO> ObtenerEntornos()
        {
            var lista = new List<EntornoFormativoDTO>();

            try
            {
                ConexionBD.ConectarBD();

                string query = @"SELECT e.IdEntorno, e.Nombre, t.Nombre AS TipoEntorno, 
                                        e.Responsable, e.Año, e.Division, e.Grupo, e.Fecha, e.Observaciones
                                 FROM Entorno e
                                 INNER JOIN TipoEntorno t ON e.IdTipoEntorno = t.IdTipoEntorno";

                SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new EntornoFormativoDTO
                    {
                        IdEntorno = Convert.ToInt32(reader["IdEntorno"]),
                        Nombre = reader["Nombre"].ToString(),
                        IdTipoEntorno = reader["TipoEntorno"].ToString(),
                        Responsable = reader["Responsable"].ToString(),
                        Año = reader["Año"].ToString(),
                        Division = reader["Division"].ToString(),
                        Grupo = reader["Grupo"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Observaciones = reader["Observaciones"].ToString()
                    });
                }
                reader.Close();
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return lista;
        }

        public void Insertar(EntornoFormativo entorno)
        {
            try
            {
                ConexionBD.ConectarBD();

                string query = @"INSERT INTO Entorno 
                                (Nombre, IdTipoEntorno, Responsable, Año, Division, Grupo, Fecha, Observaciones)
                                VALUES (@nombre, @idTipo, @responsable, @año, @division, @grupo, @fecha, @obs)";

                SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@nombre", entorno.Nombre);
                cmd.Parameters.AddWithValue("@idTipo", entorno.IdTipoEntorno);
                cmd.Parameters.AddWithValue("@responsable", entorno.Responsable);
                cmd.Parameters.AddWithValue("@año", entorno.Año);
                cmd.Parameters.AddWithValue("@division", entorno.Division);
                cmd.Parameters.AddWithValue("@grupo", entorno.Grupo);
                cmd.Parameters.AddWithValue("@fecha", entorno.Fecha);
                cmd.Parameters.AddWithValue("@obs", entorno.Observaciones);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

            public static void Modificar(EntornoFormativo entorno)
            {
                try
                {
                    ConexionBD.ConectarBD();

                    string query = @"UPDATE Entorno 
                                 SET Nombre = @Nombre, 
                                     IdTipoEntorno = @IdTipoEntorno, 
                                     Responsable = @Responsable, 
                                     Año = @Año, 
                                     Division = @Division, 
                                     Grupo = @Grupo, 
                                     Fecha = @Fecha, 
                                     Observaciones = @Observaciones
                                 WHERE IdEntorno = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                    {
                        cmd.Parameters.AddWithValue("@Id", entorno.IdEntorno);
                        cmd.Parameters.AddWithValue("@Nombre", entorno.Nombre);
                        cmd.Parameters.AddWithValue("@IdTipoEntorno", entorno.IdTipoEntorno);
                        cmd.Parameters.AddWithValue("@Responsable", entorno.Responsable);
                        cmd.Parameters.AddWithValue("@Año", entorno.Año);
                        cmd.Parameters.AddWithValue("@Division", entorno.Division);
                        cmd.Parameters.AddWithValue("@Grupo", entorno.Grupo);
                        cmd.Parameters.AddWithValue("@Fecha", entorno.Fecha);
                        cmd.Parameters.AddWithValue("@Observaciones", entorno.Observaciones);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al modificar el entorno: " + ex.Message);
                }
                finally
                {
                    ConexionBD.CierraBD();
                }
            }

        public static DataTable ObtenerTipoEntornos()
        {
            try
            {
                ConexionBD.ConectarBD();

                string query = "SELECT IdTipoEntorno, Nombre FROM TipoEntorno";
                SqlDataAdapter da = new SqlDataAdapter(query, ConexionBD.ConexionSQL);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

    }
}
