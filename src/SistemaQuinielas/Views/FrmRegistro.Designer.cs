namespace SistemaQuinielas.Views
{
    partial class FrmRegistro
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
            lbRegistrodeUsuario = new Label();
            lblNombre = new Label();
            lblContrasena = new Label();
            lblPaisFavorito = new Label();
            txtNombre = new TextBox();
            txtContrasena = new TextBox();
            txtPaisFavorito = new TextBox();
            btnGuardarRegistro = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lbRegistrodeUsuario
            // 
            lbRegistrodeUsuario.AutoSize = true;
            lbRegistrodeUsuario.Location = new Point(278, 62);
            lbRegistrodeUsuario.Name = "lbRegistrodeUsuario";
            lbRegistrodeUsuario.Size = new Size(167, 25);
            lbRegistrodeUsuario.TabIndex = 0;
            lbRegistrodeUsuario.Text = "Registro de Usuario";
            lbRegistrodeUsuario.Click += lbRegistrodeUsuario_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(318, 109);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            lblNombre.Click += label1_Click;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(308, 189);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(105, 25);
            lblContrasena.TabIndex = 2;
            lblContrasena.Text = "Contraseña:";
            lblContrasena.Click += label2_Click;
            // 
            // lblPaisFavorito
            // 
            lblPaisFavorito.AutoSize = true;
            lblPaisFavorito.Location = new Point(298, 261);
            lblPaisFavorito.Name = "lblPaisFavorito";
            lblPaisFavorito.Size = new Size(115, 25);
            lblPaisFavorito.TabIndex = 3;
            lblPaisFavorito.Text = "País Favorito:";
            lblPaisFavorito.Click += label3_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(278, 137);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 4;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(278, 217);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(150, 31);
            txtContrasena.TabIndex = 5;
            // 
            // txtPaisFavorito
            // 
            txtPaisFavorito.Location = new Point(278, 289);
            txtPaisFavorito.Name = "txtPaisFavorito";
            txtPaisFavorito.Size = new Size(150, 31);
            txtPaisFavorito.TabIndex = 6;
            // 
            // btnGuardarRegistro
            // 
            btnGuardarRegistro.Location = new Point(298, 335);
            btnGuardarRegistro.Name = "btnGuardarRegistro";
            btnGuardarRegistro.Size = new Size(112, 34);
            btnGuardarRegistro.TabIndex = 7;
            btnGuardarRegistro.Text = "Registrarse";
            btnGuardarRegistro.UseVisualStyleBackColor = true;
            btnGuardarRegistro.Click += btnGuardarRegistro_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(298, 384);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarRegistro);
            Controls.Add(txtPaisFavorito);
            Controls.Add(txtContrasena);
            Controls.Add(txtNombre);
            Controls.Add(lblPaisFavorito);
            Controls.Add(lblContrasena);
            Controls.Add(lblNombre);
            Controls.Add(lbRegistrodeUsuario);
            Name = "FrmRegistro";
            Text = "FrmRegistro";
            Load += FrmRegistro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbRegistrodeUsuario;
        private Label lblNombre;
        private Label lblContrasena;
        private Label lblPaisFavorito;
        private TextBox txtNombre;
        private TextBox txtContrasena;
        private TextBox txtPaisFavorito;
        private Button btnGuardarRegistro;
        private Button btnCancelar;
    }
}