namespace Agraria.UserControls
{
    partial class UcVegetales
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dtgCosecha = new DataGridView();
            groupBox2 = new GroupBox();
            dtpFechaCultivo = new DateTimePicker();
            lblFechaPlantacion = new Label();
            btnGuardarPlantin = new Tienda.RJButton();
            txtAgregarPlantines = new TextBox();
            lblAgregarPlantines = new Label();
            gpbEnviarindus = new GroupBox();
            btnImprimir = new Tienda.RJButton();
            btnResetearPlantines = new Tienda.RJButton();
            cmbCantidad = new ComboBox();
            dtpFechaEgreso = new DateTimePicker();
            btnEnviarArticulos = new Tienda.RJButton();
            lblFchEgreso = new Label();
            lblCantAtados = new Label();
            groupBox1 = new GroupBox();
            dtpFechaPlantado = new DateTimePicker();
            lblFechaCosecha = new Label();
            btnGuardar = new Tienda.RJButton();
            txtAgregarAtadoCosechado = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dtgCosecha).BeginInit();
            groupBox2.SuspendLayout();
            gpbEnviarindus.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtgCosecha
            // 
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dtgCosecha.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgCosecha.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.MenuText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgCosecha.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgCosecha.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCosecha.Dock = DockStyle.Bottom;
            dtgCosecha.Location = new Point(0, 0);
            dtgCosecha.Name = "dtgCosecha";
            dtgCosecha.ReadOnly = true;
            dtgCosecha.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCosecha.Size = new Size(1006, 204);
            dtgCosecha.TabIndex = 88;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpFechaCultivo);
            groupBox2.Controls.Add(lblFechaPlantacion);
            groupBox2.Controls.Add(btnGuardarPlantin);
            groupBox2.Controls.Add(txtAgregarPlantines);
            groupBox2.Controls.Add(lblAgregarPlantines);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(6, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(950, 147);
            groupBox2.TabIndex = 91;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ingresar datos de Plantines";
            // 
            // dtpFechaCultivo
            // 
            dtpFechaCultivo.Location = new Point(247, 94);
            dtpFechaCultivo.Name = "dtpFechaCultivo";
            dtpFechaCultivo.Size = new Size(425, 29);
            dtpFechaCultivo.TabIndex = 89;
            // 
            // lblFechaPlantacion
            // 
            lblFechaPlantacion.AutoSize = true;
            lblFechaPlantacion.Location = new Point(52, 99);
            lblFechaPlantacion.Name = "lblFechaPlantacion";
            lblFechaPlantacion.Size = new Size(180, 24);
            lblFechaPlantacion.TabIndex = 88;
            lblFechaPlantacion.Text = "Fecha  de Cultivo:";
            // 
            // btnGuardarPlantin
            // 
            btnGuardarPlantin.BackColor = Color.White;
            btnGuardarPlantin.FlatAppearance.BorderSize = 0;
            btnGuardarPlantin.FlatStyle = FlatStyle.Flat;
            btnGuardarPlantin.ForeColor = Color.Green;
            btnGuardarPlantin.Image = Properties.Resources.vegetales;
            btnGuardarPlantin.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarPlantin.Location = new Point(739, 95);
            btnGuardarPlantin.Name = "btnGuardarPlantin";
            btnGuardarPlantin.Size = new Size(192, 39);
            btnGuardarPlantin.TabIndex = 87;
            btnGuardarPlantin.Text = "Guardar";
            btnGuardarPlantin.UseVisualStyleBackColor = false;
            btnGuardarPlantin.Click += btnGuardarPlantin_Click;
            // 
            // txtAgregarPlantines
            // 
            txtAgregarPlantines.Location = new Point(247, 40);
            txtAgregarPlantines.MaxLength = 7;
            txtAgregarPlantines.Name = "txtAgregarPlantines";
            txtAgregarPlantines.Size = new Size(117, 29);
            txtAgregarPlantines.TabIndex = 85;
            txtAgregarPlantines.KeyDown += CopiaryPegar_KeyDown;
            txtAgregarPlantines.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblAgregarPlantines
            // 
            lblAgregarPlantines.AutoSize = true;
            lblAgregarPlantines.Location = new Point(61, 46);
            lblAgregarPlantines.Name = "lblAgregarPlantines";
            lblAgregarPlantines.Size = new Size(171, 24);
            lblAgregarPlantines.TabIndex = 84;
            lblAgregarPlantines.Text = "Plantin Cultivado:";
            // 
            // gpbEnviarindus
            // 
            gpbEnviarindus.Controls.Add(btnImprimir);
            gpbEnviarindus.Controls.Add(btnResetearPlantines);
            gpbEnviarindus.Controls.Add(cmbCantidad);
            gpbEnviarindus.Controls.Add(dtpFechaEgreso);
            gpbEnviarindus.Controls.Add(btnEnviarArticulos);
            gpbEnviarindus.Controls.Add(lblFchEgreso);
            gpbEnviarindus.Controls.Add(lblCantAtados);
            gpbEnviarindus.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            gpbEnviarindus.ForeColor = Color.White;
            gpbEnviarindus.Location = new Point(6, 309);
            gpbEnviarindus.Name = "gpbEnviarindus";
            gpbEnviarindus.Size = new Size(950, 164);
            gpbEnviarindus.TabIndex = 89;
            gpbEnviarindus.TabStop = false;
            gpbEnviarindus.Text = "Enviar a Industria";
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.Green;
            btnImprimir.Image = Properties.Resources.imprimir;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(752, 19);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(192, 39);
            btnImprimir.TabIndex = 89;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnResetearPlantines
            // 
            btnResetearPlantines.BackColor = Color.White;
            btnResetearPlantines.FlatAppearance.BorderSize = 0;
            btnResetearPlantines.FlatStyle = FlatStyle.Flat;
            btnResetearPlantines.ForeColor = Color.Green;
            btnResetearPlantines.Location = new Point(752, 69);
            btnResetearPlantines.Name = "btnResetearPlantines";
            btnResetearPlantines.Size = new Size(192, 39);
            btnResetearPlantines.TabIndex = 88;
            btnResetearPlantines.Text = "Plantines en 0";
            btnResetearPlantines.UseVisualStyleBackColor = false;
            btnResetearPlantines.Click += btnResetearPlantines_Click;
            // 
            // cmbCantidad
            // 
            cmbCantidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCantidad.FormattingEnabled = true;
            cmbCantidad.Location = new Point(247, 46);
            cmbCantidad.Name = "cmbCantidad";
            cmbCantidad.Size = new Size(121, 32);
            cmbCantidad.TabIndex = 6;
            // 
            // dtpFechaEgreso
            // 
            dtpFechaEgreso.Location = new Point(247, 93);
            dtpFechaEgreso.Name = "dtpFechaEgreso";
            dtpFechaEgreso.Size = new Size(411, 29);
            dtpFechaEgreso.TabIndex = 5;
            // 
            // btnEnviarArticulos
            // 
            btnEnviarArticulos.BackColor = Color.White;
            btnEnviarArticulos.FlatAppearance.BorderSize = 0;
            btnEnviarArticulos.FlatStyle = FlatStyle.Flat;
            btnEnviarArticulos.ForeColor = Color.Green;
            btnEnviarArticulos.Image = Properties.Resources.fabrica;
            btnEnviarArticulos.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnviarArticulos.Location = new Point(752, 119);
            btnEnviarArticulos.Name = "btnEnviarArticulos";
            btnEnviarArticulos.Size = new Size(192, 39);
            btnEnviarArticulos.TabIndex = 4;
            btnEnviarArticulos.Text = "Enviar";
            btnEnviarArticulos.UseVisualStyleBackColor = false;
            btnEnviarArticulos.Click += btnEnviarArticulos_Click;
            // 
            // lblFchEgreso
            // 
            lblFchEgreso.AutoSize = true;
            lblFchEgreso.Location = new Point(54, 97);
            lblFchEgreso.Name = "lblFchEgreso";
            lblFchEgreso.Size = new Size(178, 24);
            lblFchEgreso.TabIndex = 2;
            lblFchEgreso.Text = "Fecha de Egreso:";
            // 
            // lblCantAtados
            // 
            lblCantAtados.AutoSize = true;
            lblCantAtados.Location = new Point(134, 58);
            lblCantAtados.Name = "lblCantAtados";
            lblCantAtados.Size = new Size(98, 24);
            lblCantAtados.TabIndex = 0;
            lblCantAtados.Text = "Cantidad:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpFechaPlantado);
            groupBox1.Controls.Add(lblFechaCosecha);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtAgregarAtadoCosechado);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(6, 156);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(950, 147);
            groupBox1.TabIndex = 90;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingresar datos de ";
            // 
            // dtpFechaPlantado
            // 
            dtpFechaPlantado.Location = new Point(247, 91);
            dtpFechaPlantado.Name = "dtpFechaPlantado";
            dtpFechaPlantado.Size = new Size(425, 29);
            dtpFechaPlantado.TabIndex = 89;
            // 
            // lblFechaCosecha
            // 
            lblFechaCosecha.AutoSize = true;
            lblFechaCosecha.Location = new Point(33, 95);
            lblFechaCosecha.Name = "lblFechaCosecha";
            lblFechaCosecha.Size = new Size(199, 24);
            lblFechaCosecha.TabIndex = 88;
            lblFechaCosecha.Text = "Fecha  de Cosecha:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.White;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.Green;
            btnGuardar.Image = Properties.Resources.vegetales;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(739, 95);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(192, 39);
            btnGuardar.TabIndex = 87;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtAgregarAtadoCosechado
            // 
            txtAgregarAtadoCosechado.Location = new Point(247, 37);
            txtAgregarAtadoCosechado.MaxLength = 7;
            txtAgregarAtadoCosechado.Name = "txtAgregarAtadoCosechado";
            txtAgregarAtadoCosechado.Size = new Size(117, 29);
            txtAgregarAtadoCosechado.TabIndex = 85;
            txtAgregarAtadoCosechado.KeyDown += CopiaryPegar_KeyDown;
            txtAgregarAtadoCosechado.KeyPress += SoloNumeros_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 41);
            label1.Name = "label1";
            label1.Size = new Size(209, 24);
            label1.TabIndex = 84;
            label1.Text = "Cantidad Cosechada:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lime;
            panel1.Controls.Add(dtgCosecha);
            panel1.Location = new Point(3, 479);
            panel1.Name = "panel1";
            panel1.Size = new Size(1006, 204);
            panel1.TabIndex = 92;
            // 
            // UcVegetales
            // 
            BackColor = Color.FromArgb(141, 181, 146);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(gpbEnviarindus);
            Controls.Add(groupBox1);
            Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            MaximumSize = new Size(1012, 695);
            Name = "UcVegetales";
            Size = new Size(1012, 695);
            Load += UcVegetales_Load_1;
            ((System.ComponentModel.ISupportInitialize)dtgCosecha).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            gpbEnviarindus.ResumeLayout(false);
            gpbEnviarindus.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }
        private DataGridView dtgCosecha;
        private GroupBox groupBox2;
        private DateTimePicker dtpFechaCultivo;
        private Label lblFechaPlantacion;
        private Tienda.RJButton btnGuardarPlantin;
        private TextBox txtAgregarPlantines;
        private Label lblAgregarPlantines;
        private GroupBox gpbEnviarindus;
        private Tienda.RJButton btnImprimir;
        private Tienda.RJButton btnResetearPlantines;
        private ComboBox cmbCantidad;
        private DateTimePicker dtpFechaEgreso;
        private Tienda.RJButton btnEnviarArticulos;
        private Label lblFchEgreso;
        private Label lblCantAtados;
        private GroupBox groupBox1;
        private DateTimePicker dtpFechaPlantado;
        private Label lblFechaCosecha;
        private Tienda.RJButton btnGuardar;
        private TextBox txtAgregarAtadoCosechado;
        private Label label1;
        private Panel panel1;
    }
}
