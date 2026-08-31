using Tienda;

namespace Agraria.UserControls
{
    partial class UcCarne
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
            components = new System.ComponentModel.Container();
            tabControl2 = new TabControl();
            tabPage9 = new TabPage();
            label7 = new Label();
            txtBuscarPorGrilla = new TextBox();
            groupBox1 = new GroupBox();
            cmbBajaAnimal = new ComboBox();
            dtpFechaFallecimiento = new DateTimePicker();
            label5 = new Label();
            cmbDardeBajaAnimal = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            btnRetirarAnimal = new RJButton();
            btnImprimir = new RJButton();
            dtgProduccionCarne = new DataGridView();
            gbProduccionCerdos = new GroupBox();
            dtpIngresoAnimal = new DateTimePicker();
            label4 = new Label();
            rbMacho = new RadioButton();
            rbHembra = new RadioButton();
            cmbBoxProduccion = new ComboBox();
            lblBox = new Label();
            lblNumeroCerdo = new Label();
            txtNumeroAnimal = new TextBox();
            btnGuardarProduccion = new RJButton();
            gbIndustriaCerdo = new GroupBox();
            cmbCantidadEnviarIndustria = new ComboBox();
            label1 = new Label();
            dtpFechaEgresoEnviarIndustria = new DateTimePicker();
            btnEnviarCerdoIndustria = new RJButton();
            lblFechaEgresoCerdo = new Label();
            cmbEnviarIndustria = new ComboBox();
            label6 = new Label();
            tabPage10 = new TabPage();
            btnImprimirMonta = new RJButton();
            dtgMontaNacimientos = new DataGridView();
            gbREgistroNacimientoCerdos = new GroupBox();
            txtCantidadMachos = new TextBox();
            txtCantidadHembras = new TextBox();
            txtTotalNacidos = new TextBox();
            cmbPadreNacimiento = new ComboBox();
            cmbMadreNacimiento = new ComboBox();
            lblCantidadMachosCerdos = new Label();
            lblCantidadHembrasCerdos = new Label();
            btnGuardarRegistroNacimiento = new RJButton();
            lblNumeroPadreCerdo2 = new Label();
            lblTotalNacidosCerdos = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblNumeroMadreCerdo2 = new Label();
            lblFechaPartoCerdos = new Label();
            gbRegistroMontaCerdos = new GroupBox();
            cmbPadreMonta = new ComboBox();
            cmbMadreMonta = new ComboBox();
            btnGuardarRegistroMonta = new RJButton();
            lblNumeroPadreCerdo = new Label();
            dtpPosibleParto = new DateTimePicker();
            dtpFechaMonta = new DateTimePicker();
            lblNumeroMadreCerdo = new Label();
            lblPosiblePartoCerdos = new Label();
            lblFechaMontaCerdos = new Label();
            errorProvider1 = new ErrorProvider(components);
            tabControl2.SuspendLayout();
            tabPage9.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProduccionCarne).BeginInit();
            gbProduccionCerdos.SuspendLayout();
            gbIndustriaCerdo.SuspendLayout();
            tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgMontaNacimientos).BeginInit();
            gbREgistroNacimientoCerdos.SuspendLayout();
            gbRegistroMontaCerdos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage9);
            tabControl2.Controls.Add(tabPage10);
            tabControl2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            tabControl2.Location = new Point(3, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(993, 706);
            tabControl2.TabIndex = 1;
            // 
            // tabPage9
            // 
            tabPage9.BackColor = Color.FromArgb(141, 181, 146);
            tabPage9.Controls.Add(label7);
            tabPage9.Controls.Add(txtBuscarPorGrilla);
            tabPage9.Controls.Add(groupBox1);
            tabPage9.Controls.Add(btnImprimir);
            tabPage9.Controls.Add(dtgProduccionCarne);
            tabPage9.Controls.Add(gbProduccionCerdos);
            tabPage9.Controls.Add(gbIndustriaCerdo);
            tabPage9.Location = new Point(4, 33);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(3);
            tabPage9.Size = new Size(985, 669);
            tabPage9.TabIndex = 0;
            tabPage9.Text = "Registro de Produccón";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(787, 270);
            label7.Name = "label7";
            label7.Size = new Size(198, 24);
            label7.TabIndex = 98;
            label7.Text = "Buscar por Numero:";
            // 
            // txtBuscarPorGrilla
            // 
            txtBuscarPorGrilla.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscarPorGrilla.Location = new Point(799, 311);
            txtBuscarPorGrilla.MaxLength = 7;
            txtBuscarPorGrilla.Name = "txtBuscarPorGrilla";
            txtBuscarPorGrilla.Size = new Size(170, 29);
            txtBuscarPorGrilla.TabIndex = 99;
            txtBuscarPorGrilla.TextChanged += txtBuscarPorGrilla_TextChanged;
            txtBuscarPorGrilla.KeyDown += CopiaryPegar_KeyDown;
            txtBuscarPorGrilla.KeyPress += SoloNumeros_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbBajaAnimal);
            groupBox1.Controls.Add(dtpFechaFallecimiento);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmbDardeBajaAnimal);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnRetirarAnimal);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(4, 228);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(777, 164);
            groupBox1.TabIndex = 97;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fallecimiento de Animal";
            // 
            // cmbBajaAnimal
            // 
            cmbBajaAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBajaAnimal.FormattingEnabled = true;
            cmbBajaAnimal.Location = new Point(455, 56);
            cmbBajaAnimal.Name = "cmbBajaAnimal";
            cmbBajaAnimal.Size = new Size(170, 32);
            cmbBajaAnimal.TabIndex = 80;
            // 
            // dtpFechaFallecimiento
            // 
            dtpFechaFallecimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaFallecimiento.Location = new Point(247, 110);
            dtpFechaFallecimiento.Name = "dtpFechaFallecimiento";
            dtpFechaFallecimiento.Size = new Size(317, 29);
            dtpFechaFallecimiento.TabIndex = 79;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(21, 114);
            label5.Name = "label5";
            label5.Size = new Size(206, 24);
            label5.TabIndex = 78;
            label5.Text = "Fecha Fallecimiento:";
            // 
            // cmbDardeBajaAnimal
            // 
            cmbDardeBajaAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDardeBajaAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbDardeBajaAnimal.FormattingEnabled = true;
            cmbDardeBajaAnimal.Location = new Point(98, 56);
            cmbDardeBajaAnimal.Name = "cmbDardeBajaAnimal";
            cmbDardeBajaAnimal.Size = new Size(170, 32);
            cmbDardeBajaAnimal.TabIndex = 75;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(30, 64);
            label2.Name = "label2";
            label2.Size = new Size(52, 24);
            label2.TabIndex = 74;
            label2.Text = "Box:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(294, 64);
            label3.Name = "label3";
            label3.Size = new Size(138, 24);
            label3.TabIndex = 51;
            label3.Text = "N° de Animal:";
            // 
            // btnRetirarAnimal
            // 
            btnRetirarAnimal.BackColor = Color.White;
            btnRetirarAnimal.FlatAppearance.BorderSize = 0;
            btnRetirarAnimal.FlatStyle = FlatStyle.Flat;
            btnRetirarAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnRetirarAnimal.ForeColor = Color.FromArgb(56, 124, 31);
            btnRetirarAnimal.Image = Properties.Resources.ganado;
            btnRetirarAnimal.ImageAlign = ContentAlignment.MiddleLeft;
            btnRetirarAnimal.Location = new Point(602, 97);
            btnRetirarAnimal.Name = "btnRetirarAnimal";
            btnRetirarAnimal.Size = new Size(161, 41);
            btnRetirarAnimal.TabIndex = 47;
            btnRetirarAnimal.Text = "Retirar";
            btnRetirarAnimal.UseVisualStyleBackColor = false;
            btnRetirarAnimal.Click += btnRetirarAnimal_Click;
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
            btnImprimir.Location = new Point(807, 365);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(161, 41);
            btnImprimir.TabIndex = 96;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // dtgProduccionCarne
            // 
            dtgProduccionCarne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProduccionCarne.Location = new Point(4, 412);
            dtgProduccionCarne.Name = "dtgProduccionCarne";
            dtgProduccionCarne.ReadOnly = true;
            dtgProduccionCarne.Size = new Size(964, 247);
            dtgProduccionCarne.TabIndex = 95;
            // 
            // gbProduccionCerdos
            // 
            gbProduccionCerdos.Controls.Add(dtpIngresoAnimal);
            gbProduccionCerdos.Controls.Add(label4);
            gbProduccionCerdos.Controls.Add(rbMacho);
            gbProduccionCerdos.Controls.Add(rbHembra);
            gbProduccionCerdos.Controls.Add(cmbBoxProduccion);
            gbProduccionCerdos.Controls.Add(lblBox);
            gbProduccionCerdos.Controls.Add(lblNumeroCerdo);
            gbProduccionCerdos.Controls.Add(txtNumeroAnimal);
            gbProduccionCerdos.Controls.Add(btnGuardarProduccion);
            gbProduccionCerdos.ForeColor = Color.White;
            gbProduccionCerdos.Location = new Point(6, 6);
            gbProduccionCerdos.Name = "gbProduccionCerdos";
            gbProduccionCerdos.Size = new Size(522, 216);
            gbProduccionCerdos.TabIndex = 91;
            gbProduccionCerdos.TabStop = false;
            gbProduccionCerdos.Text = "Agregar Nuevos Animales por Numero";
            // 
            // dtpIngresoAnimal
            // 
            dtpIngresoAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpIngresoAnimal.Location = new Point(206, 122);
            dtpIngresoAnimal.Name = "dtpIngresoAnimal";
            dtpIngresoAnimal.Size = new Size(191, 29);
            dtpIngresoAnimal.TabIndex = 79;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(31, 129);
            label4.Name = "label4";
            label4.Size = new Size(151, 24);
            label4.TabIndex = 78;
            label4.Text = "Fecha Ingreso:";
            // 
            // rbMacho
            // 
            rbMacho.AutoSize = true;
            rbMacho.Location = new Point(212, 175);
            rbMacho.Name = "rbMacho";
            rbMacho.Size = new Size(91, 28);
            rbMacho.TabIndex = 77;
            rbMacho.TabStop = true;
            rbMacho.Text = "Macho";
            rbMacho.UseVisualStyleBackColor = true;
            // 
            // rbHembra
            // 
            rbHembra.AutoSize = true;
            rbHembra.Location = new Point(31, 175);
            rbHembra.Name = "rbHembra";
            rbHembra.Size = new Size(102, 28);
            rbHembra.TabIndex = 76;
            rbHembra.TabStop = true;
            rbHembra.Text = "Hembra";
            rbHembra.UseVisualStyleBackColor = true;
            // 
            // cmbBoxProduccion
            // 
            cmbBoxProduccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxProduccion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbBoxProduccion.FormattingEnabled = true;
            cmbBoxProduccion.Location = new Point(203, 34);
            cmbBoxProduccion.Name = "cmbBoxProduccion";
            cmbBoxProduccion.Size = new Size(194, 32);
            cmbBoxProduccion.TabIndex = 75;
            // 
            // lblBox
            // 
            lblBox.AutoSize = true;
            lblBox.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblBox.ForeColor = Color.White;
            lblBox.Location = new Point(127, 43);
            lblBox.Name = "lblBox";
            lblBox.Size = new Size(52, 24);
            lblBox.TabIndex = 74;
            lblBox.Text = "Box:";
            // 
            // lblNumeroCerdo
            // 
            lblNumeroCerdo.AutoSize = true;
            lblNumeroCerdo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroCerdo.ForeColor = Color.White;
            lblNumeroCerdo.Location = new Point(48, 86);
            lblNumeroCerdo.Name = "lblNumeroCerdo";
            lblNumeroCerdo.Size = new Size(138, 24);
            lblNumeroCerdo.TabIndex = 51;
            lblNumeroCerdo.Text = "N° de Animal:";
            // 
            // txtNumeroAnimal
            // 
            txtNumeroAnimal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNumeroAnimal.Location = new Point(203, 78);
            txtNumeroAnimal.MaxLength = 7;
            txtNumeroAnimal.Name = "txtNumeroAnimal";
            txtNumeroAnimal.Size = new Size(194, 29);
            txtNumeroAnimal.TabIndex = 53;
            txtNumeroAnimal.KeyDown += CopiaryPegar_KeyDown;
            txtNumeroAnimal.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnGuardarProduccion
            // 
            btnGuardarProduccion.BackColor = Color.White;
            btnGuardarProduccion.FlatAppearance.BorderSize = 0;
            btnGuardarProduccion.FlatStyle = FlatStyle.Flat;
            btnGuardarProduccion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarProduccion.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarProduccion.Image = Properties.Resources.ganado1;
            btnGuardarProduccion.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarProduccion.Location = new Point(355, 169);
            btnGuardarProduccion.Name = "btnGuardarProduccion";
            btnGuardarProduccion.Size = new Size(161, 41);
            btnGuardarProduccion.TabIndex = 47;
            btnGuardarProduccion.Text = "Guardar";
            btnGuardarProduccion.UseVisualStyleBackColor = false;
            btnGuardarProduccion.Click += btnGuardarProduccion_Click;
            // 
            // gbIndustriaCerdo
            // 
            gbIndustriaCerdo.Controls.Add(cmbCantidadEnviarIndustria);
            gbIndustriaCerdo.Controls.Add(label1);
            gbIndustriaCerdo.Controls.Add(dtpFechaEgresoEnviarIndustria);
            gbIndustriaCerdo.Controls.Add(btnEnviarCerdoIndustria);
            gbIndustriaCerdo.Controls.Add(lblFechaEgresoCerdo);
            gbIndustriaCerdo.Controls.Add(cmbEnviarIndustria);
            gbIndustriaCerdo.Controls.Add(label6);
            gbIndustriaCerdo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbIndustriaCerdo.ForeColor = Color.White;
            gbIndustriaCerdo.Location = new Point(534, 6);
            gbIndustriaCerdo.Name = "gbIndustriaCerdo";
            gbIndustriaCerdo.Size = new Size(445, 216);
            gbIndustriaCerdo.TabIndex = 88;
            gbIndustriaCerdo.TabStop = false;
            gbIndustriaCerdo.Text = "Enviar a Industria";
            // 
            // cmbCantidadEnviarIndustria
            // 
            cmbCantidadEnviarIndustria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCantidadEnviarIndustria.FormattingEnabled = true;
            cmbCantidadEnviarIndustria.Location = new Point(200, 121);
            cmbCantidadEnviarIndustria.Name = "cmbCantidadEnviarIndustria";
            cmbCantidadEnviarIndustria.Size = new Size(191, 32);
            cmbCantidadEnviarIndustria.TabIndex = 79;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(34, 125);
            label1.Name = "label1";
            label1.Size = new Size(138, 24);
            label1.TabIndex = 78;
            label1.Text = "N° de Animal:";
            // 
            // dtpFechaEgresoEnviarIndustria
            // 
            dtpFechaEgresoEnviarIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaEgresoEnviarIndustria.Location = new Point(198, 77);
            dtpFechaEgresoEnviarIndustria.Name = "dtpFechaEgresoEnviarIndustria";
            dtpFechaEgresoEnviarIndustria.Size = new Size(191, 29);
            dtpFechaEgresoEnviarIndustria.TabIndex = 77;
            // 
            // btnEnviarCerdoIndustria
            // 
            btnEnviarCerdoIndustria.BackColor = Color.White;
            btnEnviarCerdoIndustria.FlatAppearance.BorderSize = 0;
            btnEnviarCerdoIndustria.FlatStyle = FlatStyle.Flat;
            btnEnviarCerdoIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnEnviarCerdoIndustria.ForeColor = Color.FromArgb(56, 124, 31);
            btnEnviarCerdoIndustria.Image = Properties.Resources.fabrica;
            btnEnviarCerdoIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnviarCerdoIndustria.Location = new Point(274, 169);
            btnEnviarCerdoIndustria.Name = "btnEnviarCerdoIndustria";
            btnEnviarCerdoIndustria.Size = new Size(161, 41);
            btnEnviarCerdoIndustria.TabIndex = 76;
            btnEnviarCerdoIndustria.Text = "Enviar";
            btnEnviarCerdoIndustria.UseVisualStyleBackColor = false;
            btnEnviarCerdoIndustria.Click += btnEnviarCerdoIndustria_Click;
            // 
            // lblFechaEgresoCerdo
            // 
            lblFechaEgresoCerdo.AutoSize = true;
            lblFechaEgresoCerdo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaEgresoCerdo.ForeColor = Color.White;
            lblFechaEgresoCerdo.Location = new Point(22, 81);
            lblFechaEgresoCerdo.Name = "lblFechaEgresoCerdo";
            lblFechaEgresoCerdo.Size = new Size(148, 24);
            lblFechaEgresoCerdo.TabIndex = 74;
            lblFechaEgresoCerdo.Text = "Fecha Egreso:";
            // 
            // cmbEnviarIndustria
            // 
            cmbEnviarIndustria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEnviarIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbEnviarIndustria.FormattingEnabled = true;
            cmbEnviarIndustria.Location = new Point(198, 31);
            cmbEnviarIndustria.Name = "cmbEnviarIndustria";
            cmbEnviarIndustria.Size = new Size(191, 32);
            cmbEnviarIndustria.TabIndex = 73;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(109, 37);
            label6.Name = "label6";
            label6.Size = new Size(52, 24);
            label6.TabIndex = 71;
            label6.Text = "Box:";
            // 
            // tabPage10
            // 
            tabPage10.BackColor = Color.FromArgb(141, 181, 146);
            tabPage10.Controls.Add(btnImprimirMonta);
            tabPage10.Controls.Add(dtgMontaNacimientos);
            tabPage10.Controls.Add(gbREgistroNacimientoCerdos);
            tabPage10.Controls.Add(gbRegistroMontaCerdos);
            tabPage10.Location = new Point(4, 33);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(3);
            tabPage10.Size = new Size(985, 669);
            tabPage10.TabIndex = 1;
            tabPage10.Text = "Registro de Fertilidad y Nacimientos";
            // 
            // btnImprimirMonta
            // 
            btnImprimirMonta.BackColor = Color.White;
            btnImprimirMonta.FlatAppearance.BorderSize = 0;
            btnImprimirMonta.FlatStyle = FlatStyle.Flat;
            btnImprimirMonta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnImprimirMonta.ForeColor = Color.FromArgb(56, 124, 31);
            btnImprimirMonta.Image = Properties.Resources.imprimir;
            btnImprimirMonta.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirMonta.Location = new Point(809, 366);
            btnImprimirMonta.Name = "btnImprimirMonta";
            btnImprimirMonta.Size = new Size(161, 41);
            btnImprimirMonta.TabIndex = 94;
            btnImprimirMonta.Text = "Imprimir";
            btnImprimirMonta.UseVisualStyleBackColor = false;
            btnImprimirMonta.Click += btnImprimirMonta_Click;
            // 
            // dtgMontaNacimientos
            // 
            dtgMontaNacimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgMontaNacimientos.Location = new Point(6, 413);
            dtgMontaNacimientos.Name = "dtgMontaNacimientos";
            dtgMontaNacimientos.ReadOnly = true;
            dtgMontaNacimientos.Size = new Size(964, 247);
            dtgMontaNacimientos.TabIndex = 93;
            // 
            // gbREgistroNacimientoCerdos
            // 
            gbREgistroNacimientoCerdos.Controls.Add(txtCantidadMachos);
            gbREgistroNacimientoCerdos.Controls.Add(txtCantidadHembras);
            gbREgistroNacimientoCerdos.Controls.Add(txtTotalNacidos);
            gbREgistroNacimientoCerdos.Controls.Add(cmbPadreNacimiento);
            gbREgistroNacimientoCerdos.Controls.Add(cmbMadreNacimiento);
            gbREgistroNacimientoCerdos.Controls.Add(lblCantidadMachosCerdos);
            gbREgistroNacimientoCerdos.Controls.Add(lblCantidadHembrasCerdos);
            gbREgistroNacimientoCerdos.Controls.Add(btnGuardarRegistroNacimiento);
            gbREgistroNacimientoCerdos.Controls.Add(lblNumeroPadreCerdo2);
            gbREgistroNacimientoCerdos.Controls.Add(lblTotalNacidosCerdos);
            gbREgistroNacimientoCerdos.Controls.Add(dtpFechaNacimiento);
            gbREgistroNacimientoCerdos.Controls.Add(lblNumeroMadreCerdo2);
            gbREgistroNacimientoCerdos.Controls.Add(lblFechaPartoCerdos);
            gbREgistroNacimientoCerdos.ForeColor = Color.White;
            gbREgistroNacimientoCerdos.Location = new Point(510, 16);
            gbREgistroNacimientoCerdos.Name = "gbREgistroNacimientoCerdos";
            gbREgistroNacimientoCerdos.Size = new Size(441, 332);
            gbREgistroNacimientoCerdos.TabIndex = 92;
            gbREgistroNacimientoCerdos.TabStop = false;
            gbREgistroNacimientoCerdos.Text = "Registro de Nacimiento";
            gbREgistroNacimientoCerdos.Enter += gbREgistroNacimientoCerdos_Enter;
            // 
            // txtCantidadMachos
            // 
            txtCantidadMachos.Location = new Point(211, 236);
            txtCantidadMachos.Name = "txtCantidadMachos";
            txtCantidadMachos.Size = new Size(170, 29);
            txtCantidadMachos.TabIndex = 95;
            txtCantidadMachos.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadMachos.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtCantidadHembras
            // 
            txtCantidadHembras.Location = new Point(211, 196);
            txtCantidadHembras.Name = "txtCantidadHembras";
            txtCantidadHembras.Size = new Size(170, 29);
            txtCantidadHembras.TabIndex = 94;
            txtCantidadHembras.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadHembras.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtTotalNacidos
            // 
            txtTotalNacidos.Location = new Point(211, 156);
            txtTotalNacidos.Name = "txtTotalNacidos";
            txtTotalNacidos.Size = new Size(170, 29);
            txtTotalNacidos.TabIndex = 93;
            txtTotalNacidos.KeyDown += CopiaryPegar_KeyDown;
            txtTotalNacidos.KeyPress += SoloNumeros_KeyPress;
            // 
            // cmbPadreNacimiento
            // 
            cmbPadreNacimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPadreNacimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPadreNacimiento.FormattingEnabled = true;
            cmbPadreNacimiento.Location = new Point(211, 73);
            cmbPadreNacimiento.Name = "cmbPadreNacimiento";
            cmbPadreNacimiento.Size = new Size(170, 32);
            cmbPadreNacimiento.TabIndex = 92;
            // 
            // cmbMadreNacimiento
            // 
            cmbMadreNacimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMadreNacimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbMadreNacimiento.FormattingEnabled = true;
            cmbMadreNacimiento.Location = new Point(211, 30);
            cmbMadreNacimiento.Name = "cmbMadreNacimiento";
            cmbMadreNacimiento.Size = new Size(170, 32);
            cmbMadreNacimiento.TabIndex = 91;
            // 
            // lblCantidadMachosCerdos
            // 
            lblCantidadMachosCerdos.AutoSize = true;
            lblCantidadMachosCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadMachosCerdos.ForeColor = Color.White;
            lblCantidadMachosCerdos.Location = new Point(17, 241);
            lblCantidadMachosCerdos.Name = "lblCantidadMachosCerdos";
            lblCantidadMachosCerdos.Size = new Size(177, 24);
            lblCantidadMachosCerdos.TabIndex = 89;
            lblCantidadMachosCerdos.Text = "Cantidad Machos:";
            // 
            // lblCantidadHembrasCerdos
            // 
            lblCantidadHembrasCerdos.AutoSize = true;
            lblCantidadHembrasCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadHembrasCerdos.ForeColor = Color.White;
            lblCantidadHembrasCerdos.Location = new Point(6, 202);
            lblCantidadHembrasCerdos.Name = "lblCantidadHembrasCerdos";
            lblCantidadHembrasCerdos.Size = new Size(188, 24);
            lblCantidadHembrasCerdos.TabIndex = 87;
            lblCantidadHembrasCerdos.Text = "Cantidad Hembras:";
            // 
            // btnGuardarRegistroNacimiento
            // 
            btnGuardarRegistroNacimiento.BackColor = Color.White;
            btnGuardarRegistroNacimiento.FlatAppearance.BorderSize = 0;
            btnGuardarRegistroNacimiento.FlatStyle = FlatStyle.Flat;
            btnGuardarRegistroNacimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarRegistroNacimiento.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarRegistroNacimiento.Image = Properties.Resources.ganado;
            btnGuardarRegistroNacimiento.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarRegistroNacimiento.Location = new Point(280, 285);
            btnGuardarRegistroNacimiento.Name = "btnGuardarRegistroNacimiento";
            btnGuardarRegistroNacimiento.Size = new Size(161, 41);
            btnGuardarRegistroNacimiento.TabIndex = 86;
            btnGuardarRegistroNacimiento.Text = "Guardar";
            btnGuardarRegistroNacimiento.UseVisualStyleBackColor = false;
            btnGuardarRegistroNacimiento.Click += btnGuardarRegistroNacimiento_Click;
            // 
            // lblNumeroPadreCerdo2
            // 
            lblNumeroPadreCerdo2.AutoSize = true;
            lblNumeroPadreCerdo2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroPadreCerdo2.ForeColor = Color.White;
            lblNumeroPadreCerdo2.Location = new Point(40, 74);
            lblNumeroPadreCerdo2.Name = "lblNumeroPadreCerdo2";
            lblNumeroPadreCerdo2.Size = new Size(151, 24);
            lblNumeroPadreCerdo2.TabIndex = 84;
            lblNumeroPadreCerdo2.Text = "N° de la Padre:";
            // 
            // lblTotalNacidosCerdos
            // 
            lblTotalNacidosCerdos.AutoSize = true;
            lblTotalNacidosCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTotalNacidosCerdos.ForeColor = Color.White;
            lblTotalNacidosCerdos.Location = new Point(47, 156);
            lblTotalNacidosCerdos.Name = "lblTotalNacidosCerdos";
            lblTotalNacidosCerdos.Size = new Size(144, 24);
            lblTotalNacidosCerdos.TabIndex = 82;
            lblTotalNacidosCerdos.Text = "Total Nacidos:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaNacimiento.Location = new Point(211, 115);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(170, 29);
            dtpFechaNacimiento.TabIndex = 78;
            // 
            // lblNumeroMadreCerdo2
            // 
            lblNumeroMadreCerdo2.AutoSize = true;
            lblNumeroMadreCerdo2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroMadreCerdo2.ForeColor = Color.White;
            lblNumeroMadreCerdo2.Location = new Point(36, 33);
            lblNumeroMadreCerdo2.Name = "lblNumeroMadreCerdo2";
            lblNumeroMadreCerdo2.Size = new Size(155, 24);
            lblNumeroMadreCerdo2.TabIndex = 19;
            lblNumeroMadreCerdo2.Text = "N° de la Madre:";
            // 
            // lblFechaPartoCerdos
            // 
            lblFechaPartoCerdos.AutoSize = true;
            lblFechaPartoCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaPartoCerdos.ForeColor = Color.White;
            lblFechaPartoCerdos.Location = new Point(32, 114);
            lblFechaPartoCerdos.Name = "lblFechaPartoCerdos";
            lblFechaPartoCerdos.Size = new Size(159, 24);
            lblFechaPartoCerdos.TabIndex = 72;
            lblFechaPartoCerdos.Text = "Fecha de Parto:";
            // 
            // gbRegistroMontaCerdos
            // 
            gbRegistroMontaCerdos.Controls.Add(cmbPadreMonta);
            gbRegistroMontaCerdos.Controls.Add(cmbMadreMonta);
            gbRegistroMontaCerdos.Controls.Add(btnGuardarRegistroMonta);
            gbRegistroMontaCerdos.Controls.Add(lblNumeroPadreCerdo);
            gbRegistroMontaCerdos.Controls.Add(dtpPosibleParto);
            gbRegistroMontaCerdos.Controls.Add(dtpFechaMonta);
            gbRegistroMontaCerdos.Controls.Add(lblNumeroMadreCerdo);
            gbRegistroMontaCerdos.Controls.Add(lblPosiblePartoCerdos);
            gbRegistroMontaCerdos.Controls.Add(lblFechaMontaCerdos);
            gbRegistroMontaCerdos.ForeColor = Color.White;
            gbRegistroMontaCerdos.Location = new Point(23, 16);
            gbRegistroMontaCerdos.Name = "gbRegistroMontaCerdos";
            gbRegistroMontaCerdos.Size = new Size(449, 332);
            gbRegistroMontaCerdos.TabIndex = 91;
            gbRegistroMontaCerdos.TabStop = false;
            gbRegistroMontaCerdos.Text = "Registro de Monta";
            // 
            // cmbPadreMonta
            // 
            cmbPadreMonta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPadreMonta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPadreMonta.FormattingEnabled = true;
            cmbPadreMonta.Location = new Point(203, 118);
            cmbPadreMonta.Name = "cmbPadreMonta";
            cmbPadreMonta.Size = new Size(230, 32);
            cmbPadreMonta.TabIndex = 90;
            // 
            // cmbMadreMonta
            // 
            cmbMadreMonta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMadreMonta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbMadreMonta.FormattingEnabled = true;
            cmbMadreMonta.Location = new Point(203, 77);
            cmbMadreMonta.Name = "cmbMadreMonta";
            cmbMadreMonta.Size = new Size(230, 32);
            cmbMadreMonta.TabIndex = 89;
            // 
            // btnGuardarRegistroMonta
            // 
            btnGuardarRegistroMonta.BackColor = Color.White;
            btnGuardarRegistroMonta.FlatAppearance.BorderSize = 0;
            btnGuardarRegistroMonta.FlatStyle = FlatStyle.Flat;
            btnGuardarRegistroMonta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarRegistroMonta.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarRegistroMonta.Image = Properties.Resources.ganado;
            btnGuardarRegistroMonta.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarRegistroMonta.Location = new Point(282, 285);
            btnGuardarRegistroMonta.Name = "btnGuardarRegistroMonta";
            btnGuardarRegistroMonta.Size = new Size(161, 41);
            btnGuardarRegistroMonta.TabIndex = 88;
            btnGuardarRegistroMonta.Text = "Guardar";
            btnGuardarRegistroMonta.UseVisualStyleBackColor = false;
            btnGuardarRegistroMonta.Click += btnGuardarRegistroMonta_Click;
            // 
            // lblNumeroPadreCerdo
            // 
            lblNumeroPadreCerdo.AutoSize = true;
            lblNumeroPadreCerdo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroPadreCerdo.ForeColor = Color.White;
            lblNumeroPadreCerdo.Location = new Point(23, 118);
            lblNumeroPadreCerdo.Name = "lblNumeroPadreCerdo";
            lblNumeroPadreCerdo.Size = new Size(151, 24);
            lblNumeroPadreCerdo.TabIndex = 86;
            lblNumeroPadreCerdo.Text = "N° de la Padre:";
            // 
            // dtpPosibleParto
            // 
            dtpPosibleParto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpPosibleParto.Location = new Point(203, 198);
            dtpPosibleParto.Name = "dtpPosibleParto";
            dtpPosibleParto.Size = new Size(230, 29);
            dtpPosibleParto.TabIndex = 79;
            // 
            // dtpFechaMonta
            // 
            dtpFechaMonta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaMonta.Location = new Point(203, 157);
            dtpFechaMonta.Name = "dtpFechaMonta";
            dtpFechaMonta.Size = new Size(230, 29);
            dtpFechaMonta.TabIndex = 78;
            // 
            // lblNumeroMadreCerdo
            // 
            lblNumeroMadreCerdo.AutoSize = true;
            lblNumeroMadreCerdo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblNumeroMadreCerdo.ForeColor = Color.White;
            lblNumeroMadreCerdo.Location = new Point(19, 77);
            lblNumeroMadreCerdo.Name = "lblNumeroMadreCerdo";
            lblNumeroMadreCerdo.Size = new Size(155, 24);
            lblNumeroMadreCerdo.TabIndex = 19;
            lblNumeroMadreCerdo.Text = "N° de la Madre:";
            // 
            // lblPosiblePartoCerdos
            // 
            lblPosiblePartoCerdos.AutoSize = true;
            lblPosiblePartoCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblPosiblePartoCerdos.ForeColor = Color.White;
            lblPosiblePartoCerdos.Location = new Point(35, 199);
            lblPosiblePartoCerdos.Name = "lblPosiblePartoCerdos";
            lblPosiblePartoCerdos.Size = new Size(139, 24);
            lblPosiblePartoCerdos.TabIndex = 74;
            lblPosiblePartoCerdos.Text = "Posible Parto:";
            // 
            // lblFechaMontaCerdos
            // 
            lblFechaMontaCerdos.AutoSize = true;
            lblFechaMontaCerdos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaMontaCerdos.ForeColor = Color.White;
            lblFechaMontaCerdos.Location = new Point(6, 161);
            lblFechaMontaCerdos.Name = "lblFechaMontaCerdos";
            lblFechaMontaCerdos.Size = new Size(168, 24);
            lblFechaMontaCerdos.TabIndex = 72;
            lblFechaMontaCerdos.Text = "Fecha de Monta:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // UcCarne
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            Controls.Add(tabControl2);
            Name = "UcCarne";
            Size = new Size(999, 709);
            Load += UcCarne_Load;
            tabControl2.ResumeLayout(false);
            tabPage9.ResumeLayout(false);
            tabPage9.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProduccionCarne).EndInit();
            gbProduccionCerdos.ResumeLayout(false);
            gbProduccionCerdos.PerformLayout();
            gbIndustriaCerdo.ResumeLayout(false);
            gbIndustriaCerdo.PerformLayout();
            tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgMontaNacimientos).EndInit();
            gbREgistroNacimientoCerdos.ResumeLayout(false);
            gbREgistroNacimientoCerdos.PerformLayout();
            gbRegistroMontaCerdos.ResumeLayout(false);
            gbRegistroMontaCerdos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl2;
        private TabPage tabPage9;
        private GroupBox gbProduccionCerdos;
        private ComboBox cmbBoxProduccion;
        private Label lblBox;
        private Label lblNumeroCerdo;
        private TextBox txtNumeroAnimal;
        private Tienda.RJButton btnGuardarProduccion;
        private GroupBox gbIndustriaCerdo;
        private DateTimePicker dtpFechaEgresoEnviarIndustria;
        private Tienda.RJButton btnEnviarCerdoIndustria;
        private Label lblFechaEgresoCerdo;
        private ComboBox cmbEnviarIndustria;
        private Label label6;
        private TabPage tabPage10;
        private GroupBox gbREgistroNacimientoCerdos;
        private Label lblCantidadMachosCerdos;
        private Label lblCantidadHembrasCerdos;
        private Tienda.RJButton btnGuardarRegistroNacimiento;
        private Label lblNumeroPadreCerdo2;
        private Label lblTotalNacidosCerdos;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblNumeroMadreCerdo2;
        private Label lblFechaPartoCerdos;
        private GroupBox gbRegistroMontaCerdos;
        private Tienda.RJButton btnGuardarRegistroMonta;
        private Label lblNumeroPadreCerdo;
        private DateTimePicker dtpPosibleParto;
        private DateTimePicker dtpFechaMonta;
        private Label lblNumeroMadreCerdo;
        private Label lblPosiblePartoCerdos;
        private Label lblFechaMontaCerdos;
        private Tienda.RJButton btnImprimirMonta;
        private RJButton btnImprimir;
        private DataGridView dtgMontaNacimientos;
        private Tienda.RJButton rjButton2;
        private DataGridView dtgProduccionCarne;
        private TextBox txtCantidadMachos;
        private TextBox txtCantidadHembras;
        private TextBox txtTotalNacidos;
        private ComboBox cmbPadreNacimiento;
        private ComboBox cmbMadreNacimiento;
        private ComboBox cmbPadreMonta;
        private ComboBox cmbMadreMonta;
        private GroupBox groupBox1;
        private ComboBox cmbDardeBajaAnimal;
        private ComboBox comboBox5;
        private Label label2;
        private Label label3;
        private TextBox textBox4;
        private Tienda.RJButton btnRetirarAnimal;
        private Label label1;
        private RadioButton rbMacho;
        private RadioButton rbHembra;
        private DateTimePicker dtpFechaFallecimiento;
        private Label label5;
        private DateTimePicker dtpIngresoAnimal;
        private Label label4;
        private Label label7;
        private TextBox txtBuscarPorGrilla;
        private ErrorProvider errorProvider1;
        private ComboBox cmbBajaAnimal;
        private ComboBox cmbCantidadEnviarIndustria;
    }
}
