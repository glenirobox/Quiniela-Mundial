namespace SistemaQuinielas.Models
{
    public class PosicionEquipo
    {
        public string Equipo { get; set; } = string.Empty;
        public int PartidosJugados { get; set; }
        public int Puntos { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int Diferencia { get; set; }
        public string Clasificado { get; set; } = string.Empty;
    }
}