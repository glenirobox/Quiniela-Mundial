namespace SistemaQuinielas.Views
{
    partial class FrmQuiniela
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
            dgvQuinielas = new DataGridView();
            btnUnirse = new Button();
            txtNombreQuiniela = new TextBox();
            chkEsPrivada = new CheckBox();
            btnCrearQuiniela = new Button();
            lblAsignarNombreQuiniela = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnGenerarNotificaciones = new Button();
            btnVerNotificaciones = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuinielas).BeginInit();
            SuspendLayout();
            // 
            // dgvQuinielas
            // 
            dgvQuinielas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuinielas.Location = new Point(37, 32);
            dgvQuinielas.Name = "dgvQuinielas";
            dgvQuinielas.RowHeadersWidth = 62;
            dgvQuinielas.Size = new Size(993, 322);
            dgvQuinielas.TabIndex = 0;
            // 
            // btnUnirse
            // 
            btnUnirse.Location = new Point(472, 429);
            btnUnirse.Name = "btnUnirse";
            btnUnirse.Size = new Size(172, 69);
            btnUnirse.TabIndex = 1;
            btnUnirse.Text = "Unirme a Quiniela";
            btnUnirse.UseVisualStyleBackColor = true;
            btnUnirse.Click += btnUnirse_Click;
            // 
            // txtNombreQuiniela
            // 
            txtNombreQuiniela.Location = new Point(37, 467);
            txtNombreQuiniela.Name = "txtNombreQuiniela";
            txtNombreQuiniela.Size = new Size(238, 31);
            txtNombreQuiniela.TabIndex = 2;
            // 
            // chkEsPrivada
            // 
            chkEsPrivada.AutoSize = true;
            chkEsPrivada.Location = new Point(37, 524);
            chkEsPrivada.Name = "chkEsPrivada";
            chkEsPrivada.Size = new Size(118, 29);
            chkEsPrivada.TabIndex = 3;
            chkEsPrivada.Text = "Es Privada";
            chkEsPrivada.UseVisualStyleBackColor = true;
            // 
            // btnCrearQuiniela
            // 
            btnCrearQuiniela.Location = new Point(163, 524);
            btnCrearQuiniela.Name = "btnCrearQuiniela";
            btnCrearQuiniela.Size = new Size(112, 34);
            btnCrearQuiniela.TabIndex = 4;
            btnCrearQuiniela.Text = "Crear Quiniela";
            btnCrearQuiniela.UseVisualStyleBackColor = true;
            btnCrearQuiniela.Click += btnCrearQuiniela_Click;
            // 
            // lblAsignarNombreQuiniela
            // 
            lblAsignarNombreQuiniela.AutoSize = true;
            lblAsignarNombreQuiniela.Location = new Point(75, 427);
            lblAsignarNombreQuiniela.Name = "lblAsignarNombreQuiniela";
            lblAsignarNombreQuiniela.Size = new Size(176, 25);
            lblAsignarNombreQuiniela.TabIndex = 5;
            lblAsignarNombreQuiniela.Text = "Nombre de Quiniela:";
            lblAsignarNombreQuiniela.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(403, 4);
            label1.Name = "label1";
            label1.Size = new Size(231, 25);
            label1.TabIndex = 6;
            label1.Text = "Lista de Quinielas Existentes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(433, 387);
            label2.Name = "label2";
            label2.Size = new Size(264, 25);
            label2.TabIndex = 7;
            label2.Text = "*Seleccione una fila para unirse*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 377);
            label3.Name = "label3";
            label3.Size = new Size(177, 25);
            label3.TabIndex = 8;
            label3.Text = "Crear Nueva Quiniela";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 402);
            label4.Name = "label4";
            label4.Size = new Size(173, 25);
            label4.TabIndex = 9;
            label4.Text = "-----------------------";
            // 
            // btnGenerarNotificaciones
            // 
            btnGenerarNotificaciones.Location = new Point(801, 497);
            btnGenerarNotificaciones.Name = "btnGenerarNotificaciones";
            btnGenerarNotificaciones.Size = new Size(202, 34);
            btnGenerarNotificaciones.TabIndex = 10;
            btnGenerarNotificaciones.Text = "Generar Notificaciones";
            btnGenerarNotificaciones.UseVisualStyleBackColor = true;
            btnGenerarNotificaciones.Click += btnGenerarNotificaciones_Click;
            // 
            // btnVerNotificaciones
            // 
            btnVerNotificaciones.Location = new Point(801, 418);
            btnVerNotificaciones.Name = "btnVerNotificaciones";
            btnVerNotificaciones.Size = new Size(202, 34);
            btnVerNotificaciones.TabIndex = 11;
            btnVerNotificaciones.Text = "Ver Notificaciones";
            btnVerNotificaciones.UseVisualStyleBackColor = true;
            btnVerNotificaciones.Click += btnVerNotificaciones_Click;
            // 
            // FrmQuiniela
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 577);
            Controls.Add(btnVerNotificaciones);
            Controls.Add(btnGenerarNotificaciones);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblAsignarNombreQuiniela);
            Controls.Add(btnCrearQuiniela);
            Controls.Add(chkEsPrivada);
            Controls.Add(txtNombreQuiniela);
            Controls.Add(btnUnirse);
            Controls.Add(dgvQuinielas);
            Name = "FrmQuiniela";
            Text = "Quinielas Disponibles";
            Load += FrmQuiniela_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuinielas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvQuinielas;
        private Button btnUnirse;
        private TextBox txtNombreQuiniela;
        private CheckBox chkEsPrivada;
        private Button btnCrearQuiniela;
        private Label lblAsignarNombreQuiniela;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnGenerarNotificaciones;
        private Button btnVerNotificaciones;
    }
}