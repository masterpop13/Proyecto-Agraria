using Agraria.Datos.Entidades;
using Agraria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Agraria.Datos.DAL
{
    public static class AlimentoDAL
    {
        public static void Insertar(Alimento alimento)
        {
            ConexionBD.ConectarBD();
            string sql = @"INSERT INTO Alimento 
                           (Nombre, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, IdProveedor, Estado)
                           VALUES (@Nombre, @Cantidad, @IdTipoMedida, @Precio, @FechaIngreso, @IdTipoEntorno, @IdProveedor, @Estado)";
            using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@Nombre", alimento.Nombre);
                cmd.Parameters.AddWithValue("@Cantidad", alimento.Cantidad);
                cmd.Parameters.AddWithValue("@IdTipoMedida", alimento.IdTipoMedida);
                cmd.Parameters.AddWithValue("@Precio", alimento.Precio);
                cmd.Parameters.AddWithValue("@FechaIngreso", alimento.FechaIngreso);
                cmd.Parameters.AddWithValue("@IdTipoEntorno", alimento.IdTipoEntorno);
                cmd.Parameters.AddWithValue("@IdProveedor", alimento.IdProveedor);
                cmd.Parameters.AddWithValue("@Estado", alimento.Estado);
                cmd.ExecuteNonQuery();
            }
            ConexionBD.CierraBD();
        }

        public static void Modificar(Alimento alimento)
        {
            ConexionBD.ConectarBD();
            string sql = @"UPDATE Alimento 
                           SET Nombre=@Nombre, Cantidad=@Cantidad, IdTipoMedida=@IdTipoMedida, 
                               Precio=@Precio, FechaIngreso=@FechaIngreso, 
                               IdTipoEntorno=@IdTipoEntorno, IdProveedor=@IdProveedor, Estado=@Estado
                           WHERE IdAlimento=@IdAlimento";
            using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@IdAlimento", alimento.IdAlimento);
                cmd.Parameters.AddWithValue("@Nombre", alimento.Nombre);
                cmd.Parameters.AddWithValue("@Cantidad", alimento.Cantidad);
                cmd.Parameters.AddWithValue("@IdTipoMedida", alimento.IdTipoMedida);
                cmd.Parameters.AddWithValue("@Precio", alimento.Precio);
                cmd.Parameters.AddWithValue("@FechaIngreso", alimento.FechaIngreso);
                cmd.Parameters.AddWithValue("@IdTipoEntorno", alimento.IdTipoEntorno);
                cmd.Parameters.AddWithValue("@IdProveedor", alimento.IdProveedor);
                cmd.Parameters.AddWithValue("@Estado", alimento.Estado);
                cmd.ExecuteNonQuery();
            }
            ConexionBD.CierraBD();
        }

        public static List<Alimento> Listar(string filtro = "")
        {
            List<Alimento> lista = new List<Alimento>();
            ConexionBD.ConectarBD();
            string sql = "SELECT * FROM Alimento WHERE Estado = 1";

            if (!string.IsNullOrEmpty(filtro))
                sql += " AND Nombre LIKE @filtro";

            using (SqlCommand cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                if (!string.IsNullOrEmpty(filtro))
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Alimento
                        {
                            IdAlimento = Convert.ToInt32(dr["IdAlimento"]),
                            Nombre = dr["Nombre"].ToString(),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                            IdTipoMedida = Convert.ToInt32(dr["IdTipoMedida"]),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]),
                            IdTipoEntorno = Convert.ToInt32(dr["IdTipoEntorno"]),
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                            Estado = Convert.ToBoolean(dr["Estado"])
                        });
                    }
                }
            }
            ConexionBD.CierraBD();
            return lista;
        }
    }
}
