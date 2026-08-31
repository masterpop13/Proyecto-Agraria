using Agraria.Datos.DAL;
using System.Data.SqlClient;

public class BoxItem
{
    public int IdBox { get; set; }
    public string Nombre { get; set; }
}

public static class BoxDAL
{
    public static List<BoxItem> Listar()
    {
        var lista = new List<BoxItem>();
        try
        {
            ConexionBD.ConectarBD();
            using var cmd = new SqlCommand("SELECT IdBox, Nombre FROM Box ORDER BY IdBox", ConexionBD.ConexionSQL);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new BoxItem
                {
                    IdBox = dr.GetInt32(0),
                    Nombre = dr.GetString(1)
                });
            }
        }
        finally { ConexionBD.CierraBD(); }
        return lista;
    }
}
