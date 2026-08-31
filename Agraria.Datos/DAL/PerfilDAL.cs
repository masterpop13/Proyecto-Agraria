using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public class PerfilDAL
    {
        public static List<Perfil> ObtenerPerfiles()
        {
            var lista = new List<Perfil>();
            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT IdPerfil, NombrePerfil FROM Perfil ORDER BY NombrePerfil";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Perfil
                        {
                            IdPerfil = Convert.ToInt32(dr["IdPerfil"]),
                            NombrePerfil = dr["NombrePerfil"].ToString()
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

        public static void InsertarPerfil(string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string query = "INSERT INTO Perfil (NombrePerfil) VALUES (@nombre)";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }

        public static void ModificarPerfil(int id, string nombre)
        {
            try
            {
                ConexionBD.ConectarBD();
                string query = "UPDATE Perfil SET NombrePerfil = @nombre WHERE IdPerfil = @id";
                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
        }
    }
}
