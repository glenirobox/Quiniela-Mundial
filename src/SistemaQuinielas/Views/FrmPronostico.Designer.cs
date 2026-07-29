namespace SistemaQuinielas.Views
{
    partial class FrmPronostico
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
            label3 = new Label();
            dgvPartidosDisponibles = new DataGridView();
            btnGuardarPronostico = new Button();
            numGolesLocal = new NumericUpDown();
            numGolesVisitante = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPartidosDisponibles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGolesLocal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGolesVisitante).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(415, 9);
            label1.Name = "label1";
            label1.Size = new Size(239, 25);
            label1.TabIndex = 0;
            label1.Text = "Lista de Partidos Disponibles";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(448, 431);
            label3.Name = "label3";
            label3.Size = new Size(166, 25);
            label3.TabIndex = 2;
            label3.Text = "Ingresar Pronóstico";
            // 
            // dgvPartidosDisponibles
            // 
            dgvPartidosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidosDisponibles.Location = new Point(41, 43);
            dgvPartidosDisponibles.Name = "dgvPartidosDisponibles";
            dgvPartidosDisponibles.RowHeadersWidth = 62;
            dgvPartidosDisponibles.Size = new Size(1042, 366);
            dgvPartidosDisponibles.TabIndex = 3;
            dgvPartidosDisponibles.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnGuardarPronostico
            // 
            btnGuardarPronostico.Location = new Point(448, 573);
            btnGuardarPronostico.Name = "btnGuardarPronostico";
            btnGuardarPronostico.Size = new Size(179, 40);
            btnGuardarPronostico.TabIndex = 4;
            btnGuardarPronostico.Text = "Guardar Pronóstico";
            btnGuardarPronostico.UseVisualStyleBackColor = true;
            btnGuardarPronostico.Click += button1_Click;
            // 
            // numGolesLocal
            // 
            numGolesLocal.Location = new Point(326, 502);
            numGolesLocal.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numGolesLocal.Name = "numGolesLocal";
            numGolesLocal.Size = new Size(180, 31);
            numGolesLocal.TabIndex = 5;
            numGolesLocal.ValueChanged += numGolesLocal_ValueChanged;
            // 
            // numGolesVisitante
            // 
            numGolesVisitante.Location = new Point(570, 502);
            numGolesVisitante.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numGolesVisitante.Name = "numGolesVisitante";
            numGolesVisitante.Size = new Size(180, 31);
            numGolesVisitante.TabIndex = 6;
            numGolesVisitante.ValueChanged += numGolesVisitante_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(622, 474);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 7;
            label4.Text = "Goles Visitante";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(326, 474);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 8;
            label5.Text = "Goles Local";
            // 
            // FrmPronostico
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 642);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numGolesVisitante);
            Controls.Add(numGolesLocal);
            Controls.Add(btnGuardarPronostico);
            Controls.Add(dgvPartidosDisponibles);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FrmPronostico";
            Text = "Pronostico";
            Load += FrmPronostico_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPartidosDisponibles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGolesLocal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGolesVisitante).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private DataGridView dgvPartidosDisponibles;
        private Button btnGuardarPronostico;
        private NumericUpDown numGolesLocal;
        private NumericUpDown numGolesVisitante;
        private Label label4;
        private Label label5;
    }
}