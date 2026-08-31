using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public class ArticulosPañolDAL
    {
        public void Insertar(ArticulosPañol art)
        {
            ConexionBD.ConectarBD();
            string query = @"INSERT INTO ArticulosPañol 
                            (NombreProducto, Cantidad, IdUnidad, FechaIngreso, IdEntorno, Responsable, Estado)
                             VALUES (@n, @c, @idU, @f, @idE, @r, 1)";
            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@n", art.NombreProducto);
                cmd.Parameters.AddWithValue("@c", art.Cantidad);
                cmd.Parameters.AddWithValue("@idU", art.IdUnidad);
                cmd.Parameters.AddWithValue("@f", art.FechaIngreso);
                cmd.Parameters.AddWithValue("@idE", art.IdEntorno);
                cmd.Parameters.AddWithValue("@r", art.Responsable);
                cmd.ExecuteNonQuery();
            }
            ConexionBD.CierraBD();
        }

        public void Modificar(ArticulosPañol art)
        {
            ConexionBD.ConectarBD();
            string query = @"UPDATE ArticulosPañol
                             SET NombreProducto=@n, Cantidad=@c, IdUnidad=@idU, FechaIngreso=@f,
                                 IdEntorno=@idE, Responsable=@r
                             WHERE IdArtPañol=@id";
            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@id", art.IdArtPañol);
                cmd.Parameters.AddWithValue("@n", art.NombreProducto);
                cmd.Parameters.AddWithValue("@c", art.Cantidad);
                cmd.Parameters.AddWithValue("@idU", art.IdUnidad);
                cmd.Parameters.AddWithValue("@f", art.FechaIngreso);
                cmd.Parameters.AddWithValue("@idE", art.IdEntorno);
                cmd.Parameters.AddWithValue("@r", art.Responsable);
                cmd.ExecuteNonQuery();
            }
            ConexionBD.CierraBD();
        }

        public void CambiarEstado(int id, bool estado)
        {
            ConexionBD.ConectarBD();
            string query = "UPDATE ArticulosPañol SET Estado=@e WHERE IdArtPañol=@id";
            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@e", estado);
                cmd.ExecuteNonQuery();
            }
            ConexionBD.CierraBD();
        }

        public List<ArticulosPañolDTO> Listar(string filtro = "")
        {
            var lista = new List<ArticulosPañolDTO>();
            ConexionBD.ConectarBD();

            string query = @"
                SELECT a.IdArtPañol, a.NombreProducto, a.Cantidad, m.Nombre AS Unidad,
                       a.FechaIngreso, e.Nombre AS Entorno, a.Responsable, a.Estado
                FROM ArticulosPañol a
                INNER JOIN TipoMedida m ON a.IdUnidad = m.IdTipoMedida
                INNER JOIN TipoEntorno e ON a.IdEntorno = e.IdTipoEntorno
                WHERE a.NombreProducto LIKE @f
                ORDER BY a.NombreProducto";

            using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@f", $"%{filtro}%");
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ArticulosPañolDTO
                        {
                            IdArtPañol = dr.GetInt32(0),
                            NombreProducto = dr.GetString(1),
                            Cantidad = dr.GetInt32(2),
                            Unidad = dr.GetString(3),
                            FechaIngreso = dr.GetDateTime(4),
                            Entorno = dr.GetString(5),
                            Responsable = dr.GetString(6),
                            Estado = dr.GetBoolean(7)
                        });
                    }
                }
            }

            ConexionBD.CierraBD();
            return lista;
        }

        
    }
}
