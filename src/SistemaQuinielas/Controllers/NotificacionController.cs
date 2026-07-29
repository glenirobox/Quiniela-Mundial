using System.Collections.Generic;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;

namespace SistemaQuinielas.Controllers
{
    public class NotificacionController
    {
        private readonly NotificacionService servicio = new NotificacionService();

        public List<Notificacion> ObtenerNotificacionesPorQuiniela(int idQuiniela) => servicio.ObtenerNotificacionesPorQuiniela(idQuiniela);
        public void GenerarNotificaciones() => servicio.GenerarNotificaciones();
    }
}