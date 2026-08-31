using Agraria.Datos.DTO;
using Agraria.Entidades;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public class UsuarioLoginDAL
    {
        public UsuarioLoginDTO? Login(string nombreUsuario, string contraseña)
        {
            UsuarioLoginDTO? usuario = null;

            try
            {
                ConexionBD.ConectarBD();

                string query = @"
                    SELECT 
                        u.Id, 
                        u.NombreUsuario, 
                        u.Contraseña, 
                        u.Estado,
                        p.PuedeEntornoFormativo,
                        p.PuedeAltaUsuario,
                        p.PuedeVenta,
                        p.PuedeInventario,
                        p.PuedeIndustria,
                        p.PuedeProduccionAnimal,
                        p.PuedeProduccionVegetal,
                        p.PuedeAdministracion
                    FROM AbmUsuario u
                    LEFT JOIN PermisosUsuario p ON u.Id = p.IdUsuario
                    WHERE u.NombreUsuario = @usuario 
                    AND u.Contraseña = @pass 
                    AND u.Estado = 1";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@pass", contraseña);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new UsuarioLoginDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreUsuario = reader["NombreUsuario"]?.ToString() ?? string.Empty,
                                Contraseña = reader["Contraseña"]?.ToString() ?? string.Empty,
                                Estado = Convert.ToBoolean(reader["Estado"]),

                                // 🔸 Ahora cargamos los permisos
                                PuedeEntornoFormativo = reader["PuedeEntornoFormativo"] != DBNull.Value && (bool)reader["PuedeEntornoFormativo"],
                                PuedeAltaUsuario = reader["PuedeAltaUsuario"] != DBNull.Value && (bool)reader["PuedeAltaUsuario"],
                                PuedeVenta = reader["PuedeVenta"] != DBNull.Value && (bool)reader["PuedeVenta"],
                                PuedeInventario = reader["PuedeInventario"] != DBNull.Value && (bool)reader["PuedeInventario"],
                                PuedeIndustria = reader["PuedeIndustria"] != DBNull.Value && (bool)reader["PuedeIndustria"],
                                PuedeProduccionAnimal = reader["PuedeProduccionAnimal"] != DBNull.Value && (bool)reader["PuedeProduccionAnimal"],
                                PuedeProduccionVegetal = reader["PuedeProduccionVegetal"] != DBNull.Value && (bool)reader["PuedeProduccionVegetal"],
                                PuedeAdministracion = reader["PuedeAdministracion"] != DBNull.Value && (bool)reader["PuedeAdministracion"]
                            };
                        }
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }

            return usuario;
        }

        public bool ActualizarContraseña(UsuarioLogin usuario)
        {
            try
            {
                ConexionBD.ConectarBD();

                string query = "UPDATE AbmUsuario SET Contraseña = @nueva WHERE NombreUsuario = @usuario";
                SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@nueva", usuario.Contraseña);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public bool ValidarPreguntaSeguridad(UsuarioLogin usuario)
        {
            try
            {
                ConexionBD.ConectarBD();

                string query = @"SELECT COUNT(*) 
                                 FROM AbmUsuario
                                 WHERE NombreUsuario = @usuario 
                                 AND IdPreguntaSeguridad = @idPregunta
                                 AND RespuestaSeguridad = @respuesta";

                SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
                cmd.Parameters.AddWithValue("@usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@idPregunta", usuario.IdPreguntaSeguridad);
                cmd.Parameters.AddWithValue("@respuesta", usuario.RespuestaSeguridad);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }
    }
}
