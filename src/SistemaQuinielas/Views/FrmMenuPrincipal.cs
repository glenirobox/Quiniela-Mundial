using SistemaQuinielas.Models;
using SistemaQuinielas.Services;
using SistemaQuinielas.Views;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace SistemaQuinielas
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();

        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Menú Principal - " + SistemaQuinielas.Utils.SesionActual.UsuarioActual?.Nombre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios gestionUsuarios = new FrmGestionUsuarios();
            gestionUsuarios.ShowDialog();
        }

        private void btnPartidos_Click(object sender, EventArgs e)
        {
            FrmPartidos partidos = new FrmPartidos();
            partidos.ShowDialog();
        }

        private void btnQuinielas_Click(object sender, EventArgs e)
        {
            FrmQuiniela quiniela = new FrmQuiniela();
            quiniela.ShowDialog();
        }

        private void btnPronosticos_Click(object sender, EventArgs e)
        {
            FrmPronostico pronostico = new FrmPronostico();
            pronostico.ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticas estadisticas = new FrmEstadisticas();
            estadisticas.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //cierra el menú y vuelve a abrir la pantalla de Login limpiando la sesión
            Application.Restart();
        }
    }
}
