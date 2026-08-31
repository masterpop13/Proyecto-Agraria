namespace Agraria.UserControls
{
    partial class FrmSeleccionUC
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbOpciones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionUC));
            lblTipo = new Label();
            cmbOpciones = new ComboBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            btnModificarUsuario = new Tienda.RJButton();
            rjButton1 = new Tienda.RJButton();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.BackColor = Color.Transparent;
            lblTipo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTipo.Location = new Point(105, 9);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(223, 24);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Seleccione su Entorno";
            // 
            // cmbOpciones
            // 
            cmbOpciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpciones.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            cmbOpciones.FormattingEnabled = true;
            cmbOpciones.Items.AddRange(new object[] { "UcVentas", "UcProduccion", "UcReportes" });
            cmbOpciones.Location = new Point(85, 47);
            cmbOpciones.Name = "cmbOpciones";
            cmbOpciones.Size = new Size(260, 32);
            cmbOpciones.TabIndex = 1;
            cmbOpciones.SelectedIndexChanged += cmbOpciones_SelectedIndexChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 82);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(435, 24);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Nombre Ejemplo(Ponedoras , Vacas ,Acelga)";
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtTitulo.Location = new Point(85, 122);
            txtTitulo.MaxLength = 40;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(260, 29);
            txtTitulo.TabIndex = 3;
            txtTitulo.TextChanged += txtTitulo_TextChanged;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.BackColor = Color.White;
            btnModificarUsuario.FlatAppearance.BorderSize = 0;
            btnModificarUsuario.FlatStyle = FlatStyle.Flat;
            btnModificarUsuario.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnModificarUsuario.ForeColor = Color.FromArgb(56, 124, 31);
            btnModificarUsuario.Image = Properties.Resources.firma;
            btnModificarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificarUsuario.Location = new Point(12, 168);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(168, 40);
            btnModificarUsuario.TabIndex = 28;
            btnModificarUsuario.Text = "Agregar";
            btnModificarUsuario.UseVisualStyleBackColor = false;
            btnModificarUsuario.Click += btnAceptar_Click;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.White;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            rjButton1.ForeColor = Color.FromArgb(56, 124, 31);
            rjButton1.Image = (Image)resources.GetObject("rjButton1.Image");
            rjButton1.ImageAlign = ContentAlignment.MiddleLeft;
            rjButton1.Location = new Point(263, 168);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(168, 40);
            rjButton1.TabIndex = 29;
            rjButton1.Text = "Cancelar";
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += btnCancelar_Click;
            // 
            // FrmSeleccionUC
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(443, 220);
            Controls.Add(rjButton1);
            Controls.Add(btnModificarUsuario);
            Controls.Add(txtTitulo);
            Controls.Add(lblTitulo);
            Controls.Add(cmbOpciones);
            Controls.Add(lblTipo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSeleccionUC";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva página";
            Load += FrmSeleccionUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Tienda.RJButton btnModificarUsuario;
        private Tienda.RJButton rjButton1;
    }
}
