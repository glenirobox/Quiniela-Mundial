namespace SistemaQuinielas.Views
{
    partial class FrmEstadisticas
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
            cmbVista = new ComboBox();
            btnVer = new Button();
            label2 = new Label();
            dgvResultados = new DataGridView();
            label3 = new Label();
            button1 = new Button();
            lblEstadisticas = new Label();
            btnCalcularInsignias = new Button();
            txtGrupo = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 13);
            label1.Name = "label1";
            label1.Size = new Size(155, 32);
            label1.TabIndex = 0;
            label1.Text = "Tipo de vista:";
            // 
            // cmbVista
            // 
            cmbVista.FormattingEnabled = true;
            cmbVista.Location = new Point(26, 59);
            cmbVista.Name = "cmbVista";
            cmbVista.Size = new Size(216, 33);
            cmbVista.TabIndex = 1;
            // 
            // btnVer
            // 
            btnVer.Location = new Point(814, 59);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(112, 34);
            btnVer.TabIndex = 2;
            btnVer.Text = "Ver";
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 123);
            label2.Name = "label2";
            label2.Size = new Size(682, 25);
            label2.TabIndex = 3;
            label2.Text = "----------------------------------- Resultados de la vista -----------------------------------";
            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(74, 151);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 62;
            dgvResultados.Size = new Size(1069, 225);
            dgvResultados.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(277, 392);
            label3.Name = "label3";
            label3.Size = new Size(673, 25);
            label3.TabIndex = 5;
            label3.Text = "----------------------------------- Resumen Estadistico -----------------------------------";
            // 
            // button1
            // 
            button1.Location = new Point(74, 427);
            button1.Name = "button1";
            button1.Size = new Size(201, 54);
            button1.TabIndex = 6;
            button1.Text = "Calcular Estadisticas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.BorderStyle = BorderStyle.FixedSingle;
            lblEstadisticas.Location = new Point(74, 497);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(682, 150);
            lblEstadisticas.TabIndex = 7;
            // 
            // btnCalcularInsignias
            // 
            btnCalcularInsignias.Location = new Point(942, 457);
            btnCalcularInsignias.Name = "btnCalcularInsignias";
            btnCalcularInsignias.Size = new Size(201, 54);
            btnCalcularInsignias.TabIndex = 8;
            btnCalcularInsignias.Text = "Calcular Insignias";
            btnCalcularInsignias.UseVisualStyleBackColor = true;
            btnCalcularInsignias.Click += btnCalcularInsignias_Click;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(310, 62);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(288, 31);
            txtGrupo.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(310, 28);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 10;
            label4.Text = "Grupo:";
            // 
            // FrmEstadisticas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 662);
            Controls.Add(label4);
            Controls.Add(txtGrupo);
            Controls.Add(btnCalcularInsignias);
            Controls.Add(lblEstadisticas);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(dgvResultados);
            Controls.Add(label2);
            Controls.Add(btnVer);
            Controls.Add(cmbVista);
            Controls.Add(label1);
            Name = "FrmEstadisticas";
            Text = "Estadisticas y Reportes";
            Load += FrmEstadisticas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbVista;
        private Button btnVer;
        private Label label2;
        private DataGridView dgvResultados;
        private Label label3;
        private Button button1;
        private Label lblEstadisticas;
        private Button btnCalcularInsignias;
        private TextBox txtGrupo;
        private Label label4;
    }
}