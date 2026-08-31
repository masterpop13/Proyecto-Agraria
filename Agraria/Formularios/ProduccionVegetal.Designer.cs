  namespace Agraria.Formularios
{
    partial class ProduccionVegetal
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
            groupBox7 = new GroupBox();
            groupBox1 = new GroupBox();
            btnAgregarPagina2 = new Tienda.RJButton();
            btnQuitarPagina2 = new Tienda.RJButton();
            tbVegetales = new TabControl();
            errorProvider1 = new ErrorProvider(components);
            PanelDeGrupoBox = new Panel();
            groupBox7.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(groupBox1);
            groupBox7.Controls.Add(tbVegetales);
            groupBox7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox7.ForeColor = Color.White;
            groupBox7.Location = new Point(849, -1);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(1018, 850);
            groupBox7.TabIndex = 36;
            groupBox7.TabStop = false;
            groupBox7.Text = "Registro de Datos Vegetales";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAgregarPagina2);
            groupBox1.Controls.Add(btnQuitarPagina2);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(6, 729);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1006, 94);
            groupBox1.TabIndex = 68;
            groupBox1.TabStop = false;
            groupBox1.Text = "Botones exclusivos para Agregar o Quitar paginas :";
            // 
            // btnAgregarPagina2
            // 
            btnAgregarPagina2.BackColor = Color.White;
            btnAgregarPagina2.FlatAppearance.BorderSize = 0;
            btnAgregarPagina2.FlatStyle = FlatStyle.Flat;
            btnAgregarPagina2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnAgregarPagina2.ForeColor = Color.FromArgb(56, 124, 31);
            btnAgregarPagina2.Image = Properties.Resources.entrada;
            btnAgregarPagina2.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarPagina2.Location = new Point(121, 37);
            btnAgregarPagina2.Name = "btnAgregarPagina2";
            btnAgregarPagina2.Size = new Size(173, 40);
            btnAgregarPagina2.TabIndex = 28;
            btnAgregarPagina2.Text = "Agregar";
            btnAgregarPagina2.UseVisualStyleBackColor = false;
            btnAgregarPagina2.Click += btnAgregarPagina_Click;
            // 
            // btnQuitarPagina2
            // 
            btnQuitarPagina2.BackColor = Color.White;
            btnQuitarPagina2.FlatAppearance.BorderSize = 0;
            btnQuitarPagina2.FlatStyle = FlatStyle.Flat;
            btnQuitarPagina2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnQuitarPagina2.ForeColor = Color.FromArgb(56, 124, 31);
            btnQuitarPagina2.Image = Properties.Resources.salida;
            btnQuitarPagina2.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitarPagina2.Location = new Point(729, 37);
            btnQuitarPagina2.Name = "btnQuitarPagina2";
            btnQuitarPagina2.Size = new Size(173, 40);
            btnQuitarPagina2.TabIndex = 29;
            btnQuitarPagina2.Text = "Quitar";
            btnQuitarPagina2.UseVisualStyleBackColor = false;
            btnQuitarPagina2.Click += btnQuitarPagina_Click;
            // 
            // tbVegetales
            // 
            tbVegetales.Location = new Point(6, 28);
            tbVegetales.Name = "tbVegetales";
            tbVegetales.SelectedIndex = 0;
            tbVegetales.Size = new Size(1012, 695);
            tbVegetales.TabIndex = 67;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // PanelDeGrupoBox
            // 
            PanelDeGrupoBox.AutoScroll = true;
            PanelDeGrupoBox.Location = new Point(12, 12);
            PanelDeGrupoBox.Name = "PanelDeGrupoBox";
            PanelDeGrupoBox.Size = new Size(831, 837);
            PanelDeGrupoBox.TabIndex = 37;
            // 
            // ProduccionVegetal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            ClientSize = new Size(1884, 861);
            Controls.Add(PanelDeGrupoBox);
            Controls.Add(groupBox7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProduccionVegetal";
            Text = "ProduccionVegetal";
            Load += ProduccionVegetal_Load;
            groupBox7.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox7;
        private Tienda.RJButton rjButton7;
        private TextBox txtCantAtaados;
        private TabControl tbVegetales;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private ErrorProvider errorProvider1;
        private Panel PanelDeGrupoBox;
        private GroupBox groupBox1;
        private Tienda.RJButton btnAgregarPagina2;
        private Tienda.RJButton btnQuitarPagina2;
    }
}