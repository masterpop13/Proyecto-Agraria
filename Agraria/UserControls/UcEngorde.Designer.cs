namespace Agraria.UserControls
{
    partial class UcEngorde
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcEngorde));
            dtpFechaIngresoPollosEngorde = new DateTimePicker();
            dtgRegistroPollos = new DataGridView();
            gbEnviarPolloIndustria = new GroupBox();
            dtpFechaEgresoPollosEngorde = new DateTimePicker();
            btnEnviarPolloEngordeIndustria = new Tienda.RJButton();
            lblFechaEgresoPollosEngorde = new Label();
            cmbPolloEnvio = new ComboBox();
            lblCantidadPollosEngorde2 = new Label();
            lblBoxPolloEngorde2 = new Label();
            txtCantidadPollosEngorde2 = new TextBox();
            lblFechaIngresoPollosEngorde = new Label();
            lblEdadPollo = new Label();
            cmbTipoAlimento = new ComboBox();
            btnGuardarRegistro = new Tienda.RJButton();
            lblAlimentoKlDia = new Label();
            cmbPolloActualizar = new ComboBox();
            txtEdadPollo = new TextBox();
            txtPesoPollo = new TextBox();
            lblPesoPollo = new Label();
            lblCantidadPollosEngorde = new Label();
            lblBoxPolloEngorde = new Label();
            lblTipoAlimento = new Label();
            txtCantidadPollosEngorde = new TextBox();
            txtAlimentoKlDia = new TextBox();
            btnImprimir = new Tienda.RJButton();
            groupBox1 = new GroupBox();
            dtpFechaCarga = new DateTimePicker();
            btnGuardarPollos = new Tienda.RJButton();
            label1 = new Label();
            cmbBoxCarga = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            txtCargabox = new TextBox();
            groupBox2 = new GroupBox();
            label4 = new Label();
            txtBuscarPorGrilla = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dtgRegistroPollos).BeginInit();
            gbEnviarPolloIndustria.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dtpFechaIngresoPollosEngorde
            // 
            dtpFechaIngresoPollosEngorde.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaIngresoPollosEngorde.Location = new Point(237, 69);
            dtpFechaIngresoPollosEngorde.Name = "dtpFechaIngresoPollosEngorde";
            dtpFechaIngresoPollosEngorde.Size = new Size(219, 29);
            dtpFechaIngresoPollosEngorde.TabIndex = 89;
            // 
            // dtgRegistroPollos
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgRegistroPollos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgRegistroPollos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgRegistroPollos.DefaultCellStyle = dataGridViewCellStyle2;
            dtgRegistroPollos.Dock = DockStyle.Bottom;
            dtgRegistroPollos.Location = new Point(0, 482);
            dtgRegistroPollos.Name = "dtgRegistroPollos";
            dtgRegistroPollos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgRegistroPollos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgRegistroPollos.Size = new Size(999, 227);
            dtgRegistroPollos.TabIndex = 88;
            // 
            // gbEnviarPolloIndustria
            // 
            gbEnviarPolloIndustria.Controls.Add(dtpFechaEgresoPollosEngorde);
            gbEnviarPolloIndustria.Controls.Add(btnEnviarPolloEngordeIndustria);
            gbEnviarPolloIndustria.Controls.Add(lblFechaEgresoPollosEngorde);
            gbEnviarPolloIndustria.Controls.Add(cmbPolloEnvio);
            gbEnviarPolloIndustria.Controls.Add(lblCantidadPollosEngorde2);
            gbEnviarPolloIndustria.Controls.Add(lblBoxPolloEngorde2);
            gbEnviarPolloIndustria.Controls.Add(txtCantidadPollosEngorde2);
            gbEnviarPolloIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbEnviarPolloIndustria.ForeColor = Color.White;
            gbEnviarPolloIndustria.Location = new Point(6, 219);
            gbEnviarPolloIndustria.Name = "gbEnviarPolloIndustria";
            gbEnviarPolloIndustria.Size = new Size(456, 200);
            gbEnviarPolloIndustria.TabIndex = 87;
            gbEnviarPolloIndustria.TabStop = false;
            gbEnviarPolloIndustria.Text = "Enviar Pollos a Industria";
            // 
            // dtpFechaEgresoPollosEngorde
            // 
            dtpFechaEgresoPollosEngorde.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaEgresoPollosEngorde.Location = new Point(216, 73);
            dtpFechaEgresoPollosEngorde.Name = "dtpFechaEgresoPollosEngorde";
            dtpFechaEgresoPollosEngorde.Size = new Size(200, 29);
            dtpFechaEgresoPollosEngorde.TabIndex = 77;
            // 
            // btnEnviarPolloEngordeIndustria
            // 
            btnEnviarPolloEngordeIndustria.BackColor = Color.White;
            btnEnviarPolloEngordeIndustria.FlatAppearance.BorderSize = 0;
            btnEnviarPolloEngordeIndustria.FlatStyle = FlatStyle.Flat;
            btnEnviarPolloEngordeIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnEnviarPolloEngordeIndustria.ForeColor = Color.FromArgb(56, 124, 31);
            btnEnviarPolloEngordeIndustria.Image = Properties.Resources.fabrica;
            btnEnviarPolloEngordeIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnviarPolloEngordeIndustria.Location = new Point(284, 148);
            btnEnviarPolloEngordeIndustria.Name = "btnEnviarPolloEngordeIndustria";
            btnEnviarPolloEngordeIndustria.Size = new Size(161, 41);
            btnEnviarPolloEngordeIndustria.TabIndex = 76;
            btnEnviarPolloEngordeIndustria.Text = "Enviar";
            btnEnviarPolloEngordeIndustria.UseVisualStyleBackColor = false;
            btnEnviarPolloEngordeIndustria.Click += btnEnviarPolloEngordeIndustria_Click;
            // 
            // lblFechaEgresoPollosEngorde
            // 
            lblFechaEgresoPollosEngorde.AutoSize = true;
            lblFechaEgresoPollosEngorde.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaEgresoPollosEngorde.ForeColor = Color.White;
            lblFechaEgresoPollosEngorde.Location = new Point(34, 72);
            lblFechaEgresoPollosEngorde.Name = "lblFechaEgresoPollosEngorde";
            lblFechaEgresoPollosEngorde.Size = new Size(164, 24);
            lblFechaEgresoPollosEngorde.TabIndex = 74;
            lblFechaEgresoPollosEngorde.Text = "Fecha de Envio:";
            // 
            // cmbPolloEnvio
            // 
            cmbPolloEnvio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPolloEnvio.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPolloEnvio.FormattingEnabled = true;
            cmbPolloEnvio.Location = new Point(216, 31);
            cmbPolloEnvio.Name = "cmbPolloEnvio";
            cmbPolloEnvio.Size = new Size(200, 32);
            cmbPolloEnvio.TabIndex = 73;
            // 
            // lblCantidadPollosEngorde2
            // 
            lblCantidadPollosEngorde2.AutoSize = true;
            lblCantidadPollosEngorde2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadPollosEngorde2.ForeColor = Color.White;
            lblCantidadPollosEngorde2.Location = new Point(97, 115);
            lblCantidadPollosEngorde2.Name = "lblCantidadPollosEngorde2";
            lblCantidadPollosEngorde2.Size = new Size(98, 24);
            lblCantidadPollosEngorde2.TabIndex = 72;
            lblCantidadPollosEngorde2.Text = "Cantidad:";
            // 
            // lblBoxPolloEngorde2
            // 
            lblBoxPolloEngorde2.AutoSize = true;
            lblBoxPolloEngorde2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblBoxPolloEngorde2.ForeColor = Color.White;
            lblBoxPolloEngorde2.Location = new Point(143, 33);
            lblBoxPolloEngorde2.Name = "lblBoxPolloEngorde2";
            lblBoxPolloEngorde2.Size = new Size(52, 24);
            lblBoxPolloEngorde2.TabIndex = 71;
            lblBoxPolloEngorde2.Text = "Box:";
            // 
            // txtCantidadPollosEngorde2
            // 
            txtCantidadPollosEngorde2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCantidadPollosEngorde2.Location = new Point(216, 112);
            txtCantidadPollosEngorde2.MaxLength = 7;
            txtCantidadPollosEngorde2.Name = "txtCantidadPollosEngorde2";
            txtCantidadPollosEngorde2.Size = new Size(200, 29);
            txtCantidadPollosEngorde2.TabIndex = 70;
            txtCantidadPollosEngorde2.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadPollosEngorde2.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblFechaIngresoPollosEngorde
            // 
            lblFechaIngresoPollosEngorde.AutoSize = true;
            lblFechaIngresoPollosEngorde.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaIngresoPollosEngorde.ForeColor = Color.White;
            lblFechaIngresoPollosEngorde.Location = new Point(63, 72);
            lblFechaIngresoPollosEngorde.Name = "lblFechaIngresoPollosEngorde";
            lblFechaIngresoPollosEngorde.Size = new Size(151, 24);
            lblFechaIngresoPollosEngorde.TabIndex = 86;
            lblFechaIngresoPollosEngorde.Text = "Fecha Ingreso:";
            // 
            // lblEdadPollo
            // 
            lblEdadPollo.AutoSize = true;
            lblEdadPollo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblEdadPollo.ForeColor = Color.White;
            lblEdadPollo.Location = new Point(49, 165);
            lblEdadPollo.Name = "lblEdadPollo";
            lblEdadPollo.Size = new Size(165, 24);
            lblEdadPollo.TabIndex = 85;
            lblEdadPollo.Text = "Edad(Semanas):";
            // 
            // cmbTipoAlimento
            // 
            cmbTipoAlimento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoAlimento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbTipoAlimento.FormattingEnabled = true;
            cmbTipoAlimento.Location = new Point(237, 253);
            cmbTipoAlimento.Name = "cmbTipoAlimento";
            cmbTipoAlimento.Size = new Size(219, 32);
            cmbTipoAlimento.TabIndex = 83;
            // 
            // btnGuardarRegistro
            // 
            btnGuardarRegistro.BackColor = Color.White;
            btnGuardarRegistro.FlatAppearance.BorderSize = 0;
            btnGuardarRegistro.FlatStyle = FlatStyle.Flat;
            btnGuardarRegistro.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarRegistro.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarRegistro.Image = (Image)resources.GetObject("btnGuardarRegistro.Image");
            btnGuardarRegistro.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarRegistro.Location = new Point(316, 359);
            btnGuardarRegistro.Name = "btnGuardarRegistro";
            btnGuardarRegistro.Size = new Size(161, 41);
            btnGuardarRegistro.TabIndex = 84;
            btnGuardarRegistro.Text = "Guardar";
            btnGuardarRegistro.UseVisualStyleBackColor = false;
            btnGuardarRegistro.Click += btnGuardarRegistro_Click;
            // 
            // lblAlimentoKlDia
            // 
            lblAlimentoKlDia.AutoSize = true;
            lblAlimentoKlDia.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblAlimentoKlDia.ForeColor = Color.White;
            lblAlimentoKlDia.Location = new Point(37, 307);
            lblAlimentoKlDia.Name = "lblAlimentoKlDia";
            lblAlimentoKlDia.Size = new Size(177, 24);
            lblAlimentoKlDia.TabIndex = 82;
            lblAlimentoKlDia.Text = "Alimento Kg / Dia:";
            // 
            // cmbPolloActualizar
            // 
            cmbPolloActualizar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPolloActualizar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPolloActualizar.FormattingEnabled = true;
            cmbPolloActualizar.Location = new Point(237, 20);
            cmbPolloActualizar.Name = "cmbPolloActualizar";
            cmbPolloActualizar.Size = new Size(219, 32);
            cmbPolloActualizar.TabIndex = 81;
            // 
            // txtEdadPollo
            // 
            txtEdadPollo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtEdadPollo.Location = new Point(237, 161);
            txtEdadPollo.MaxLength = 5;
            txtEdadPollo.Name = "txtEdadPollo";
            txtEdadPollo.Size = new Size(219, 29);
            txtEdadPollo.TabIndex = 79;
            txtEdadPollo.KeyDown += CopiaryPegar_KeyDown;
            txtEdadPollo.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // txtPesoPollo
            // 
            txtPesoPollo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtPesoPollo.Location = new Point(237, 207);
            txtPesoPollo.MaxLength = 10;
            txtPesoPollo.Name = "txtPesoPollo";
            txtPesoPollo.Size = new Size(219, 29);
            txtPesoPollo.TabIndex = 80;
            txtPesoPollo.KeyDown += CopiaryPegar_KeyDown;
            txtPesoPollo.KeyPress += SoloNumerosYComa_KeyPress;
            // 
            // lblPesoPollo
            // 
            lblPesoPollo.AutoSize = true;
            lblPesoPollo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblPesoPollo.ForeColor = Color.White;
            lblPesoPollo.Location = new Point(151, 213);
            lblPesoPollo.Name = "lblPesoPollo";
            lblPesoPollo.Size = new Size(63, 24);
            lblPesoPollo.TabIndex = 78;
            lblPesoPollo.Text = "Peso:";
            // 
            // lblCantidadPollosEngorde
            // 
            lblCantidadPollosEngorde.AutoSize = true;
            lblCantidadPollosEngorde.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadPollosEngorde.ForeColor = Color.White;
            lblCantidadPollosEngorde.Location = new Point(116, 113);
            lblCantidadPollosEngorde.Name = "lblCantidadPollosEngorde";
            lblCantidadPollosEngorde.Size = new Size(98, 24);
            lblCantidadPollosEngorde.TabIndex = 76;
            lblCantidadPollosEngorde.Text = "Cantidad:";
            // 
            // lblBoxPolloEngorde
            // 
            lblBoxPolloEngorde.AutoSize = true;
            lblBoxPolloEngorde.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblBoxPolloEngorde.ForeColor = Color.White;
            lblBoxPolloEngorde.Location = new Point(162, 23);
            lblBoxPolloEngorde.Name = "lblBoxPolloEngorde";
            lblBoxPolloEngorde.Size = new Size(52, 24);
            lblBoxPolloEngorde.TabIndex = 75;
            lblBoxPolloEngorde.Text = "Box:";
            // 
            // lblTipoAlimento
            // 
            lblTipoAlimento.AutoSize = true;
            lblTipoAlimento.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTipoAlimento.ForeColor = Color.White;
            lblTipoAlimento.Location = new Point(68, 255);
            lblTipoAlimento.Name = "lblTipoAlimento";
            lblTipoAlimento.Size = new Size(146, 24);
            lblTipoAlimento.TabIndex = 77;
            lblTipoAlimento.Text = "Tipo Alimento:";
            // 
            // txtCantidadPollosEngorde
            // 
            txtCantidadPollosEngorde.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCantidadPollosEngorde.Location = new Point(237, 115);
            txtCantidadPollosEngorde.MaxLength = 7;
            txtCantidadPollosEngorde.Name = "txtCantidadPollosEngorde";
            txtCantidadPollosEngorde.Size = new Size(219, 29);
            txtCantidadPollosEngorde.TabIndex = 73;
            txtCantidadPollosEngorde.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadPollosEngorde.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtAlimentoKlDia
            // 
            txtAlimentoKlDia.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtAlimentoKlDia.Location = new Point(237, 302);
            txtAlimentoKlDia.MaxLength = 10;
            txtAlimentoKlDia.Name = "txtAlimentoKlDia";
            txtAlimentoKlDia.Size = new Size(219, 29);
            txtAlimentoKlDia.TabIndex = 74;
            txtAlimentoKlDia.KeyDown += CopiaryPegar_KeyDown;
            txtAlimentoKlDia.KeyPress += SoloNumerosYComa_KeyPress;
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
            btnImprimir.Location = new Point(808, 425);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(161, 41);
            btnImprimir.TabIndex = 90;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpFechaCarga);
            groupBox1.Controls.Add(btnGuardarPollos);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbBoxCarga);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCargabox);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(6, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(456, 200);
            groupBox1.TabIndex = 91;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cargar los Box";
            // 
            // dtpFechaCarga
            // 
            dtpFechaCarga.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaCarga.Location = new Point(216, 66);
            dtpFechaCarga.Name = "dtpFechaCarga";
            dtpFechaCarga.Size = new Size(200, 29);
            dtpFechaCarga.TabIndex = 77;
            // 
            // btnGuardarPollos
            // 
            btnGuardarPollos.BackColor = Color.White;
            btnGuardarPollos.FlatAppearance.BorderSize = 0;
            btnGuardarPollos.FlatStyle = FlatStyle.Flat;
            btnGuardarPollos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarPollos.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarPollos.Image = (Image)resources.GetObject("btnGuardarPollos.Image");
            btnGuardarPollos.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarPollos.Location = new Point(286, 148);
            btnGuardarPollos.Name = "btnGuardarPollos";
            btnGuardarPollos.Size = new Size(161, 41);
            btnGuardarPollos.TabIndex = 76;
            btnGuardarPollos.Text = "Enviar";
            btnGuardarPollos.UseVisualStyleBackColor = false;
            btnGuardarPollos.Click += btnGuardarPollos_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 71);
            label1.Name = "label1";
            label1.Size = new Size(181, 24);
            label1.TabIndex = 74;
            label1.Text = "Fecha de Ingreso:";
            // 
            // cmbBoxCarga
            // 
            cmbBoxCarga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxCarga.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbBoxCarga.FormattingEnabled = true;
            cmbBoxCarga.Location = new Point(216, 24);
            cmbBoxCarga.Name = "cmbBoxCarga";
            cmbBoxCarga.Size = new Size(200, 32);
            cmbBoxCarga.TabIndex = 73;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(97, 110);
            label2.Name = "label2";
            label2.Size = new Size(98, 24);
            label2.TabIndex = 72;
            label2.Text = "Cantidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(143, 28);
            label3.Name = "label3";
            label3.Size = new Size(52, 24);
            label3.TabIndex = 71;
            label3.Text = "Box:";
            // 
            // txtCargabox
            // 
            txtCargabox.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCargabox.Location = new Point(216, 105);
            txtCargabox.MaxLength = 7;
            txtCargabox.Name = "txtCargabox";
            txtCargabox.Size = new Size(200, 29);
            txtCargabox.TabIndex = 70;
            txtCargabox.KeyDown += CopiaryPegar_KeyDown;
            txtCargabox.KeyPress += SoloNumeros_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpFechaIngresoPollosEngorde);
            groupBox2.Controls.Add(lblBoxPolloEngorde);
            groupBox2.Controls.Add(cmbPolloActualizar);
            groupBox2.Controls.Add(lblFechaIngresoPollosEngorde);
            groupBox2.Controls.Add(txtEdadPollo);
            groupBox2.Controls.Add(btnGuardarRegistro);
            groupBox2.Controls.Add(cmbTipoAlimento);
            groupBox2.Controls.Add(lblEdadPollo);
            groupBox2.Controls.Add(txtCantidadPollosEngorde);
            groupBox2.Controls.Add(lblAlimentoKlDia);
            groupBox2.Controls.Add(lblCantidadPollosEngorde);
            groupBox2.Controls.Add(lblTipoAlimento);
            groupBox2.Controls.Add(lblPesoPollo);
            groupBox2.Controls.Add(txtAlimentoKlDia);
            groupBox2.Controls.Add(txtPesoPollo);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(492, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(492, 406);
            groupBox2.TabIndex = 92;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actualizar Registros";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(393, 438);
            label4.Name = "label4";
            label4.Size = new Size(159, 24);
            label4.TabIndex = 93;
            label4.Text = "Buscar por Box:";
            // 
            // txtBuscarPorGrilla
            // 
            txtBuscarPorGrilla.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtBuscarPorGrilla.Location = new Point(558, 435);
            txtBuscarPorGrilla.MaxLength = 10;
            txtBuscarPorGrilla.Name = "txtBuscarPorGrilla";
            txtBuscarPorGrilla.Size = new Size(219, 29);
            txtBuscarPorGrilla.TabIndex = 94;
            txtBuscarPorGrilla.KeyDown += CopiaryPegar_KeyDown;
            txtBuscarPorGrilla.KeyPress += SoloNumeros_KeyPress;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // UcEngorde
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            Controls.Add(txtBuscarPorGrilla);
            Controls.Add(label4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnImprimir);
            Controls.Add(dtgRegistroPollos);
            Controls.Add(gbEnviarPolloIndustria);
            Name = "UcEngorde";
            Size = new Size(999, 709);
            Load += UcEngorde_Load;
            ((System.ComponentModel.ISupportInitialize)dtgRegistroPollos).EndInit();
            gbEnviarPolloIndustria.ResumeLayout(false);
            gbEnviarPolloIndustria.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpFechaIngresoPollosEngorde;
        private DataGridView dtgRegistroPollos;
        private GroupBox gbEnviarPolloIndustria;
        private DateTimePicker dtpFechaEgresoPollosEngorde;
        private Tienda.RJButton btnEnviarPolloEngordeIndustria;
        private Label lblFechaEgresoPollosEngorde;
        private ComboBox cmbPolloEnvio;
        private Label lblCantidadPollosEngorde2;
        private Label lblBoxPolloEngorde2;
        private Label lblFechaIngresoPollosEngorde;
        private Label lblEdadPollo;
        private ComboBox cmbTipoAlimento;
        private Tienda.RJButton btnGuardarRegistro;
        private Label lblAlimentoKlDia;
        private ComboBox cmbPolloActualizar;
        private TextBox txtEdadPollo;
        private TextBox txtPesoPollo;
        private Label lblPesoPollo;
        private Label lblCantidadPollosEngorde;
        private Label lblBoxPolloEngorde;
        private Label lblTipoAlimento;
        private TextBox txtCantidadPollosEngorde;
        private TextBox txtAlimentoKlDia;
        private Tienda.RJButton btnImprimir;
        private GroupBox groupBox1;
        private DateTimePicker dtpFechaCarga;
        private Tienda.RJButton btnGuardarPollos;
        private Label label1;
        private ComboBox cmbBoxCarga;
        private Label label2;
        private Label label3;
        private TextBox txtCargabox;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox txtBuscarPorGrilla;
        private TextBox txtCantidadPollosEngorde2;
        private ErrorProvider errorProvider1;
    }
}
