namespace Agraria.Formularios
{
    partial class CambiarContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContraseña));
            txtRespuestaSeguridad = new TextBox();
            label14 = new Label();
            label13 = new Label();
            cmbPreguntaSeguridad = new ComboBox();
            label9 = new Label();
            txtNombreUsuario = new TextBox();
            label11 = new Label();
            label1 = new Label();
            btnGuardar = new Tienda.RJButton();
            txtConfirmarNuevaContraseña = new TextBox();
            txtNuevaContraseña = new TextBox();
            pictureBox1 = new PictureBox();
            pbCerrar = new PictureBox();
            btnConfirmar = new Tienda.RJButton();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtRespuestaSeguridad
            // 
            txtRespuestaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtRespuestaSeguridad.Location = new Point(528, 115);
            txtRespuestaSeguridad.MaxLength = 15;
            txtRespuestaSeguridad.Name = "txtRespuestaSeguridad";
            txtRespuestaSeguridad.Size = new Size(326, 29);
            txtRespuestaSeguridad.TabIndex = 41;
            txtRespuestaSeguridad.KeyDown += CopiaryPegar_KeyDown;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(279, 114);
            label14.Name = "label14";
            label14.Size = new Size(243, 24);
            label14.TabIndex = 42;
            label14.Text = "Respuesta de seguridad:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(290, 76);
            label13.Name = "label13";
            label13.Size = new Size(232, 24);
            label13.TabIndex = 40;
            label13.Text = "Pregunta de Seguridad:";
            // 
            // cmbPreguntaSeguridad
            // 
            cmbPreguntaSeguridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPreguntaSeguridad.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbPreguntaSeguridad.FormattingEnabled = true;
            cmbPreguntaSeguridad.Location = new Point(528, 76);
            cmbPreguntaSeguridad.Name = "cmbPreguntaSeguridad";
            cmbPreguntaSeguridad.Size = new Size(326, 32);
            cmbPreguntaSeguridad.TabIndex = 39;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(334, 154);
            label9.Name = "label9";
            label9.Size = new Size(188, 24);
            label9.TabIndex = 37;
            label9.Text = "Nueva Contraseña:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNombreUsuario.ForeColor = Color.Black;
            txtNombreUsuario.Location = new Point(528, 37);
            txtNombreUsuario.MaxLength = 15;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(146, 29);
            txtNombreUsuario.TabIndex = 33;
            txtNombreUsuario.KeyDown += CopiaryPegar_KeyDown;
            txtNombreUsuario.KeyPress += SoloTextoNumeroEspacio_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(326, 37);
            label11.Name = "label11";
            label11.Size = new Size(196, 24);
            label11.TabIndex = 35;
            label11.Text = "Nombre de usuario:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(238, 193);
            label1.Name = "label1";
            label1.Size = new Size(284, 24);
            label1.TabIndex = 43;
            label1.Text = "Confirmar Nueva Contraseña:";
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
            btnGuardar.Location = new Point(726, 192);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(166, 40);
            btnGuardar.TabIndex = 45;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Visible = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtConfirmarNuevaContraseña
            // 
            txtConfirmarNuevaContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtConfirmarNuevaContraseña.Location = new Point(528, 193);
            txtConfirmarNuevaContraseña.MaxLength = 15;
            txtConfirmarNuevaContraseña.Name = "txtConfirmarNuevaContraseña";
            txtConfirmarNuevaContraseña.Size = new Size(146, 29);
            txtConfirmarNuevaContraseña.TabIndex = 46;
            txtConfirmarNuevaContraseña.Visible = false;
            txtConfirmarNuevaContraseña.KeyDown += CopiaryPegar_KeyDown;
            // 
            // txtNuevaContraseña
            // 
            txtNuevaContraseña.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtNuevaContraseña.Location = new Point(528, 154);
            txtNuevaContraseña.MaxLength = 15;
            txtNuevaContraseña.Name = "txtNuevaContraseña";
            txtNuevaContraseña.Size = new Size(146, 29);
            txtNuevaContraseña.TabIndex = 47;
            txtNuevaContraseña.Visible = false;
            txtNuevaContraseña.KeyDown += CopiaryPegar_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.agr;
            pictureBox1.Location = new Point(12, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 166);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 48;
            pictureBox1.TabStop = false;
            // 
            // pbCerrar
            // 
            pbCerrar.BackgroundImage = Properties.Resources.x;
            pbCerrar.BackgroundImageLayout = ImageLayout.Stretch;
            pbCerrar.Location = new Point(855, 7);
            pbCerrar.Margin = new Padding(2);
            pbCerrar.Name = "pbCerrar";
            pbCerrar.Size = new Size(32, 26);
            pbCerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCerrar.TabIndex = 49;
            pbCerrar.TabStop = false;
            pbCerrar.Click += pbCerrar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.White;
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.FromArgb(56, 124, 31);
            btnConfirmar.Image = (Image)resources.GetObject("btnConfirmar.Image");
            btnConfirmar.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfirmar.Location = new Point(726, 146);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(166, 40);
            btnConfirmar.TabIndex = 50;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CambiarContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 124, 31);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(904, 246);
            Controls.Add(btnConfirmar);
            Controls.Add(pbCerrar);
            Controls.Add(pictureBox1);
            Controls.Add(txtNuevaContraseña);
            Controls.Add(txtConfirmarNuevaContraseña);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Controls.Add(txtRespuestaSeguridad);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(cmbPreguntaSeguridad);
            Controls.Add(label9);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label11);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CambiarContraseña";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CambiarContraseña";
            Load += CambiarContraseña_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRespuestaSeguridad;
        private Label label14;
        private Label label13;
        private ComboBox cmbPreguntaSeguridad;
        private Label label9;
        private TextBox txtNombreUsuario;
        private Label label11;
        private Label label1;
        private Tienda.RJButton btnGuardar;
        private TextBox txtConfirmarNuevaContraseña;
        private TextBox txtNuevaContraseña;
        private PictureBox pictureBox1;
        private PictureBox pbCerrar;
        private Tienda.RJButton btnConfirmar;
        private ErrorProvider errorProvider1;
    }
}