namespace SistemaQuinielas
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnGestionUsuarios = new Button();
            btnPartidos = new Button();
            btnQuinielas = new Button();
            btnCerrarSesion = new Button();
            btnPronosticos = new Button();
            btnEstadisticas = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 51);
            label1.Name = "label1";
            label1.Size = new Size(180, 25);
            label1.TabIndex = 0;
            label1.Text = "QUINIELA MUNDIAL ";
            label1.Click += label1_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Location = new Point(102, 107);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(180, 34);
            btnGestionUsuarios.TabIndex = 1;
            btnGestionUsuarios.Text = "Gestionar Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnPartidos
            // 
            btnPartidos.Location = new Point(427, 107);
            btnPartidos.Name = "btnPartidos";
            btnPartidos.Size = new Size(180, 34);
            btnPartidos.TabIndex = 2;
            btnPartidos.Text = "Partidos";
            btnPartidos.UseVisualStyleBackColor = true;
            btnPartidos.Click += btnPartidos_Click;
            // 
            // btnQuinielas
            // 
            btnQuinielas.Location = new Point(102, 200);
            btnQuinielas.Name = "btnQuinielas";
            btnQuinielas.Size = new Size(180, 34);
            btnQuinielas.TabIndex = 3;
            btnQuinielas.Text = "Quinielas";
            btnQuinielas.UseVisualStyleBackColor = true;
            btnQuinielas.Click += btnQuinielas_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(427, 290);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(180, 34);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnPronosticos
            // 
            btnPronosticos.Location = new Point(102, 290);
            btnPronosticos.Name = "btnPronosticos";
            btnPronosticos.Size = new Size(180, 34);
            btnPronosticos.TabIndex = 6;
            btnPronosticos.Text = "Pronósticos";
            btnPronosticos.UseVisualStyleBackColor = true;
            btnPronosticos.Click += btnPronosticos_Click;
            // 
            // btnEstadisticas
            // 
            btnEstadisticas.Location = new Point(427, 200);
            btnEstadisticas.Name = "btnEstadisticas";
            btnEstadisticas.Size = new Size(180, 34);
            btnEstadisticas.TabIndex = 7;
            btnEstadisticas.Text = "Estadisticas";
            btnEstadisticas.UseVisualStyleBackColor = true;
            btnEstadisticas.Click += btnEstadisticas_Click;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEstadisticas);
            Controls.Add(btnPronosticos);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnQuinielas);
            Controls.Add(btnPartidos);
            Controls.Add(btnGestionUsuarios);
            Controls.Add(label1);
            Name = "FrmMenuPrincipal";
            Text = "Menu Principal ⚽";
            Load += FrmMenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGestionUsuarios;
        private Button btnPartidos;
        private Button btnQuinielas;
        private Button btnCerrarSesion;
        private Button btnPronosticos;
        private Button btnEstadisticas;
    }
}
