using ProyectoTecnicasProgra.Models;

namespace ProyectoTecnicasProgra.Data;

public class DatosMemoria
{
    public List<Usuario> Usuarios { get; set; } = new()
    {
        new Usuario { Username = "Admin", Password = "123", Rol = "Admin" },
        new Usuario { Username = "Glen", Password = "123", Rol = "Usuario" }
    };

    public Usuario? UsuarioActual { get; set; }

    public bool ValidarLogin(string username, string password)
    {
        var user = Usuarios.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);

        if (user != null)
        {
            UsuarioActual = user;
            return true;
        }

        return false;
    }
}
