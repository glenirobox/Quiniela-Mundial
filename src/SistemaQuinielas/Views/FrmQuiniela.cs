using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaQuinielas.Models;
using SistemaQuinielas.Controllers;
using SistemaQuinielas.Utils;

namespace SistemaQuinielas.Views
{
    public partial class FrmQuiniela : Form
    {
        private QuinielaController controladorQuinielas = new QuinielaController();
        private NotificacionController controladorNotificaciones = new NotificacionController();

        public FrmQuiniela()
        {
            InitializeComponent();
            CargarQuinielas();
        }

        private void CargarQuinielas()
        {
            dgvQuinielas.DataSource = null;
            dgvQuinielas.DataSource = controladorQuinielas.ObtenerQuinielas();
        }

        private void btnCrearQuiniela_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreQuiniela.Text))
            {
                MessageBox.Show("Debe escribir un nombre para la quiniela.");
                return;
            }

            if (SesionActual.UsuarioActual == null)
            {
                MessageBox.Show("No hay un usuario en sesión.");
                return;
            }

            Quiniela nueva = new Quiniela();
            nueva.Nombre = txtNombreQuiniela.Text.Trim();
            nueva.EsPrivada = chkEsPrivada.Checked;
            nueva.IdCreador = SesionActual.UsuarioActual.Id;

            try
            {
                controladorQuinielas.CrearQuiniela(nueva);
                MessageBox.Show("Quiniela creada correctamente.");
                txtNombreQuiniela.Clear();
                chkEsPrivada.Checked = false;
                CargarQuinielas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnirse_Click(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioActual == null)
            {
                MessageBox.Show("No hay un usuario en sesión.");
                return;
            }

            if (dgvQuinielas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una quiniela de la lista.");
                return;
            }

            Quiniela? seleccionada = dgvQuinielas.CurrentRow.DataBoundItem as Quiniela;

            if (seleccionada == null)
            {
                MessageBox.Show("No se pudo identificar la quiniela seleccionada.");
                return;
            }

            try
            {
                controladorQuinielas.UnirseAQuiniela(seleccionada.Id, SesionActual.UsuarioActual.Id);
                MessageBox.Show("Te uniste a la quiniela.");
                CargarQuinielas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerarNotificaciones_Click(object sender, EventArgs e)
        {
            controladorNotificaciones.GenerarNotificaciones();
            MessageBox.Show("Notificaciones generadas correctamente.");
        }

        private void btnVerNotificaciones_Click(object sender, EventArgs e)
        {
            if (dgvQuinielas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una quiniela de la lista.");
                return;
            }

            Quiniela? seleccionada = dgvQuinielas.CurrentRow.DataBoundItem as Quiniela;

            if (seleccionada == null)
            {
                MessageBox.Show("No se pudo identificar la quiniela seleccionada.");
                return;
            }

            var notificaciones = controladorNotificaciones.ObtenerNotificacionesPorQuiniela(seleccionada.Id);

            if (notificaciones.Count == 0)
            {
                MessageBox.Show("Esta quiniela no tiene notificaciones todavía.");
                return;
            }

            StringBuilder texto = new StringBuilder();
            foreach (Notificacion n in notificaciones)
            {
                texto.AppendLine($"[{n.Fecha:dd/MM HH:mm}] {n.Mensaje}");
            }

            MessageBox.Show(texto.ToString(), $"Timeline - {seleccionada.Nombre}");
        }

        private void FrmQuiniela_Load(object sender, EventArgs e)
        {

        }
    }
}