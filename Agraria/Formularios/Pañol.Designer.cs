namespace Agraria.Formularios
{
    partial class Pañol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pañol));
            groupBox2 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnImprimir = new Tienda.RJButton();
            dtgArticulos = new DataGridView();
            groupBox1 = new GroupBox();
            btnDarDeAlta = new Tienda.RJButton();
            btnDarDeBaja = new Tienda.RJButton();
            txtFiltrarNombre = new TextBox();
            label3 = new Label();
            gbEnviarPolloIndustria = new GroupBox();
            btnModificarArticulo = new Tienda.RJButton();
            btnLimpiar = new Tienda.RJButton();
            btnAgregar = new Tienda.RJButton();
            label6 = new Label();
            cmbKgUnidad = new ComboBox();
            txtCantidad = new TextBox();
            cmbEntornoFormativo = new ComboBox();
            label2 = new Label();
            dtpFechaIngreso = new DateTimePicker();
            label7 = new Label();
            txtNombreProducto = new TextBox();
            lblEntorno = new Label();
            label4 = new Label();
            lblID = new Label();
            txtResponsableCargo = new TextBox();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgArticulos).BeginInit();
            groupBox1.SuspendLayout();
            gbEnviarPolloIndustria.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tabControl1);
            groupBox2.Controls.Add(groupBox1);
            groupBox2.Controls.Add(gbEnviarPolloIndustria);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(4, 1);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1860, 822);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Busqueda y Carga de todos los Articulos del Pañol";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(6, 436);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1848, 382);
            tabControl1.TabIndex = 75;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(141, 181, 146);
            tabPage1.Controls.Add(btnImprimir);
            tabPage1.Controls.Add(dtgArticulos);
            tabPage1.ForeColor = Color.Black;
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1840, 345);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Articulos";
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.Green;
            btnImprimir.Image = Properties.Resources.imprimir;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(1642, 7);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(192, 39);
            btnImprimir.TabIndex = 55;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // dtgArticulos
            // 
            dtgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgArticulos.Dock = DockStyle.Bottom;
            dtgArticulos.Location = new Point(3, 53);
            dtgArticulos.Margin = new Padding(3, 2, 3, 2);
            dtgArticulos.Name = "dtgArticulos";
            dtgArticulos.ReadOnly = true;
            dtgArticulos.RowHeadersWidth = 51;
            dtgArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgArticulos.Size = new Size(1834, 289);
            dtgArticulos.TabIndex = 45;
            dtgArticulos.CellClick += dtgArticulos_CellClick;
            dtgArticulos.CellContentClick += dtgArticulos_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDarDeAlta);
            groupBox1.Controls.Add(btnDarDeBaja);
            groupBox1.Controls.Add(txtFiltrarNombre);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(722, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 397);
            groupBox1.TabIndex = 72;
            groupBox1.TabStop = false;
            groupBox1.Text = "Busqueda Articulos por Nombre";
            // 
            // btnDarDeAlta
            // 
            btnDarDeAlta.BackColor = Color.White;
            btnDarDeAlta.FlatAppearance.BorderSize = 0;
            btnDarDeAlta.FlatStyle = FlatStyle.Flat;
            btnDarDeAlta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnDarDeAlta.ForeColor = Color.FromArgb(56, 124, 31);
            btnDarDeAlta.Image = (Image)resources.GetObject("btnDarDeAlta.Image");
            btnDarDeAlta.ImageAlign = ContentAlignment.MiddleLeft;
            btnDarDeAlta.Location = new Point(6, 351);
            btnDarDeAlta.Name = "btnDarDeAlta";
            btnDarDeAlta.Size = new Size(150, 40);
            btnDarDeAlta.TabIndex = 42;
            btnDarDeAlta.Text = "Alta";
            btnDarDeAlta.UseVisualStyleBackColor = false;
            btnDarDeAlta.Click += btnDarDeAlta_Click;
            // 
            // btnDarDeBaja
            // 
            btnDarDeBaja.BackColor = Color.White;
            btnDarDeBaja.FlatAppearance.BorderSize = 0;
            btnDarDeBaja.FlatStyle = FlatStyle.Flat;
            btnDarDeBaja.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnDarDeBaja.ForeColor = Color.FromArgb(56, 124, 31);
            btnDarDeBaja.Image = (Image)resources.GetObject("btnDarDeBaja.Image");
            btnDarDeBaja.ImageAlign = ContentAlignment.MiddleLeft;
            btnDarDeBaja.Location = new Point(289, 351);
            btnDarDeBaja.Name = "btnDarDeBaja";
            btnDarDeBaja.Size = new Size(150, 40);
            btnDarDeBaja.TabIndex = 43;
            btnDarDeBaja.Text = "Baja";
            btnDarDeBaja.UseVisualStyleBackColor = false;
            btnDarDeBaja.Click += btnDarDeBaja_Click;
            // 
            // txtFiltrarNombre
            // 
            txtFiltrarNombre.Location = new Point(157, 76);
            txtFiltrarNombre.MaxLength = 30;
            txtFiltrarNombre.Name = "txtFiltrarNombre";
            txtFiltrarNombre.Size = new Size(223, 29);
            txtFiltrarNombre.TabIndex = 40;
            txtFiltrarNombre.TextChanged += txtFiltrarNombre_TextChanged;
            txtFiltrarNombre.KeyDown += CopiaryPegar_KeyDown;
            txtFiltrarNombre.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(60, 79);
            label3.Name = "label3";
            label3.Size = new Size(91, 24);
            label3.TabIndex = 41;
            label3.Text = "Nombre:";
            label3.Visible = false;
            // 
            // gbEnviarPolloIndustria
            // 
            gbEnviarPolloIndustria.Controls.Add(btnModificarArticulo);
            gbEnviarPolloIndustria.Controls.Add(btnLimpiar);
            gbEnviarPolloIndustria.Controls.Add(btnAgregar);
            gbEnviarPolloIndustria.Controls.Add(label6);
            gbEnviarPolloIndustria.Controls.Add(cmbKgUnidad);
            gbEnviarPolloIndustria.Controls.Add(txtCantidad);
            gbEnviarPolloIndustria.Controls.Add(cmbEntornoFormativo);
            gbEnviarPolloIndustria.Controls.Add(label2);
            gbEnviarPolloIndustria.Controls.Add(dtpFechaIngreso);
            gbEnviarPolloIndustria.Controls.Add(label7);
            gbEnviarPolloIndustria.Controls.Add(txtNombreProducto);
            gbEnviarPolloIndustria.Controls.Add(lblEntorno);
            gbEnviarPolloIndustria.Controls.Add(label4);
            gbEnviarPolloIndustria.Controls.Add(lblID);
            gbEnviarPolloIndustria.Controls.Add(txtResponsableCargo);
            gbEnviarPolloIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbEnviarPolloIndustria.ForeColor = Color.White;
            gbEnviarPolloIndustria.Location = new Point(26, 33);
            gbEnviarPolloIndustria.Name = "gbEnviarPolloIndustria";
            gbEnviarPolloIndustria.Size = new Size(677, 397);
            gbEnviarPolloIndustria.TabIndex = 71;
            gbEnviarPolloIndustria.TabStop = false;
            gbEnviarPolloIndustria.Text = "Carga de Articulos";
            // 
            // btnModificarArticulo
            // 
            btnModificarArticulo.BackColor = Color.White;
            btnModificarArticulo.FlatAppearance.BorderSize = 0;
            btnModificarArticulo.FlatStyle = FlatStyle.Flat;
            btnModificarArticulo.ForeColor = Color.Green;
            btnModificarArticulo.Image = Properties.Resources.Modificar77;
            btnModificarArticulo.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarArticulo.Location = new Point(83, 352);
            btnModificarArticulo.Name = "btnModificarArticulo";
            btnModificarArticulo.Size = new Size(192, 39);
            btnModificarArticulo.TabIndex = 5;
            btnModificarArticulo.Text = "Modificar";
            btnModificarArticulo.UseVisualStyleBackColor = false;
            btnModificarArticulo.Click += btnModificarArticulo_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.Green;
            btnLimpiar.Image = Properties.Resources.escoba;
            btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.Location = new Point(281, 352);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(192, 39);
            btnLimpiar.TabIndex = 54;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.White;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.Green;
            btnAgregar.Image = Properties.Resources.guardar_datos;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(479, 352);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(192, 39);
            btnAgregar.TabIndex = 53;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(130, 130);
            label6.Name = "label6";
            label6.Size = new Size(119, 24);
            label6.TabIndex = 52;
            label6.Text = "Kg /Unidad:";
            // 
            // cmbKgUnidad
            // 
            cmbKgUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKgUnidad.FormattingEnabled = true;
            cmbKgUnidad.Location = new Point(255, 122);
            cmbKgUnidad.Name = "cmbKgUnidad";
            cmbKgUnidad.Size = new Size(223, 32);
            cmbKgUnidad.TabIndex = 51;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(255, 78);
            txtCantidad.MaxLength = 5;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(223, 29);
            txtCantidad.TabIndex = 5;
            txtCantidad.KeyDown += CopiaryPegar_KeyDown;
            txtCantidad.KeyPress += SoloNumeros_KeyPress;
            // 
            // cmbEntornoFormativo
            // 
            cmbEntornoFormativo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntornoFormativo.FormattingEnabled = true;
            cmbEntornoFormativo.Location = new Point(255, 218);
            cmbEntornoFormativo.Name = "cmbEntornoFormativo";
            cmbEntornoFormativo.Size = new Size(223, 32);
            cmbEntornoFormativo.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 276);
            label2.Name = "label2";
            label2.Size = new Size(214, 24);
            label2.TabIndex = 15;
            label2.Text = "Responsable a cargo:";
            // 
            // dtpFechaIngreso
            // 
            dtpFechaIngreso.Location = new Point(255, 172);
            dtpFechaIngreso.Margin = new Padding(3, 2, 3, 2);
            dtpFechaIngreso.Name = "dtpFechaIngreso";
            dtpFechaIngreso.Size = new Size(391, 29);
            dtpFechaIngreso.TabIndex = 47;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(151, 81);
            label7.Name = "label7";
            label7.Size = new Size(98, 24);
            label7.TabIndex = 20;
            label7.Text = "Cantidad:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(255, 34);
            txtNombreProducto.MaxLength = 40;
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(223, 29);
            txtNombreProducto.TabIndex = 11;
            txtNombreProducto.KeyDown += CopiaryPegar_KeyDown;
            // 
            // lblEntorno
            // 
            lblEntorno.AutoSize = true;
            lblEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblEntorno.ForeColor = Color.White;
            lblEntorno.Location = new Point(68, 37);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(181, 24);
            lblEntorno.TabIndex = 21;
            lblEntorno.Text = "Nombre Producto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(61, 218);
            label4.Name = "label4";
            label4.Size = new Size(188, 24);
            label4.TabIndex = 44;
            label4.Text = "Entorno Formativo:";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(98, 172);
            lblID.Name = "lblID";
            lblID.Size = new Size(151, 24);
            lblID.TabIndex = 34;
            lblID.Text = "Fecha Ingreso:";
            // 
            // txtResponsableCargo
            // 
            txtResponsableCargo.Location = new Point(255, 269);
            txtResponsableCargo.MaxLength = 40;
            txtResponsableCargo.Name = "txtResponsableCargo";
            txtResponsableCargo.Size = new Size(223, 29);
            txtResponsableCargo.TabIndex = 36;
            txtResponsableCargo.KeyDown += CopiaryPegar_KeyDown;
            txtResponsableCargo.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // Pañol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1868, 822);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Pañol";
            Text = "Pañol";
            Load += Pañol_Load;
            groupBox2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgArticulos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbEnviarPolloIndustria.ResumeLayout(false);
            gbEnviarPolloIndustria.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Tienda.RJButton btnImprimir;
        private DataGridView dtgArticulos;
        private GroupBox groupBox1;
        private TextBox txtFiltrarNombre;
        private Label label3;
        private GroupBox gbEnviarPolloIndustria;
        private Tienda.RJButton btnModificarArticulo;
        private Tienda.RJButton btnLimpiar;
        private Tienda.RJButton btnAgregar;
        private Label label6;
        private ComboBox cmbKgUnidad;
        private TextBox txtCantidad;
        private ComboBox cmbEntornoFormativo;
        private Label label2;
        private DateTimePicker dtpFechaIngreso;
        private Label label7;
        private TextBox txtNombreProducto;
        private Label lblEntorno;
        private Label label4;
        private Label lblID;
        private TextBox txtResponsableCargo;
        private Tienda.RJButton btnDarDeAlta;
        private Tienda.RJButton btnDarDeBaja;
    }
}