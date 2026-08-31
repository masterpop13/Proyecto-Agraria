namespace Agraria.Formularios
{
    partial class AbmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmUsuario));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            PanelDatos = new Panel();
            groupBox4 = new GroupBox();
            btnDarDeAltaUsuario = new Tienda.RJButton();
            btnDarDeBajaUsuario = new Tienda.RJButton();
            groupBox3 = new GroupBox();
            btnAgregarUsuario = new Tienda.RJButton();
            btnModificarUsuario = new Tienda.RJButton();
            pbExitAbmUsuario = new PictureBox();
            groupBox2 = new GroupBox();
            chkPañol = new CheckBox();
            chkVenta = new CheckBox();
            chkInventario = new CheckBox();
            chkIndustria = new CheckBox();
            chkProduccionAnimal = new CheckBox();
            chkProduccionVegetal = new CheckBox();
            label14 = new Label();
            cmbPreguntaSeguridad = new ComboBox();
            txtRespuestaSeguridad = new TextBox();
            label13 = new Label();
            txtID = new TextBox();
            lblID = new Label();
            chkAdministracion = new CheckBox();
            chkEntornoFormativo = new CheckBox();
            chkAltaUsuario = new CheckBox();
            btnLimpiar = new Tienda.RJButton();
            txtEmail = new TextBox();
            label12 = new Label();
            cmbLocalidad = new ComboBox();
            cmbPartido = new ComboBox();
            label8 = new Label();
            txtNombre = new TextBox();
            label5 = new Label();
            txtContraseña = new TextBox();
            label7 = new Label();
            label10 = new Label();
            label4 = new Label();
            txtNombreUsuario = new TextBox();
            label11 = new Label();
            label3 = new Label();
            label6 = new Label();
            label2 = new Label();
            txtTelefono = new TextBox();
            lblApellido = new Label();
            txtCodigoPostal = new TextBox();
            txtDireccion = new TextBox();
            txtApellido = new TextBox();
            txtDocumento = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtBuscarApellido = new TextBox();
            dtgAbmUsuario = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            PanelDatos.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbExitAbmUsuario).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAbmUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PanelDatos
            // 
            PanelDatos.BackColor = Color.FromArgb(141, 181, 146);
            PanelDatos.Controls.Add(groupBox4);
            PanelDatos.Controls.Add(groupBox3);
            PanelDatos.Controls.Add(pbExitAbmUsuario);
            PanelDatos.Controls.Add(groupBox2);
            PanelDatos.Controls.Add(groupBox1);
            PanelDatos.Dock = DockStyle.Top;
            PanelDatos.Location = new Point(0, 0);
            PanelDatos.Name = "PanelDatos";
            PanelDatos.Size = new Size(1386, 408);
            PanelDatos.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(btnDarDeAltaUsuario);
            groupBox4.Controls.Add(btnDarDeBajaUsuario);
            groupBox4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(1093, 323);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(779, 75);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Text = "Dar de Alta o Baja a Usuarios Existentes";
            // 
            // btnDarDeAltaUsuario
            // 
            btnDarDeAltaUsuario.BackColor = Color.White;
            btnDarDeAltaUsuario.FlatAppearance.BorderSize = 0;
            btnDarDeAltaUsuario.FlatStyle = FlatStyle.Flat;
            btnDarDeAltaUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnDarDeAltaUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnDarDeAltaUsuario.Image = (Image)resources.GetObject("btnDarDeAltaUsuario.Image");
            btnDarDeAltaUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnDarDeAltaUsuario.Location = new Point(79, 25);
            btnDarDeAltaUsuario.Name = "btnDarDeAltaUsuario";
            btnDarDeAltaUsuario.Size = new Size(150, 40);
            btnDarDeAltaUsuario.TabIndex = 0;
            btnDarDeAltaUsuario.Text = "Alta";
            btnDarDeAltaUsuario.UseVisualStyleBackColor = false;
            btnDarDeAltaUsuario.Click += btnAltaUsuario_Click;
            // 
            // btnDarDeBajaUsuario
            // 
            btnDarDeBajaUsuario.BackColor = Color.White;
            btnDarDeBajaUsuario.FlatAppearance.BorderSize = 0;
            btnDarDeBajaUsuario.FlatStyle = FlatStyle.Flat;
            btnDarDeBajaUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnDarDeBajaUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnDarDeBajaUsuario.Image = (Image)resources.GetObject("btnDarDeBajaUsuario.Image");
            btnDarDeBajaUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnDarDeBajaUsuario.Location = new Point(597, 25);
            btnDarDeBajaUsuario.Name = "btnDarDeBajaUsuario";
            btnDarDeBajaUsuario.Size = new Size(150, 40);
            btnDarDeBajaUsuario.TabIndex = 7;
            btnDarDeBajaUsuario.Text = "Baja";
            btnDarDeBajaUsuario.UseVisualStyleBackColor = false;
            btnDarDeBajaUsuario.Click += btnBajaUsuario_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(btnAgregarUsuario);
            groupBox3.Controls.Add(btnModificarUsuario);
            groupBox3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(297, 323);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(790, 75);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            groupBox3.Text = "Agregar o Modificar Usuario";
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.BackColor = Color.White;
            btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarUsuario.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnAgregarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnAgregarUsuario.Image = (Image)resources.GetObject("btnAgregarUsuario.Image");
            btnAgregarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarUsuario.Location = new Point(116, 28);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(150, 40);
            btnAgregarUsuario.TabIndex = 5;
            btnAgregarUsuario.Text = "Nuevo";
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            btnAgregarUsuario.Click += btnNuevoUsuario_Click;
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
            btnModificarUsuario.Location = new Point(590, 28);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(150, 40);
            btnModificarUsuario.TabIndex = 6;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.UseVisualStyleBackColor = false;
            btnModificarUsuario.Click += btnModificarUsuario_Click;
            // 
            // pbExitAbmUsuario
            // 
            pbExitAbmUsuario.Image = Properties.Resources.x;
            pbExitAbmUsuario.Location = new Point(1852, 3);
            pbExitAbmUsuario.Name = "pbExitAbmUsuario";
            pbExitAbmUsuario.Size = new Size(29, 28);
            pbExitAbmUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            pbExitAbmUsuario.TabIndex = 23;
            pbExitAbmUsuario.TabStop = false;
            pbExitAbmUsuario.Click += pbExitAbmUsuarios_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(141, 181, 146);
            groupBox2.Controls.Add(chkPañol);
            groupBox2.Controls.Add(chkVenta);
            groupBox2.Controls.Add(chkInventario);
            groupBox2.Controls.Add(chkIndustria);
            groupBox2.Controls.Add(chkProduccionAnimal);
            groupBox2.Controls.Add(chkProduccionVegetal);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(cmbPreguntaSeguridad);
            groupBox2.Controls.Add(txtRespuestaSeguridad);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(txtID);
            groupBox2.Controls.Add(lblID);
            groupBox2.Controls.Add(chkAdministracion);
            groupBox2.Controls.Add(chkEntornoFormativo);
            groupBox2.Controls.Add(chkAltaUsuario);
            groupBox2.Controls.Add(btnLimpiar);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(cmbLocalidad);
            groupBox2.Controls.Add(cmbPartido);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtContraseña);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtNombreUsuario);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtTelefono);
            groupBox2.Controls.Add(lblApellido);
            groupBox2.Controls.Add(txtCodigoPostal);
            groupBox2.Controls.Add(txtDireccion);
            groupBox2.Controls.Add(txtApellido);
            groupBox2.Controls.Add(txtDocumento);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(291, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1581, 291);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos Personales :";
            // 
            // chkPañol
            // 
            chkPañol.AutoSize = true;
            chkPañol.Location = new Point(1346, 244);
            chkPañol.Name = "chkPañol";
            chkPañol.Size = new Size(82, 28);
            chkPañol.TabIndex = 44;
            chkPañol.Text = "Pañol";
            chkPañol.UseVisualStyleBackColor = true;
            // 
            // chkVenta
            // 
            chkVenta.AutoSize = true;
            chkVenta.Location = new Point(1346, 20);
            chkVenta.Name = "chkVenta";
            chkVenta.Size = new Size(83, 28);
            chkVenta.TabIndex = 43;
            chkVenta.Text = "Venta";
            chkVenta.UseVisualStyleBackColor = true;
            // 
            // chkInventario
            // 
            chkInventario.AutoSize = true;
            chkInventario.Location = new Point(1346, 76);
            chkInventario.Name = "chkInventario";
            chkInventario.Size = new Size(120, 28);
            chkInventario.TabIndex = 42;
            chkInventario.Text = "Inventario";
            chkInventario.UseVisualStyleBackColor = true;
            // 
            // chkIndustria
            // 
            chkIndustria.AutoSize = true;
            chkIndustria.Location = new Point(1346, 48);
            chkIndustria.Name = "chkIndustria";
            chkIndustria.Size = new Size(108, 28);
            chkIndustria.TabIndex = 41;
            chkIndustria.Text = "Industria";
            chkIndustria.UseVisualStyleBackColor = true;
            // 
            // chkProduccionAnimal
            // 
            chkProduccionAnimal.AutoSize = true;
            chkProduccionAnimal.Location = new Point(1346, 104);
            chkProduccionAnimal.Name = "chkProduccionAnimal";
            chkProduccionAnimal.Size = new Size(200, 28);
            chkProduccionAnimal.TabIndex = 40;
            chkProduccionAnimal.Text = "ProduccionAnimal";
            chkProduccionAnimal.UseVisualStyleBackColor = true;
            // 
            // chkProduccionVegetal
            // 
            chkProduccionVegetal.AutoSize = true;
            chkProduccionVegetal.Location = new Point(1346, 132);
            chkProduccionVegetal.Name = "chkProduccionVegetal";
            chkProduccionVegetal.Size = new Size(207, 28);
            chkProduccionVegetal.TabIndex = 39;
            chkProduccionVegetal.Text = "ProduccionVegetal";
            chkProduccionVegetal.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(583, 239);
            label14.Name = "label14";
            label14.Size = new Size(243, 24);
            label14.TabIndex = 32;
            label14.Text = "Respuesta de seguridad:";
            // 
            // cmbPreguntaSeguridad
            // 
            cmbPreguntaSeguridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPreguntaSeguridad.FormattingEnabled = true;
            cmbPreguntaSeguridad.Location = new Point(244, 234);
            cmbPreguntaSeguridad.Name = "cmbPreguntaSeguridad";
            cmbPreguntaSeguridad.Size = new Size(326, 32);
            cmbPreguntaSeguridad.TabIndex = 29;
            // 
            // txtRespuestaSeguridad
            // 
            txtRespuestaSeguridad.Location = new Point(832, 234);
            txtRespuestaSeguridad.Name = "txtRespuestaSeguridad";
            txtRespuestaSeguridad.Size = new Size(326, 29);
            txtRespuestaSeguridad.TabIndex = 31;
            txtRespuestaSeguridad.KeyDown += CopiaryPegar_KeyDown;
            txtRespuestaSeguridad.KeyPress += TextoyNumero_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(6, 240);
            label13.Name = "label13";
            label13.Size = new Size(232, 24);
            label13.TabIndex = 30;
            label13.Text = "Pregunta de Seguridad:";
            // 
            // txtID
            // 
            txtID.Location = new Point(1157, 39);
            txtID.Name = "txtID";
            txtID.Size = new Size(162, 29);
            txtID.TabIndex = 33;
            txtID.Visible = false;
            txtID.KeyDown += CopiaryPegar_KeyDown;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(1109, 41);
            lblID.Name = "lblID";
            lblID.Size = new Size(35, 24);
            lblID.TabIndex = 34;
            lblID.Text = "ID:";
            lblID.Visible = false;
            // 
            // chkAdministracion
            // 
            chkAdministracion.AutoSize = true;
            chkAdministracion.Location = new Point(1346, 160);
            chkAdministracion.Name = "chkAdministracion";
            chkAdministracion.Size = new Size(167, 28);
            chkAdministracion.TabIndex = 38;
            chkAdministracion.Text = "Administracion";
            chkAdministracion.UseVisualStyleBackColor = true;
            // 
            // chkEntornoFormativo
            // 
            chkEntornoFormativo.AutoSize = true;
            chkEntornoFormativo.Location = new Point(1346, 216);
            chkEntornoFormativo.Name = "chkEntornoFormativo";
            chkEntornoFormativo.Size = new Size(221, 28);
            chkEntornoFormativo.TabIndex = 37;
            chkEntornoFormativo.Text = "Entornos Formativos";
            chkEntornoFormativo.UseVisualStyleBackColor = true;
            // 
            // chkAltaUsuario
            // 
            chkAltaUsuario.AutoSize = true;
            chkAltaUsuario.Location = new Point(1346, 188);
            chkAltaUsuario.Name = "chkAltaUsuario";
            chkAltaUsuario.Size = new Size(141, 28);
            chkAltaUsuario.TabIndex = 36;
            chkAltaUsuario.Text = "Alta Usuario";
            chkAltaUsuario.UseVisualStyleBackColor = true;
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
            btnLimpiar.Location = new Point(1180, 232);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(139, 41);
            btnLimpiar.TabIndex = 35;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(519, 169);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(162, 29);
            txtEmail.TabIndex = 0;
            txtEmail.KeyDown += CopiaryPegar_KeyDown;
            txtEmail.KeyPress += TextoyNumero_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(432, 167);
            label12.Name = "label12";
            label12.Size = new Size(68, 24);
            label12.TabIndex = 24;
            label12.Text = "Email:";
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(144, 165);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(162, 32);
            cmbLocalidad.TabIndex = 23;
            // 
            // cmbPartido
            // 
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(144, 122);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(162, 32);
            cmbPartido.TabIndex = 22;
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(34, 44);
            label8.Name = "label8";
            label8.Size = new Size(97, 24);
            label8.TabIndex = 21;
            label8.Text = "Nombre :";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(144, 39);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(162, 29);
            txtNombre.TabIndex = 15;
            txtNombre.KeyDown += CopiaryPegar_KeyDown;
            txtNombre.KeyPress += Solotexto_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(823, 44);
            label5.Name = "label5";
            label5.Size = new Size(99, 24);
            label5.TabIndex = 18;
            label5.Text = "Telefono:";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(932, 120);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(162, 29);
            txtContraseña.TabIndex = 10;
            txtContraseña.KeyDown += CopiaryPegar_KeyDown;
            txtContraseña.KeyPress += TextoyNumero_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(383, 47);
            label7.Name = "label7";
            label7.Size = new Size(123, 24);
            label7.TabIndex = 20;
            label7.Text = "Documento:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(795, 121);
            label10.Name = "label10";
            label10.Size = new Size(122, 24);
            label10.TabIndex = 26;
            label10.Text = "Contraseña:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(355, 125);
            label4.Name = "label4";
            label4.Size = new Size(145, 24);
            label4.TabIndex = 17;
            label4.Text = "Código Postal:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(932, 81);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(162, 29);
            txtNombreUsuario.TabIndex = 2;
            txtNombreUsuario.KeyDown += CopiaryPegar_KeyDown;
            txtNombreUsuario.KeyPress += Solotexto_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(721, 81);
            label11.Name = "label11";
            label11.Size = new Size(196, 24);
            label11.TabIndex = 25;
            label11.Text = "Nombre de usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(401, 89);
            label3.Name = "label3";
            label3.Size = new Size(105, 24);
            label3.TabIndex = 16;
            label3.Text = "Dirección:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(38, 86);
            label6.Name = "label6";
            label6.Size = new Size(93, 24);
            label6.TabIndex = 19;
            label6.Text = "Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(44, 121);
            label2.Name = "label2";
            label2.Size = new Size(81, 24);
            label2.TabIndex = 15;
            label2.Text = "Partido:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(932, 41);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(162, 29);
            txtTelefono.TabIndex = 6;
            txtTelefono.KeyDown += CopiaryPegar_KeyDown;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(19, 163);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(106, 24);
            lblApellido.TabIndex = 14;
            lblApellido.Text = "Localidad:";
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(519, 125);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(162, 29);
            txtCodigoPostal.TabIndex = 7;
            txtCodigoPostal.KeyDown += CopiaryPegar_KeyDown;
            txtCodigoPostal.KeyPress += SoloNumeros_KeyPress;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(519, 84);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(162, 29);
            txtDireccion.TabIndex = 9;
            txtDireccion.KeyDown += CopiaryPegar_KeyDown;
            txtDireccion.KeyPress += TextoyNumero_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(144, 81);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(162, 29);
            txtApellido.TabIndex = 4;
            txtApellido.KeyDown += CopiaryPegar_KeyDown;
            txtApellido.KeyPress += Solotexto_KeyPress;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(519, 42);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(162, 29);
            txtDocumento.TabIndex = 5;
            txtDocumento.KeyDown += CopiaryPegar_KeyDown;
            txtDocumento.KeyPress += SoloNumeros_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(141, 181, 146);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBuscarApellido);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 372);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buscar :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 39);
            label1.Name = "label1";
            label1.Size = new Size(93, 24);
            label1.TabIndex = 21;
            label1.Text = "Apellido:";
            // 
            // txtBuscarApellido
            // 
            txtBuscarApellido.Location = new Point(124, 39);
            txtBuscarApellido.Name = "txtBuscarApellido";
            txtBuscarApellido.Size = new Size(100, 29);
            txtBuscarApellido.TabIndex = 11;
            txtBuscarApellido.TextChanged += txtBuscarNombreDni_TextChanged;
            txtBuscarApellido.KeyDown += CopiaryPegar_KeyDown;
            txtBuscarApellido.KeyPress += Solotexto_KeyPress;
            // 
            // dtgAbmUsuario
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgAbmUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgAbmUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgAbmUsuario.DefaultCellStyle = dataGridViewCellStyle2;
            dtgAbmUsuario.Dock = DockStyle.Fill;
            dtgAbmUsuario.Location = new Point(0, 408);
            dtgAbmUsuario.Name = "dtgAbmUsuario";
            dtgAbmUsuario.ReadOnly = true;
            dtgAbmUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAbmUsuario.Size = new Size(1386, 380);
            dtgAbmUsuario.TabIndex = 1;
            dtgAbmUsuario.CellClick += dtgAbmUsuario_CellContentClick;
            dtgAbmUsuario.CellContentClick += dtgAbmUsuario_CellContentClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AbmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 788);
            Controls.Add(dtgAbmUsuario);
            Controls.Add(PanelDatos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AbmUsuario";
            Text = "AbmUsuario";
            Load += AbmUsuario_Load;
            PanelDatos.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbExitAbmUsuario).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAbmUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelDatos;
        private DataGridView dtgAbmUsuario;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label lblApellido;
        private TextBox txtBuscarApellido;
        private TextBox txtContraseña;
        private TextBox txtDireccion;
        private TextBox txtCodigoPostal;
        private TextBox txtTelefono;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombreUsuario;
        private TextBox txtEmail;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label8;
        private TextBox txtNombre;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private ComboBox cmbLocalidad;
        private ComboBox cmbPartido;
        private Label label13;
        private ComboBox cmbPreguntaSeguridad;
        private TextBox txtRespuestaSeguridad;
        private Label label14;
        private Tienda.RJButton btnDarDeAltaUsuario;
        private Tienda.RJButton btnDarDeBajaUsuario;
        private Tienda.RJButton btnModificarUsuario;
        private Tienda.RJButton btnAgregarUsuario;
        private Label lblID;
        private TextBox txtID;
        private PictureBox pbExitAbmUsuario;
        private Tienda.RJButton btnLimpiar;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private ErrorProvider errorProvider1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox chkEntornoFormativo;
        private CheckBox chkAltaUsuario;
        private CheckBox chkVenta;
        private CheckBox chkInventario;
        private CheckBox chkIndustria;
        private CheckBox chkProduccionAnimal;
        private CheckBox chkProduccionVegetal;
        private CheckBox chkAdministracion;
        private CheckBox chkPañol;
    }
}