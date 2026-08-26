namespace ProyectoTecnicasProgra.Models
{
    /// <summary>
    /// Representa una insignia o logro obtenido por un usuario en la quiniela.
    /// </summary>
    public class Insignia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
    }
}
