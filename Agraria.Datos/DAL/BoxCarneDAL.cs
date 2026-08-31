using System.Collections.Generic;
using System.Data.SqlClient;
using Agraria.Datos.DTO;

namespace Agraria.Datos.DAL
{
    public static class BoxCarneDAL
    {
        public static List<BoxCarneDTO> ListarBoxes()
        {
            var lista = new List<BoxCarneDTO>();

            ConexionBD.ConectarBD();
            string query = "SELECT IdBoxCarne, Nombre, Estado FROM BoxCarne WHERE Estado = 1";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new BoxCarneDTO
                    {
                        IdBoxCarne = (int)dr["IdBoxCarne"],
                        Nombre = dr["Nombre"].ToString(),
                        Estado = (bool)dr["Estado"]
                    });
                }
            }

            ConexionBD.CierraBD();
            return lista;
        }
    }
}
