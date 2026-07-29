using System.Collections.Generic;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;

namespace SistemaQuinielas.Controllers
{
    public class InsigniaController
    {
        private readonly InsigniaService servicio = new InsigniaService();

        public List<Insignia> ObtenerInsignias() => servicio.ObtenerInsignias();
        public void CalcularYAsignarInsignias() => servicio.CalcularYAsignarInsignias();
    }
}