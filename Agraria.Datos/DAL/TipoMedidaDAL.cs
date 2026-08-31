using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DAL
{
    public class TipoMedidaDAL
    {
        public static List<TipoMedidaDTO> Listar()
        {
            List<TipoMedidaDTO> lista = new List<TipoMedidaDTO>();

            try
            {
                ConexionBD.ConectarBD();
                string query = "SELECT IdTipoMedida, Nombre FROM TipoMedida";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoMedidaDTO
                        {
                            IdTipoMedida = Convert.ToInt32(dr["IdTipoMedida"]),
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
