namespace Agraria.UserControls
{
    partial class UcGrupoBox
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
            txtActualCosechados = new TextBox();
            txtCantidadPlantines = new TextBox();
            gpbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCambiarImagen).BeginInit();
            SuspendLayout();
            // 
            // gpbDatos
            // 
            gpbDatos.BackColor = Color.FromArgb(141, 181, 146);
            gpbDatos.Controls.Add(btnQuitarImagen);
            gpbDatos.Controls.Add(btnCambiarImagen);
            gpbDatos.Controls.Add(pbCambiarImagen);
            gpbDatos.Controls.Add(lblActualCosechados);
            gpbDatos.Controls.Add(lblCantidadAtados);
            gpbDatos.Controls.Add(txtActualCosechados);
            gpbDatos.Controls.Add(txtCantidadPlantines);
            gpbDatos.Dock = DockStyle.Top;
            gpbDatos.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            gpbDatos.ForeColor = Color.White;
            gpbDatos.Location = new Point(0, 0);
            gpbDatos.Name = "gpbDatos";
            gpbDatos.Size = new Size(831, 142);
            gpbDatos.TabIndex = 38;
            gpbDatos.TabStop = false;
            gpbDatos.Text = "Produccion de ";
            gpbDatos.Enter += gpbDatos_Enter;
            // 
            // btnQuitarImagen
            // 
            btnQuitarImagen.BackColor = Color.White;
            btnQuitarImagen.FlatAppearance.BorderSize = 0;
            btnQuitarImagen.FlatStyle = FlatStyle.Flat;
            btnQuitarImagen.ForeColor = Color.Green;
            btnQuitarImagen.Location = new Point(639, 66);
            btnQuitarImagen.Name = "btnQuitarImagen";
            btnQuitarImagen.Size = new Size(189, 32);
            btnQuitarImagen.TabIndex = 21;
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
            btnCambiarImagen.Location = new Point(636, 104);
            btnCambiarImagen.Name = "btnCambiarImagen";
            btnCambiarImagen.Size = new Size(189, 32);
            btnCambiarImagen.TabIndex = 20;
            btnCambiarImagen.Text = "Agregar Imagen";
            btnCambiarImagen.UseVisualStyleBackColor = false;
            btnCambiarImagen.Click += btnCambiarImagen_Click;
            // 
            // pbCambiarImagen
            // 
            pbCambiarImagen.BackColor = Color.White;
            pbCambiarImagen.Location = new Point(18, 28);
            pbCambiarImagen.Name = "pbCambiarImagen";
            pbCambiarImagen.Size = new Size(193, 98);
            pbCambiarImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCambiarImagen.TabIndex = 19;
            pbCambiarImagen.TabStop = false;
            // 
            // lblActualCosechados
            // 
            lblActualCosechados.AutoSize = true;
            lblActualCosechados.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblActualCosechados.ForeColor = Color.White;
            lblActualCosechados.Location = new Point(248, 85);
            lblActualCosechados.Name = "lblActualCosechados";
            lblActualCosechados.Size = new Size(199, 24);
            lblActualCosechados.TabIndex = 18;
            lblActualCosechados.Text = "Actual  cosechados:";
            // 
            // lblCantidadAtados
            // 
            lblCantidadAtados.AutoSize = true;
            lblCantidadAtados.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCantidadAtados.ForeColor = Color.White;
            lblCantidadAtados.Location = new Point(228, 41);
            lblCantidadAtados.Name = "lblCantidadAtados";
            lblCantidadAtados.Size = new Size(219, 24);
            lblCantidadAtados.TabIndex = 16;
            lblCantidadAtados.Text = "Cantidad de Plantines:";
            // 
            // txtActualCosechados
            // 
            txtActualCosechados.Location = new Point(468, 80);
            txtActualCosechados.Name = "txtActualCosechados";
            txtActualCosechados.Size = new Size(144, 29);
            txtActualCosechados.TabIndex = 6;
            // 
            // txtCantidadPlantines
            // 
            txtCantidadPlantines.Location = new Point(468, 39);
            txtCantidadPlantines.Name = "txtCantidadPlantines";
            txtCantidadPlantines.Size = new Size(144, 29);
            txtCantidadPlantines.TabIndex = 9;
            // 
            // UcGrupoBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gpbDatos);
            Name = "UcGrupoBox";
            Size = new Size(831, 142);
            Load += UcGrupoBox_Load;
            gpbDatos.ResumeLayout(false);
            gpbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCambiarImagen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbDatos;
        private PictureBox pbCambiarImagen;
        private Label lblActualCosechados;
        private Label lblCantidadAtados;
        private TextBox txtActualCosechados;
        private TextBox txtCantidadPlantines;
        private Tienda.RJButton btnCambiarImagen;
        private Tienda.RJButton btnQuitarImagen;
    }
}
