using System.Collections.Generic;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;

namespace SistemaQuinielas.Controllers
{
    public class PartidoController
    {
        private readonly PartidoService servicio = new PartidoService();
        private readonly PronosticoService servicioPronosticos = new PronosticoService();

        public List<Partido> ObtenerPartidos() => servicio.ObtenerPartidos();
        public List<PosicionEquipo> ObtenerTablaPosiciones(string grupo) => servicio.ObtenerTablaPosiciones(grupo);

        public void FinalizarPartidoYCalcularPuntos(int idPartido)
        {
            servicio.FinalizarPartido(idPartido);

            Partido? partido = servicio.ObtenerPartidos().Find(p => p.Id == idPartido);
            if (partido != null)
            {
                servicioPronosticos.CalcularPuntosPorPartido(partido);
            }
        }
    }
}