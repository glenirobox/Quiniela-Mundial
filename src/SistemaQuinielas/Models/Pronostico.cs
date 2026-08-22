namespace SistemaQuinielas.Models
{
    public class Pronostico
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPartido { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public int PuntosObtenidos { get; set; }
    }
}