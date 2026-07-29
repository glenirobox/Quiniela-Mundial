using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaQuinielas.Models;
using SistemaQuinielas.Controllers;
using SistemaQuinielas.Utils;

namespace SistemaQuinielas.Views
{
    public partial class FrmEstadisticas : Form
    {
        private PartidoController controladorPartidos = new PartidoController();
        private PronosticoController controladorPronosticos = new PronosticoController();
        private UsuarioController controladorUsuarios = new UsuarioController();
        private InsigniaController controladorInsignias = new InsigniaController();

        public FrmEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            cmbVista.Items.Clear();
            cmbVista.Items.Add("Ranking");
            cmbVista.Items.Add("Historial de Pronosticos");
            cmbVista.Items.Add("Ultimos 5 Partidos");
            cmbVista.Items.Add("Proximos Partidos");
            cmbVista.Items.Add("Tabla de Posiciones");
            cmbVista.SelectedIndex = 0;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (cmbVista.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de vista.");
                return;
            }

            string vista = cmbVista.SelectedItem.ToString() ?? string.Empty;
            dgvResultados.DataSource = null;

            switch (vista)
            {
                case "Ranking":
                    dgvResultados.DataSource = controladorUsuarios.ObtenerUsuarios()
                        .OrderByDescending(u => u.Puntos)
                        .ToList();
                    break;

                case "Historial de Pronosticos":
                    if (SesionActual.UsuarioActual == null)
                    {
                        MessageBox.Show("No hay un usuario en sesión.");
                        return;
                    }
                    dgvResultados.DataSource = controladorPronosticos.ObtenerPronosticos()
                        .Where(p => p.IdUsuario == SesionActual.UsuarioActual.Id)
                        .ToList();
                    break;

                case "Ultimos 5 Partidos":
                    dgvResultados.DataSource = controladorPartidos.ObtenerPartidos()
                        .Where(p => p.Fecha <= DateTime.Now)
                        .OrderByDescending(p => p.Fecha)
                        .Take(5)
                        .ToList();
                    break;

                case "Proximos Partidos":
                    dgvResultados.DataSource = controladorPartidos.ObtenerPartidos()
                        .Where(p => p.Fecha > DateTime.Now)
                        .OrderBy(p => p.Fecha)
                        .Take(5)
                        .ToList();
                    break;

                case "Tabla de Posiciones":
                    if (string.IsNullOrWhiteSpace(txtGrupo.Text))
                    {
                        MessageBox.Show("Escriba la letra del grupo (ej. A).");
                        return;
                    }
                    dgvResultados.DataSource = controladorPartidos.ObtenerTablaPosiciones(txtGrupo.Text.Trim().ToUpper());
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var partidos = controladorPartidos.ObtenerPartidos();
            var pronosticos = controladorPronosticos.ObtenerPronosticos();
            var usuarios = controladorUsuarios.ObtenerUsuarios();

            if (partidos.Count == 0)
            {
                lblEstadisticas.Text = "No hay partidos cargados para calcular estadísticas.";
                return;
            }

            int totalGoles = 0;
            foreach (Partido p in partidos)
            {
                totalGoles += p.GolesLocal + p.GolesVisitante;
            }
            double promedioGoles = (double)totalGoles / partidos.Count;

            Dictionary<string, int> conteoEquipos = new Dictionary<string, int>();

            foreach (Pronostico pron in pronosticos)
            {
                Partido? partido = partidos.FirstOrDefault(p => p.Id == pron.IdPartido);
                if (partido == null) continue;

                if (!conteoEquipos.ContainsKey(partido.EquipoLocal))
                    conteoEquipos[partido.EquipoLocal] = 0;
                conteoEquipos[partido.EquipoLocal]++;

                if (!conteoEquipos.ContainsKey(partido.EquipoVisitante))
                    conteoEquipos[partido.EquipoVisitante] = 0;
                conteoEquipos[partido.EquipoVisitante]++;
            }

            string equipoMasApostado = "N/A";
            int maxConteoEquipo = 0;
            foreach (var par in conteoEquipos)
            {
                if (par.Value > maxConteoEquipo)
                {
                    maxConteoEquipo = par.Value;
                    equipoMasApostado = par.Key;
                }
            }

            Dictionary<int, int> conteoPorPartido = new Dictionary<int, int>();

            foreach (Pronostico pron in pronosticos)
            {
                if (!conteoPorPartido.ContainsKey(pron.IdPartido))
                    conteoPorPartido[pron.IdPartido] = 0;
                conteoPorPartido[pron.IdPartido]++;
            }

            string nombrePartidoTop = "N/A";
            int maxConteoPartido = 0;
            foreach (var par in conteoPorPartido)
            {
                if (par.Value > maxConteoPartido)
                {
                    maxConteoPartido = par.Value;
                    Partido? partidoTop = partidos.FirstOrDefault(p => p.Id == par.Key);
                    if (partidoTop != null)
                    {
                        nombrePartidoTop = $"{partidoTop.EquipoLocal} vs {partidoTop.EquipoVisitante}";
                    }
                }
            }

            string nombreUsuarioTop = "N/A";
            int maxPuntos = -1;
            foreach (Usuario u in usuarios)
            {
                if (u.Puntos > maxPuntos)
                {
                    maxPuntos = u.Puntos;
                    nombreUsuarioTop = u.Nombre;
                }
            }

            lblEstadisticas.Text =
                $"Promedio de goles por partido: {promedioGoles:F2}\r\n" +
                $"Equipo más apostado: {equipoMasApostado}\r\n" +
                $"Partido con más pronósticos: {nombrePartidoTop}\r\n" +
                $"Usuario con más puntos: {nombreUsuarioTop}";
        }

        private void btnCalcularInsignias_Click(object sender, EventArgs e)
        {
            controladorInsignias.CalcularYAsignarInsignias();
            MessageBox.Show("Insignias calculadas y asignadas correctamente.");
        }
    }
}