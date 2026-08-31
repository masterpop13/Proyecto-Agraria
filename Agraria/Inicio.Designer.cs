namespace Agraria
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            pbCerrarPrograma = new Panel();
            lblUrgencia = new Label();
            pbCerrarAgraria = new PictureBox();
            pictureBox1 = new PictureBox();
            pbAlerta = new PictureBox();
            lblTitle = new Label();
            pbUrgencias = new PictureBox();
            lblUsuario = new Label();
            btnClose = new Button();
            bntMinimize = new Button();
            panelMenu = new Panel();
            btnCerrarSesion = new Button();
            btnPañol = new Button();
            btnVenta = new Button();
            btnInventario = new Button();
            btnIndustria = new Button();
            btnProduccionAnimal = new Button();
            btnProduccionVegetal = new Button();
            btnAdministracion = new Button();
            btnIniciar = new Button();
            btnEntornoFormativo = new Button();
            btnUsuarioAlta = new Button();
            pbCerrarPrograma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCerrarAgraria).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAlerta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUrgencias).BeginInit();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pbCerrarPrograma
            // 
            pbCerrarPrograma.BackColor = Color.FromArgb(56, 124, 31);
            pbCerrarPrograma.BackgroundImage = (Image)resources.GetObject("pbCerrarPrograma.BackgroundImage");
            pbCerrarPrograma.Controls.Add(lblUrgencia);
            pbCerrarPrograma.Controls.Add(pbCerrarAgraria);
            pbCerrarPrograma.Controls.Add(pictureBox1);
            pbCerrarPrograma.Controls.Add(pbAlerta);
            pbCerrarPrograma.Controls.Add(lblTitle);
            pbCerrarPrograma.Controls.Add(pbUrgencias);
            pbCerrarPrograma.Controls.Add(lblUsuario);
            pbCerrarPrograma.Controls.Add(btnClose);
            pbCerrarPrograma.Controls.Add(bntMinimize);
            pbCerrarPrograma.Dock = DockStyle.Top;
            pbCerrarPrograma.ForeColor = Color.FromArgb(56, 124, 31);
            pbCerrarPrograma.Location = new Point(0, 0);
            pbCerrarPrograma.Margin = new Padding(4, 5, 4, 5);
            pbCerrarPrograma.Name = "pbCerrarPrograma";
            pbCerrarPrograma.Size = new Size(2564, 95);
            pbCerrarPrograma.TabIndex = 2;
            pbCerrarPrograma.MouseDown += panelSuperior_MouseDown;
            // 
            // lblUrgencia
            // 
            lblUrgencia.Anchor = AnchorStyles.Left;
            lblUrgencia.AutoSize = true;
            lblUrgencia.BackColor = Color.Transparent;
            lblUrgencia.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUrgencia.ForeColor = Color.Red;
            lblUrgencia.Location = new Point(2031, 23);
            lblUrgencia.Margin = new Padding(4, 0, 4, 0);
            lblUrgencia.Name = "lblUrgencia";
            lblUrgencia.Size = new Size(376, 40);
            lblUrgencia.TabIndex = 17;
            lblUrgencia.Text = "Mensaje de Urgencia";
            lblUrgencia.Visible = false;
            // 
            // pbCerrarAgraria
            // 
            pbCerrarAgraria.BackColor = Color.Transparent;
            pbCerrarAgraria.Image = Properties.Resources.x;
            pbCerrarAgraria.Location = new Point(2681, 5);
            pbCerrarAgraria.Margin = new Padding(4, 5, 4, 5);
            pbCerrarAgraria.Name = "pbCerrarAgraria";
            pbCerrarAgraria.Size = new Size(43, 42);
            pbCerrarAgraria.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCerrarAgraria.TabIndex = 16;
            pbCerrarAgraria.TabStop = false;
            pbCerrarAgraria.Click += pbCerrarAgraria_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 12);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(94, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pbAlerta
            // 
            pbAlerta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pbAlerta.BackColor = Color.Transparent;
            pbAlerta.Cursor = Cursors.Hand;
            pbAlerta.Location = new Point(2824, 5);
            pbAlerta.Margin = new Padding(4, 5, 4, 5);
            pbAlerta.Name = "pbAlerta";
            pbAlerta.Size = new Size(103, 12);
            pbAlerta.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAlerta.TabIndex = 14;
            pbAlerta.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(1075, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(563, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Escuela Secundaria Agraria N°1";
            // 
            // pbUrgencias
            // 
            pbUrgencias.BackColor = Color.Transparent;
            pbUrgencias.Cursor = Cursors.Hand;
            pbUrgencias.Image = Properties.Resources.alerta;
            pbUrgencias.Location = new Point(1949, 12);
            pbUrgencias.Margin = new Padding(4, 5, 4, 5);
            pbUrgencias.Name = "pbUrgencias";
            pbUrgencias.Size = new Size(74, 73);
            pbUrgencias.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUrgencias.TabIndex = 13;
            pbUrgencias.TabStop = false;
            pbUrgencias.Visible = false;
            pbUrgencias.Click += pbUrgencias_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.Left;
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.Black;
            lblUsuario.Location = new Point(244, 23);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(148, 40);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "Usuario";
            lblUsuario.Visible = false;
            lblUsuario.Click += lblUsuario_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(4444, 5);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 38);
            btnClose.TabIndex = 4;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // bntMinimize
            // 
            bntMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bntMinimize.BackColor = Color.Transparent;
            bntMinimize.BackgroundImageLayout = ImageLayout.Stretch;
            bntMinimize.FlatAppearance.BorderSize = 0;
            bntMinimize.FlatStyle = FlatStyle.Flat;
            bntMinimize.Location = new Point(4401, 5);
            bntMinimize.Margin = new Padding(4, 5, 4, 5);
            bntMinimize.Name = "bntMinimize";
            bntMinimize.Size = new Size(34, 38);
            bntMinimize.TabIndex = 2;
            bntMinimize.UseVisualStyleBackColor = false;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(56, 124, 31);
            panelMenu.Controls.Add(btnCerrarSesion);
            panelMenu.Controls.Add(btnPañol);
            panelMenu.Controls.Add(btnVenta);
            panelMenu.Controls.Add(btnInventario);
            panelMenu.Controls.Add(btnIndustria);
            panelMenu.Controls.Add(btnProduccionAnimal);
            panelMenu.Controls.Add(btnProduccionVegetal);
            panelMenu.Controls.Add(btnAdministracion);
            panelMenu.Controls.Add(btnIniciar);
            panelMenu.Controls.Add(btnEntornoFormativo);
            panelMenu.Controls.Add(btnUsuarioAlta);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.ForeColor = Color.FromArgb(56, 124, 31);
            panelMenu.Location = new Point(0, 95);
            panelMenu.Margin = new Padding(4, 5, 4, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(328, 1475);
            panelMenu.TabIndex = 7;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(137, 195, 32);
            btnCerrarSesion.BackgroundImage = (Image)resources.GetObject("btnCerrarSesion.BackgroundImage");
            btnCerrarSesion.Dock = DockStyle.Top;
            btnCerrarSesion.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnCerrarSesion.FlatAppearance.BorderSize = 4;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.Black;
            btnCerrarSesion.Image = Properties.Resources.cerrar;
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Location = new Point(0, 800);
            btnCerrarSesion.Margin = new Padding(4, 5, 4, 5);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(17, 0, 0, 0);
            btnCerrarSesion.Size = new Size(328, 100);
            btnCerrarSesion.TabIndex = 31;
            btnCerrarSesion.Tag = "Cerrar Sesión";
            btnCerrarSesion.Text = "Cerrar";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += pbCerrarAgraria_Click;
            // 
            // btnPañol
            // 
            btnPañol.BackColor = Color.FromArgb(137, 195, 32);
            btnPañol.BackgroundImage = (Image)resources.GetObject("btnPañol.BackgroundImage");
            btnPañol.Dock = DockStyle.Top;
            btnPañol.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnPañol.FlatAppearance.BorderSize = 4;
            btnPañol.FlatStyle = FlatStyle.Flat;
            btnPañol.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnPañol.ForeColor = Color.Black;
            btnPañol.Image = (Image)resources.GetObject("btnPañol.Image");
            btnPañol.ImageAlign = ContentAlignment.MiddleLeft;
            btnPañol.Location = new Point(0, 700);
            btnPañol.Margin = new Padding(4, 5, 4, 5);
            btnPañol.Name = "btnPañol";
            btnPañol.Padding = new Padding(17, 0, 0, 0);
            btnPañol.Size = new Size(328, 100);
            btnPañol.TabIndex = 30;
            btnPañol.Tag = "Editar ";
            btnPañol.Text = "Pañol";
            btnPañol.UseVisualStyleBackColor = false;
            btnPañol.Click += btnPañol_Click;
            // 
            // btnVenta
            // 
            btnVenta.BackColor = Color.FromArgb(137, 195, 32);
            btnVenta.BackgroundImage = (Image)resources.GetObject("btnVenta.BackgroundImage");
            btnVenta.Dock = DockStyle.Top;
            btnVenta.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnVenta.FlatAppearance.BorderSize = 4;
            btnVenta.FlatStyle = FlatStyle.Flat;
            btnVenta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnVenta.ForeColor = Color.Black;
            btnVenta.Image = Properties.Resources.metodo_de_pago1;
            btnVenta.ImageAlign = ContentAlignment.MiddleLeft;
            btnVenta.Location = new Point(0, 600);
            btnVenta.Margin = new Padding(4, 5, 4, 5);
            btnVenta.Name = "btnVenta";
            btnVenta.Padding = new Padding(17, 0, 0, 0);
            btnVenta.Size = new Size(328, 100);
            btnVenta.TabIndex = 29;
            btnVenta.Tag = "Editar ";
            btnVenta.Text = "Venta";
            btnVenta.UseVisualStyleBackColor = false;
            btnVenta.Click += btnVenta_Click;
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.FromArgb(137, 195, 32);
            btnInventario.BackgroundImage = (Image)resources.GetObject("btnInventario.BackgroundImage");
            btnInventario.Dock = DockStyle.Top;
            btnInventario.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnInventario.FlatAppearance.BorderSize = 4;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnInventario.ForeColor = Color.Black;
            btnInventario.Image = Properties.Resources.inventario;
            btnInventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventario.Location = new Point(0, 500);
            btnInventario.Margin = new Padding(4, 5, 4, 5);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(17, 0, 0, 0);
            btnInventario.Size = new Size(328, 100);
            btnInventario.TabIndex = 28;
            btnInventario.Tag = "Bomberos";
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnIndustria
            // 
            btnIndustria.BackColor = Color.FromArgb(137, 195, 32);
            btnIndustria.BackgroundImage = (Image)resources.GetObject("btnIndustria.BackgroundImage");
            btnIndustria.Dock = DockStyle.Top;
            btnIndustria.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnIndustria.FlatAppearance.BorderSize = 4;
            btnIndustria.FlatStyle = FlatStyle.Flat;
            btnIndustria.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnIndustria.ForeColor = Color.Black;
            btnIndustria.Image = Properties.Resources.fabrica;
            btnIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnIndustria.Location = new Point(0, 400);
            btnIndustria.Margin = new Padding(4, 5, 4, 5);
            btnIndustria.Name = "btnIndustria";
            btnIndustria.Padding = new Padding(17, 0, 0, 0);
            btnIndustria.Size = new Size(328, 100);
            btnIndustria.TabIndex = 27;
            btnIndustria.Tag = "Emergencia";
            btnIndustria.Text = "Industria";
            btnIndustria.UseMnemonic = false;
            btnIndustria.UseVisualStyleBackColor = false;
            btnIndustria.Click += btnIndustria_Click;
            // 
            // btnProduccionAnimal
            // 
            btnProduccionAnimal.BackColor = Color.FromArgb(137, 195, 32);
            btnProduccionAnimal.BackgroundImage = (Image)resources.GetObject("btnProduccionAnimal.BackgroundImage");
            btnProduccionAnimal.Dock = DockStyle.Top;
            btnProduccionAnimal.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnProduccionAnimal.FlatAppearance.BorderSize = 4;
            btnProduccionAnimal.FlatStyle = FlatStyle.Flat;
            btnProduccionAnimal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnProduccionAnimal.ForeColor = Color.Black;
            btnProduccionAnimal.Image = Properties.Resources.ganado;
            btnProduccionAnimal.ImageAlign = ContentAlignment.MiddleLeft;
            btnProduccionAnimal.Location = new Point(0, 300);
            btnProduccionAnimal.Margin = new Padding(4, 5, 4, 5);
            btnProduccionAnimal.Name = "btnProduccionAnimal";
            btnProduccionAnimal.Padding = new Padding(17, 0, 0, 0);
            btnProduccionAnimal.Size = new Size(328, 100);
            btnProduccionAnimal.TabIndex = 26;
            btnProduccionAnimal.Tag = "Alta Usuario";
            btnProduccionAnimal.Text = "Producción  Animal";
            btnProduccionAnimal.TextAlign = ContentAlignment.MiddleRight;
            btnProduccionAnimal.UseVisualStyleBackColor = false;
            btnProduccionAnimal.Click += btnProduccionAnimal_Click;
            // 
            // btnProduccionVegetal
            // 
            btnProduccionVegetal.BackColor = Color.FromArgb(137, 195, 32);
            btnProduccionVegetal.BackgroundImage = (Image)resources.GetObject("btnProduccionVegetal.BackgroundImage");
            btnProduccionVegetal.Dock = DockStyle.Top;
            btnProduccionVegetal.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnProduccionVegetal.FlatAppearance.BorderSize = 4;
            btnProduccionVegetal.FlatStyle = FlatStyle.Flat;
            btnProduccionVegetal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnProduccionVegetal.ForeColor = Color.Black;
            btnProduccionVegetal.Image = Properties.Resources.agricola;
            btnProduccionVegetal.ImageAlign = ContentAlignment.MiddleLeft;
            btnProduccionVegetal.Location = new Point(0, 200);
            btnProduccionVegetal.Margin = new Padding(4, 5, 4, 5);
            btnProduccionVegetal.Name = "btnProduccionVegetal";
            btnProduccionVegetal.Padding = new Padding(17, 0, 0, 0);
            btnProduccionVegetal.Size = new Size(328, 100);
            btnProduccionVegetal.TabIndex = 25;
            btnProduccionVegetal.Tag = "Administración";
            btnProduccionVegetal.Text = "Producción  Vegetal";
            btnProduccionVegetal.TextAlign = ContentAlignment.MiddleRight;
            btnProduccionVegetal.UseVisualStyleBackColor = false;
            btnProduccionVegetal.Click += btnProduccionVegetal_Click;
            // 
            // btnAdministracion
            // 
            btnAdministracion.BackColor = Color.FromArgb(137, 195, 32);
            btnAdministracion.BackgroundImage = (Image)resources.GetObject("btnAdministracion.BackgroundImage");
            btnAdministracion.Dock = DockStyle.Top;
            btnAdministracion.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnAdministracion.FlatAppearance.BorderSize = 4;
            btnAdministracion.FlatStyle = FlatStyle.Flat;
            btnAdministracion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAdministracion.ForeColor = Color.Black;
            btnAdministracion.Image = Properties.Resources.investigacion1;
            btnAdministracion.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdministracion.Location = new Point(0, 100);
            btnAdministracion.Margin = new Padding(4, 5, 4, 5);
            btnAdministracion.Name = "btnAdministracion";
            btnAdministracion.Padding = new Padding(17, 0, 0, 0);
            btnAdministracion.Size = new Size(328, 100);
            btnAdministracion.TabIndex = 24;
            btnAdministracion.Tag = "";
            btnAdministracion.Text = "Administracion";
            btnAdministracion.TextAlign = ContentAlignment.MiddleRight;
            btnAdministracion.UseVisualStyleBackColor = false;
            btnAdministracion.Click += btnAdministracion_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.FromArgb(137, 195, 32);
            btnIniciar.BackgroundImage = (Image)resources.GetObject("btnIniciar.BackgroundImage");
            btnIniciar.Dock = DockStyle.Top;
            btnIniciar.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnIniciar.FlatAppearance.BorderSize = 4;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnIniciar.ForeColor = Color.Black;
            btnIniciar.Image = Properties.Resources.iniciar_sesion1;
            btnIniciar.ImageAlign = ContentAlignment.MiddleLeft;
            btnIniciar.Location = new Point(0, 0);
            btnIniciar.Margin = new Padding(4, 5, 4, 5);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Padding = new Padding(17, 0, 0, 0);
            btnIniciar.Size = new Size(328, 100);
            btnIniciar.TabIndex = 22;
            btnIniciar.Tag = "Iniciar";
            btnIniciar.Text = "Iniciar Sesión";
            btnIniciar.TextAlign = ContentAlignment.MiddleRight;
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnEntornoFormativo
            // 
            btnEntornoFormativo.BackColor = Color.FromArgb(137, 195, 32);
            btnEntornoFormativo.BackgroundImage = (Image)resources.GetObject("btnEntornoFormativo.BackgroundImage");
            btnEntornoFormativo.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnEntornoFormativo.FlatAppearance.BorderSize = 4;
            btnEntornoFormativo.FlatStyle = FlatStyle.Flat;
            btnEntornoFormativo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnEntornoFormativo.ForeColor = Color.Black;
            btnEntornoFormativo.Image = Properties.Resources.Areas1;
            btnEntornoFormativo.ImageAlign = ContentAlignment.MiddleLeft;
            btnEntornoFormativo.Location = new Point(218, 0);
            btnEntornoFormativo.Margin = new Padding(4, 5, 4, 5);
            btnEntornoFormativo.Name = "btnEntornoFormativo";
            btnEntornoFormativo.Padding = new Padding(17, 0, 0, 0);
            btnEntornoFormativo.Size = new Size(217, 100);
            btnEntornoFormativo.TabIndex = 9;
            btnEntornoFormativo.Tag = "Areas";
            btnEntornoFormativo.Text = "Entornos Formativos";
            btnEntornoFormativo.TextAlign = ContentAlignment.MiddleRight;
            btnEntornoFormativo.UseVisualStyleBackColor = false;
            btnEntornoFormativo.Click += btnEntornoFormativo_Click;
            // 
            // btnUsuarioAlta
            // 
            btnUsuarioAlta.BackColor = Color.FromArgb(137, 195, 32);
            btnUsuarioAlta.BackgroundImage = (Image)resources.GetObject("btnUsuarioAlta.BackgroundImage");
            btnUsuarioAlta.FlatAppearance.BorderColor = Color.FromArgb(137, 195, 32);
            btnUsuarioAlta.FlatAppearance.BorderSize = 4;
            btnUsuarioAlta.FlatStyle = FlatStyle.Flat;
            btnUsuarioAlta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnUsuarioAlta.ForeColor = Color.Black;
            btnUsuarioAlta.Image = Properties.Resources.administrador;
            btnUsuarioAlta.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarioAlta.Location = new Point(0, 0);
            btnUsuarioAlta.Margin = new Padding(4, 5, 4, 5);
            btnUsuarioAlta.Name = "btnUsuarioAlta";
            btnUsuarioAlta.Padding = new Padding(17, 0, 0, 0);
            btnUsuarioAlta.Size = new Size(218, 100);
            btnUsuarioAlta.TabIndex = 2;
            btnUsuarioAlta.Tag = "";
            btnUsuarioAlta.Text = "Alta de Usuario";
            btnUsuarioAlta.TextAlign = ContentAlignment.MiddleRight;
            btnUsuarioAlta.UseVisualStyleBackColor = false;
            btnUsuarioAlta.Click += btnUsuarioAlta_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1570);
            Controls.Add(panelMenu);
            Controls.Add(pbCerrarPrograma);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Inicio";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inicio";
            Load += Inicio_Load;
            pbCerrarPrograma.ResumeLayout(false);
            pbCerrarPrograma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCerrarAgraria).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAlerta).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUrgencias).EndInit();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pbCerrarPrograma;
        private PictureBox pbAlerta;
        private Label lblTitle;
        private Label lblUsuario;
        private Button btnClose;
        private Button bntMinimize;
        private PictureBox pbUrgencias;
        private Panel panelMenu;
        private Button btnEntornoFormativo;
        private Button btnUsuarioAlta;
        private PictureBox pictureBox1;
        private PictureBox pbCerrarAgraria;
        private Label lblUrgencia;
        private Button btnIniciar;
        private Button btnCerrarSesion;
        private Button btnPañol;
        private Button btnVenta;
        private Button btnInventario;
        private Button btnIndustria;
        private Button btnProduccionAnimal;
        private Button btnProduccionVegetal;
        private Button btnAdministracion;
    }
}