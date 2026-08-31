namespace Agraria.UserControls
{
    partial class UcGrupoBoxAnimal
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
            gpbDatos = new GroupBox();
            btnQuitarImagen = new Tienda.RJButton();
            btnCambiarImagen = new Tienda.RJButton();
            pbCambiarImagen = new PictureBox();
            lblActualCosechados = new Label();
            lblCantidadAtados = new Label();
            txtCantidadProducida = new TextBox();
            txtCantidadActual = new TextBox();
            gpbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCambiarImagen).BeginInit();
            SuspendLayout();
            // 
            // gpbDatos
            // 
            gpbDatos.Controls.Add(btnQuitarImagen);
            gpbDatos.Controls.Add(btnCambiarImagen);
            gpbDatos.Controls.Add(pbCambiarImagen);
            gpbDatos.Controls.Add(lblActualCosechados);
            gpbDatos.Controls.Add(lblCantidadAtados);
            gpbDatos.Controls.Add(txtCantidadProducida);
            gpbDatos.Controls.Add(txtCantidadActual);
            gpbDatos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            gpbDatos.ForeColor = Color.White;
            gpbDatos.Location = new Point(3, 3);
            gpbDatos.Name = "gpbDatos";
            gpbDatos.Size = new Size(780, 136);
            gpbDatos.TabIndex = 24;
            gpbDatos.TabStop = false;
            gpbDatos.Text = "Produccion de ";
            // 
            // btnQuitarImagen
            // 
            btnQuitarImagen.BackColor = Color.White;
            btnQuitarImagen.FlatAppearance.BorderSize = 0;
            btnQuitarImagen.FlatStyle = FlatStyle.Flat;
            btnQuitarImagen.ForeColor = Color.Green;
            btnQuitarImagen.Location = new Point(581, 56);
            btnQuitarImagen.Name = "btnQuitarImagen";
            btnQuitarImagen.Size = new Size(189, 32);
            btnQuitarImagen.TabIndex = 28;
            btnQuitarImagen.Text = "Quitar Imagen";
            btnQuitarImagen.UseVisualStyleBackColor = false;
            btnQuitarImagen.Click += btnQuitarImagen_Click;
            // 
            // btnCambiarImagen
            // 
            btnCambiarImagen.BackColor = Color.White;
            btnCambiarImagen.FlatAppearance.BorderSize = 0;
            btnCambiarImagen.FlatStyle = FlatStyle.Flat;
            btnCambiarImagen.ForeColor = Color.Green;
            btnCambiarImagen.Location = new Point(578, 94);
            btnCambiarImagen.Name = "btnCambiarImagen";
            btnCambiarImagen.Size = new Size(189, 32);
            btnCambiarImagen.TabIndex = 27;
            btnCambiarImagen.Text = "Agregar Imagen";
            btnCambiarImagen.UseVisualStyleBackColor = false;
            btnCambiarImagen.Click += btnCambiarImagen_Click;
            // 
            // pbCambiarImagen
            // 
            pbCambiarImagen.BackColor = Color.White;
            pbCambiarImagen.Location = new Point(6, 28);
            pbCambiarImagen.Name = "pbCambiarImagen";
            pbCambiarImagen.Size = new Size(173, 98);
            pbCambiarImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCambiarImagen.TabIndex = 26;
            pbCambiarImagen.TabStop = false;
            // 
            // lblActualCosechados
            // 
            lblActualCosechados.AutoSize = true;
            lblActualCosechados.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblActualCosechados.ForeColor = Color.White;
            lblActualCosechados.Location = new Point(195, 85);
            lblActualCosechados.Name = "lblActualCosechados";
            lblActualCosechados.Size = new Size(199, 24);
            lblActualCosechados.TabIndex = 25;
            lblActualCosechados.Text = "Cantidad Producida:";
            // 
            // lblCantidadAtados
            // 
            lblCantidadAtados.AutoSize = true;
            lblCantidadAtados.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadAtados.ForeColor = Color.White;
            lblCantidadAtados.Location = new Point(232, 46);
            lblCantidadAtados.Name = "lblCantidadAtados";
            lblCantidadAtados.Size = new Size(162, 24);
            lblCantidadAtados.TabIndex = 24;
            lblCantidadAtados.Text = "Cantidad Actual:";
            // 
            // txtCantidadProducida
            // 
            txtCantidadProducida.Location = new Point(409, 80);
            txtCantidadProducida.Name = "txtCantidadProducida";
            txtCantidadProducida.Size = new Size(144, 29);
            txtCantidadProducida.TabIndex = 22;
            // 
            // txtCantidadActual
            // 
            txtCantidadActual.Location = new Point(409, 39);
            txtCantidadActual.Name = "txtCantidadActual";
            txtCantidadActual.Size = new Size(144, 29);
            txtCantidadActual.TabIndex = 23;
            // 
            // UcGrupoBoxAnimal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            Controls.Add(gpbDatos);
            Name = "UcGrupoBoxAnimal";
            Size = new Size(786, 138);
            Load += UcGrupoBoxAnimal_Load_1;
            gpbDatos.ResumeLayout(false);
            gpbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCambiarImagen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbDatos;
        private Tienda.RJButton btnQuitarImagen;
        private Tienda.RJButton btnCambiarImagen;
        private PictureBox pbCambiarImagen;
        private Label lblActualCosechados;
        private Label lblCantidadAtados;
        private TextBox txtCantidadProducida;
        private TextBox txtCantidadActual;
    }
}
