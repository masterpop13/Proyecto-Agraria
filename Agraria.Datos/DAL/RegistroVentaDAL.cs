using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Entidades;
using System.Data.SqlClient;

namespace Agraria.Datos
{
    public class RegistroVentaDAL
    {
        // Lista de productos disponibles desde Industria + precio de Productos
        public List<ProductoVentaDTO> ListarProductosVenta(string filtroNombre = "")
        {
            var lista = new List<ProductoVentaDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
SELECT p.IdProducto,
       p.Nombre AS NombreProducto,
       p.PrecioUnitario,
       ISNULL(SUM(i.CantidadProduccion),0) AS StockDisponible
FROM Productos p
LEFT JOIN Industria i ON i.idProducto = p.idProducto
GROUP BY p.IdProducto, p.Nombre, p.PrecioUnitario
HAVING ISNULL(SUM(i.CantidadProduccion),0) > 0
AND (@filtro = '' OR p.Nombre LIKE '%' + @filtro + '%')
ORDER BY p.Nombre";

                using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@filtro", filtroNombre ?? "");
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ProductoVentaDTO
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                                StockDisponible = Convert.ToInt32(dr["StockDisponible"])
                            });
                        }
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }

        // Descontar del stock (Industria): consume de registros con CantidadProduccion > 0 por FIFO (FechaProduccion ASC)
        public void DescontarStockIndustria(int idProducto, int cantidadSolicitada, SqlTransaction tr)
        {
            if (cantidadSolicitada <= 0) return;

            // Traemos los registros con cantidad >0
            string sel = @"SELECT IdRegistroIndustria, CantidadProduccion
                           FROM Industria
                           WHERE idProducto = @idProd AND CantidadProduccion > 0
                           ORDER BY FechaProduccion ASC";
            var lotes = new List<(int idReg, int cant)>();
            using (var cmdSel = new SqlCommand(sel, tr.Connection, tr))
            {
                cmdSel.Parameters.AddWithValue("@idProd", idProducto);
                using (var dr = cmdSel.ExecuteReader())
                {
                    while (dr.Read())
                        lotes.Add((Convert.ToInt32(dr["IdRegistroIndustria"]), Convert.ToInt32(dr["CantidadProduccion"])));
                }
            }

            int restante = cantidadSolicitada;
            foreach (var lote in lotes)
            {
                if (restante <= 0) break;

                if (lote.cant <= restante)
                {
                    // consumir todo el lote -> dejar en 0
                    using (var cmdUpd = new SqlCommand(
                        "UPDATE Industria SET CantidadProduccion = 0 WHERE IdRegistroIndustria = @id", tr.Connection, tr))
                    {
                        cmdUpd.Parameters.AddWithValue("@id", lote.idReg);
                        cmdUpd.ExecuteNonQuery();
                    }
                    restante -= lote.cant;
                }
                else
                {
                    // consumir parcialmente
                    using (var cmdUpd = new SqlCommand(
                        "UPDATE Industria SET CantidadProduccion = CantidadProduccion - @q WHERE IdRegistroIndustria = @id", tr.Connection, tr))
                    {
                        cmdUpd.Parameters.AddWithValue("@q", restante);
                        cmdUpd.Parameters.AddWithValue("@id", lote.idReg);
                        cmdUpd.ExecuteNonQuery();
                    }
                    restante = 0;
                }
            }

            if (restante > 0)
                throw new Exception("Stock insuficiente en Industria.");
        }

        // Obtener el próximo número de factura (max + 1)
        public int ObtenerProximoNumeroFactura(SqlTransaction tr)
        {
            string sql = "SELECT ISNULL(MAX(IdNumeroFactura),0) + 1 FROM RegistroCompra";
            using (var cmd = new SqlCommand(sql, tr.Connection, tr))
                return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void InsertarRegistroCompra(RegistroCompra cab, List<DetalleCompra> detalles)
        {
            ConexionBD.ConectarBD();
            using (var tr = ConexionBD.ConexionSQL.BeginTransaction())
            {
                try
                {
                    // 1) número de factura
                    int nro = ObtenerProximoNumeroFactura(tr);

                    // 2) insertar cabecera
                    string insCab = @"
INSERT INTO RegistroCompra (IdNumeroFactura, Nombre, Cuit, Fecha, Precio, Descuento, Total)
VALUES (@nro, @nom, @cuit, @fec, @precio, @desc, @tot);";

                    using (var cmdCab = new SqlCommand(insCab, ConexionBD.ConexionSQL, tr))
                    {
                        cmdCab.Parameters.AddWithValue("@nro", nro);
                        cmdCab.Parameters.AddWithValue("@nom", (object)cab.Nombre ?? DBNull.Value);
                        cmdCab.Parameters.AddWithValue("@cuit", (object)cab.Cuit ?? DBNull.Value);
                        cmdCab.Parameters.AddWithValue("@fec", cab.Fecha);
                        cmdCab.Parameters.AddWithValue("@precio", cab.Precio);
                        cmdCab.Parameters.AddWithValue("@desc", cab.Descuento);
                        cmdCab.Parameters.AddWithValue("@tot", cab.Total);
                        cmdCab.ExecuteNonQuery();
                    }

                    // 3) insertar detalles y descontar stock
                    string insDet = @"
INSERT INTO DetalleCompra (IdNumeroFactura, Fecha, IdProducto, NombreProducto, PrecioUnitario, Cantidad)
VALUES (@nro, @fec, @idp, @nomp, @precio, @cant)";
                    foreach (var d in detalles)
                    {
                        // descontar stock de Industria
                        DescontarStockIndustria(d.IdProducto, d.Cantidad, tr);

                        using (var cmdDet = new SqlCommand(insDet, ConexionBD.ConexionSQL, tr))
                        {
                            cmdDet.Parameters.AddWithValue("@nro", nro);
                            cmdDet.Parameters.AddWithValue("@fec", d.Fecha);
                            cmdDet.Parameters.AddWithValue("@idp", d.IdProducto);
                            cmdDet.Parameters.AddWithValue("@nomp", d.NombreProducto);
                            cmdDet.Parameters.AddWithValue("@precio", d.PrecioUnitario);
                            cmdDet.Parameters.AddWithValue("@cant", d.Cantidad);
                            cmdDet.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
                finally
                {
                    ConexionBD.CierraBD();
                }
            }
        }

        // Listados para grillas de registro/detalle
        public List<RegistroCompraDTO> ListarRegistroCompras(DateTime? desde, DateTime? hasta)
        {
            var lista = new List<RegistroCompraDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
SELECT IdRegistro, IdNumeroFactura, Nombre, Cuit, Fecha, Precio, Descuento, Total
FROM RegistroCompra
WHERE (@d IS NULL OR Fecha >= @d) AND (@h IS NULL OR Fecha <= @h)
ORDER BY IdRegistro DESC";

                using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@d", (object?)desde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@h", (object?)hasta ?? DBNull.Value);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new RegistroCompraDTO
                            {
                                IdRegistro = Convert.ToInt32(dr["IdRegistro"]),
                                IdNumeroFactura = Convert.ToInt32(dr["IdNumeroFactura"]),
                                Nombre = dr["Nombre"] as string ?? string.Empty,
                                Cuit = dr["Cuit"] as string ?? string.Empty,
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Descuento = Convert.ToDecimal(dr["Descuento"]),
                                Total = Convert.ToDecimal(dr["Total"])
                            });
                        }
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }


        public List<DetalleCompraDTO> ListarDetallePorFactura(int idNumeroFactura)
        {
            var lista = new List<DetalleCompraDTO>();
            try
            {
                ConexionBD.ConectarBD();
                string sql = @"
SELECT IdDetalle, IdNumeroFactura, Fecha, IdProducto, NombreProducto, PrecioUnitario, Cantidad
FROM DetalleCompra
WHERE IdNumeroFactura = @nro
ORDER BY IdDetalle";

                using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
                {
                    cmd.Parameters.AddWithValue("@nro", idNumeroFactura);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleCompraDTO
                            {
                                IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                                IdNumeroFactura = Convert.ToInt32(dr["IdNumeroFactura"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"])
                            });
                        }
                    }
                }
            }
            finally { ConexionBD.CierraBD(); }
            return lista;
        }
    }
}
