namespace ProyectoTecnicasProgra.Models
{
    /// <summary>
    /// Entidad que gestiona la información, rol y los logros obtenidos por un usuario.
    /// </summary>
    public class Usuario
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario"; // "Admin" o "Usuario"

        // Lista de IDs o nombres de insignias obtenidas por el usuario
        public List<Insignia> Insignias { get; set; } = new List<Insignia>();
    }
}
