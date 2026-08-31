using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DAL
{

    public class TipoEntornoDAL
    {
        public static List<TipoEntornoDTO> Listar()
        {
            List<TipoEntornoDTO> lista = new List<TipoEntornoDTO>();

            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT IdTipoEntorno, Nombre FROM TipoEntorno";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoEntornoDTO
                        {
                            IdTipoEntorno = Convert.ToInt32(dr["IdTipoEntorno"]),
                            Nombre = dr["Nombre"].ToString()
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
    }
}
