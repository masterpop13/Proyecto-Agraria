namespace Agraria.Formularios
{
    partial class AbmAdministracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmAdministracion));
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            btnLimpiarEntornos = new Tienda.RJButton();
            txtTipoEntorno = new TextBox();
            cmbTipoEntorno = new ComboBox();
            lblTipoEntorno = new Label();
            btnGuardarEntorno = new Tienda.RJButton();
            btnModificarEntorno = new Tienda.RJButton();
            tabPage1 = new TabPage();
            groupBox1 = new GroupBox();
            label12 = new Label();
            txtCodigoPostal = new TextBox();
            btnLimpiarLocalidadPartido = new Tienda.RJButton();
            txtLocalidad = new TextBox();
            txtPartido = new TextBox();
            btnGuardarUsuario = new Tienda.RJButton();
            btnModificarUsuario = new Tienda.RJButton();
            cmbLocalidad = new ComboBox();
            lblApellido = new Label();
            cmbPartido = new ComboBox();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            groupBox4 = new GroupBox();
            btnLimpiarIndustria = new Tienda.RJButton();
            label5 = new Label();
            label4 = new Label();
            txtPrecioProducto = new TextBox();
            label3 = new Label();
            txtReceta = new TextBox();
            txtProducto = new TextBox();
            label1 = new Label();
            cmbProducto = new ComboBox();
            btnGuardarProducto = new Tienda.RJButton();
            btnModificarProducto = new Tienda.RJButton();
            tabPage4 = new TabPage();
            btnImprimirProveedores = new Tienda.RJButton();
            groupBox5 = new GroupBox();
            btnLimpiarProveedores = new Tienda.RJButton();
            dtgProveedores = new DataGridView();
            label11 = new Label();
            txtDireccion = new TextBox();
            label10 = new Label();
            txtEmail = new TextBox();
            label8 = new Label();
            txtTelefono = new TextBox();
            label7 = new Label();
            txtRazonSocial = new TextBox();
            btnGuardarProveedor = new Tienda.RJButton();
            btnModificarProveedor = new Tienda.RJButton();
            groupBox6 = new GroupBox();
            btnLimpiarAlimentos = new Tienda.RJButton();
            label6 = new Label();
            txtKgUnidad = new TextBox();
            cmbKgUnidad = new ComboBox();
            btnGuardarUnidad = new Tienda.RJButton();
            btnModificarUnidad = new Tienda.RJButton();
            errorProvider1 = new ErrorProvider(components);
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox4.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(141, 181, 146);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1852, 811);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Entorno Formativo";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnLimpiarEntornos);
            groupBox3.Controls.Add(txtTipoEntorno);
            groupBox3.Controls.Add(cmbTipoEntorno);
            groupBox3.Controls.Add(lblTipoEntorno);
            groupBox3.Controls.Add(btnGuardarEntorno);
            groupBox3.Controls.Add(btnModificarEntorno);
            groupBox3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(946, 160);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Entornos:";
            // 
            // btnLimpiarEntornos
            // 
            btnLimpiarEntornos.BackColor = Color.White;
            btnLimpiarEntornos.FlatAppearance.BorderSize = 0;
            btnLimpiarEntornos.FlatStyle = FlatStyle.Flat;
            btnLimpiarEntornos.ForeColor = Color.Green;
            btnLimpiarEntornos.Image = Properties.Resources.escoba;
            btnLimpiarEntornos.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiarEntornos.Location = new Point(460, 113);
            btnLimpiarEntornos.Name = "btnLimpiarEntornos";
            btnLimpiarEntornos.Size = new Size(192, 39);
            btnLimpiarEntornos.TabIndex = 55;
            btnLimpiarEntornos.Text = "Limpiar";
            btnLimpiarEntornos.UseVisualStyleBackColor = false;
            btnLimpiarEntornos.Click += btnLimpiarEntornos_Click;
            // 
            // txtTipoEntorno
            // 
            txtTipoEntorno.Location = new Point(389, 67);
            txtTipoEntorno.MaxLength = 30;
            txtTipoEntorno.Name = "txtTipoEntorno";
            txtTipoEntorno.Size = new Size(162, 29);
            txtTipoEntorno.TabIndex = 43;
            txtTipoEntorno.KeyDown += CopiaryPegar_KeyDown;
            txtTipoEntorno.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // cmbTipoEntorno
            // 
            cmbTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEntorno.FormattingEnabled = true;
            cmbTipoEntorno.Location = new Point(211, 64);
            cmbTipoEntorno.Name = "cmbTipoEntorno";
            cmbTipoEntorno.Size = new Size(162, 32);
            cmbTipoEntorno.TabIndex = 41;
            cmbTipoEntorno.SelectedIndexChanged += cmbTipoEntorno_SelectedIndexChanged;
            cmbTipoEntorno.Click += cmbTipoEntorno_SelectedIndexChanged;
            // 
            // lblTipoEntorno
            // 
            lblTipoEntorno.AutoSize = true;
            lblTipoEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTipoEntorno.ForeColor = Color.White;
            lblTipoEntorno.Location = new Point(33, 70);
            lblTipoEntorno.Name = "lblTipoEntorno";
            lblTipoEntorno.Size = new Size(168, 24);
            lblTipoEntorno.TabIndex = 40;
            lblTipoEntorno.Text = "Tipo de Entorno:";
            // 
            // btnGuardarEntorno
            // 
            btnGuardarEntorno.BackColor = Color.White;
            btnGuardarEntorno.FlatAppearance.BorderSize = 0;
            btnGuardarEntorno.FlatStyle = FlatStyle.Flat;
            btnGuardarEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarEntorno.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarEntorno.Image = (Image)resources.GetObject("btnGuardarEntorno.Image");
            btnGuardarEntorno.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarEntorno.Location = new Point(814, 113);
            btnGuardarEntorno.Name = "btnGuardarEntorno";
            btnGuardarEntorno.Size = new Size(126, 41);
            btnGuardarEntorno.TabIndex = 39;
            btnGuardarEntorno.Text = "Guardar";
            btnGuardarEntorno.TextAlign = ContentAlignment.MiddleRight;
            btnGuardarEntorno.UseVisualStyleBackColor = false;
            btnGuardarEntorno.Click += btnGuardarEntorno_Click;
            // 
            // btnModificarEntorno
            // 
            btnModificarEntorno.BackColor = Color.White;
            btnModificarEntorno.FlatAppearance.BorderSize = 0;
            btnModificarEntorno.FlatStyle = FlatStyle.Flat;
            btnModificarEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnModificarEntorno.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarEntorno.Image = (Image)resources.GetObject("btnModificarEntorno.Image");
            btnModificarEntorno.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarEntorno.Location = new Point(658, 113);
            btnModificarEntorno.Name = "btnModificarEntorno";
            btnModificarEntorno.Size = new Size(150, 40);
            btnModificarEntorno.TabIndex = 27;
            btnModificarEntorno.Text = "Modificar";
            btnModificarEntorno.UseVisualStyleBackColor = false;
            btnModificarEntorno.Click += btnModificarEntorno_Click;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(141, 181, 146);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1852, 811);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Alta de Usuario";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtCodigoPostal);
            groupBox1.Controls.Add(btnLimpiarLocalidadPartido);
            groupBox1.Controls.Add(txtLocalidad);
            groupBox1.Controls.Add(txtPartido);
            groupBox1.Controls.Add(btnGuardarUsuario);
            groupBox1.Controls.Add(btnModificarUsuario);
            groupBox1.Controls.Add(cmbLocalidad);
            groupBox1.Controls.Add(lblApellido);
            groupBox1.Controls.Add(cmbPartido);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(8, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(946, 183);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Localidad y Partido:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(506, 50);
            label12.Name = "label12";
            label12.Size = new Size(145, 24);
            label12.TabIndex = 57;
            label12.Text = "Codigo Postal:";
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(657, 44);
            txtCodigoPostal.MaxLength = 10;
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(162, 29);
            txtCodigoPostal.TabIndex = 56;
            txtCodigoPostal.KeyDown += CopiaryPegar_KeyDown;
            txtCodigoPostal.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnLimpiarLocalidadPartido
            // 
            btnLimpiarLocalidadPartido.BackColor = Color.White;
            btnLimpiarLocalidadPartido.FlatAppearance.BorderSize = 0;
            btnLimpiarLocalidadPartido.FlatStyle = FlatStyle.Flat;
            btnLimpiarLocalidadPartido.ForeColor = Color.Green;
            btnLimpiarLocalidadPartido.Image = Properties.Resources.escoba;
            btnLimpiarLocalidadPartido.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiarLocalidadPartido.Location = new Point(460, 136);
            btnLimpiarLocalidadPartido.Name = "btnLimpiarLocalidadPartido";
            btnLimpiarLocalidadPartido.Size = new Size(192, 39);
            btnLimpiarLocalidadPartido.TabIndex = 55;
            btnLimpiarLocalidadPartido.Text = "Limpiar";
            btnLimpiarLocalidadPartido.UseVisualStyleBackColor = false;
            btnLimpiarLocalidadPartido.Click += btnLimpiarLocalidadPartido_Click;
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(304, 44);
            txtLocalidad.MaxLength = 40;
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(162, 29);
            txtLocalidad.TabIndex = 43;
            txtLocalidad.KeyDown += CopiaryPegar_KeyDown;
            txtLocalidad.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // txtPartido
            // 
            txtPartido.Location = new Point(304, 101);
            txtPartido.MaxLength = 40;
            txtPartido.Name = "txtPartido";
            txtPartido.Size = new Size(162, 29);
            txtPartido.TabIndex = 42;
            txtPartido.KeyDown += CopiaryPegar_KeyDown;
            txtPartido.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.BackColor = Color.White;
            btnGuardarUsuario.FlatAppearance.BorderSize = 0;
            btnGuardarUsuario.FlatStyle = FlatStyle.Flat;
            btnGuardarUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarUsuario.Image = (Image)resources.GetObject("btnGuardarUsuario.Image");
            btnGuardarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarUsuario.Location = new Point(814, 136);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(126, 41);
            btnGuardarUsuario.TabIndex = 38;
            btnGuardarUsuario.Text = "Guardar";
            btnGuardarUsuario.TextAlign = ContentAlignment.MiddleRight;
            btnGuardarUsuario.UseVisualStyleBackColor = false;
            btnGuardarUsuario.Click += btnGuardarUsuario_Click;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.BackColor = Color.White;
            btnModificarUsuario.FlatAppearance.BorderSize = 0;
            btnModificarUsuario.FlatStyle = FlatStyle.Flat;
            btnModificarUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnModificarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarUsuario.Image = (Image)resources.GetObject("btnModificarUsuario.Image");
            btnModificarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarUsuario.Location = new Point(658, 136);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(150, 40);
            btnModificarUsuario.TabIndex = 27;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.UseVisualStyleBackColor = false;
            btnModificarUsuario.Click += btnModificarUsuario_Click;
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(126, 41);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(162, 32);
            cmbLocalidad.TabIndex = 26;
            cmbLocalidad.SelectedIndexChanged += cmbLocalidad_SelectedIndexChanged;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(10, 44);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(106, 24);
            lblApellido.TabIndex = 25;
            lblApellido.Text = "Localidad:";
            // 
            // cmbPartido
            // 
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(126, 97);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(162, 32);
            cmbPartido.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 101);
            label2.Name = "label2";
            label2.Size = new Size(81, 24);
            label2.TabIndex = 23;
            label2.Text = "Partido:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1860, 848);
            tabControl1.TabIndex = 4;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(141, 181, 146);
            tabPage3.Controls.Add(groupBox4);
            tabPage3.Location = new Point(4, 33);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1852, 811);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Industria";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnLimpiarIndustria);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(txtPrecioProducto);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(txtReceta);
            groupBox4.Controls.Add(txtProducto);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(cmbProducto);
            groupBox4.Controls.Add(btnGuardarProducto);
            groupBox4.Controls.Add(btnModificarProducto);
            groupBox4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(6, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1827, 368);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Industria:";
            // 
            // btnLimpiarIndustria
            // 
            btnLimpiarIndustria.BackColor = Color.White;
            btnLimpiarIndustria.FlatAppearance.BorderSize = 0;
            btnLimpiarIndustria.FlatStyle = FlatStyle.Flat;
            btnLimpiarIndustria.ForeColor = Color.Green;
            btnLimpiarIndustria.Image = Properties.Resources.escoba;
            btnLimpiarIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiarIndustria.Location = new Point(1321, 308);
            btnLimpiarIndustria.Name = "btnLimpiarIndustria";
            btnLimpiarIndustria.Size = new Size(192, 39);
            btnLimpiarIndustria.TabIndex = 55;
            btnLimpiarIndustria.Text = "Limpiar";
            btnLimpiarIndustria.UseVisualStyleBackColor = false;
            btnLimpiarIndustria.Click += btnLimpiarIndustria_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(40, 107);
            label5.Name = "label5";
            label5.Size = new Size(182, 20);
            label5.TabIndex = 46;
            label5.Text = "Nombre del Producto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(52, 169);
            label4.Name = "label4";
            label4.Size = new Size(170, 20);
            label4.TabIndex = 45;
            label4.Text = "Precio del Producto:";
            // 
            // txtPrecioProducto
            // 
            txtPrecioProducto.Location = new Point(228, 163);
            txtPrecioProducto.MaxLength = 10;
            txtPrecioProducto.Name = "txtPrecioProducto";
            txtPrecioProducto.Size = new Size(162, 29);
            txtPrecioProducto.TabIndex = 44;
            txtPrecioProducto.KeyDown += CopiaryPegar_KeyDown;
            txtPrecioProducto.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(453, 39);
            label3.Name = "label3";
            label3.Size = new Size(81, 24);
            label3.TabIndex = 43;
            label3.Text = "Receta:";
            // 
            // txtReceta
            // 
            txtReceta.Location = new Point(540, 28);
            txtReceta.Multiline = true;
            txtReceta.Name = "txtReceta";
            txtReceta.Size = new Size(1261, 215);
            txtReceta.TabIndex = 42;
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(228, 101);
            txtProducto.MaxLength = 30;
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(162, 29);
            txtProducto.TabIndex = 41;
            txtProducto.KeyDown += CopiaryPegar_KeyDown;
            txtProducto.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 39);
            label1.Name = "label1";
            label1.Size = new Size(201, 24);
            label1.TabIndex = 39;
            label1.Text = "Producto a producir:";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(231, 36);
            cmbProducto.Margin = new Padding(3, 2, 3, 2);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(162, 32);
            cmbProducto.TabIndex = 40;
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.White;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarProducto.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarProducto.Image = (Image)resources.GetObject("btnGuardarProducto.Image");
            btnGuardarProducto.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarProducto.Location = new Point(1675, 306);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(126, 41);
            btnGuardarProducto.TabIndex = 38;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.TextAlign = ContentAlignment.MiddleRight;
            btnGuardarProducto.UseVisualStyleBackColor = false;
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.White;
            btnModificarProducto.FlatAppearance.BorderSize = 0;
            btnModificarProducto.FlatStyle = FlatStyle.Flat;
            btnModificarProducto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnModificarProducto.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarProducto.Image = (Image)resources.GetObject("btnModificarProducto.Image");
            btnModificarProducto.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarProducto.Location = new Point(1519, 306);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(150, 40);
            btnModificarProducto.TabIndex = 27;
            btnModificarProducto.Text = "Modificar";
            btnModificarProducto.UseVisualStyleBackColor = false;
            btnModificarProducto.Click += btnModificarProducto_Click;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.FromArgb(141, 181, 146);
            tabPage4.Controls.Add(btnImprimirProveedores);
            tabPage4.Controls.Add(groupBox5);
            tabPage4.Controls.Add(groupBox6);
            tabPage4.Location = new Point(4, 33);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1852, 811);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Inventario";
            // 
            // btnImprimirProveedores
            // 
            btnImprimirProveedores.BackColor = Color.AliceBlue;
            btnImprimirProveedores.FlatAppearance.BorderSize = 0;
            btnImprimirProveedores.FlatStyle = FlatStyle.Flat;
            btnImprimirProveedores.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimirProveedores.Image = Properties.Resources.imprimir;
            btnImprimirProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirProveedores.Location = new Point(796, 693);
            btnImprimirProveedores.Name = "btnImprimirProveedores";
            btnImprimirProveedores.Size = new Size(150, 40);
            btnImprimirProveedores.TabIndex = 66;
            btnImprimirProveedores.Text = "Imprimir";
            btnImprimirProveedores.UseVisualStyleBackColor = false;
            btnImprimirProveedores.Click += btnImprimirProveedores_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnLimpiarProveedores);
            groupBox5.Controls.Add(dtgProveedores);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(txtDireccion);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(txtEmail);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(txtTelefono);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(txtRazonSocial);
            groupBox5.Controls.Add(btnGuardarProveedor);
            groupBox5.Controls.Add(btnModificarProveedor);
            groupBox5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(3, 172);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(949, 515);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Agrega o Modificar Proveedores:";
            // 
            // btnLimpiarProveedores
            // 
            btnLimpiarProveedores.BackColor = Color.White;
            btnLimpiarProveedores.FlatAppearance.BorderSize = 0;
            btnLimpiarProveedores.FlatStyle = FlatStyle.Flat;
            btnLimpiarProveedores.ForeColor = Color.Green;
            btnLimpiarProveedores.Image = Properties.Resources.escoba;
            btnLimpiarProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiarProveedores.Location = new Point(465, 204);
            btnLimpiarProveedores.Name = "btnLimpiarProveedores";
            btnLimpiarProveedores.Size = new Size(193, 39);
            btnLimpiarProveedores.TabIndex = 56;
            btnLimpiarProveedores.Text = "Limpiar";
            btnLimpiarProveedores.UseVisualStyleBackColor = false;
            btnLimpiarProveedores.Click += btnLimpiarProveedores_Click;
            // 
            // dtgProveedores
            // 
            dtgProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProveedores.Dock = DockStyle.Bottom;
            dtgProveedores.Location = new Point(3, 253);
            dtgProveedores.Name = "dtgProveedores";
            dtgProveedores.Size = new Size(943, 259);
            dtgProveedores.TabIndex = 65;
            dtgProveedores.CellClick += dtgProveedores_CellClick;
            dtgProveedores.CellContentClick += dtgProveedores_CellClick;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(70, 202);
            label11.Name = "label11";
            label11.Size = new Size(105, 24);
            label11.TabIndex = 60;
            label11.Text = "Direccion:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(181, 199);
            txtDireccion.MaxLength = 40;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(278, 29);
            txtDireccion.TabIndex = 59;
            txtDireccion.KeyDown += CopiaryPegar_KeyDown;
            txtDireccion.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(107, 157);
            label10.Name = "label10";
            label10.Size = new Size(68, 24);
            label10.TabIndex = 58;
            label10.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(181, 152);
            txtEmail.MaxLength = 40;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(278, 29);
            txtEmail.TabIndex = 57;
            txtEmail.KeyDown += CopiaryPegar_KeyDown;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(76, 110);
            label8.Name = "label8";
            label8.Size = new Size(99, 24);
            label8.TabIndex = 56;
            label8.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(181, 105);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(278, 29);
            txtTelefono.TabIndex = 55;
            txtTelefono.KeyDown += CopiaryPegar_KeyDown;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(37, 61);
            label7.Name = "label7";
            label7.Size = new Size(138, 24);
            label7.TabIndex = 54;
            label7.Text = "Razon Social:";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(181, 58);
            txtRazonSocial.MaxLength = 40;
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(278, 29);
            txtRazonSocial.TabIndex = 43;
            txtRazonSocial.KeyDown += CopiaryPegar_KeyDown;
            txtRazonSocial.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // btnGuardarProveedor
            // 
            btnGuardarProveedor.BackColor = Color.White;
            btnGuardarProveedor.FlatAppearance.BorderSize = 0;
            btnGuardarProveedor.FlatStyle = FlatStyle.Flat;
            btnGuardarProveedor.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarProveedor.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarProveedor.Image = (Image)resources.GetObject("btnGuardarProveedor.Image");
            btnGuardarProveedor.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarProveedor.Location = new Point(817, 202);
            btnGuardarProveedor.Name = "btnGuardarProveedor";
            btnGuardarProveedor.Size = new Size(126, 41);
            btnGuardarProveedor.TabIndex = 39;
            btnGuardarProveedor.Text = "Guardar";
            btnGuardarProveedor.TextAlign = ContentAlignment.MiddleRight;
            btnGuardarProveedor.UseVisualStyleBackColor = false;
            btnGuardarProveedor.Click += btnGuardarProveedor_Click;
            // 
            // btnModificarProveedor
            // 
            btnModificarProveedor.BackColor = Color.White;
            btnModificarProveedor.FlatAppearance.BorderSize = 0;
            btnModificarProveedor.FlatStyle = FlatStyle.Flat;
            btnModificarProveedor.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnModificarProveedor.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarProveedor.Image = (Image)resources.GetObject("btnModificarProveedor.Image");
            btnModificarProveedor.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarProveedor.Location = new Point(664, 203);
            btnModificarProveedor.Name = "btnModificarProveedor";
            btnModificarProveedor.Size = new Size(150, 40);
            btnModificarProveedor.TabIndex = 27;
            btnModificarProveedor.Text = "Modificar";
            btnModificarProveedor.UseVisualStyleBackColor = false;
            btnModificarProveedor.Click += btnModificarProveedor_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnLimpiarAlimentos);
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(txtKgUnidad);
            groupBox6.Controls.Add(cmbKgUnidad);
            groupBox6.Controls.Add(btnGuardarUnidad);
            groupBox6.Controls.Add(btnModificarUnidad);
            groupBox6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox6.ForeColor = Color.White;
            groupBox6.Location = new Point(6, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(946, 160);
            groupBox6.TabIndex = 2;
            groupBox6.TabStop = false;
            groupBox6.Text = "Agrega o Modificar Tipo de Unidad:";
            // 
            // btnLimpiarAlimentos
            // 
            btnLimpiarAlimentos.BackColor = Color.White;
            btnLimpiarAlimentos.FlatAppearance.BorderSize = 0;
            btnLimpiarAlimentos.FlatStyle = FlatStyle.Flat;
            btnLimpiarAlimentos.ForeColor = Color.Green;
            btnLimpiarAlimentos.Image = Properties.Resources.escoba;
            btnLimpiarAlimentos.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiarAlimentos.Location = new Point(460, 113);
            btnLimpiarAlimentos.Name = "btnLimpiarAlimentos";
            btnLimpiarAlimentos.Size = new Size(192, 39);
            btnLimpiarAlimentos.TabIndex = 55;
            btnLimpiarAlimentos.Text = "Limpiar";
            btnLimpiarAlimentos.UseVisualStyleBackColor = false;
            btnLimpiarAlimentos.Click += btnLimpiarAlimentos_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(47, 71);
            label6.Name = "label6";
            label6.Size = new Size(125, 24);
            label6.TabIndex = 54;
            label6.Text = "Kg / Unidad:";
            // 
            // txtKgUnidad
            // 
            txtKgUnidad.Location = new Point(361, 71);
            txtKgUnidad.MaxLength = 20;
            txtKgUnidad.Name = "txtKgUnidad";
            txtKgUnidad.Size = new Size(162, 29);
            txtKgUnidad.TabIndex = 43;
            txtKgUnidad.KeyDown += CopiaryPegar_KeyDown;
            txtKgUnidad.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // cmbKgUnidad
            // 
            cmbKgUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKgUnidad.FormattingEnabled = true;
            cmbKgUnidad.Location = new Point(178, 68);
            cmbKgUnidad.Name = "cmbKgUnidad";
            cmbKgUnidad.Size = new Size(162, 32);
            cmbKgUnidad.TabIndex = 53;
            cmbKgUnidad.SelectedIndexChanged += cmbKgUnidad_SelectedIndexChanged;
            // 
            // btnGuardarUnidad
            // 
            btnGuardarUnidad.BackColor = Color.White;
            btnGuardarUnidad.FlatAppearance.BorderSize = 0;
            btnGuardarUnidad.FlatStyle = FlatStyle.Flat;
            btnGuardarUnidad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarUnidad.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarUnidad.Image = (Image)resources.GetObject("btnGuardarUnidad.Image");
            btnGuardarUnidad.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarUnidad.Location = new Point(814, 113);
            btnGuardarUnidad.Name = "btnGuardarUnidad";
            btnGuardarUnidad.Size = new Size(126, 41);
            btnGuardarUnidad.TabIndex = 39;
            btnGuardarUnidad.Text = "Guardar";
            btnGuardarUnidad.TextAlign = ContentAlignment.MiddleRight;
            btnGuardarUnidad.UseVisualStyleBackColor = false;
            btnGuardarUnidad.Click += btnGuardarUnidad_Click;
            // 
            // btnModificarUnidad
            // 
            btnModificarUnidad.BackColor = Color.White;
            btnModificarUnidad.FlatAppearance.BorderSize = 0;
            btnModificarUnidad.FlatStyle = FlatStyle.Flat;
            btnModificarUnidad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnModificarUnidad.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarUnidad.Image = (Image)resources.GetObject("btnModificarUnidad.Image");
            btnModificarUnidad.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarUnidad.Location = new Point(658, 113);
            btnModificarUnidad.Name = "btnModificarUnidad";
            btnModificarUnidad.Size = new Size(150, 40);
            btnModificarUnidad.TabIndex = 27;
            btnModificarUnidad.Text = "Modificar";
            btnModificarUnidad.UseVisualStyleBackColor = false;
            btnModificarUnidad.Click += btnModificarUnidad_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AbmAdministracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1884, 861);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AbmAdministracion";
            Text = "AbmAdministracion";
            Load += AbmAdministracion_Load;
            tabPage2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tabPage4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage2;
        private GroupBox groupBox3;
        private TextBox txtTipoEntorno;
        private ComboBox cmbTipoEntorno;
        private Label lblTipoEntorno;
        private Tienda.RJButton btnGuardarEntorno;
        private Tienda.RJButton btnModificarEntorno;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private TextBox txtLocalidad;
        private TextBox txtPartido;
        private Tienda.RJButton btnGuardarUsuario;
        private Tienda.RJButton btnModificarUsuario;
        private ComboBox cmbLocalidad;
        private Label lblApellido;
        private ComboBox cmbPartido;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private GroupBox groupBox4;
        private Tienda.RJButton btnGuardarProducto;
        private Tienda.RJButton btnModificarProducto;
        private Label label1;
        private ComboBox cmbProducto;
        private Label label3;
        private TextBox txtReceta;
        private TextBox txtProducto;
        private TabPage tabPage4;
        private GroupBox groupBox6;
        private TextBox txtKgUnidad;
        private Tienda.RJButton btnGuardarUnidad;
        private Tienda.RJButton btnModificarUnidad;
        private Label label6;
        private ComboBox cmbKgUnidad;
        private Label label4;
        private TextBox txtPrecioProducto;
        private Label label5;
        private GroupBox groupBox5;
        private Label label7;
        private TextBox txtRazonSocial;
        private Tienda.RJButton btnGuardarProveedor;
        private Tienda.RJButton btnModificarProveedor;
        private Label label11;
        private TextBox txtDireccion;
        private Label label10;
        private TextBox txtEmail;
        private Label label8;
        private TextBox txtTelefono;
        private DataGridView dtgProveedores;
        private Tienda.RJButton btnLimpiarEntornos;
        private Tienda.RJButton btnLimpiarLocalidadPartido;
        private Tienda.RJButton btnLimpiarIndustria;
        private Tienda.RJButton btnLimpiarProveedores;
        private Tienda.RJButton btnLimpiarAlimentos;
        private Label label12;
        private TextBox txtCodigoPostal;
        private ErrorProvider errorProvider1;
        private Tienda.RJButton btnImprimirProveedores;
    }
}