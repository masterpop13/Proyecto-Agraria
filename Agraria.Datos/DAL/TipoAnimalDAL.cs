using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public static class TipoAnimalDAL
    {
        public static DataTable Listar()
        {
            ConexionBD.ConectarBD();
            DataTable dt = new DataTable();

            string query = "SELECT * FROM TipoAnimal";
            using (SqlDataAdapter da = new SqlDataAdapter(query, ConexionBD.ConexionSQL))
            {
                da.Fill(dt);
            }

            ConexionBD.CierraBD();
            return dt;
        }
    }
}

