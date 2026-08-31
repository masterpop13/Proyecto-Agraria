namespace Agraria.Formularios
{
    partial class RegistroActividad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroActividad));
            PanelDatos = new Panel();
            pbExitEntornoFormativo = new PictureBox();
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            txtGrupo = new TextBox();
            btnLimpiar = new Tienda.RJButton();
            lblID = new Label();
            txtID = new TextBox();
            cmbTipoEntorno = new ComboBox();
            lblEntorno = new Label();
            label5 = new Label();
            label7 = new Label();
            label3 = new Label();
            lblTipoEntorno = new Label();
            label2 = new Label();
            txtDivision = new TextBox();
            lblApellido = new Label();
            txtAño = new TextBox();
            txt = new TextBox();
            txtProfesorResponsable = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtBuscarNombreDni = new TextBox();
            dtgAbmUsuario = new DataGridView();
            panel2 = new Panel();
            btnDarDeBajaUsuario = new Tienda.RJButton();
            btnModificarUsuario = new Tienda.RJButton();
            btnAgregarUsuario = new Tienda.RJButton();
            btnDarDeAltaUsuario = new Tienda.RJButton();
            PanelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbExitEntornoFormativo).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAbmUsuario).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelDatos
            // 
            PanelDatos.BackColor = Color.FromArgb(141, 181, 146);
            PanelDatos.Controls.Add(pbExitEntornoFormativo);
            PanelDatos.Controls.Add(groupBox2);
            PanelDatos.Controls.Add(groupBox1);
            PanelDatos.Dock = DockStyle.Top;
            PanelDatos.Location = new Point(0, 0);
            PanelDatos.Name = "PanelDatos";
            PanelDatos.Size = new Size(1884, 284);
            PanelDatos.TabIndex = 2;
            PanelDatos.Paint += PanelDatos_Paint;
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
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(txtGrupo);
            groupBox2.Controls.Add(btnLimpiar);
            groupBox2.Controls.Add(lblID);
            groupBox2.Controls.Add(txtID);
            groupBox2.Controls.Add(cmbTipoEntorno);
            groupBox2.Controls.Add(lblEntorno);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(lblTipoEntorno);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtDivision);
            groupBox2.Controls.Add(lblApellido);
            groupBox2.Controls.Add(txtAño);
            groupBox2.Controls.Add(txt);
            groupBox2.Controls.Add(txtProfesorResponsable);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(425, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1431, 245);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos Entorno :";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(235, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(223, 24);
            comboBox1.TabIndex = 37;
            comboBox1.UseWaitCursor = true;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(549, 137);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(100, 22);
            txtGrupo.TabIndex = 36;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.FromArgb(56, 124, 31);
            btnLimpiar.Image = (Image)resources.GetObject("btnLimpiar.Image");
            btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.Location = new Point(1286, 196);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(139, 41);
            btnLimpiar.TabIndex = 35;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(119, 198);
            lblID.Name = "lblID";
            lblID.Size = new Size(26, 16);
            lblID.TabIndex = 34;
            lblID.Text = "ID:";
            lblID.Visible = false;
            // 
            // txtID
            // 
            txtID.Location = new Point(164, 192);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 22);
            txtID.TabIndex = 33;
            txtID.Visible = false;
            // 
            // cmbTipoEntorno
            // 
            cmbTipoEntorno.FormattingEnabled = true;
            cmbTipoEntorno.Location = new Point(235, 94);
            cmbTipoEntorno.Name = "cmbTipoEntorno";
            cmbTipoEntorno.Size = new Size(223, 24);
            cmbTipoEntorno.TabIndex = 22;
            // 
            // lblEntorno
            // 
            lblEntorno.AutoSize = true;
            lblEntorno.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEntorno.ForeColor = Color.White;
            lblEntorno.Location = new Point(10, 67);
            lblEntorno.Name = "lblEntorno";
            lblEntorno.Size = new Size(219, 16);
            lblEntorno.TabIndex = 21;
            lblEntorno.Text = "Seleccione Entorno Formativo:";
            lblEntorno.UseWaitCursor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(464, 105);
            label5.Name = "label5";
            label5.Size = new Size(67, 16);
            label5.TabIndex = 18;
            label5.Text = "División:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(48, 140);
            label7.Name = "label7";
            label7.Size = new Size(167, 16);
            label7.TabIndex = 20;
            label7.Text = "Profesor Responsable:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(493, 69);
            label3.Name = "label3";
            label3.Size = new Size(38, 16);
            label3.TabIndex = 16;
            label3.Text = "Año:";
            // 
            // lblTipoEntorno
            // 
            lblTipoEntorno.AutoSize = true;
            lblTipoEntorno.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoEntorno.ForeColor = Color.White;
            lblTipoEntorno.Location = new Point(93, 97);
            lblTipoEntorno.Name = "lblTipoEntorno";
            lblTipoEntorno.Size = new Size(122, 16);
            lblTipoEntorno.TabIndex = 19;
            lblTipoEntorno.Text = "Tipo de Entorno:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(478, 143);
            label2.Name = "label2";
            label2.Size = new Size(53, 16);
            label2.TabIndex = 15;
            label2.Text = "Grupo:";
            // 
            // txtDivision
            // 
            txtDivision.Location = new Point(549, 99);
            txtDivision.Name = "txtDivision";
            txtDivision.Size = new Size(100, 22);
            txtDivision.TabIndex = 6;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(702, 33);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(116, 16);
            lblApellido.TabIndex = 14;
            lblApellido.Text = "Observaciones:";
            // 
            // txtAño
            // 
            txtAño.Location = new Point(549, 61);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(100, 22);
            txtAño.TabIndex = 9;
            // 
            // txt
            // 
            txt.Location = new Point(839, 24);
            txt.Multiline = true;
            txt.Name = "txt";
            txt.Size = new Size(479, 166);
            txt.TabIndex = 4;
            // 
            // txtProfesorResponsable
            // 
            txtProfesorResponsable.Location = new Point(235, 137);
            txtProfesorResponsable.Name = "txtProfesorResponsable";
            txtProfesorResponsable.Size = new Size(223, 22);
            txtProfesorResponsable.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBuscarNombreDni);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 138);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buscar :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 39);
            label1.Name = "label1";
            label1.Size = new Size(70, 16);
            label1.TabIndex = 21;
            label1.Text = "Nombre :";
            // 
            // txtBuscarNombreDni
            // 
            txtBuscarNombreDni.Location = new Point(144, 33);
            txtBuscarNombreDni.Name = "txtBuscarNombreDni";
            txtBuscarNombreDni.Size = new Size(100, 22);
            txtBuscarNombreDni.TabIndex = 11;
            // 
            // dtgAbmUsuario
            // 
            dtgAbmUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgAbmUsuario.Dock = DockStyle.Fill;
            dtgAbmUsuario.Location = new Point(0, 284);
            dtgAbmUsuario.Name = "dtgAbmUsuario";
            dtgAbmUsuario.ReadOnly = true;
            dtgAbmUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAbmUsuario.Size = new Size(1884, 577);
            dtgAbmUsuario.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(141, 181, 146);
            panel2.Controls.Add(btnDarDeBajaUsuario);
            panel2.Controls.Add(btnModificarUsuario);
            panel2.Controls.Add(btnAgregarUsuario);
            panel2.Controls.Add(btnDarDeAltaUsuario);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 774);
            panel2.Name = "panel2";
            panel2.Size = new Size(1884, 87);
            panel2.TabIndex = 5;
            // 
            // btnDarDeBajaUsuario
            // 
            btnDarDeBajaUsuario.BackColor = Color.White;
            btnDarDeBajaUsuario.FlatAppearance.BorderSize = 0;
            btnDarDeBajaUsuario.FlatStyle = FlatStyle.Flat;
            btnDarDeBajaUsuario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDarDeBajaUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnDarDeBajaUsuario.Image = (Image)resources.GetObject("btnDarDeBajaUsuario.Image");
            btnDarDeBajaUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnDarDeBajaUsuario.Location = new Point(1127, 35);
            btnDarDeBajaUsuario.Name = "btnDarDeBajaUsuario";
            btnDarDeBajaUsuario.Size = new Size(150, 40);
            btnDarDeBajaUsuario.TabIndex = 7;
            btnDarDeBajaUsuario.Text = "Baja";
            btnDarDeBajaUsuario.UseVisualStyleBackColor = false;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.BackColor = Color.White;
            btnModificarUsuario.FlatAppearance.BorderSize = 0;
            btnModificarUsuario.FlatStyle = FlatStyle.Flat;
            btnModificarUsuario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarUsuario.Image = (Image)resources.GetObject("btnModificarUsuario.Image");
            btnModificarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarUsuario.Location = new Point(736, 35);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(150, 40);
            btnModificarUsuario.TabIndex = 6;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.BackColor = Color.White;
            btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarUsuario.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnAgregarUsuario.Image = (Image)resources.GetObject("btnAgregarUsuario.Image");
            btnAgregarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarUsuario.Location = new Point(329, 35);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(150, 40);
            btnAgregarUsuario.TabIndex = 5;
            btnAgregarUsuario.Text = "Nuevo";
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnDarDeAltaUsuario
            // 
            btnDarDeAltaUsuario.BackColor = Color.White;
            btnDarDeAltaUsuario.FlatAppearance.BorderSize = 0;
            btnDarDeAltaUsuario.FlatStyle = FlatStyle.Flat;
            btnDarDeAltaUsuario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDarDeAltaUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnDarDeAltaUsuario.Image = (Image)resources.GetObject("btnDarDeAltaUsuario.Image");
            btnDarDeAltaUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnDarDeAltaUsuario.Location = new Point(1515, 35);
            btnDarDeAltaUsuario.Name = "btnDarDeAltaUsuario";
            btnDarDeAltaUsuario.Size = new Size(150, 40);
            btnDarDeAltaUsuario.TabIndex = 0;
            btnDarDeAltaUsuario.Text = "Alta";
            btnDarDeAltaUsuario.UseVisualStyleBackColor = false;
            // 
            // RegistroActividad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1884, 861);
            Controls.Add(panel2);
            Controls.Add(dtgAbmUsuario);
            Controls.Add(PanelDatos);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1884, 861);
            MinimumSize = new Size(1884, 861);
            Name = "RegistroActividad";
            Text = "RegistroActividad";
            PanelDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbExitEntornoFormativo).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAbmUsuario).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelDatos;
        private PictureBox pbExitEntornoFormativo;
        private GroupBox groupBox2;
        private TextBox txtGrupo;
        private Tienda.RJButton btnLimpiar;
        private Label lblID;
        private TextBox txtID;
        private ComboBox cmbTipoEntorno;
        private Label lblEntorno;
        private Label label5;
        private Label label7;
        private Label label3;
        private Label lblTipoEntorno;
        private Label label2;
        private TextBox txtDivision;
        private Label lblApellido;
        private TextBox txtAño;
        private TextBox txt;
        private TextBox txtProfesorResponsable;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtBuscarNombreDni;
        private DataGridView dtgAbmUsuario;
        private ComboBox comboBox1;
        private Panel panel2;
        private Tienda.RJButton btnDarDeBajaUsuario;
        private Tienda.RJButton btnModificarUsuario;
        private Tienda.RJButton btnAgregarUsuario;
        private Tienda.RJButton btnDarDeAltaUsuario;
    }
}