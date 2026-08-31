namespace Agraria.Formularios
{
    partial class Industria
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
            groupBox1 = new GroupBox();
            txtDetalle = new TextBox();
            panel2 = new Panel();
            dtgArticulosIndustria = new DataGridView();
            panel1 = new Panel();
            dtgInsumos = new DataGridView();
            btnGuardarIndustria = new Tienda.RJButton();
            btnImprimir = new Tienda.RJButton();
            btnQuitar = new Tienda.RJButton();
            btnAgregar = new Tienda.RJButton();
            txtCantidadInsumos = new TextBox();
            txtCantidadProduccion = new TextBox();
            label3 = new Label();
            txtRecetas = new TextBox();
            label2 = new Label();
            cmbInsumos = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            dtpFecha = new DateTimePicker();
            label4 = new Label();
            label1 = new Label();
            cmbProducto = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgArticulosIndustria).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgInsumos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(141, 181, 146);
            groupBox1.Controls.Add(txtDetalle);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(btnGuardarIndustria);
            groupBox1.Controls.Add(btnImprimir);
            groupBox1.Controls.Add(btnQuitar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtCantidadInsumos);
            groupBox1.Controls.Add(txtCantidadProduccion);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtRecetas);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbInsumos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpFecha);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbProducto);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(5, 1);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(1875, 827);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Elaboracion de Productos a Base de Producción Vegetal y Animal";
            // 
            // txtDetalle
            // 
            txtDetalle.Location = new Point(502, 207);
            txtDetalle.MaxLength = 5;
            txtDetalle.Name = "txtDetalle";
            txtDetalle.Size = new Size(111, 29);
            txtDetalle.TabIndex = 61;
            txtDetalle.KeyDown += CopiaryPegar_KeyDown;
            txtDetalle.KeyPress += SoloNumeros_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Yellow;
            panel2.Controls.Add(dtgArticulosIndustria);
            panel2.ForeColor = Color.Black;
            panel2.Location = new Point(595, 351);
            panel2.Name = "panel2";
            panel2.Size = new Size(1267, 409);
            panel2.TabIndex = 60;
            // 
            // dtgArticulosIndustria
            // 
            dtgArticulosIndustria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgArticulosIndustria.Location = new Point(0, 0);
            dtgArticulosIndustria.Margin = new Padding(3, 2, 3, 2);
            dtgArticulosIndustria.Name = "dtgArticulosIndustria";
            dtgArticulosIndustria.RowHeadersWidth = 51;
            dtgArticulosIndustria.Size = new Size(1267, 409);
            dtgArticulosIndustria.TabIndex = 54;
            dtgArticulosIndustria.CellContentClick += dtgArticulosIndustria_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Yellow;
            panel1.Controls.Add(dtgInsumos);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(102, 350);
            panel1.Name = "panel1";
            panel1.Size = new Size(487, 410);
            panel1.TabIndex = 59;
            // 
            // dtgInsumos
            // 
            dtgInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgInsumos.Location = new Point(0, -1);
            dtgInsumos.Margin = new Padding(3, 2, 3, 2);
            dtgInsumos.Name = "dtgInsumos";
            dtgInsumos.RowHeadersWidth = 51;
            dtgInsumos.Size = new Size(488, 411);
            dtgInsumos.TabIndex = 45;
            // 
            // btnGuardarIndustria
            // 
            btnGuardarIndustria.BackColor = Color.White;
            btnGuardarIndustria.FlatAppearance.BorderSize = 0;
            btnGuardarIndustria.FlatStyle = FlatStyle.Flat;
            btnGuardarIndustria.ForeColor = Color.Green;
            btnGuardarIndustria.Image = Properties.Resources.guardar_datos;
            btnGuardarIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarIndustria.Location = new Point(1654, 774);
            btnGuardarIndustria.Name = "btnGuardarIndustria";
            btnGuardarIndustria.Size = new Size(192, 39);
            btnGuardarIndustria.TabIndex = 58;
            btnGuardarIndustria.Text = "Guardar";
            btnGuardarIndustria.UseVisualStyleBackColor = false;
            btnGuardarIndustria.Click += btnGuardar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.Green;
            btnImprimir.Image = Properties.Resources.imprimir;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(1426, 774);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(192, 39);
            btnImprimir.TabIndex = 57;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.BackColor = Color.White;
            btnQuitar.FlatAppearance.BorderSize = 0;
            btnQuitar.FlatStyle = FlatStyle.Flat;
            btnQuitar.ForeColor = Color.Green;
            btnQuitar.Image = Properties.Resources.cruz66;
            btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitar.Location = new Point(384, 305);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(192, 39);
            btnQuitar.TabIndex = 56;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.White;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.Green;
            btnAgregar.Image = Properties.Resources.salida;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(174, 305);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(192, 39);
            btnAgregar.TabIndex = 55;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtCantidadInsumos
            // 
            txtCantidadInsumos.Location = new Point(320, 254);
            txtCantidadInsumos.MaxLength = 5;
            txtCantidadInsumos.Name = "txtCantidadInsumos";
            txtCantidadInsumos.Size = new Size(162, 29);
            txtCantidadInsumos.TabIndex = 53;
            txtCantidadInsumos.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadInsumos.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtCantidadProduccion
            // 
            txtCantidadProduccion.Location = new Point(320, 111);
            txtCantidadProduccion.MaxLength = 4;
            txtCantidadProduccion.Name = "txtCantidadProduccion";
            txtCantidadProduccion.Size = new Size(162, 29);
            txtCantidadProduccion.TabIndex = 52;
            txtCantidadProduccion.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadProduccion.KeyPress += SoloNumeros_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1329, 40);
            label3.Name = "label3";
            label3.Size = new Size(85, 24);
            label3.TabIndex = 51;
            label3.Text = "Recetas";
            // 
            // txtRecetas
            // 
            txtRecetas.Location = new Point(887, 73);
            txtRecetas.Multiline = true;
            txtRecetas.Name = "txtRecetas";
            txtRecetas.Size = new Size(959, 250);
            txtRecetas.TabIndex = 50;
            txtRecetas.KeyDown += CopiaryPegar_KeyDown;
            txtRecetas.KeyPress += TextoyNumero_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(102, 254);
            label2.Name = "label2";
            label2.Size = new Size(212, 24);
            label2.TabIndex = 49;
            label2.Text = "Cantidad de Insumos:";
            // 
            // cmbInsumos
            // 
            cmbInsumos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInsumos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbInsumos.FormattingEnabled = true;
            cmbInsumos.Location = new Point(320, 204);
            cmbInsumos.Margin = new Padding(3, 2, 3, 2);
            cmbInsumos.Name = "cmbInsumos";
            cmbInsumos.Size = new Size(162, 32);
            cmbInsumos.TabIndex = 43;
            cmbInsumos.SelectedIndexChanged += cmbInsumos_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(220, 207);
            label7.Name = "label7";
            label7.Size = new Size(94, 24);
            label7.TabIndex = 42;
            label7.Text = "Insumos:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(97, 160);
            label6.Name = "label6";
            label6.Size = new Size(217, 24);
            label6.TabIndex = 41;
            label6.Text = "Fecha de produccion:";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFecha.Location = new Point(320, 159);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(401, 29);
            dtpFecha.TabIndex = 40;
            dtpFecha.Value = new DateTime(2025, 9, 16, 20, 46, 43, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(74, 111);
            label4.Name = "label4";
            label4.Size = new Size(240, 24);
            label4.TabIndex = 2;
            label4.Text = "Cantidad en produccion:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(113, 69);
            label1.Name = "label1";
            label1.Size = new Size(201, 24);
            label1.TabIndex = 0;
            label1.Text = "Producto a producir:";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(320, 66);
            cmbProducto.Margin = new Padding(3, 2, 3, 2);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(162, 32);
            cmbProducto.TabIndex = 1;
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Industria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1884, 861);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Industria";
            Text = "Industria";
            Load += Industria_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgArticulosIndustria).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgInsumos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Tienda.RJButton btn_imprimir;
        private Tienda.RJButton btn_eliminar;
        private Tienda.RJButton btn_agregar;
        private DataGridView dgv_producion;
        private NumericUpDown nud_insumos;
        private ComboBox cmbInsumos;
        private Label label7;
        private Label label6;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtp_fecha;
        private Tienda.RJButton btnGuardar;
        private NumericUpDown nud_cantidad;
        private Label label4;
        private Label label1;
        private ComboBox cmbProducto;
        private Label label2;
        private Label label3;
        private TextBox txtRecetas;
        private TextBox txtCantidadInsumos;
        private DataGridView dtgArticulosIndustria;
        private TextBox txtCantidadProduccion;
        private DataGridView dtgInsumos;
        private Tienda.RJButton btnGuardarIndustria;
        private Tienda.RJButton btnImprimir;
        private Tienda.RJButton btnQuitar;
        private Tienda.RJButton btnAgregar;
        private Panel panel2;
        private Panel panel1;
        private TextBox txtDetalle;
        private ErrorProvider errorProvider1;
    }
}