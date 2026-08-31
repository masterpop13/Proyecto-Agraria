namespace Agraria.UserControls
{
    partial class UcColmenas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcColmenas));
            gbRegistroMiel = new GroupBox();
            lblFechaMiel = new Label();
            dtpFechaColmena = new DateTimePicker();
            label15 = new Label();
            txtColmena = new TextBox();
            btnGuardarColmena = new Tienda.RJButton();
            btnImprimir = new Tienda.RJButton();
            groupBox1 = new GroupBox();
            label1 = new Label();
            dtpFechaCosechaMiel = new DateTimePicker();
            label2 = new Label();
            txtCantidadMiel = new TextBox();
            btnCantidadMiel = new Tienda.RJButton();
            groupBox2 = new GroupBox();
            label3 = new Label();
            dtpFechaRetiroColmena = new DateTimePicker();
            label4 = new Label();
            txtRetiroColmena = new TextBox();
            btnQuitarColmena = new Tienda.RJButton();
            groupBox3 = new GroupBox();
            cmbEnviarIndustria = new ComboBox();
            label5 = new Label();
            dtpFechaEnvioIndustria = new DateTimePicker();
            label6 = new Label();
            btnEnviarIndustria = new Tienda.RJButton();
            dtgDatosMiel = new DataGridView();
            gbRegistroMiel.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDatosMiel).BeginInit();
            SuspendLayout();
            // 
            // gbRegistroMiel
            // 
            gbRegistroMiel.Controls.Add(lblFechaMiel);
            gbRegistroMiel.Controls.Add(dtpFechaColmena);
            gbRegistroMiel.Controls.Add(label15);
            gbRegistroMiel.Controls.Add(txtColmena);
            gbRegistroMiel.Controls.Add(btnGuardarColmena);
            gbRegistroMiel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            gbRegistroMiel.ForeColor = Color.White;
            gbRegistroMiel.Location = new Point(15, 3);
            gbRegistroMiel.Name = "gbRegistroMiel";
            gbRegistroMiel.Size = new Size(932, 115);
            gbRegistroMiel.TabIndex = 80;
            gbRegistroMiel.TabStop = false;
            gbRegistroMiel.Text = "Agregar Colmena";
            // 
            // lblFechaMiel
            // 
            lblFechaMiel.AutoSize = true;
            lblFechaMiel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblFechaMiel.ForeColor = Color.White;
            lblFechaMiel.Location = new Point(100, 36);
            lblFechaMiel.Name = "lblFechaMiel";
            lblFechaMiel.Size = new Size(75, 24);
            lblFechaMiel.TabIndex = 76;
            lblFechaMiel.Text = "Fecha:";
            // 
            // dtpFechaColmena
            // 
            dtpFechaColmena.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaColmena.Location = new Point(191, 32);
            dtpFechaColmena.Name = "dtpFechaColmena";
            dtpFechaColmena.Size = new Size(414, 29);
            dtpFechaColmena.TabIndex = 77;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(18, 71);
            label15.Name = "label15";
            label15.Size = new Size(157, 24);
            label15.TabIndex = 59;
            label15.Text = "N° de Colmena:";
            // 
            // txtColmena
            // 
            txtColmena.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtColmena.Location = new Point(191, 71);
            txtColmena.MaxLength = 7;
            txtColmena.Name = "txtColmena";
            txtColmena.Size = new Size(414, 29);
            txtColmena.TabIndex = 61;
            txtColmena.KeyDown += CopiaryPegar_KeyDown;
            txtColmena.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnGuardarColmena
            // 
            btnGuardarColmena.BackColor = Color.White;
            btnGuardarColmena.FlatAppearance.BorderSize = 0;
            btnGuardarColmena.FlatStyle = FlatStyle.Flat;
            btnGuardarColmena.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnGuardarColmena.ForeColor = Color.FromArgb(56, 124, 31);
            btnGuardarColmena.Image = (Image)resources.GetObject("btnGuardarColmena.Image");
            btnGuardarColmena.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarColmena.Location = new Point(727, 54);
            btnGuardarColmena.Name = "btnGuardarColmena";
            btnGuardarColmena.Size = new Size(161, 41);
            btnGuardarColmena.TabIndex = 62;
            btnGuardarColmena.Text = "Guardar";
            btnGuardarColmena.UseVisualStyleBackColor = false;
            btnGuardarColmena.Click += btnGuardarColmena_Click;
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
            btnImprimir.Location = new Point(727, 19);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(161, 41);
            btnImprimir.TabIndex = 76;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtpFechaCosechaMiel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCantidadMiel);
            groupBox1.Controls.Add(btnCantidadMiel);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(15, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(932, 115);
            groupBox1.TabIndex = 81;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro de Miel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(100, 36);
            label1.Name = "label1";
            label1.Size = new Size(75, 24);
            label1.TabIndex = 76;
            label1.Text = "Fecha:";
            // 
            // dtpFechaCosechaMiel
            // 
            dtpFechaCosechaMiel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaCosechaMiel.Location = new Point(191, 28);
            dtpFechaCosechaMiel.Name = "dtpFechaCosechaMiel";
            dtpFechaCosechaMiel.Size = new Size(414, 29);
            dtpFechaCosechaMiel.TabIndex = 77;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(2, 71);
            label2.Name = "label2";
            label2.Size = new Size(173, 24);
            label2.TabIndex = 59;
            label2.Text = "Cantidad de Miel:";
            // 
            // txtCantidadMiel
            // 
            txtCantidadMiel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtCantidadMiel.Location = new Point(191, 68);
            txtCantidadMiel.MaxLength = 7;
            txtCantidadMiel.Name = "txtCantidadMiel";
            txtCantidadMiel.Size = new Size(414, 29);
            txtCantidadMiel.TabIndex = 61;
            txtCantidadMiel.KeyDown += CopiaryPegar_KeyDown;
            txtCantidadMiel.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnCantidadMiel
            // 
            btnCantidadMiel.BackColor = Color.White;
            btnCantidadMiel.FlatAppearance.BorderSize = 0;
            btnCantidadMiel.FlatStyle = FlatStyle.Flat;
            btnCantidadMiel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnCantidadMiel.ForeColor = Color.FromArgb(56, 124, 31);
            btnCantidadMiel.Image = (Image)resources.GetObject("btnCantidadMiel.Image");
            btnCantidadMiel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCantidadMiel.Location = new Point(727, 54);
            btnCantidadMiel.Name = "btnCantidadMiel";
            btnCantidadMiel.Size = new Size(161, 41);
            btnCantidadMiel.TabIndex = 62;
            btnCantidadMiel.Text = "Guardar";
            btnCantidadMiel.UseVisualStyleBackColor = false;
            btnCantidadMiel.Click += btnCantidadMiel_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dtpFechaRetiroColmena);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtRetiroColmena);
            groupBox2.Controls.Add(btnQuitarColmena);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(15, 245);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(932, 115);
            groupBox2.TabIndex = 82;
            groupBox2.TabStop = false;
            groupBox2.Text = "Retirar Colmenas";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(100, 36);
            label3.Name = "label3";
            label3.Size = new Size(75, 24);
            label3.TabIndex = 76;
            label3.Text = "Fecha:";
            // 
            // dtpFechaRetiroColmena
            // 
            dtpFechaRetiroColmena.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaRetiroColmena.Location = new Point(191, 29);
            dtpFechaRetiroColmena.Name = "dtpFechaRetiroColmena";
            dtpFechaRetiroColmena.Size = new Size(414, 29);
            dtpFechaRetiroColmena.TabIndex = 77;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(18, 71);
            label4.Name = "label4";
            label4.Size = new Size(161, 24);
            label4.TabIndex = 59;
            label4.Text = "Quitar Colmena:";
            // 
            // txtRetiroColmena
            // 
            txtRetiroColmena.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            txtRetiroColmena.Location = new Point(191, 71);
            txtRetiroColmena.MaxLength = 7;
            txtRetiroColmena.Name = "txtRetiroColmena";
            txtRetiroColmena.Size = new Size(414, 29);
            txtRetiroColmena.TabIndex = 61;
            txtRetiroColmena.KeyDown += CopiaryPegar_KeyDown;
            txtRetiroColmena.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnQuitarColmena
            // 
            btnQuitarColmena.BackColor = Color.White;
            btnQuitarColmena.FlatAppearance.BorderSize = 0;
            btnQuitarColmena.FlatStyle = FlatStyle.Flat;
            btnQuitarColmena.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnQuitarColmena.ForeColor = Color.FromArgb(56, 124, 31);
            btnQuitarColmena.Image = (Image)resources.GetObject("btnQuitarColmena.Image");
            btnQuitarColmena.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitarColmena.Location = new Point(727, 54);
            btnQuitarColmena.Name = "btnQuitarColmena";
            btnQuitarColmena.Size = new Size(161, 41);
            btnQuitarColmena.TabIndex = 62;
            btnQuitarColmena.Text = "Quitar";
            btnQuitarColmena.UseVisualStyleBackColor = false;
            btnQuitarColmena.Click += btnQuitarColmena_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbEnviarIndustria);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(btnImprimir);
            groupBox3.Controls.Add(dtpFechaEnvioIndustria);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(btnEnviarIndustria);
            groupBox3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(15, 366);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(932, 115);
            groupBox3.TabIndex = 83;
            groupBox3.TabStop = false;
            groupBox3.Text = "Enviar Miel a Industria:";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // cmbEnviarIndustria
            // 
            cmbEnviarIndustria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEnviarIndustria.FormattingEnabled = true;
            cmbEnviarIndustria.Location = new Point(191, 71);
            cmbEnviarIndustria.Name = "cmbEnviarIndustria";
            cmbEnviarIndustria.Size = new Size(414, 32);
            cmbEnviarIndustria.TabIndex = 78;
            cmbEnviarIndustria.KeyDown += CopiaryPegar_KeyDown;
            cmbEnviarIndustria.KeyPress += SoloNumeros_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(100, 36);
            label5.Name = "label5";
            label5.Size = new Size(75, 24);
            label5.TabIndex = 76;
            label5.Text = "Fecha:";
            // 
            // dtpFechaEnvioIndustria
            // 
            dtpFechaEnvioIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dtpFechaEnvioIndustria.Location = new Point(191, 28);
            dtpFechaEnvioIndustria.Name = "dtpFechaEnvioIndustria";
            dtpFechaEnvioIndustria.Size = new Size(414, 29);
            dtpFechaEnvioIndustria.TabIndex = 77;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(6, 71);
            label6.Name = "label6";
            label6.Size = new Size(173, 24);
            label6.TabIndex = 59;
            label6.Text = "Cantidad de Miel:";
            // 
            // btnEnviarIndustria
            // 
            btnEnviarIndustria.BackColor = Color.White;
            btnEnviarIndustria.FlatAppearance.BorderSize = 0;
            btnEnviarIndustria.FlatStyle = FlatStyle.Flat;
            btnEnviarIndustria.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnEnviarIndustria.ForeColor = Color.FromArgb(56, 124, 31);
            btnEnviarIndustria.Image = Properties.Resources.fabrica;
            btnEnviarIndustria.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnviarIndustria.Location = new Point(727, 63);
            btnEnviarIndustria.Name = "btnEnviarIndustria";
            btnEnviarIndustria.Size = new Size(161, 41);
            btnEnviarIndustria.TabIndex = 62;
            btnEnviarIndustria.Text = "Enviar";
            btnEnviarIndustria.UseVisualStyleBackColor = false;
            btnEnviarIndustria.Click += btnEnviarIndustria_Click;
            // 
            // dtgDatosMiel
            // 
            dtgDatosMiel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDatosMiel.Dock = DockStyle.Bottom;
            dtgDatosMiel.Location = new Point(0, 487);
            dtgDatosMiel.Name = "dtgDatosMiel";
            dtgDatosMiel.ReadOnly = true;
            dtgDatosMiel.Size = new Size(999, 222);
            dtgDatosMiel.TabIndex = 84;
            // 
            // UcColmenas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 181, 146);
            Controls.Add(dtgDatosMiel);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gbRegistroMiel);
            Name = "UcColmenas";
            Size = new Size(999, 709);
            Load += UcColmenas_Load;
            gbRegistroMiel.ResumeLayout(false);
            gbRegistroMiel.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDatosMiel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbRegistroMiel;
        private Label lblFechaMiel;
        private DateTimePicker dtpFechaColmena;
        private Label label15;
        private TextBox txtColmena;
        private Tienda.RJButton btnGuardarColmena;
        private Tienda.RJButton btnImprimir;
        private GroupBox groupBox1;
        private Label label1;
        private DateTimePicker dtpFechaCosechaMiel;
        private Label label2;
        private TextBox txtCantidadMiel;
        private Tienda.RJButton btnCantidadMiel;
        private GroupBox groupBox2;
        private Label label3;
        private DateTimePicker dtpFechaRetiroColmena;
        private Label label4;
        private TextBox txtRetiroColmena;
        private Tienda.RJButton btnQuitarColmena;
        private GroupBox groupBox3;
        private Label label5;
        private DateTimePicker dtpFechaEnvioIndustria;
        private Label label6;
        private Tienda.RJButton btnEnviarIndustria;
        private ComboBox cmbEnviarIndustria;
        private DataGridView dtgDatosMiel;
    }
}
