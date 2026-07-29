using System;
namespace SistemaQuinielas.Models
{
    public class Notificacion
    {
        public int IdQuiniela { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}