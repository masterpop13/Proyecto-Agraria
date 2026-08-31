using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public static class UrgenciaDAL
    {
        public static void Insertar(string mensaje)
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "INSERT INTO Urgencias (Mensaje, Fecha) VALUES (@m, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@m", mensaje);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static List<string> ObtenerMensajesDelDia()
        {
            List<string> mensajes = new List<string>();
            try
            {
                ConexionBD.ConectarBD();
                string q = @"SELECT Mensaje 
                             FROM Urgencias 
                             WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE)
                             ORDER BY Fecha DESC";
                using (SqlCommand cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        mensajes.Add(dr.GetString(0));
                }
            }
            finally { ConexionBD.CierraBD(); }
            return mensajes;
        }

        public static bool HayMensajesDelDia()
        {
            try
            {
                ConexionBD.ConectarBD();
                string q = "SELECT COUNT(*) FROM Urgencias WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE)";
                using (SqlCommand cmd = new SqlCommand(q, ConexionBD.ConexionSQL))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            finally { ConexionBD.CierraBD(); }
        }
    }
}
