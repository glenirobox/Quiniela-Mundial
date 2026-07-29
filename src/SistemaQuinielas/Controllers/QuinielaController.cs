// QuinielaController.cs
using System.Collections.Generic;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;

namespace SistemaQuinielas.Controllers
{
    public class QuinielaController
    {
        private readonly QuinielaService servicio = new QuinielaService();

        public List<Quiniela> ObtenerQuinielas() => servicio.ObtenerQuinielas();
        public void CrearQuiniela(Quiniela quiniela) => servicio.CrearQuiniela(quiniela);
        public void UnirseAQuiniela(int idQuiniela, int idUsuario) => servicio.UnirUsuarioAQuiniela(idQuiniela, idUsuario);
    }
}