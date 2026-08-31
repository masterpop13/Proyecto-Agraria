using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Agraria.Datos.DTO;

namespace Agraria.Datos.DAL
{
    public class RegistroCompraDAL
    {
        public static List<RegistroCompraDTO> ObtenerRegistros(DateTime? desde = null, DateTime? hasta = null)
        {
            var lista = new List<RegistroCompraDTO>();
            try
            {
                ConexionBD.ConectarBD();

                string query = @"SELECT IdRegistro, IdNumeroFactura, Nombre, Cuit, Fecha, Precio, Descuento, Total 
                                 FROM RegistroCompra
                                 WHERE 1=1";

                if (desde.HasValue && hasta.HasValue)
                    query += " AND Fecha BETWEEN @desde AND @hasta";

                query += " ORDER BY Fecha DESC";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    if (desde.HasValue && hasta.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@desde", desde.Value);
                        cmd.Parameters.AddWithValue("@hasta", hasta.Value);
                    }

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new RegistroCompraDTO
                            {
                                IdRegistro = Convert.ToInt32(dr["IdRegistro"]),
                                IdNumeroFactura = Convert.ToInt32(dr["IdNumeroFactura"]),
                                Nombre = dr["Nombre"].ToString(),
                                Cuit = dr["Cuit"].ToString(),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Descuento = Convert.ToDecimal(dr["Descuento"]),
                                Total = Convert.ToDecimal(dr["Total"])
                            });
                        }
                    }
                }
            }
            finally
            {
                ConexionBD.CierraBD();
            }
            return lista;
        }

        public static List<DetalleCompraDTO> ObtenerDetallesPorFactura(int idFactura)
        {
            var lista = new List<DetalleCompraDTO>();
            try
            {
                ConexionBD.ConectarBD();

                string query = @"SELECT IdDetalle, IdNumeroFactura, Fecha, NombreProducto, PrecioUnitario, Cantidad
                                 FROM DetalleCompra WHERE IdNumeroFactura = @idFactura";

                using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleCompraDTO
                            {
                                IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                                IdNumeroFactura = Convert.ToInt32(dr["IdNumeroFactura"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"])
                            });
                        }
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
