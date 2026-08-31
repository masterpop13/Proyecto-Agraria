using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DAL
{
    public class PreguntaSeguridadDAL
    {
        public List<PreguntaSeguridadDTO> ObtenerPreguntas()
        {
            var lista = new List<PreguntaSeguridadDTO>();

            try
            {
                ConexionBD.ConectarBD();

                string query = "SELECT IdPregunta, TextoPregunta FROM PreguntaSeguridad";
                SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new PreguntaSeguridadDTO
                    {
                        IdPregunta = Convert.ToInt32(reader["IdPregunta"]),
                        TextoPregunta = reader["TextoPregunta"].ToString()
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
    }
}