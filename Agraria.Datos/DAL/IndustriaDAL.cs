using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Agraria.Datos.Entidades;
using Agraria.Datos.DTO;

namespace Agraria.Datos.DAL
{
    public class IndustriaDAL
    {
        public static void InsertarIndustria(Industria entidad)
        {
            try
            {
                ConexionBD.ConectarBD();
                string query = @"INSERT INTO Industria 
                (idIndustria, idProducto, cantidadProduccion, FechaProduccion, idInsumos, CantidadInsumos)
                VALUES (@idIndustria, @idProducto, @cantidadProd, @fecha, @idInsumos, @cantidadIns)";


                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                   
                    cmd.Parameters.AddWithValue("@idIndustria", entidad.IdIndustria);
                    cmd.Parameters.AddWithValue("@idProducto", entidad.IdProducto);
                    cmd.Parameters.AddWithValue("@cantidadProd", entidad.CantidadProduccion);
                    cmd.Parameters.AddWithValue("@fecha", entidad.FechaProduccion);
                    cmd.Parameters.AddWithValue("@idInsumos", entidad.IdInsumos);
                    cmd.Parameters.AddWithValue("@cantidadIns", entidad.CantidadInsumos);

                    cmd.ExecuteNonQuery();
                }

                // 🔹 Descontar stock de insumos en tabla Articulos
                string update = @"UPDATE Articulo SET Cantidad = Cantidad - @cantidad 
                                  WHERE IdArticulo = @idInsumos";
                using (SqlCommand cmdUpd = new SqlCommand(update, ConexionBD.ConexionSQL))
                {
                    cmdUpd.Parameters.AddWithValue("@cantidad", entidad.CantidadInsumos);
                    cmdUpd.Parameters.AddWithValue("@idInsumos", entidad.IdInsumos);
                    cmdUpd.ExecuteNonQuery();
                }
            }
            finally { ConexionBD.CierraBD(); }
        }

        public static List<IndustriaDTO> ObtenerRegistrosIndustria()
        {
            var lista = new List<IndustriaDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string query = @"SELECT i.idRegistroIndustria, i.idIndustria, p.Nombre AS NombreProducto, 
                                        i.cantidadProduccion, i.FechaProduccion, a.NombreProducto AS NombreInsumo, 
                                        i.CantidadInsumos
                                 FROM Industria i
                                 INNER JOIN Productos p ON i.idProducto = p.idProducto
                                 INNER JOIN Articulo a ON i.idInsumos = a.IdArticulo
                                 ORDER BY i.idRegistroIndustria DESC";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new IndustriaDTO
                        {
                            IdRegistroIndustria = Convert.ToInt32(dr["idRegistroIndustria"]),
                            IdIndustria = Convert.ToInt32(dr["idIndustria"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            CantidadProduccion = Convert.ToInt32(dr["cantidadProduccion"]),
                            FechaProduccion = Convert.ToDateTime(dr["FechaProduccion"]),
                            NombreInsumo = dr["NombreInsumo"].ToString(),
                            CantidadInsumos = Convert.ToInt32(dr["CantidadInsumos"])
                        });
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }



    }
}

