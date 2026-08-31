using Tienda;

namespace Agraria.UserControls
{
    partial class UcLeche
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcLeche));
            tabControl1 = new TabControl();
            tabPage7 = new TabPage();
            groupBox2 = new GroupBox();
            cmbRetiroAnimal = new ComboBox();
            dtpFechaRetiro = new DateTimePicker();
            label3 = new Label();
            btnRetiroAnimal = new RJButton();
            label5 = new Label();
            groupBox1 = new GroupBox();
            cmbAnimalOrdeñe = new ComboBox();
            dtpFechaOrdeñe = new DateTimePicker();
            label1 = new Label();
            btnGuardarLeche = new RJButton();
            label2 = new Label();
            txtLitroLeche = new TextBox();
            lblLitroLeche = new Label();
            btnImprimir = new RJButton();
            txtBuscarRegistroProduccion = new TextBox();
            label10 = new Label();
            dtgRegistrosProduccion = new DataGridView();
            gbRegistroProductoras = new GroupBox();
            dtpIngresoAnimal = new DateTimePicker();
            label4 = new Label();
            rbMacho = new RadioButton();
            rbHembra = new RadioButton();
            btnGuardarAnimal = new RJButton();
            lblNumeroCaravana = new Label();
            txtNumeroAnimal = new TextBox();
            gbEnviarIndustria = new GroupBox();
            cmbLitroLecheEnviado = new ComboBox();
            dtpFechaEnviado = new DateTimePicker();
            btnEnviarLeche = new RJButton();
            lblLecheEnvasado2 = new Label();
            lblLitroLeche2 = new Label();
            tabPage8 = new TabPage();
            btnImprimirNacimientos = new RJButton();
            txtBuscarRegistroNacimiento = new TextBox();
            label7 = new Label();
            dtgNacimientos = new DataGridView();
            gbRegistroNacimiento = new GroupBox();
            cmbTipo2 = new ComboBox();
            label6 = new Label();
            cmbPadreNacimiento = new ComboBox();
            cmbMadreNacimiento = new ComboBox();
            txtCantidadMachos = new TextBox();
            txtCantidadHembras = new TextBox();
            txtTotalNacidos = new TextBox();
            lblCantidadMachosCerdos = new Label();
            lblCantidadHembrasCerdos = new Label();
            lblTotalNacidosCerdos = new Label();
            lblNumeroPadre2 = new Label();
            dtpFechaParto = new DateTimePicker();
            btnRegistroNacimiento = new RJButton();
            lblNumeroMadre2 = new Label();
            lblFechaParto = new Label();
            gbRegistroMonta = new GroupBox();
            cmbNumeroPadre = new ComboBox();
            cmbNumeroMadre = new ComboBox();
            lblNumeroPadreOvino = new Label();
            cmbTipo = new ComboBox();
            lblTipo = new Label();
            dtpPosibleParto = new DateTimePicker();
            dtpFechaMonta = new DateTimePicker();
            btnGuardarRegistroMontaOvina = new RJButton();
            lblNumeroMadreOvina = new Label();
            lblPosibleParto = new Label();
            lblFechaMonta = new Label();
            tabControl1.SuspendLayout();
            tabPage7.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgRegistrosProduccion).BeginInit();
            gbRegistroProductoras.SuspendLayout();
            gbEnviarIndustria.SuspendLayout();
            tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgNacimientos).BeginInit();
            gbRegistroNacimiento.SuspendLayout();
            gbRegistroMonta.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage8);
            tabControl1.Cursor = Cursors.Hand;
            tabControl1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(993, 706);
            tabControl1.TabIndex = 1;
            // 
            // tabPage7
            // 
            tabPage7.BackColor = Color.FromArgb(141, 181, 146);
            tabPage7.Controls.Add(groupBox2);
            tabPage7.Controls.Add(groupBox1);
            tabPage7.Controls.Add(btnImprimir);
            tabPage7.Controls.Add(txtBuscarRegistroProduccion);
            tabPage7.Controls.Add(label10);
            tabPage7.Controls.Add(dtgRegistrosProduccion);
            tabPage7.Controls.Add(gbRegistroProductoras);
            tabPage7.Controls.Add(gbEnviarIndustria);
            tabPage7.Location = new Point(4, 33);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(985, 669);
            tabPage7.TabIndex = 0;
            tabPage7.Text = "Registro de Producción de Leche";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbRetiroAnimal);
            groupBox2.Controls.Add(dtpFechaRetiro);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnRetiroAnimal);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(510, 211);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(477, 228);
            groupBox2.TabIndex = 99;
            groupBox2.TabStop = false;
            groupBox2.Text = "Retirar animal Fallecido:";
            // 
            // cmbRetiroAnimal
            // 
            cmbRetiroAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRetiroAnimal.FormattingEnabled = true;
            cmbRetiroAnimal.Location = new Point(187, 78);
            cmbRetiroAnimal.Name = "cmbRetiroAnimal";
            cmbRetiroAnimal.Size = new Size(189, 32);
            cmbRetiroAnimal.TabIndex = 83;
            // 
            // dtpFechaRetiro
            // 
            dtpFechaRetiro.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaRetiro.Location = new Point(185, 123);
            dtpFechaRetiro.Name = "dtpFechaRetiro";
            dtpFechaRetiro.Size = new Size(191, 29);
            dtpFechaRetiro.TabIndex = 81;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(32, 128);
            label3.Name = "label3";
            label3.Size = new Size(136, 24);
            label3.TabIndex = 80;
            label3.Text = "Fecha Retiro:";
            // 
            // btnRetiroAnimal
            // 
            btnRetiroAnimal.BackColor = Color.White;
            btnRetiroAnimal.FlatAppearance.BorderSize = 0;
            btnRetiroAnimal.FlatStyle = FlatStyle.Flat;
            btnRetiroAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnRetiroAnimal.ForeColor = Color.FromArgb(56, 124, 31);
            btnRetiroAnimal.Image = Properties.Resources.leche;
            btnRetiroAnimal.ImageAlign = ContentAlignment.MiddleLeft;
            btnRetiroAnimal.Location = new Point(313, 176);
            btnRetiroAnimal.Name = "btnRetiroAnimal";
            btnRetiroAnimal.Size = new Size(161, 41);
            btnRetiroAnimal.TabIndex = 38;
            btnRetiroAnimal.Text = "Guardar";
            btnRetiroAnimal.UseVisualStyleBackColor = false;
            btnRetiroAnimal.Click += btnRetiroAnimal_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(33, 79);
            label5.Name = "label5";
            label5.Size = new Size(138, 24);
            label5.TabIndex = 19;
            label5.Text = "N° de Animal:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbAnimalOrdeñe);
            groupBox1.Controls.Add(dtpFechaOrdeñe);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnGuardarLeche);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtLitroLeche);
            groupBox1.Controls.Add(lblLitroLeche);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(18, 209);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(486, 230);
            groupBox1.TabIndex = 98;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fecha de Ordeñe";
            // 
            // cmbAnimalOrdeñe
            // 
            cmbAnimalOrdeñe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnimalOrdeñe.FormattingEnabled = true;
            cmbAnimalOrdeñe.Location = new Point(182, 49);
            cmbAnimalOrdeñe.Name = "cmbAnimalOrdeñe";
            cmbAnimalOrdeñe.Size = new Size(189, 32);
            cmbAnimalOrdeñe.TabIndex = 82;
            // 
            // dtpFechaOrdeñe
            // 
            dtpFechaOrdeñe.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaOrdeñe.Location = new Point(181, 97);
            dtpFechaOrdeñe.Name = "dtpFechaOrdeñe";
            dtpFechaOrdeñe.Size = new Size(191, 29);
            dtpFechaOrdeñe.TabIndex = 81;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 101);
            label1.Name = "label1";
            label1.Size = new Size(152, 24);
            label1.TabIndex = 80;
            label1.Text = "Fecha Ordeñe:";
            // 
            // btnGuardarLeche
            // 
            btnGuardarLeche.BackColor = Color.White;
            btnGuardarLeche.FlatAppearance.BorderSize = 0;
            btnGuardarLeche.FlatStyle = FlatStyle.Flat;
            btnGuardarLeche.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarLeche.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarLeche.Image = Properties.Resources.leche;
            btnGuardarLeche.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarLeche.Location = new Point(305, 178);
            btnGuardarLeche.Name = "btnGuardarLeche";
            btnGuardarLeche.Size = new Size(161, 41);
            btnGuardarLeche.TabIndex = 38;
            btnGuardarLeche.Text = "Guardar";
            btnGuardarLeche.UseVisualStyleBackColor = false;
            btnGuardarLeche.Click += btnGuardarLeche_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(24, 52);
            label2.Name = "label2";
            label2.Size = new Size(138, 24);
            label2.TabIndex = 19;
            label2.Text = "N° de Animal:";
            // 
            // txtLitroLeche
            // 
            txtLitroLeche.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtLitroLeche.Location = new Point(182, 143);
            txtLitroLeche.MaxLength = 7;
            txtLitroLeche.Name = "txtLitroLeche";
            txtLitroLeche.Size = new Size(190, 29);
            txtLitroLeche.TabIndex = 75;
            txtLitroLeche.KeyDown += CopiaryPegar_KeyDown;
            txtLitroLeche.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblLitroLeche
            // 
            lblLitroLeche.AutoSize = true;
            lblLitroLeche.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblLitroLeche.ForeColor = Color.White;
            lblLitroLeche.Location = new Point(13, 144);
            lblLitroLeche.Name = "lblLitroLeche";
            lblLitroLeche.Size = new Size(150, 24);
            lblLitroLeche.TabIndex = 74;
            lblLitroLeche.Text = "Litro de Leche:";
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimir.Image = Properties.Resources.imprimir;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(823, 445);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(161, 41);
            btnImprimir.TabIndex = 97;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // txtBuscarRegistroProduccion
            // 
            txtBuscarRegistroProduccion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscarRegistroProduccion.Location = new Point(615, 457);
            txtBuscarRegistroProduccion.MaxLength = 7;
            txtBuscarRegistroProduccion.Name = "txtBuscarRegistroProduccion";
            txtBuscarRegistroProduccion.Size = new Size(190, 29);
            txtBuscarRegistroProduccion.TabIndex = 96;
            txtBuscarRegistroProduccion.TextChanged += txtBuscarRegistroProduccion_TextChanged;
            txtBuscarRegistroProduccion.KeyDown += CopiaryPegar_KeyDown;
            txtBuscarRegistroProduccion.KeyPress += SoloNumeros_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(414, 463);
            label10.Name = "label10";
            label10.Size = new Size(198, 24);
            label10.TabIndex = 95;
            label10.Text = "Buscar por Numero:";
            // 
            // dtgRegistrosProduccion
            // 
            dtgRegistrosProduccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgRegistrosProduccion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgRegistrosProduccion.Location = new Point(9, 492);
            dtgRegistrosProduccion.Name = "dtgRegistrosProduccion";
            dtgRegistrosProduccion.ReadOnly = true;
            dtgRegistrosProduccion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgRegistrosProduccion.Size = new Size(975, 180);
            dtgRegistrosProduccion.TabIndex = 92;
            dtgRegistrosProduccion.CellContentClick += dtgRegistrosProduccion_CellContentClick;
            // 
            // gbRegistroProductoras
            // 
            gbRegistroProductoras.Controls.Add(dtpIngresoAnimal);
            gbRegistroProductoras.Controls.Add(label4);
            gbRegistroProductoras.Controls.Add(rbMacho);
            gbRegistroProductoras.Controls.Add(rbHembra);
            gbRegistroProductoras.Controls.Add(btnGuardarAnimal);
            gbRegistroProductoras.Controls.Add(lblNumeroCaravana);
            gbRegistroProductoras.Controls.Add(txtNumeroAnimal);
            gbRegistroProductoras.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbRegistroProductoras.ForeColor = Color.White;
            gbRegistroProductoras.Location = new Point(18, 13);
            gbRegistroProductoras.Name = "gbRegistroProductoras";
            gbRegistroProductoras.Size = new Size(484, 181);
            gbRegistroProductoras.TabIndex = 87;
            gbRegistroProductoras.TabStop = false;
            gbRegistroProductoras.Text = "Registro de Animales";
            // 
            // dtpIngresoAnimal
            // 
            dtpIngresoAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpIngresoAnimal.Location = new Point(182, 96);
            dtpIngresoAnimal.Name = "dtpIngresoAnimal";
            dtpIngresoAnimal.Size = new Size(191, 29);
            dtpIngresoAnimal.TabIndex = 81;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(11, 101);
            label4.Name = "label4";
            label4.Size = new Size(151, 24);
            label4.TabIndex = 80;
            label4.Text = "Fecha Ingreso:";
            // 
            // rbMacho
            // 
            rbMacho.AutoSize = true;
            rbMacho.Location = new Point(182, 138);
            rbMacho.Name = "rbMacho";
            rbMacho.Size = new Size(91, 28);
            rbMacho.TabIndex = 79;
            rbMacho.TabStop = true;
            rbMacho.Text = "Macho";
            rbMacho.UseVisualStyleBackColor = true;
            // 
            // rbHembra
            // 
            rbHembra.AutoSize = true;
            rbHembra.Location = new Point(24, 138);
            rbHembra.Name = "rbHembra";
            rbHembra.Size = new Size(102, 28);
            rbHembra.TabIndex = 78;
            rbHembra.TabStop = true;
            rbHembra.Text = "Hembra";
            rbHembra.UseVisualStyleBackColor = true;
            rbHembra.CheckedChanged += rbHembra_CheckedChanged;
            // 
            // btnGuardarAnimal
            // 
            btnGuardarAnimal.BackColor = Color.White;
            btnGuardarAnimal.FlatAppearance.BorderSize = 0;
            btnGuardarAnimal.FlatStyle = FlatStyle.Flat;
            btnGuardarAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarAnimal.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarAnimal.Image = (Image)resources.GetObject("btnGuardarAnimal.Image");
            btnGuardarAnimal.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarAnimal.Location = new Point(310, 132);
            btnGuardarAnimal.Name = "btnGuardarAnimal";
            btnGuardarAnimal.Size = new Size(161, 41);
            btnGuardarAnimal.TabIndex = 38;
            btnGuardarAnimal.Text = "Guardar";
            btnGuardarAnimal.UseVisualStyleBackColor = false;
            btnGuardarAnimal.Click += btnGuardarAnimal_Click;
            // 
            // lblNumeroCaravana
            // 
            lblNumeroCaravana.AutoSize = true;
            lblNumeroCaravana.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroCaravana.ForeColor = Color.White;
            lblNumeroCaravana.Location = new Point(13, 50);
            lblNumeroCaravana.Name = "lblNumeroCaravana";
            lblNumeroCaravana.Size = new Size(138, 24);
            lblNumeroCaravana.TabIndex = 19;
            lblNumeroCaravana.Text = "N° de Animal:";
            // 
            // txtNumeroAnimal
            // 
            txtNumeroAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNumeroAnimal.Location = new Point(182, 46);
            txtNumeroAnimal.MaxLength = 7;
            txtNumeroAnimal.Name = "txtNumeroAnimal";
            txtNumeroAnimal.Size = new Size(190, 29);
            txtNumeroAnimal.TabIndex = 36;
            txtNumeroAnimal.KeyDown += CopiaryPegar_KeyDown;
            txtNumeroAnimal.KeyPress += SoloNumeros_KeyPress;
            // 
            // gbEnviarIndustria
            // 
            gbEnviarIndustria.Controls.Add(cmbLitroLecheEnviado);
            gbEnviarIndustria.Controls.Add(dtpFechaEnviado);
            gbEnviarIndustria.Controls.Add(btnEnviarLeche);
            gbEnviarIndustria.Controls.Add(lblLecheEnvasado2);
            gbEnviarIndustria.Controls.Add(lblLitroLeche2);
            gbEnviarIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbEnviarIndustria.ForeColor = Color.White;
            gbEnviarIndustria.Location = new Point(520, 13);
            gbEnviarIndustria.Name = "gbEnviarIndustria";
            gbEnviarIndustria.Size = new Size(441, 181);
            gbEnviarIndustria.TabIndex = 85;
            gbEnviarIndustria.TabStop = false;
            gbEnviarIndustria.Text = "Enviar Leche a Industria";
            // 
            // cmbLitroLecheEnviado
            // 
            cmbLitroLecheEnviado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLitroLecheEnviado.FormattingEnabled = true;
            cmbLitroLecheEnviado.Location = new Point(212, 93);
            cmbLitroLecheEnviado.Name = "cmbLitroLecheEnviado";
            cmbLitroLecheEnviado.Size = new Size(193, 32);
            cmbLitroLecheEnviado.TabIndex = 76;
            // 
            // dtpFechaEnviado
            // 
            dtpFechaEnviado.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaEnviado.Location = new Point(212, 40);
            dtpFechaEnviado.Name = "dtpFechaEnviado";
            dtpFechaEnviado.Size = new Size(193, 29);
            dtpFechaEnviado.TabIndex = 75;
            // 
            // btnEnviarLeche
            // 
            btnEnviarLeche.BackColor = Color.White;
            btnEnviarLeche.FlatAppearance.BorderSize = 0;
            btnEnviarLeche.FlatStyle = FlatStyle.Flat;
            btnEnviarLeche.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnEnviarLeche.ForeColor = Color.FromArgb(56, 124, 31);
            btnEnviarLeche.Image = Properties.Resources.fabrica;
            btnEnviarLeche.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnviarLeche.Location = new Point(264, 132);
            btnEnviarLeche.Name = "btnEnviarLeche";
            btnEnviarLeche.Size = new Size(161, 41);
            btnEnviarLeche.TabIndex = 72;
            btnEnviarLeche.Text = "Enviar";
            btnEnviarLeche.UseVisualStyleBackColor = false;
            btnEnviarLeche.Click += btnEnviarLeche_Click;
            // 
            // lblLecheEnvasado2
            // 
            lblLecheEnvasado2.AutoSize = true;
            lblLecheEnvasado2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblLecheEnvasado2.ForeColor = Color.White;
            lblLecheEnvasado2.Location = new Point(22, 45);
            lblLecheEnvasado2.Name = "lblLecheEnvasado2";
            lblLecheEnvasado2.Size = new Size(173, 24);
            lblLecheEnvasado2.TabIndex = 74;
            lblLecheEnvasado2.Text = "Fecha Envasado:";
            // 
            // lblLitroLeche2
            // 
            lblLitroLeche2.AutoSize = true;
            lblLitroLeche2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblLitroLeche2.ForeColor = Color.White;
            lblLitroLeche2.Location = new Point(35, 96);
            lblLitroLeche2.Name = "lblLitroLeche2";
            lblLitroLeche2.Size = new Size(160, 24);
            lblLitroLeche2.TabIndex = 72;
            lblLitroLeche2.Text = "Litros de Leche:";
            // 
            // tabPage8
            // 
            tabPage8.BackColor = Color.FromArgb(141, 181, 146);
            tabPage8.Controls.Add(btnImprimirNacimientos);
            tabPage8.Controls.Add(txtBuscarRegistroNacimiento);
            tabPage8.Controls.Add(label7);
            tabPage8.Controls.Add(dtgNacimientos);
            tabPage8.Controls.Add(gbRegistroNacimiento);
            tabPage8.Controls.Add(gbRegistroMonta);
            tabPage8.Location = new Point(4, 33);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(985, 669);
            tabPage8.TabIndex = 1;
            tabPage8.Text = "Registro de Fertilidad y Nacimientos";
            // 
            // btnImprimirNacimientos
            // 
            btnImprimirNacimientos.BackColor = Color.White;
            btnImprimirNacimientos.FlatAppearance.BorderSize = 0;
            btnImprimirNacimientos.FlatStyle = FlatStyle.Flat;
            btnImprimirNacimientos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnImprimirNacimientos.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimirNacimientos.Image = Properties.Resources.imprimir;
            btnImprimirNacimientos.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirNacimientos.Location = new Point(818, 364);
            btnImprimirNacimientos.Name = "btnImprimirNacimientos";
            btnImprimirNacimientos.Size = new Size(161, 41);
            btnImprimirNacimientos.TabIndex = 94;
            btnImprimirNacimientos.Text = "Imprimir";
            btnImprimirNacimientos.UseVisualStyleBackColor = false;
            btnImprimirNacimientos.Click += btnImprimirNacimiento_Click;
            // 
            // txtBuscarRegistroNacimiento
            // 
            txtBuscarRegistroNacimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscarRegistroNacimiento.Location = new Point(604, 375);
            txtBuscarRegistroNacimiento.MaxLength = 7;
            txtBuscarRegistroNacimiento.Name = "txtBuscarRegistroNacimiento";
            txtBuscarRegistroNacimiento.Size = new Size(190, 29);
            txtBuscarRegistroNacimiento.TabIndex = 93;
            txtBuscarRegistroNacimiento.TextChanged += txtBuscarRegistroNacimiento_TextChanged;
            txtBuscarRegistroNacimiento.KeyDown += CopiaryPegar_KeyDown;
            txtBuscarRegistroNacimiento.KeyPress += SoloNumeros_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(403, 381);
            label7.Name = "label7";
            label7.Size = new Size(198, 24);
            label7.TabIndex = 92;
            label7.Text = "Buscar por Numero:";
            // 
            // dtgNacimientos
            // 
            dtgNacimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgNacimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgNacimientos.Location = new Point(6, 418);
            dtgNacimientos.Name = "dtgNacimientos";
            dtgNacimientos.ReadOnly = true;
            dtgNacimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgNacimientos.Size = new Size(978, 255);
            dtgNacimientos.TabIndex = 91;
            // 
            // gbRegistroNacimiento
            // 
            gbRegistroNacimiento.Controls.Add(cmbTipo2);
            gbRegistroNacimiento.Controls.Add(label6);
            gbRegistroNacimiento.Controls.Add(cmbPadreNacimiento);
            gbRegistroNacimiento.Controls.Add(cmbMadreNacimiento);
            gbRegistroNacimiento.Controls.Add(txtCantidadMachos);
            gbRegistroNacimiento.Controls.Add(txtCantidadHembras);
            gbRegistroNacimiento.Controls.Add(txtTotalNacidos);
            gbRegistroNacimiento.Controls.Add(lblCantidadMachosCerdos);
            gbRegistroNacimiento.Controls.Add(lblCantidadHembrasCerdos);
            gbRegistroNacimiento.Controls.Add(lblTotalNacidosCerdos);
            gbRegistroNacimiento.Controls.Add(lblNumeroPadre2);
            gbRegistroNacimiento.Controls.Add(dtpFechaParto);
            gbRegistroNacimiento.Controls.Add(btnRegistroNacimiento);
            gbRegistroNacimiento.Controls.Add(lblNumeroMadre2);
            gbRegistroNacimiento.Controls.Add(lblFechaParto);
            gbRegistroNacimiento.ForeColor = Color.White;
            gbRegistroNacimiento.Location = new Point(510, 6);
            gbRegistroNacimiento.Name = "gbRegistroNacimiento";
            gbRegistroNacimiento.Size = new Size(439, 351);
            gbRegistroNacimiento.TabIndex = 90;
            gbRegistroNacimiento.TabStop = false;
            gbRegistroNacimiento.Text = "Registro de Nacimiento";
            // 
            // cmbTipo2
            // 
            cmbTipo2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipo2.FormattingEnabled = true;
            cmbTipo2.Location = new Point(212, 109);
            cmbTipo2.Name = "cmbTipo2";
            cmbTipo2.Size = new Size(190, 32);
            cmbTipo2.TabIndex = 105;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(135, 109);
            label6.Name = "label6";
            label6.Size = new Size(58, 24);
            label6.TabIndex = 104;
            label6.Text = "Tipo:";
            // 
            // cmbPadreNacimiento
            // 
            cmbPadreNacimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPadreNacimiento.FormattingEnabled = true;
            cmbPadreNacimiento.Location = new Point(213, 70);
            cmbPadreNacimiento.Name = "cmbPadreNacimiento";
            cmbPadreNacimiento.Size = new Size(190, 32);
            cmbPadreNacimiento.TabIndex = 103;
            // 
            // cmbMadreNacimiento
            // 
            cmbMadreNacimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMadreNacimiento.FormattingEnabled = true;
            cmbMadreNacimiento.Location = new Point(213, 31);
            cmbMadreNacimiento.Name = "cmbMadreNacimiento";
            cmbMadreNacimiento.Size = new Size(190, 32);
            cmbMadreNacimiento.TabIndex = 102;
            // 
            // txtCantidadMachos
            // 
            txtCantidadMachos.Location = new Point(212, 256);
            txtCantidadMachos.MaxLength = 7;
            txtCantidadMachos.Name = "txtCantidadMachos";
            txtCantidadMachos.Size = new Size(191, 29);
            txtCantidadMachos.TabIndex = 101;
            txtCantidadMachos.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadMachos.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtCantidadHembras
            // 
            txtCantidadHembras.Location = new Point(212, 220);
            txtCantidadHembras.MaxLength = 7;
            txtCantidadHembras.Name = "txtCantidadHembras";
            txtCantidadHembras.Size = new Size(191, 29);
            txtCantidadHembras.TabIndex = 100;
            txtCantidadHembras.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadHembras.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtTotalNacidos
            // 
            txtTotalNacidos.Location = new Point(212, 184);
            txtTotalNacidos.MaxLength = 7;
            txtTotalNacidos.Name = "txtTotalNacidos";
            txtTotalNacidos.Size = new Size(191, 29);
            txtTotalNacidos.TabIndex = 99;
            txtTotalNacidos.KeyDown += CopiaryPegar_KeyDown;
            txtTotalNacidos.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblCantidadMachosCerdos
            // 
            lblCantidadMachosCerdos.AutoSize = true;
            lblCantidadMachosCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadMachosCerdos.ForeColor = Color.White;
            lblCantidadMachosCerdos.Location = new Point(16, 261);
            lblCantidadMachosCerdos.Name = "lblCantidadMachosCerdos";
            lblCantidadMachosCerdos.Size = new Size(177, 24);
            lblCantidadMachosCerdos.TabIndex = 98;
            lblCantidadMachosCerdos.Text = "Cantidad Machos:";
            // 
            // lblCantidadHembrasCerdos
            // 
            lblCantidadHembrasCerdos.AutoSize = true;
            lblCantidadHembrasCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadHembrasCerdos.ForeColor = Color.White;
            lblCantidadHembrasCerdos.Location = new Point(6, 223);
            lblCantidadHembrasCerdos.Name = "lblCantidadHembrasCerdos";
            lblCantidadHembrasCerdos.Size = new Size(188, 24);
            lblCantidadHembrasCerdos.TabIndex = 97;
            lblCantidadHembrasCerdos.Text = "Cantidad Hembras:";
            // 
            // lblTotalNacidosCerdos
            // 
            lblTotalNacidosCerdos.AutoSize = true;
            lblTotalNacidosCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTotalNacidosCerdos.ForeColor = Color.White;
            lblTotalNacidosCerdos.Location = new Point(49, 185);
            lblTotalNacidosCerdos.Name = "lblTotalNacidosCerdos";
            lblTotalNacidosCerdos.Size = new Size(144, 24);
            lblTotalNacidosCerdos.TabIndex = 96;
            lblTotalNacidosCerdos.Text = "Total Nacidos:";
            // 
            // lblNumeroPadre2
            // 
            lblNumeroPadre2.AutoSize = true;
            lblNumeroPadre2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroPadre2.ForeColor = Color.White;
            lblNumeroPadre2.Location = new Point(43, 71);
            lblNumeroPadre2.Name = "lblNumeroPadre2";
            lblNumeroPadre2.Size = new Size(151, 24);
            lblNumeroPadre2.TabIndex = 84;
            lblNumeroPadre2.Text = "N° de la Padre:";
            // 
            // dtpFechaParto
            // 
            dtpFechaParto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaParto.Location = new Point(212, 148);
            dtpFechaParto.Name = "dtpFechaParto";
            dtpFechaParto.Size = new Size(191, 29);
            dtpFechaParto.TabIndex = 78;
            // 
            // btnRegistroNacimiento
            // 
            btnRegistroNacimiento.BackColor = Color.White;
            btnRegistroNacimiento.FlatAppearance.BorderSize = 0;
            btnRegistroNacimiento.FlatStyle = FlatStyle.Flat;
            btnRegistroNacimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnRegistroNacimiento.ForeColor = Color.FromArgb(56, 124, 31);
            btnRegistroNacimiento.Image = Properties.Resources.leche;
            btnRegistroNacimiento.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistroNacimiento.Location = new Point(272, 304);
            btnRegistroNacimiento.Name = "btnRegistroNacimiento";
            btnRegistroNacimiento.Size = new Size(161, 41);
            btnRegistroNacimiento.TabIndex = 38;
            btnRegistroNacimiento.Text = "Guardar";
            btnRegistroNacimiento.UseVisualStyleBackColor = false;
            btnRegistroNacimiento.Click += btnRegistroNacimiento_Click;
            // 
            // lblNumeroMadre2
            // 
            lblNumeroMadre2.AutoSize = true;
            lblNumeroMadre2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroMadre2.ForeColor = Color.White;
            lblNumeroMadre2.Location = new Point(39, 33);
            lblNumeroMadre2.Name = "lblNumeroMadre2";
            lblNumeroMadre2.Size = new Size(155, 24);
            lblNumeroMadre2.TabIndex = 19;
            lblNumeroMadre2.Text = "N° de la Madre:";
            // 
            // lblFechaParto
            // 
            lblFechaParto.AutoSize = true;
            lblFechaParto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaParto.ForeColor = Color.White;
            lblFechaParto.Location = new Point(35, 147);
            lblFechaParto.Name = "lblFechaParto";
            lblFechaParto.Size = new Size(159, 24);
            lblFechaParto.TabIndex = 72;
            lblFechaParto.Text = "Fecha de Parto:";
            // 
            // gbRegistroMonta
            // 
            gbRegistroMonta.Controls.Add(cmbNumeroPadre);
            gbRegistroMonta.Controls.Add(cmbNumeroMadre);
            gbRegistroMonta.Controls.Add(lblNumeroPadreOvino);
            gbRegistroMonta.Controls.Add(cmbTipo);
            gbRegistroMonta.Controls.Add(lblTipo);
            gbRegistroMonta.Controls.Add(dtpPosibleParto);
            gbRegistroMonta.Controls.Add(dtpFechaMonta);
            gbRegistroMonta.Controls.Add(btnGuardarRegistroMontaOvina);
            gbRegistroMonta.Controls.Add(lblNumeroMadreOvina);
            gbRegistroMonta.Controls.Add(lblPosibleParto);
            gbRegistroMonta.Controls.Add(lblFechaMonta);
            gbRegistroMonta.ForeColor = Color.White;
            gbRegistroMonta.Location = new Point(27, 6);
            gbRegistroMonta.Name = "gbRegistroMonta";
            gbRegistroMonta.Size = new Size(449, 351);
            gbRegistroMonta.TabIndex = 89;
            gbRegistroMonta.TabStop = false;
            gbRegistroMonta.Text = "Registro de Monta";
            // 
            // cmbNumeroPadre
            // 
            cmbNumeroPadre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNumeroPadre.FormattingEnabled = true;
            cmbNumeroPadre.Location = new Point(208, 71);
            cmbNumeroPadre.Name = "cmbNumeroPadre";
            cmbNumeroPadre.Size = new Size(190, 32);
            cmbNumeroPadre.TabIndex = 88;
            // 
            // cmbNumeroMadre
            // 
            cmbNumeroMadre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNumeroMadre.FormattingEnabled = true;
            cmbNumeroMadre.Location = new Point(208, 24);
            cmbNumeroMadre.Name = "cmbNumeroMadre";
            cmbNumeroMadre.Size = new Size(190, 32);
            cmbNumeroMadre.TabIndex = 87;
            // 
            // lblNumeroPadreOvino
            // 
            lblNumeroPadreOvino.AutoSize = true;
            lblNumeroPadreOvino.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroPadreOvino.ForeColor = Color.White;
            lblNumeroPadreOvino.Location = new Point(38, 76);
            lblNumeroPadreOvino.Name = "lblNumeroPadreOvino";
            lblNumeroPadreOvino.Size = new Size(151, 24);
            lblNumeroPadreOvino.TabIndex = 86;
            lblNumeroPadreOvino.Text = "N° de la Padre:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(208, 197);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(190, 32);
            cmbTipo.TabIndex = 83;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTipo.ForeColor = Color.White;
            lblTipo.Location = new Point(131, 204);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(58, 24);
            lblTipo.TabIndex = 82;
            lblTipo.Text = "Tipo:";
            // 
            // dtpPosibleParto
            // 
            dtpPosibleParto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpPosibleParto.Location = new Point(208, 162);
            dtpPosibleParto.Name = "dtpPosibleParto";
            dtpPosibleParto.Size = new Size(190, 29);
            dtpPosibleParto.TabIndex = 79;
            // 
            // dtpFechaMonta
            // 
            dtpFechaMonta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaMonta.Location = new Point(208, 118);
            dtpFechaMonta.Name = "dtpFechaMonta";
            dtpFechaMonta.Size = new Size(190, 29);
            dtpFechaMonta.TabIndex = 78;
            // 
            // btnGuardarRegistroMontaOvina
            // 
            btnGuardarRegistroMontaOvina.BackColor = Color.White;
            btnGuardarRegistroMontaOvina.FlatAppearance.BorderSize = 0;
            btnGuardarRegistroMontaOvina.FlatStyle = FlatStyle.Flat;
            btnGuardarRegistroMontaOvina.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarRegistroMontaOvina.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarRegistroMontaOvina.Image = Properties.Resources.leche;
            btnGuardarRegistroMontaOvina.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarRegistroMontaOvina.Location = new Point(268, 304);
            btnGuardarRegistroMontaOvina.Name = "btnGuardarRegistroMontaOvina";
            btnGuardarRegistroMontaOvina.Size = new Size(161, 41);
            btnGuardarRegistroMontaOvina.TabIndex = 38;
            btnGuardarRegistroMontaOvina.Text = "Guardar";
            btnGuardarRegistroMontaOvina.UseVisualStyleBackColor = false;
            btnGuardarRegistroMontaOvina.Click += btnGuardarRegistroMontaOvina_Click;
            // 
            // lblNumeroMadreOvina
            // 
            lblNumeroMadreOvina.AutoSize = true;
            lblNumeroMadreOvina.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroMadreOvina.ForeColor = Color.White;
            lblNumeroMadreOvina.Location = new Point(34, 31);
            lblNumeroMadreOvina.Name = "lblNumeroMadreOvina";
            lblNumeroMadreOvina.Size = new Size(155, 24);
            lblNumeroMadreOvina.TabIndex = 19;
            lblNumeroMadreOvina.Text = "N° de la Madre:";
            // 
            // lblPosibleParto
            // 
            lblPosibleParto.AutoSize = true;
            lblPosibleParto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblPosibleParto.ForeColor = Color.White;
            lblPosibleParto.Location = new Point(50, 166);
            lblPosibleParto.Name = "lblPosibleParto";
            lblPosibleParto.Size = new Size(139, 24);
            lblPosibleParto.TabIndex = 74;
            lblPosibleParto.Text = "Posible Parto:";
            // 
            // lblFechaMonta
            // 
            lblFechaMonta.AutoSize = true;
            lblFechaMonta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaMonta.ForeColor = Color.White;
            lblFechaMonta.Location = new Point(21, 121);
            lblFechaMonta.Name = "lblFechaMonta";
            lblFechaMonta.Size = new Size(168, 24);
            lblFechaMonta.TabIndex = 72;
            lblFechaMonta.Text = "Fecha de Monta:";
            // 
            // UcLeche
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            Controls.Add(tabControl1);
            Name = "UcLeche";
            Size = new Size(999, 709);
            Load += UcLeche_Load;
            tabControl1.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgRegistrosProduccion).EndInit();
            gbRegistroProductoras.ResumeLayout(false);
            gbRegistroProductoras.PerformLayout();
            gbEnviarIndustria.ResumeLayout(false);
            gbEnviarIndustria.PerformLayout();
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgNacimientos).EndInit();
            gbRegistroNacimiento.ResumeLayout(false);
            gbRegistroNacimiento.PerformLayout();
            gbRegistroMonta.ResumeLayout(false);
            gbRegistroMonta.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage7;
        private Tienda.RJButton btnImprimir;
        private TextBox txtBuscarRegistroProduccion;
        private Label label10;
        private DataGridView dtgRegistrosProduccion;
        private GroupBox gbRegistroProductoras;
        private Tienda.RJButton btnGuardarAnimal;
        private Label lblNumeroCaravana;
        private TextBox txtLitroLeche;
        private TextBox txtNumeroAnimal;
        private Label lblLitroLeche;
        private GroupBox gbEnviarIndustria;
        private DateTimePicker dtpFechaEnviado;
        private Tienda.RJButton btnEnviarLeche;
        private Label lblLecheEnvasado2;
        private Label lblLitroLeche2;
        private TabPage tabPage8;
        private RJButton btnImprimirNacimientos;
        private TextBox txtBuscarRegistroNacimiento;
        private Tienda.RJButton rjButton1;
        private TextBox textBox2;
        private Label label7;
        private DataGridView dtgNacimientos;
        private DataGridView dtgEntorno;
        private GroupBox gbRegistroNacimiento;
        private Label lblNumeroPadre2;
        private TextBox txtNumeropadre2;
        private ComboBox cbGenero;
        private Label lblGenero;
        private DateTimePicker dtpFechaParto;
        private Tienda.RJButton btnRegistroNacimiento;
        private Label lblNumeroMadre2;
        private TextBox txtNumeromadre2;
        private Label lblFechaParto;
        private GroupBox gbRegistroMonta;
        private Label lblNumeroPadreOvino;
        private ComboBox cmbTipo;
        private Label lblTipo;
        private DateTimePicker dtpPosibleParto;
        private DateTimePicker dtpFechaMonta;
        private Tienda.RJButton btnGuardarRegistroMontaOvina;
        private Label lblNumeroMadreOvina;
        private Label lblPosibleParto;
        private Label lblFechaMonta;
        private RadioButton rbMacho;
        private RadioButton rbHembra;
        private DateTimePicker dtpIngresoAnimal;
        private Label label4;
        private GroupBox groupBox2;
        private DateTimePicker dtpFechaRetiro;
        private Label label3;
        private Tienda.RJButton btnRetiroAnimal;
        private Label label5;
        private GroupBox groupBox1;
        private DateTimePicker dtpFechaOrdeñe;
        private Label label1;
        private Tienda.RJButton btnGuardarLeche;
        private Label label2;
        private TextBox txtCantidadMachos;
        private TextBox txtCantidadHembras;
        private TextBox txtTotalNacidos;
        private Label lblCantidadMachosCerdos;
        private Label lblCantidadHembrasCerdos;
        private Label lblTotalNacidosCerdos;
        private ComboBox cmbAnimalOrdeñe;
        private ComboBox cmbRetiroAnimal;
        private ComboBox comboBox2;
        private ComboBox cmbNumeroMadre;
        private ComboBox cmbNumeroPadre;
        private ComboBox cmbPadreNacimiento;
        private ComboBox cmbMadreNacimiento;
        private ComboBox cmbLitroLecheEnviado;
        private ComboBox cmbTipo2;
        private Label label6;
    }
}
