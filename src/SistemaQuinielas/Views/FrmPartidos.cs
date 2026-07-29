using System;
using System.Windows.Forms;
using SistemaQuinielas.Models;
using SistemaQuinielas.Controllers;

namespace SistemaQuinielas.Views
{
    public partial class FrmPartidos : Form
    {
        private PartidoController controladorPartidos = new PartidoController();

        public FrmPartidos()
        {
            InitializeComponent();
            CargarPartidos();
        }

        private void CargarPartidos()
        {
            dgvPartidos.DataSource = null;
            dgvPartidos.DataSource = controladorPartidos.ObtenerPartidos();
        }

        private void FrmPartidos_Load(object sender, EventArgs e)
        {

        }

        private void btnFinalizarPartido_Click(object sender, EventArgs e)
        {
            if (dgvPartidos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un partido de la lista.");
                return;
            }

            Partido? partidoSeleccionado = dgvPartidos.CurrentRow.DataBoundItem as Partido;

            if (partidoSeleccionado == null)
            {
                MessageBox.Show("No se pudo identificar el partido seleccionado.");
                return;
            }

            if (partidoSeleccionado.Estado == EstadoPartido.Finalizado)
            {
                MessageBox.Show("Este partido ya fue finalizado.");
                return;
            }

            try
            {
                controladorPartidos.FinalizarPartidoYCalcularPuntos(partidoSeleccionado.Id);
                MessageBox.Show("Partido finalizado y puntos calculados correctamente.");
                CargarPartidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}