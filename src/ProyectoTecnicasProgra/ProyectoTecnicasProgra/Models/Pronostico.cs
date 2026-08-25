namespace ProyectoTecnicasProgra.Models;

public class Pronostico
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public int PartidoId { get; set; }
    public int GolesLocalPredichos { get; set; }
    public int GolesVisitantePredichos { get; set; }
    public int PuntosObtenidos { get; set; }
}