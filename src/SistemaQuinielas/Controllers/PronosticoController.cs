// PronosticoController.cs
using System.Collections.Generic;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;

namespace SistemaQuinielas.Controllers
{
    public class PronosticoController
    {
        private readonly PronosticoService servicio = new PronosticoService();

        public List<Pronostico> ObtenerPronosticos() => servicio.ObtenerPronosticos();
        public void GuardarPronostico(Pronostico pronostico) => servicio.GuardarPronostico(pronostico);
        public void CalcularPuntos(Partido partido) => servicio.CalcularPuntosPorPartido(partido);
    }
}