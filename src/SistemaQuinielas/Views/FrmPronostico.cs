using System;
using System.Windows.Forms;
using SistemaQuinielas.Models;
using SistemaQuinielas.Controllers;
using SistemaQuinielas.Utils;

namespace SistemaQuinielas.Views
{
    public partial class FrmPronostico : Form
    {
        private PartidoController controladorPartidos = new PartidoController();
        private PronosticoController controladorPronosticos = new PronosticoController();

        public FrmPronostico()
        {
            InitializeComponent();
            CargarPartidos();
        }

        private void CargarPartidos()
        {
            dgvPartidosDisponibles.DataSource = null;
            dgvPartidosDisponibles.DataSource = controladorPartidos.ObtenerPartidos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioActual == null)
            {
                MessageBox.Show("No hay un usuario en sesión.");
                return;
            }

            if (dgvPartidosDisponibles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un partido de la lista.");
                return;
            }

            Partido? partidoSeleccionado = dgvPartidosDisponibles.CurrentRow.DataBoundItem as Partido;

            if (partidoSeleccionado == null)
            {
                MessageBox.Show("No se pudo identificar el partido seleccionado.");
                return;
            }

            Pronostico nuevo = new Pronostico();
            nuevo.IdUsuario = SesionActual.UsuarioActual.Id;
            nuevo.IdPartido = partidoSeleccionado.Id;
            nuevo.GolesLocal = (int)numGolesLocal.Value;
            nuevo.GolesVisitante = (int)numGolesVisitante.Value;

            try
            {
                controladorPronosticos.GuardarPronostico(nuevo);
                MessageBox.Show("Pronóstico guardado correctamente.");
                numGolesLocal.Value = 0;
                numGolesVisitante.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmPronostico_Load(object sender, EventArgs e)
        {

        }

        private void numGolesLocal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numGolesVisitante_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}