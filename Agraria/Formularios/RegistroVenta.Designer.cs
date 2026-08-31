using Tienda;

namespace Agraria.Formularios
{
    partial class RegistroVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroVenta));
            groupBox2 = new GroupBox();
            btnQuitar = new RJButton();
            btnAgregar = new RJButton();
            groupBox3 = new GroupBox();
            btnCobrar = new RJButton();
            txtTotal = new TextBox();
            dtpFechaCompra = new DateTimePicker();
            panel1 = new Panel();
            lblTotal = new Label();
            lblDescuento = new Label();
            lblPrecioFinal = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label12 = new Label();
            label9 = new Label();
            txtDescuento = new TextBox();
            txtCuit = new TextBox();
            label8 = new Label();
            txtCliente = new TextBox();
            label7 = new Label();
            label2 = new Label();
            lblEntorno = new Label();
            txtPrecioFinal = new TextBox();
            dtgCompra = new DataGridView();
            label6 = new Label();
            txtCantidad = new TextBox();
            label4 = new Label();
            txtPrecio = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            groupBox1 = new GroupBox();
            dtgProductos = new DataGridView();
            label1 = new Label();
            txtBuscarNombre = new TextBox();
            lblTipoEntorno = new Label();
            txtCodigo = new TextBox();
            groupBox4 = new GroupBox();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            btnImprimirRegistro = new RJButton();
            dtgDetalles = new DataGridView();
            label20 = new Label();
            label19 = new Label();
            dtgRegistro = new DataGridView();
            label5 = new Label();
            errorProvider1 = new ErrorProvider(components);
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgCompra).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProductos).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgRegistro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(dtgCompra);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtCantidad);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtPrecio);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(groupBox1);
            groupBox2.Controls.Add(lblTipoEntorno);
            groupBox2.Controls.Add(txtCodigo);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox2.ForeColor = Color.WhiteSmoke;
            groupBox2.Location = new Point(12, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1021, 846);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ventas :";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // btnQuitar
            // 
            btnQuitar.BackColor = Color.AliceBlue;
            btnQuitar.FlatAppearance.BorderSize = 0;
            btnQuitar.FlatStyle = FlatStyle.Flat;
            btnQuitar.ForeColor = Color.FromArgb(56, 124, 31);
            btnQuitar.Image = (Image)resources.GetObject("btnQuitar.Image");
            btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitar.Location = new Point(857, 446);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(150, 40);
            btnQuitar.TabIndex = 50;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.AliceBlue;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.FromArgb(56, 124, 31);
            btnAgregar.Image = (Image)resources.GetObject("btnAgregar.Image");
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(857, 270);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 40);
            btnAgregar.TabIndex = 49;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnCobrar);
            groupBox3.Controls.Add(txtTotal);
            groupBox3.Controls.Add(dtpFechaCompra);
            groupBox3.Controls.Add(panel1);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtDescuento);
            groupBox3.Controls.Add(txtCuit);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txtCliente);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(lblEntorno);
            groupBox3.Controls.Add(txtPrecioFinal);
            groupBox3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(16, 492);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(991, 345);
            groupBox3.TabIndex = 48;
            groupBox3.TabStop = false;
            groupBox3.Text = "Finalizar Compra:";
            // 
            // btnCobrar
            // 
            btnCobrar.BackColor = Color.AliceBlue;
            btnCobrar.FlatAppearance.BorderSize = 0;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.ForeColor = Color.FromArgb(56, 124, 31);
            btnCobrar.Image = Properties.Resources.metodo_de_pago1;
            btnCobrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCobrar.Location = new Point(831, 283);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(150, 40);
            btnCobrar.TabIndex = 51;
            btnCobrar.Text = "Cobrar";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(163, 234);
            txtTotal.MaxLength = 15;
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(151, 29);
            txtTotal.TabIndex = 50;
            txtTotal.KeyDown += CopiaryPegar_KeyDown;
            txtTotal.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // dtpFechaCompra
            // 
            dtpFechaCompra.Location = new Point(163, 131);
            dtpFechaCompra.Name = "dtpFechaCompra";
            dtpFechaCompra.Size = new Size(151, 29);
            dtpFechaCompra.TabIndex = 49;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(lblTotal);
            panel1.Controls.Add(lblDescuento);
            panel1.Controls.Add(lblPrecioFinal);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Location = new Point(358, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(411, 263);
            panel1.TabIndex = 48;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(199, 202);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(135, 55);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total";
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescuento.Location = new Point(287, 68);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(99, 25);
            lblDescuento.TabIndex = 5;
            lblDescuento.Text = "Subtotal";
            // 
            // lblPrecioFinal
            // 
            lblPrecioFinal.AutoSize = true;
            lblPrecioFinal.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioFinal.Location = new Point(287, 24);
            lblPrecioFinal.Name = "lblPrecioFinal";
            lblPrecioFinal.Size = new Size(99, 25);
            lblPrecioFinal.TabIndex = 4;
            lblPrecioFinal.Text = "Subtotal";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(12, 74);
            label16.Name = "label16";
            label16.Size = new Size(124, 25);
            label16.TabIndex = 3;
            label16.Text = "Descuento";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(12, 24);
            label15.Name = "label15";
            label15.Size = new Size(99, 25);
            label15.TabIndex = 2;
            label15.Text = "Subtotal";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(12, 202);
            label14.Name = "label14";
            label14.Size = new Size(135, 55);
            label14.TabIndex = 1;
            label14.Text = "Total";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(95, 233);
            label12.Name = "label12";
            label12.Size = new Size(62, 24);
            label12.TabIndex = 46;
            label12.Text = "Total:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(18, 200);
            label9.Name = "label9";
            label9.Size = new Size(138, 24);
            label9.TabIndex = 40;
            label9.Text = "Descuento %:";
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(163, 197);
            txtDescuento.MaxLength = 3;
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(151, 29);
            txtDescuento.TabIndex = 41;
            txtDescuento.Click += txtDescuento_TextChanged;
            txtDescuento.TextChanged += txtDescuento_TextChanged;
            txtDescuento.KeyDown += CopiaryPegar_KeyDown;
            txtDescuento.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(162, 95);
            txtCuit.MaxLength = 30;
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(151, 29);
            txtCuit.TabIndex = 38;
            txtCuit.KeyDown += CopiaryPegar_KeyDown;
            txtCuit.KeyPress += SoloNumeros_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(60, 98);
            label8.Name = "label8";
            label8.Size = new Size(96, 24);
            label8.TabIndex = 39;
            label8.Text = "Cuit-Dni :";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(162, 61);
            txtCliente.MaxLength = 30;
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(151, 29);
            txtCliente.TabIndex = 6;
            txtCliente.KeyDown += CopiaryPegar_KeyDown;
            txtCliente.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(75, 64);
            label7.Name = "label7";
            label7.Size = new Size(81, 24);
            label7.TabIndex = 20;
            label7.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(29, 163);
            label2.Name = "label2";
            label2.Size = new Size(128, 24);
            label2.TabIndex = 15;
            label2.Text = "Precio Final:";
            // 
            // lblEntorno
            // 
            lblEntorno.AutoSize = true;
            lblEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblEntorno.ForeColor = Color.White;
            lblEntorno.Location = new Point(82, 131);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(75, 24);
            lblEntorno.TabIndex = 21;
            lblEntorno.Text = "Fecha:";
            // 
            // txtPrecioFinal
            // 
            txtPrecioFinal.Location = new Point(163, 163);
            txtPrecioFinal.MaxLength = 15;
            txtPrecioFinal.Name = "txtPrecioFinal";
            txtPrecioFinal.Size = new Size(151, 29);
            txtPrecioFinal.TabIndex = 36;
            txtPrecioFinal.KeyDown += CopiaryPegar_KeyDown;
            txtPrecioFinal.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // dtgCompra
            // 
            dtgCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCompra.Location = new Point(26, 325);
            dtgCompra.Name = "dtgCompra";
            dtgCompra.ReadOnly = true;
            dtgCompra.Size = new Size(964, 115);
            dtgCompra.TabIndex = 46;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(332, 287);
            label6.Name = "label6";
            label6.Size = new Size(98, 24);
            label6.TabIndex = 44;
            label6.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(436, 283);
            txtCantidad.MaxLength = 5;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(151, 29);
            txtCantidad.TabIndex = 43;
            txtCantidad.KeyDown += CopiaryPegar_KeyDown;
            txtCantidad.KeyPress += SoloNumeros_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(354, 240);
            label4.Name = "label4";
            label4.Size = new Size(76, 24);
            label4.TabIndex = 42;
            label4.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(436, 237);
            txtPrecio.MaxLength = 10;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(151, 29);
            txtPrecio.TabIndex = 41;
            txtPrecio.KeyDown += CopiaryPegar_KeyDown;
            txtPrecio.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(41, 283);
            label3.Name = "label3";
            label3.Size = new Size(91, 24);
            label3.TabIndex = 40;
            label3.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(135, 280);
            txtNombre.MaxLength = 10;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 29);
            txtNombre.TabIndex = 39;
            txtNombre.KeyDown += CopiaryPegar_KeyDown;
            txtNombre.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtgProductos);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBuscarNombre);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(6, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(991, 189);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buscar Producto:";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dtgProductos
            // 
            dtgProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProductos.Location = new Point(6, 65);
            dtgProductos.Name = "dtgProductos";
            dtgProductos.ReadOnly = true;
            dtgProductos.Size = new Size(960, 115);
            dtgProductos.TabIndex = 22;
            dtgProductos.CellClick += dtgProductos_CellClick;
            dtgProductos.CellContentClick += dtgProductos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(346, 24);
            label1.TabIndex = 21;
            label1.Text = "Buscar por el Nombre del Producto:";
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Location = new Point(358, 28);
            txtBuscarNombre.MaxLength = 20;
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(187, 29);
            txtBuscarNombre.TabIndex = 11;
            txtBuscarNombre.Click += txtBuscarNombre_TextChanged;
            txtBuscarNombre.KeyDown += CopiaryPegar_KeyDown;
            txtBuscarNombre.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // lblTipoEntorno
            // 
            lblTipoEntorno.AutoSize = true;
            lblTipoEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTipoEntorno.ForeColor = Color.White;
            lblTipoEntorno.Location = new Point(44, 237);
            lblTipoEntorno.Name = "lblTipoEntorno";
            lblTipoEntorno.Size = new Size(83, 24);
            lblTipoEntorno.TabIndex = 19;
            lblTipoEntorno.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(135, 237);
            txtCodigo.MaxLength = 10;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(151, 29);
            txtCodigo.TabIndex = 5;
            txtCodigo.KeyDown += CopiaryPegar_KeyDown;
            txtCodigo.KeyPress += SoloNumeros_KeyPress;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dtpHasta);
            groupBox4.Controls.Add(dtpDesde);
            groupBox4.Controls.Add(btnImprimirRegistro);
            groupBox4.Controls.Add(dtgDetalles);
            groupBox4.Controls.Add(label20);
            groupBox4.Controls.Add(label19);
            groupBox4.Controls.Add(dtgRegistro);
            groupBox4.Controls.Add(label5);
            groupBox4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox4.ForeColor = Color.WhiteSmoke;
            groupBox4.Location = new Point(1039, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(848, 846);
            groupBox4.TabIndex = 25;
            groupBox4.TabStop = false;
            groupBox4.Text = "Consulta de Ventas:";
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(528, 52);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(265, 29);
            dtpHasta.TabIndex = 55;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(127, 52);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(257, 29);
            dtpDesde.TabIndex = 54;
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            // 
            // btnImprimirRegistro
            // 
            btnImprimirRegistro.BackColor = Color.AliceBlue;
            btnImprimirRegistro.FlatAppearance.BorderSize = 0;
            btnImprimirRegistro.FlatStyle = FlatStyle.Flat;
            btnImprimirRegistro.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimirRegistro.Image = Properties.Resources.imprimir;
            btnImprimirRegistro.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirRegistro.Location = new Point(683, 787);
            btnImprimirRegistro.Name = "btnImprimirRegistro";
            btnImprimirRegistro.Size = new Size(150, 40);
            btnImprimirRegistro.TabIndex = 53;
            btnImprimirRegistro.Text = "Imprimir";
            btnImprimirRegistro.UseVisualStyleBackColor = false;
            btnImprimirRegistro.Click += btnImprimirRegistro_Click;
            // 
            // dtgDetalles
            // 
            dtgDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDetalles.Location = new Point(23, 404);
            dtgDetalles.Name = "dtgDetalles";
            dtgDetalles.ReadOnly = true;
            dtgDetalles.Size = new Size(810, 276);
            dtgDetalles.TabIndex = 52;
            dtgDetalles.CellClick += dtgDetalles_CellContentClick;
            dtgDetalles.CellContentClick += dtgDetalles_CellContentClick;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label20.ForeColor = Color.White;
            label20.Location = new Point(45, 52);
            label20.Name = "label20";
            label20.Size = new Size(76, 24);
            label20.TabIndex = 46;
            label20.Text = "Desde:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Location = new Point(454, 52);
            label19.Name = "label19";
            label19.Size = new Size(68, 24);
            label19.TabIndex = 45;
            label19.Text = "Hasta:";
            // 
            // dtgRegistro
            // 
            dtgRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgRegistro.Location = new Point(23, 93);
            dtgRegistro.Name = "dtgRegistro";
            dtgRegistro.ReadOnly = true;
            dtgRegistro.Size = new Size(810, 276);
            dtgRegistro.TabIndex = 22;
            dtgRegistro.CellClick += dtgRegistro_CellClick;
            dtgRegistro.CellContentClick += dtgRegistro_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(239, 16);
            label5.Name = "label5";
            label5.Size = new Size(328, 24);
            label5.TabIndex = 21;
            label5.Text = "Busqueda por Fecha desde Hasta";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // RegistroVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1884, 861);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistroVenta";
            Text = "RegistroVenta";
            Load += RegistroVenta_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgCompra).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProductos).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgRegistro).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker2;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Panel panel1;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label12;
        private Label label9;
        private TextBox txtDescuento;
        private TextBox txtCuit;
        private Label label8;
        private TextBox txtCliente;
        private Label label7;
        private Label label2;
        private Label lblEntorno;
        private TextBox txtPrecioFinal;
        private DataGridView dtgCompra;
        private Label label6;
        private TextBox txtCantidad;
        private Label label4;
        private TextBox txtPrecio;
        private Label label3;
        private TextBox txtNombre;
        private GroupBox groupBox1;
        private DataGridView dtgProductos;
        private Label label1;
        private TextBox txtBuscarNombre;
        private Label lblTipoEntorno;
        private TextBox txtCodigo;
        private GroupBox groupBox4;
        private DataGridView dtgDetalles;
        private Label label20;
        private Label label19;
        private DataGridView dtgRegistro;
        private Label label5;
        private DateTimePicker dtpFechaCompra;
        private RJButton btnQuitar;
        private RJButton btnAgregar;
        private RJButton btnCobrar;
        private TextBox txtTotal;
        private Label lblTotal;
        private Label lblDescuento;
        private Label lblPrecioFinal;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private RJButton btnImprimirRegistro;
        private ErrorProvider errorProvider1;
    }
}