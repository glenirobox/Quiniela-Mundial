using ProyectoTecnicasProgra.Models;

namespace ProyectoTecnicasProgra.Data;

public class DatosMemoria
{
    public List<Usuario> Usuarios { get; set; } = new()
    {
        new Usuario { Username = "Admin", Password = "123", Rol = "Admin" },
        new Usuario { Username = "Glen", Password = "123", Rol = "Usuario" }
    };

    public List<Partido> Partidos { get; set; } = new()
    {
        new Partido { Id = 1, EquipoLocal = "México", EquipoVisitante = "Sudáfrica", Fecha = DateTime.Now.AddDays(-1), GolesLocal = 2, GolesVisitante = 1, Finalizado = true },
        new Partido { Id = 2, EquipoLocal = "Costa Rica", EquipoVisitante = "Alemania", Fecha = DateTime.Now.AddDays(1), Finalizado = false },
        new Partido { Id = 3, EquipoLocal = "Brasil", EquipoVisitante = "Argentina", Fecha = DateTime.Now.AddDays(2), Finalizado = false },
        new Partido { Id = 4, EquipoLocal = "España", EquipoVisitante = "Francia", Fecha = DateTime.Now.AddDays(3), Finalizado = false }
    };

    public List<Pronostico> Pronosticos { get; set; } = new();

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