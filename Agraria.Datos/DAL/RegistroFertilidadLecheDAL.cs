using Agraria.Datos.DTO;
using Agraria.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public static class RegistroFertilidadLecheDAL
    {
        public static void Insertar(RegistroFertilidadLeche registro)
        {
            ConexionBD.ConectarBD();

            string query = @"
                INSERT INTO RegistroFertilidadLeche 
                (Nombre, NumeroMadre, NumeroPadre, FechaMonta, FechaParto, IdTipo, CantidadHembras, CantidadMachos, TotalNacidos, Estado)
                VALUES 
                (@Nombre, @NumeroMadre, @NumeroPadre, @FechaMonta, @FechaParto, @IdTipo, @CantidadHembras, @CantidadMachos, @TotalNacidos, @Estado)";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@Nombre", registro.Nombre);
                cmd.Parameters.AddWithValue("@NumeroMadre", registro.NumeroMadre);
                cmd.Parameters.AddWithValue("@NumeroPadre", registro.NumeroPadre);
                cmd.Parameters.AddWithValue("@FechaMonta", (object)registro.FechaMonta ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaParto", (object)registro.FechaParto ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdTipo", registro.IdTipo);
                cmd.Parameters.AddWithValue("@CantidadHembras", registro.CantidadHembras);
                cmd.Parameters.AddWithValue("@CantidadMachos", registro.CantidadMachos);
                cmd.Parameters.AddWithValue("@TotalNacidos", registro.TotalNacidos);
                cmd.Parameters.AddWithValue("@Estado", registro.Estado);
                cmd.ExecuteNonQuery();
            }

            ConexionBD.CierraBD();
        }

            public static List<RegistroFertilidadLecheDTO> Listar(string nombrePagina)
            {
                List<RegistroFertilidadLecheDTO> lista = new List<RegistroFertilidadLecheDTO>();

                try
                {
                    ConexionBD.ConectarBD();

                    string query = @"
                SELECT 
                    r.IdRegistro,
                    r.Nombre,
                    r.NumeroMadre,
                    r.NumeroPadre,
                    r.FechaMonta,
                    r.FechaParto,
                    t.Nombre AS TipoAnimal,
                    r.CantidadHembras,
                    r.CantidadMachos,
                    r.TotalNacidos,
                    r.Estado
                FROM RegistroFertilidadLeche r
                INNER JOIN TipoAnimal t ON r.IdTipo = t.IdTipo
                WHERE r.Nombre = @nombre";

                    using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombrePagina);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var registro = new RegistroFertilidadLecheDTO
                                {
                                    IdRegistro = dr["IdRegistro"] != DBNull.Value ? Convert.ToInt32(dr["IdRegistro"]) : 0,
                                    Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                                    NumeroMadre = dr["NumeroMadre"] != DBNull.Value ? dr["NumeroMadre"].ToString() : string.Empty,
                                    NumeroPadre = dr["NumeroPadre"] != DBNull.Value ? dr["NumeroPadre"].ToString() : string.Empty,
                                    FechaMonta = dr["FechaMonta"] != DBNull.Value ? Convert.ToDateTime(dr["FechaMonta"]) : (DateTime?)null,
                                    FechaParto = dr["FechaParto"] != DBNull.Value ? Convert.ToDateTime(dr["FechaParto"]) : (DateTime?)null,
                                    TipoAnimal = dr["TipoAnimal"] != DBNull.Value ? dr["TipoAnimal"].ToString() : string.Empty,
                                    CantidadHembras = dr["CantidadHembras"] != DBNull.Value ? Convert.ToInt32(dr["CantidadHembras"]) : 0,
                                    CantidadMachos = dr["CantidadMachos"] != DBNull.Value ? Convert.ToInt32(dr["CantidadMachos"]) : 0,
                                    TotalNacidos = dr["TotalNacidos"] != DBNull.Value ? Convert.ToInt32(dr["TotalNacidos"]) : 0,
                                    Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"])
                                };

                                lista.Add(registro);
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

            public static DataTable Buscar(string texto, string nombrePagina)
        {
            ConexionBD.ConectarBD();
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM RegistroFertilidadLeche 
                     WHERE (NumeroMadre LIKE '%' + @texto + '%' OR NumeroPadre LIKE '%' + @texto + '%')
                     AND Nombre = @nombre";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@texto", texto);
                cmd.Parameters.AddWithValue("@nombre", nombrePagina);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            ConexionBD.CierraBD();
            return dt;
        }

    }
}


