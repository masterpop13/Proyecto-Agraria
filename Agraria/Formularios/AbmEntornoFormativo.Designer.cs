namespace Agraria.Formularios
{
    partial class AbmEntornoFormativo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmEntornoFormativo));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            PanelDatos = new Panel();
            groupBox3 = new GroupBox();
            btnModificarUsuario = new Tienda.RJButton();
            pbExitEntornoFormativo = new PictureBox();
            groupBox2 = new GroupBox();
            chkUrgencia = new CheckBox();
            dtpFecha = new DateTimePicker();
            label4 = new Label();
            btnGuardar = new Tienda.RJButton();
            txtGrupo = new TextBox();
            btnLimpiar = new Tienda.RJButton();
            txtID = new TextBox();
            cmbTipoEntorno = new ComboBox();
            lblEntorno = new Label();
            txtNombreEntorno = new TextBox();
            label5 = new Label();
            label7 = new Label();
            label3 = new Label();
            lblTipoEntorno = new Label();
            label2 = new Label();
            txtDivision = new TextBox();
            lblApellido = new Label();
            txtAño = new TextBox();
            txtObservacion = new TextBox();
            txtProfesorResponsable = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtBuscarEntorno = new TextBox();
            dtgEntorno = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            PanelDatos.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbExitEntornoFormativo).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgEntorno).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PanelDatos
            // 
            PanelDatos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelDatos.BackColor = Color.FromArgb(141, 181, 146);
            PanelDatos.Controls.Add(groupBox3);
            PanelDatos.Controls.Add(pbExitEntornoFormativo);
            PanelDatos.Controls.Add(groupBox2);
            PanelDatos.Controls.Add(groupBox1);
            PanelDatos.Dock = DockStyle.Top;
            PanelDatos.Location = new Point(0, 0);
            PanelDatos.Name = "PanelDatos";
            PanelDatos.Size = new Size(1884, 284);
            PanelDatos.TabIndex = 1;
            PanelDatos.Paint += PanelDatos_Paint;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnModificarUsuario);
            groupBox3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(12, 152);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(393, 119);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Modificar exclusivo Administrador:";
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
            btnModificarUsuario.Location = new Point(128, 56);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(134, 40);
            btnModificarUsuario.TabIndex = 7;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.TextAlign = ContentAlignment.MiddleRight;
            btnModificarUsuario.UseVisualStyleBackColor = false;
            btnModificarUsuario.Click += btnModificar_Click;
            // 
            // pbExitEntornoFormativo
            // 
            pbExitEntornoFormativo.Image = Properties.Resources.x;
            pbExitEntornoFormativo.Location = new Point(1827, 3);
            pbExitEntornoFormativo.Name = "pbExitEntornoFormativo";
            pbExitEntornoFormativo.Size = new Size(29, 28);
            pbExitEntornoFormativo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbExitEntornoFormativo.TabIndex = 23;
            pbExitEntornoFormativo.TabStop = false;
            pbExitEntornoFormativo.Click += pbExitEntornoFormativo_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkUrgencia);
            groupBox2.Controls.Add(dtpFecha);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnGuardar);
            groupBox2.Controls.Add(txtGrupo);
            groupBox2.Controls.Add(btnLimpiar);
            groupBox2.Controls.Add(txtID);
            groupBox2.Controls.Add(cmbTipoEntorno);
            groupBox2.Controls.Add(lblEntorno);
            groupBox2.Controls.Add(txtNombreEntorno);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(lblTipoEntorno);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtDivision);
            groupBox2.Controls.Add(lblApellido);
            groupBox2.Controls.Add(txtAño);
            groupBox2.Controls.Add(txtObservacion);
            groupBox2.Controls.Add(txtProfesorResponsable);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(425, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1431, 245);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos Entorno :";
            // 
            // chkUrgencia
            // 
            chkUrgencia.AutoSize = true;
            chkUrgencia.Location = new Point(36, 191);
            chkUrgencia.Name = "chkUrgencia";
            chkUrgencia.Size = new Size(241, 28);
            chkUrgencia.TabIndex = 41;
            chkUrgencia.Text = "Marcar como Urgencia";
            chkUrgencia.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(632, 190);
            dtpFecha.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(452, 29);
            dtpFecha.TabIndex = 40;
            dtpFecha.Value = new DateTime(2025, 9, 14, 20, 55, 36, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(551, 190);
            label4.Name = "label4";
            label4.Size = new Size(75, 24);
            label4.TabIndex = 39;
            label4.Text = "Fecha:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.White;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(1299, 198);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(126, 41);
            btnGuardar.TabIndex = 37;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(632, 143);
            txtGrupo.MaxLength = 5;
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(111, 29);
            txtGrupo.TabIndex = 36;
            txtGrupo.KeyDown += CopiaryPegar_KeyDown;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.FromArgb(56, 124, 31);
            btnLimpiar.Image = (Image)resources.GetObject("btnLimpiar.Image");
            btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.Location = new Point(1161, 198);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(119, 41);
            btnLimpiar.TabIndex = 35;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(410, 190);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 29);
            txtID.TabIndex = 33;
            txtID.Visible = false;
            // 
            // cmbTipoEntorno
            // 
            cmbTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEntorno.FormattingEnabled = true;
            cmbTipoEntorno.Location = new Point(287, 95);
            cmbTipoEntorno.Name = "cmbTipoEntorno";
            cmbTipoEntorno.Size = new Size(223, 32);
            cmbTipoEntorno.TabIndex = 22;
            // 
            // lblEntorno
            // 
            lblEntorno.AutoSize = true;
            lblEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblEntorno.ForeColor = Color.White;
            lblEntorno.Location = new Point(75, 59);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(206, 24);
            lblEntorno.TabIndex = 21;
            lblEntorno.Text = "Nombre del Entorno:";
            // 
            // txtNombreEntorno
            // 
            txtNombreEntorno.Location = new Point(287, 53);
            txtNombreEntorno.MaxLength = 40;
            txtNombreEntorno.Name = "txtNombreEntorno";
            txtNombreEntorno.Size = new Size(223, 29);
            txtNombreEntorno.TabIndex = 11;
            txtNombreEntorno.KeyDown += CopiaryPegar_KeyDown;
            txtNombreEntorno.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(537, 102);
            label5.Name = "label5";
            label5.Size = new Size(89, 24);
            label5.TabIndex = 18;
            label5.Text = "División:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(59, 143);
            label7.Name = "label7";
            label7.Size = new Size(222, 24);
            label7.TabIndex = 20;
            label7.Text = "Profesor Responsable:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(572, 58);
            label3.Name = "label3";
            label3.Size = new Size(54, 24);
            label3.TabIndex = 16;
            label3.Text = "Año:";
            // 
            // lblTipoEntorno
            // 
            lblTipoEntorno.AutoSize = true;
            lblTipoEntorno.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTipoEntorno.ForeColor = Color.White;
            lblTipoEntorno.Location = new Point(109, 101);
            lblTipoEntorno.Name = "lblTipoEntorno";
            lblTipoEntorno.Size = new Size(168, 24);
            lblTipoEntorno.TabIndex = 19;
            lblTipoEntorno.Text = "Tipo de Entorno:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(552, 146);
            label2.Name = "label2";
            label2.Size = new Size(74, 24);
            label2.TabIndex = 15;
            label2.Text = "Grupo:";
            // 
            // txtDivision
            // 
            txtDivision.Location = new Point(632, 99);
            txtDivision.MaxLength = 5;
            txtDivision.Name = "txtDivision";
            txtDivision.Size = new Size(111, 29);
            txtDivision.TabIndex = 6;
            txtDivision.KeyDown += CopiaryPegar_KeyDown;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(784, 27);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(156, 24);
            lblApellido.TabIndex = 14;
            lblApellido.Text = "Observaciones:";
            // 
            // txtAño
            // 
            txtAño.Location = new Point(632, 55);
            txtAño.MaxLength = 4;
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(111, 29);
            txtAño.TabIndex = 9;
            txtAño.KeyDown += CopiaryPegar_KeyDown;
            txtAño.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(946, 24);
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(479, 158);
            txtObservacion.TabIndex = 4;
            txtObservacion.KeyDown += CopiaryPegar_KeyDown;
            // 
            // txtProfesorResponsable
            // 
            txtProfesorResponsable.Location = new Point(287, 140);
            txtProfesorResponsable.MaxLength = 40;
            txtProfesorResponsable.Name = "txtProfesorResponsable";
            txtProfesorResponsable.Size = new Size(223, 29);
            txtProfesorResponsable.TabIndex = 5;
            txtProfesorResponsable.KeyDown += CopiaryPegar_KeyDown;
            txtProfesorResponsable.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBuscarEntorno);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 120);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buscar  Por Tipo de Entorno:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 59);
            label1.Name = "label1";
            label1.Size = new Size(97, 24);
            label1.TabIndex = 21;
            label1.Text = "Nombre :";
            // 
            // txtBuscarEntorno
            // 
            txtBuscarEntorno.Location = new Point(128, 56);
            txtBuscarEntorno.MaxLength = 20;
            txtBuscarEntorno.Name = "txtBuscarEntorno";
            txtBuscarEntorno.Size = new Size(150, 29);
            txtBuscarEntorno.TabIndex = 11;
            txtBuscarEntorno.TextChanged += txtBuscarEntorno_TextChanged;
            txtBuscarEntorno.KeyDown += CopiaryPegar_KeyDown;
            txtBuscarEntorno.KeyPress += Solotexto_KeyPress;
            // 
            // dtgEntorno
            // 
            dtgEntorno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgEntorno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgEntorno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgEntorno.DefaultCellStyle = dataGridViewCellStyle2;
            dtgEntorno.Dock = DockStyle.Bottom;
            dtgEntorno.Location = new Point(0, 277);
            dtgEntorno.Name = "dtgEntorno";
            dtgEntorno.ReadOnly = true;
            dtgEntorno.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgEntorno.Size = new Size(1884, 584);
            dtgEntorno.TabIndex = 3;
            dtgEntorno.CellClick += dtgEntorno_CellClick;
            dtgEntorno.CellContentClick += dtgEntorno_CellContentClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AbmEntornoFormativo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1884, 861);
            Controls.Add(dtgEntorno);
            Controls.Add(PanelDatos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AbmEntornoFormativo";
            Text = "AbmEntornoFormativo";
            Load += AbmEntornoFormativo_Load;
            PanelDatos.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbExitEntornoFormativo).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgEntorno).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelDatos;
        private PictureBox pbExitEntornoFormativo;
        private GroupBox groupBox2;
        private Tienda.RJButton btnLimpiar;
        private TextBox txtID;
        private ComboBox cmbTipoEntorno;
        private Label lblEntorno;
        private TextBox txtNombreEntorno;
        private Label label5;
        private Label label7;
        private Label label3;
        private Label lblTipoEntorno;
        private Label label2;
        private TextBox txtDivision;
        private Label lblApellido;
        private TextBox txtAño;
        private TextBox txtObservacion;
        private TextBox txtProfesorResponsable;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtBuscarEntorno;
        private DataGridView dtgEntorno;
        private TextBox txtGrupo;
        private Tienda.RJButton btnGuardar;
        private GroupBox groupBox3;
        private Tienda.RJButton btnModificarUsuario;
        private Label label4;
        private DateTimePicker dtpFecha;
        private CheckBox chkUrgencia;
        private ErrorProvider errorProvider1;
    }
}