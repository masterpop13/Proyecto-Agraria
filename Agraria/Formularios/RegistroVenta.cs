using Agraria.Datos.DTO;
using Agraria.Entidades;
using Agraria.Helpers;
using Agraria.Negocio;
using Agraria.Negocio.BLL;
using iTextSharp.text;             
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Agraria.Formularios
{
    public partial class RegistroVenta : Form
    {
        private readonly RegistroVentaBLL bll = new RegistroVentaBLL();
        private readonly BindingList<DetalleCompra> carrito = new BindingList<DetalleCompra>();
        private readonly RegistroCompraBLL _bll = new RegistroCompraBLL();
        private bool esInvitado = false;

        public RegistroVenta(Form formulariomenu)
        {
            InitializeComponent();
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RegistroVenta_Load(object sender, EventArgs e)
        {
            ResolutionAdapter.AdaptMdiChild(this);
            ConfigurarGrillas();
            CargarProductos();     // carga dtgProductos
            dtpFechaCompra.Value = DateTime.Now;
            txtDescuento.Text = "0";
            RecalcularTotales();
            CargarRegistros();


            dtgProductos.DefaultCellStyle.ForeColor = Color.Black;
            dtgCompra.DefaultCellStyle.ForeColor = Color.Black;
            dtgRegistro.DefaultCellStyle.ForeColor = Color.Black;
            dtgDetalles.DefaultCellStyle.ForeColor = Color.Black;
            txtCodigo.Enabled = false;
            txtPrecio.Enabled = false;
            txtNombre.Enabled = false;

        }

        public RegistroVenta(bool invitado = false)
        {
            InitializeComponent();
            esInvitado = invitado;

            if (esInvitado)
                DeshabilitarControles();
        }

        private void DeshabilitarControles()
        {
            DeshabilitarControlesRecursivo(this);
        }

        private void DeshabilitarControlesRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt)
                    txt.ReadOnly = true;

                else if (c is ComboBox combo)
                    combo.Enabled = false;

                else if (c is Button btn && btn.Name != "btnCerrar")
                    btn.Enabled = false;

                // ✅ Recorre los hijos del control actual (GroupBox, Panel, etc.)
                if (c.HasChildren)
                    DeshabilitarControlesRecursivo(c);
            }
        }
        
        private void ConfigurarGrillas()
        {
            // dtgProductos: se llena con ProductoVentaDTO
            dtgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Carrito dtgCompra – columnas manuales
            dtgCompra.AutoGenerateColumns = false;
            dtgCompra.Columns.Clear();
            dtgCompra.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdProducto", HeaderText = "Código", DataPropertyName = "IdProducto", ReadOnly = true });
            dtgCompra.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombreProducto", HeaderText = "Nombre", DataPropertyName = "NombreProducto", ReadOnly = true });
            dtgCompra.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecioUnitario", HeaderText = "Precio", DataPropertyName = "PrecioUnitario", ReadOnly = true, DefaultCellStyle = { Format = "N2" } });
            dtgCompra.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cant.", DataPropertyName = "Cantidad", ReadOnly = true });
            dtgCompra.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", DataPropertyName = "SubtotalCalc", ReadOnly = true, DefaultCellStyle = { Format = "N2" } });

            dtgCompra.DataSource = new BindingSource { DataSource = carrito };

            // Registrar columna calculada
            // (No existe en entidad, la exponemos vía extensión al pintar)
            dtgCompra.CellFormatting += (s, e2) =>
            {
                if (dtgCompra.Columns[e2.ColumnIndex].Name == "Subtotal")
                {
                    var row = dtgCompra.Rows[e2.RowIndex].DataBoundItem as DetalleCompra;
                    if (row != null) e2.Value = row.PrecioUnitario * row.Cantidad;
                }
            };
        }
        
  

        private void CargarProductos(string filtro = "")
        {
            dtgProductos.DataSource = bll.ListarProductosVenta(filtro);
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(txtBuscarNombre.Text.Trim());
        }

        private void dtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dtgProductos.Rows[e.RowIndex].DataBoundItem as ProductoVentaDTO;
            if (row == null) return;

            // precargar textboxes
            txtCodigo.Text = row.IdProducto.ToString();
            txtNombre.Text = row.NombreProducto;
            txtPrecio.Text = row.PrecioUnitario.ToString("0.##");
            txtCantidad.Text = row.StockDisponible.ToString(); // sugerimos disponible (el usuario puede cambiar)
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCodigo.Text, out int idProducto) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Seleccione un producto de la lista.");
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Precio inválido.");
                return;
            }
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }

            // validamos contra stock actual
            var lista = bll.ListarProductosVenta(txtBuscarNombre.Text.Trim());
            var prod = lista.FirstOrDefault(x => x.IdProducto == idProducto);
            if (prod == null)
            {
                MessageBox.Show("No se encontró stock disponible.");
                return;
            }

            // cantidad ya en carrito para ese producto
            int enCarrito = carrito.Where(x => x.IdProducto == idProducto).Sum(x => x.Cantidad);
            if (enCarrito + cantidad > prod.StockDisponible)
            {
                MessageBox.Show($"Stock insuficiente. Disponible: {prod.StockDisponible - enCarrito}");
                return;
            }

            carrito.Add(new DetalleCompra
            {
                IdNumeroFactura = 0,           // se asigna al guardar
                Fecha = dtpFechaCompra.Value,
                IdProducto = idProducto,
                NombreProducto = txtNombre.Text.Trim(),
                PrecioUnitario = precio,
                Cantidad = cantidad
            });

            RecalcularTotales();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgCompra.CurrentRow == null) return;
            var item = dtgCompra.CurrentRow.DataBoundItem as DetalleCompra;
            if (item != null) carrito.Remove(item);
            RecalcularTotales();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotales();
        }

        private void RecalcularTotales()
        {
            decimal precioFinal = carrito.Sum(x => x.PrecioUnitario * x.Cantidad);
            txtPrecioFinal.Text = precioFinal.ToString("0.00");
            lblPrecioFinal.Text = txtPrecioFinal.Text;

            decimal porc = 0;
            decimal.TryParse(txtDescuento.Text.Replace("%", "").Trim(), out porc);

            if (porc < 0) porc = 0;
            if (porc > 100) porc = 100;

            // 🔹 Calcular monto de descuento
            decimal montoDescuento = precioFinal * (porc / 100m);

            // 🔹 Calcular total con descuento aplicado
            decimal total = precioFinal - montoDescuento;

            // 🔹 Mostrar resultados
            lblDescuento.Text = montoDescuento.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
            lblTotal.Text = txtTotal.Text;
        }


        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (carrito.Count == 0)
                {
                    MessageBox.Show("No hay productos en la compra.");
                    return;
                }

                if (!decimal.TryParse(txtPrecioFinal.Text, out decimal precioFinal)) precioFinal = 0;
                if (!decimal.TryParse(txtTotal.Text, out decimal total)) total = 0;
                decimal desc = 0;
                decimal.TryParse(txtDescuento.Text.Replace("%", "").Trim(), out desc);

                var cab = new RegistroCompra
                {
                    IdNumeroFactura = 0, // lo define DAL (max+1)
                    Nombre = txtCliente.Text.Trim(),
                    Cuit = txtCuit.Text.Trim(),
                    Fecha = dtpFechaCompra.Value.Date,
                    Precio = precioFinal,
                    Descuento = desc,
                    Total = total
                };

                // Guardar (descuenta stock de Industria dentro de la transacción)
                bll.GuardarVenta(cab, carrito.ToList());

                MessageBox.Show("Venta registrada correctamente.");

                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(PrintTicket);

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument;
                previewDialog.ShowDialog(); // Muestra vista previa antes de imprimir

                // Reset de la UI
                carrito.Clear();
                RecalcularTotales();
                CargarProductos(txtBuscarNombre.Text.Trim()); // refrescar stock mostrado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cobrar: " + ex.Message);
            }
        }



        // --------- Sección de consultas de registro/detalles ----------
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            CargarRegistro();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            CargarRegistro();
        }

        private void CargarRegistro()
        {
            DateTime? d = dtpDesde.Checked ? (DateTime?)dtpDesde.Value.Date : null;
            DateTime? h = dtpHasta.Checked ? (DateTime?)dtpHasta.Value.Date : null;
            dtgRegistro.DataSource = bll.ListarRegistroCompras(d, h);
        }



        // --------- Imprimir --------------
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintTicket);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            previewDialog.ShowDialog(); // Muestra vista previa antes de imprimir
        }



        private void PrintTicket(object sender, PrintPageEventArgs e)
        {
            // Fuente y posiciones
            System.Drawing.Font font = new System.Drawing.Font("Arial", 10);
            float y = 20;
            float leftMargin = 20;

            // Encabezado
            e.Graphics!.DrawString("=== TICKET DE COMPRA ===",
                new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                Brushes.Black, leftMargin, y);
            y += 30;

            // Datos del cliente (se asegura que no haya nulos)
            string cliente = txtCliente.Text ?? string.Empty;
            string cuit = txtCuit.Text ?? string.Empty;
            string fecha = dtpFechaCompra?.Value.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy");

            e.Graphics.DrawString($"Cliente: {cliente}", font, Brushes.Black, leftMargin, y); y += 20;
            e.Graphics.DrawString($"CUIT: {cuit}", font, Brushes.Black, leftMargin, y); y += 20;
            e.Graphics.DrawString($"Fecha: {fecha}", font, Brushes.Black, leftMargin, y); y += 30;

            // Encabezado de tabla
            e.Graphics.DrawString("Producto         Precio     Cantidad", font, Brushes.Black, leftMargin, y);
            y += 20;
            e.Graphics.DrawString("-----------------------------------", font, Brushes.Black, leftMargin, y);
            y += 20;

            // Recorrer productos en dtgCompra
            foreach (DataGridViewRow row in dtgCompra.Rows)
            {
                if (row.IsNewRow) continue;

                string nombre = row.Cells[1].Value?.ToString() ?? "";
                string precio = row.Cells[2].Value?.ToString() ?? "";
                string cantidad = row.Cells[3].Value?.ToString() ?? "";

                e.Graphics.DrawString($"{nombre,-15} {precio,7} {cantidad,10}", font, Brushes.Black, leftMargin, y);
                y += 20;
            }

            y += 20;
            e.Graphics.DrawString("-----------------------------------", font, Brushes.Black, leftMargin, y);
            y += 20;

            // Totales
            string subtotal = txtPrecioFinal.Text ?? "0";
            string descuento = txtDescuento.Text ?? "0";
            string total = txtTotal.Text ?? "0";

            e.Graphics.DrawString($"Subtotal: {subtotal}", font, Brushes.Black, leftMargin, y); y += 20;
            e.Graphics.DrawString($"Descuento: {descuento}%", font, Brushes.Black, leftMargin, y); y += 20;
            e.Graphics.DrawString($"TOTAL: {total}",
                new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                Brushes.Black, leftMargin, y);
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CargarRegistros()
        {
            var registros = _bll.ObtenerRegistros();
            dtgRegistro.DataSource = registros;
        }

        private void dtgRegistro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgRegistro.Rows[e.RowIndex].Cells["IdNumeroFactura"] != null)
            {
                int idFactura = Convert.ToInt32(dtgRegistro.Rows[e.RowIndex].Cells["IdNumeroFactura"].Value);
                var detalles = _bll.ObtenerDetalles(idFactura);
                dtgDetalles.DataSource = detalles;
            }
        }

        private void btnBuscarFechas_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            var registros = _bll.ObtenerRegistros(desde, hasta);
            dtgRegistro.DataSource = registros;
        }

        private void btnImprimirRegistro_Click(object sender, EventArgs e)
        {
            if (dtgRegistro.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para imprimir.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "Factura.pdf";
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                string rutaPlantilla = Path.Combine(Application.StartupPath, "Recursos", "Factura.html");
                string html = File.ReadAllText(rutaPlantilla);

                var registro = (RegistroCompraDTO)dtgRegistro.CurrentRow.DataBoundItem;
                html = html.Replace("@NUMEROFACTURA", registro.IdNumeroFactura.ToString());
                html = html.Replace("@FECHA", registro.Fecha.ToString("dd/MM/yyyy"));
                html = html.Replace("@CLIENTE", registro.Nombre);
                html = html.Replace("@CUIT", registro.Cuit);
                html = html.Replace("@TOTAL", registro.Total.ToString("0.00"));
                html = html.Replace("@DESCUENTO", registro.Descuento.ToString("0.00"));
                html = html.Replace("@PRECIO", registro.Precio.ToString("0.00"));

                string filas = "";
                foreach (DataGridViewRow row in dtgDetalles.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        filas += "<tr>";
                        filas += $"<td>{row.Cells["NombreProducto"].Value}</td>";
                        filas += $"<td>{row.Cells["Cantidad"].Value}</td>";
                        filas += $"<td>{Convert.ToDecimal(row.Cells["PrecioUnitario"].Value):0.00}</td>";
                        filas += "</tr>";
                    }
                }
                html = html.Replace("@FILAS", filas);

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }
                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Factura generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SoloTextoNumeroEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTextoNumeroEspacio(e);
        }

        private void CopiaryPegar_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.DeshabilitarCopiarPegar(e);
        }


        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);

        }
        private void SoloNumerosYComa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumerosYComa(txtPrecioFinal, e, errorProvider1);
        }
    }
}
