public class Partido
{
    public int Id { get; set;}
    public string EquipoLocal { get; set;} = string.Empty;
    public string EquipoVisitante { get; set; } = string.Empty;
    public DateTime Fecha { get; set;}
    public int GolesLocal { get; set;}
    public int GolesVisitante { get; set;}
}