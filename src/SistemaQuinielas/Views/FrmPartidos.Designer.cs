namespace SistemaQuinielas.Views
{
    partial class FrmPartidos
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
            dgvPartidos = new DataGridView();
            btnFinalizarPartido = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPartidos).BeginInit();
            SuspendLayout();
            // 
            // dgvPartidos
            // 
            dgvPartidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidos.Location = new Point(12, 12);
            dgvPartidos.Name = "dgvPartidos";
            dgvPartidos.RowHeadersWidth = 62;
            dgvPartidos.Size = new Size(768, 360);
            dgvPartidos.TabIndex = 0;
            // 
            // btnFinalizarPartido
            // 
            btnFinalizarPartido.Location = new Point(213, 395);
            btnFinalizarPartido.Name = "btnFinalizarPartido";
            btnFinalizarPartido.Size = new Size(316, 34);
            btnFinalizarPartido.TabIndex = 1;
            btnFinalizarPartido.Text = "Finalizar Partido y Calcular Puntos ";
            btnFinalizarPartido.UseVisualStyleBackColor = true;
            btnFinalizarPartido.Click += btnFinalizarPartido_Click;
            // 
            // FrmPartidos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFinalizarPartido);
            Controls.Add(dgvPartidos);
            Name = "FrmPartidos";
            Text = "Partidos";
            Load += FrmPartidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPartidos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPartidos;
        private Button btnFinalizarPartido;
    }
}