namespace SistemaQuinielas.Views
{
    partial class FrmGestionUsuarios
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
            label1 = new Label();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            dgvUsuarios = new DataGridView();
            lblUsuarios = new Label();
            txtNombre = new TextBox();
            txtContrasena = new TextBox();
            txtPaisFavorito = new TextBox();
            lblNombre = new Label();
            lblContrasena = new Label();
            lblPaisFavorito = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(282, 9);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
            label1.TabIndex = 0;
            label1.Text = "Gestion de Usuarios";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(500, 58);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(112, 47);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(500, 129);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(112, 52);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(52, 233);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 62;
            dgvUsuarios.Size = new Size(711, 205);
            dgvUsuarios.TabIndex = 4;
            // 
            // lblUsuarios
            // 
            lblUsuarios.AutoSize = true;
            lblUsuarios.Location = new Point(52, 205);
            lblUsuarios.Name = "lblUsuarios";
            lblUsuarios.Size = new Size(182, 25);
            lblUsuarios.TabIndex = 5;
            lblUsuarios.Text = "Usuarios Registrados:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(229, 52);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(185, 31);
            txtNombre.TabIndex = 6;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(229, 104);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(185, 31);
            txtContrasena.TabIndex = 7;
            // 
            // txtPaisFavorito
            // 
            txtPaisFavorito.Location = new Point(229, 150);
            txtPaisFavorito.Name = "txtPaisFavorito";
            txtPaisFavorito.Size = new Size(185, 31);
            txtPaisFavorito.TabIndex = 8;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(94, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre:";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(94, 104);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(105, 25);
            lblContrasena.TabIndex = 10;
            lblContrasena.Text = "Contraseña:";
            // 
            // lblPaisFavorito
            // 
            lblPaisFavorito.AutoSize = true;
            lblPaisFavorito.Location = new Point(94, 156);
            lblPaisFavorito.Name = "lblPaisFavorito";
            lblPaisFavorito.Size = new Size(115, 25);
            lblPaisFavorito.TabIndex = 11;
            lblPaisFavorito.Text = "País Favorito:";
            // 
            // FrmGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPaisFavorito);
            Controls.Add(lblContrasena);
            Controls.Add(lblNombre);
            Controls.Add(txtPaisFavorito);
            Controls.Add(txtContrasena);
            Controls.Add(txtNombre);
            Controls.Add(lblUsuarios);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(label1);
            Name = "FrmGestionUsuarios";
            Text = "GestionUsuarios";
            Load += FrmGestionUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnRegistrar;
        private Button btnLimpiar;
        private DataGridView dgvUsuarios;
        private Label lblUsuarios;
        private TextBox txtNombre;
        private TextBox txtContrasena;
        private TextBox txtPaisFavorito;
        private Label lblNombre;
        private Label lblContrasena;
        private Label lblPaisFavorito;
    }
}