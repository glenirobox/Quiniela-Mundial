namespace ProyectoTecnicasProgra.Models
{
    public class Usuario
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario"; // "Admin" o "Usuario"
    }
}
