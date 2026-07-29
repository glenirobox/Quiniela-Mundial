using System.Collections.Generic;
namespace SistemaQuinielas.Models
{
    public class Quiniela
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool EsPrivada { get; set; }
        public int IdCreador { get; set; }
        public List<int> IdsUsuarios { get; set; } = new List<int>();
    }
}