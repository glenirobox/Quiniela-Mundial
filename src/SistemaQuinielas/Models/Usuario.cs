using System.Collections.Generic;

namespace SistemaQuinielas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string PaisFavorito { get; set; } = string.Empty;
        public int Puntos { get; set; }
        public string Rol { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public List<int> IdsQuinielas { get; set; } = new List<int>();
        public List<int> IdsInsignias { get; set; } = new List<int>();
    }
}