using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public static class RegistroFertilidadCarneDAL
    {
        public static void GuardarMonta(string nombre, string madre, string padre, DateTime fechaMonta, DateTime fechaParto)
        {
            ConexionBD.ConectarBD();
            string sql = @"INSERT INTO RegistroFertilidadCarne (NumeroMadre, NumeroPadre, FechaMonta, FechaParto, Estado)
                           VALUES (@m, @p, @fm, @fp, 1)";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@m", madre);
            cmd.Parameters.AddWithValue("@p", padre);
            cmd.Parameters.AddWithValue("@fm", fechaMonta);
            cmd.Parameters.AddWithValue("@fp", fechaParto);
            cmd.ExecuteNonQuery();
            ConexionBD.CierraBD();
        }

        public static void GuardarNacimiento(string nombre, string madre, string padre, DateTime fechaParto,
                                             int hembras, int machos, int total)
        {
            ConexionBD.ConectarBD();
            string sql = @"INSERT INTO RegistroFertilidadCarne 
                           (NumeroMadre, NumeroPadre, FechaParto, CantidadHembras, CantidadMachos, TotalNacidos, Estado)
                           VALUES (@m, @p, @fp, @h, @c, @t, 1)";
            using var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@m", madre);
            cmd.Parameters.AddWithValue("@p", padre);
            cmd.Parameters.AddWithValue("@fp", fechaParto);
            cmd.Parameters.AddWithValue("@h", hembras);
            cmd.Parameters.AddWithValue("@c", machos);
            cmd.Parameters.AddWithValue("@t", total);
            cmd.ExecuteNonQuery();
            ConexionBD.CierraBD();
        }

        public static List<RegistroFertilidadCarneDTO> ListarRegistrosFertilidad(string nombre)
        {
            List<RegistroFertilidadCarneDTO> lista = new List<RegistroFertilidadCarneDTO>();

            try
            {
                ConexionBD.ConectarBD();

                // 🔹 No existe la columna "Nombre" en la tabla, así que se quita el filtro
                string sql = @"
            SELECT *
            FROM RegistroFertilidadCarne
            ORDER BY IdRegistro DESC";

                using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    // Este parámetro ya no se usa, pero podés dejarlo si planeás filtrar más adelante
                    cmd.Parameters.AddWithValue("@nombre", nombre ?? (object)DBNull.Value);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var registro = new RegistroFertilidadCarneDTO
                            {
                                IdRegistro = dr["IdRegistro"] != DBNull.Value ? Convert.ToInt32(dr["IdRegistro"]) : 0,
                                NumeroMadre = dr["NumeroMadre"] != DBNull.Value ? dr["NumeroMadre"].ToString() : string.Empty,
                                NumeroPadre = dr["NumeroPadre"] != DBNull.Value ? dr["NumeroPadre"].ToString() : string.Empty,
                                FechaMonta = dr["FechaMonta"] != DBNull.Value ? Convert.ToDateTime(dr["FechaMonta"]) : (DateTime?)null,
                                FechaParto = dr["FechaParto"] != DBNull.Value ? Convert.ToDateTime(dr["FechaParto"]) : (DateTime?)null,
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


    }
}
