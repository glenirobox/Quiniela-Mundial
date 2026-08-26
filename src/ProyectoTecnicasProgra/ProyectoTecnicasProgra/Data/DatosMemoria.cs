using ProyectoTecnicasProgra.Models;

namespace ProyectoTecnicasProgra.Data;

public class DatosMemoria
{
    public List<Usuario> Usuarios { get; set; } = new()
    {
        new Usuario { Username = "Admin", Password = "123", Rol = "Admin" },
        new Usuario { Username = "Glen", Password = "123", Rol = "Usuario" },
        new Usuario { Username = "Carlos", Password = "123", Rol = "Usuario" },
        new Usuario { Username = "Maria", Password = "123", Rol = "Usuario" },
        new Usuario { Username = "Andres", Password = "123", Rol = "Usuario" },
        new Usuario { Username = "Sofia", Password = "123", Rol = "Usuario" },
        new Usuario { Username = "Luis", Password = "123", Rol = "Usuario" }
    };

    // Catálogo de Insignias disponibles
    public List<Insignia> InsigniasDisponibles { get; set; } = new()
    {
        new Insignia { Id = 1, Nombre = "Primer Pronóstico", Descripcion = "Otorgado al guardar el primer pronóstico en la quiniela.", Icono = "🎯" },
        new Insignia { Id = 2, Nombre = "Estratega", Descripcion = "Otorgado por registrar 5 o más pronósticos.", Icono = "🧠" },
        new Insignia { Id = 3, Nombre = "Experto del Mundial", Descripcion = "Otorgado por registrar 10 o más pronósticos.", Icono = "🏆" }
    };

    public List<Partido> Partidos { get; set; } = new()
    {
        new Partido { Id = 1, EquipoLocal = "Mexico", EquipoVisitante = "Sudafrica", Fecha = DateTime.Parse("2026-06-11"), GolesLocal = 2, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 2, EquipoLocal = "Brasil", EquipoVisitante = "Marruecos", Fecha = DateTime.Parse("2026-06-13"), GolesLocal = 2, GolesVisitante = 1, Finalizado = true },
        new Partido { Id = 3, EquipoLocal = "Haiti", EquipoVisitante = "Escocia", Fecha = DateTime.Parse("2026-06-13"), GolesLocal = 1, GolesVisitante = 1, Finalizado = true },
        new Partido { Id = 4, EquipoLocal = "Brasil", EquipoVisitante = "Haiti", Fecha = DateTime.Parse("2026-06-19"), GolesLocal = 3, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 5, EquipoLocal = "Escocia", EquipoVisitante = "Marruecos", Fecha = DateTime.Parse("2026-06-19"), GolesLocal = 0, GolesVisitante = 2, Finalizado = true },
        new Partido { Id = 6, EquipoLocal = "Francia", EquipoVisitante = "Senegal", Fecha = DateTime.Parse("2026-06-16"), GolesLocal = 3, GolesVisitante = 1, Finalizado = true },
        new Partido { Id = 7, EquipoLocal = "Noruega", EquipoVisitante = "Francia", Fecha = DateTime.Parse("2026-06-22"), GolesLocal = 1, GolesVisitante = 4, Finalizado = true },
        new Partido { Id = 8, EquipoLocal = "Senegal", EquipoVisitante = "Irak", Fecha = DateTime.Parse("2026-06-22"), GolesLocal = 5, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 9, EquipoLocal = "Japon", EquipoVisitante = "Tunez", Fecha = DateTime.Parse("2026-06-15"), GolesLocal = 4, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 10, EquipoLocal = "Paraguay", EquipoVisitante = "Turquia", Fecha = DateTime.Parse("2026-06-16"), GolesLocal = 1, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 11, EquipoLocal = "Argelia", EquipoVisitante = "Austria", Fecha = DateTime.Parse("2026-06-17"), GolesLocal = 3, GolesVisitante = 3, Finalizado = true },
        new Partido { Id = 12, EquipoLocal = "Jordania", EquipoVisitante = "Argentina", Fecha = DateTime.Parse("2026-06-17"), GolesLocal = 1, GolesVisitante = 3, Finalizado = true },
        new Partido { Id = 13, EquipoLocal = "Inglaterra", EquipoVisitante = "Croacia", Fecha = DateTime.Parse("2026-06-17"), Finalizado = false },
        new Partido { Id = 14, EquipoLocal = "Ghana", EquipoVisitante = "Panama", Fecha = DateTime.Parse("2026-06-17"), Finalizado = false },
        new Partido { Id = 15, EquipoLocal = "Inglaterra", EquipoVisitante = "Ghana", Fecha = DateTime.Parse("2026-06-23"), Finalizado = false },
        new Partido { Id = 16, EquipoLocal = "Panama", EquipoVisitante = "Croacia", Fecha = DateTime.Parse("2026-06-23"), Finalizado = false },
        new Partido { Id = 17, EquipoLocal = "Panama", EquipoVisitante = "Inglaterra", Fecha = DateTime.Parse("2026-06-27"), Finalizado = false },
        new Partido { Id = 18, EquipoLocal = "Croacia", EquipoVisitante = "Ghana", Fecha = DateTime.Parse("2026-06-27"), Finalizado = false },
        new Partido { Id = 19, EquipoLocal = "Portugal", EquipoVisitante = "Uzbekistan", Fecha = DateTime.Parse("2026-06-23"), GolesLocal = 5, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 20, EquipoLocal = "Colombia", EquipoVisitante = "RDCongo", Fecha = DateTime.Parse("2026-06-23"), GolesLocal = 1, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 21, EquipoLocal = "Colombia", EquipoVisitante = "Portugal", Fecha = DateTime.Parse("2026-06-27"), GolesLocal = 0, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 22, EquipoLocal = "RDCongo", EquipoVisitante = "Uzbekistan", Fecha = DateTime.Parse("2026-06-27"), GolesLocal = 3, GolesVisitante = 1, Finalizado = true },
        new Partido { Id = 23, EquipoLocal = "CaboVerde", EquipoVisitante = "ArabiaSaudita", Fecha = DateTime.Parse("2026-06-26"), GolesLocal = 0, GolesVisitante = 0, Finalizado = true },
        new Partido { Id = 24, EquipoLocal = "Uruguay", EquipoVisitante = "Espana", Fecha = DateTime.Parse("2026-06-26"), GolesLocal = 0, GolesVisitante = 1, Finalizado = true },
        new Partido { Id = 25, EquipoLocal = "Alemania", EquipoVisitante = "Curazao", Fecha = DateTime.Parse("2026-08-05"), Finalizado = false },
        new Partido { Id = 26, EquipoLocal = "PaisesBajos", EquipoVisitante = "Japon", Fecha = DateTime.Parse("2026-08-08"), Finalizado = false },
        new Partido { Id = 27, EquipoLocal = "EstadosUnidos", EquipoVisitante = "Bolivia", Fecha = DateTime.Parse("2026-06-12"), Finalizado = false },
        new Partido { Id = 28, EquipoLocal = "Canada", EquipoVisitante = "Nigeria", Fecha = DateTime.Parse("2026-06-12"), Finalizado = false },
        new Partido { Id = 29, EquipoLocal = "Italia", EquipoVisitante = "Ecuador", Fecha = DateTime.Parse("2026-06-13"), Finalizado = false },
        new Partido { Id = 30, EquipoLocal = "Belgica", EquipoVisitante = "Egipto", Fecha = DateTime.Parse("2026-06-14"), Finalizado = false },
        new Partido { Id = 31, EquipoLocal = "CoreaDelSur", EquipoVisitante = "Australia", Fecha = DateTime.Parse("2026-06-14"), Finalizado = false },
        new Partido { Id = 32, EquipoLocal = "Suiza", EquipoVisitante = "Camerun", Fecha = DateTime.Parse("2026-06-15"), Finalizado = false },
        new Partido { Id = 33, EquipoLocal = "Dinamarca", EquipoVisitante = "Chile", Fecha = DateTime.Parse("2026-06-15"), Finalizado = false },
        new Partido { Id = 34, EquipoLocal = "Iran", EquipoVisitante = "NuevaZelanda", Fecha = DateTime.Parse("2026-06-16"), Finalizado = false },
        new Partido { Id = 35, EquipoLocal = "Mexico", EquipoVisitante = "CoreaDelSur", Fecha = DateTime.Parse("2026-06-18"), Finalizado = false },
        new Partido { Id = 36, EquipoLocal = "Sudafrica", EquipoVisitante = "Australia", Fecha = DateTime.Parse("2026-06-18"), Finalizado = false },
        new Partido { Id = 37, EquipoLocal = "Canada", EquipoVisitante = "Italia", Fecha = DateTime.Parse("2026-06-18"), Finalizado = false },
        new Partido { Id = 38, EquipoLocal = "Nigeria", EquipoVisitante = "Ecuador", Fecha = DateTime.Parse("2026-06-18"), Finalizado = false },
        new Partido { Id = 39, EquipoLocal = "EstadosUnidos", EquipoVisitante = "Paraguay", Fecha = DateTime.Parse("2026-06-19"), Finalizado = false },
        new Partido { Id = 40, EquipoLocal = "Bolivia", EquipoVisitante = "Turquia", Fecha = DateTime.Parse("2026-06-19"), Finalizado = false },
        new Partido { Id = 41, EquipoLocal = "Alemania", EquipoVisitante = "Belgica", Fecha = DateTime.Parse("2026-06-20"), Finalizado = false },
        new Partido { Id = 42, EquipoLocal = "Curazao", EquipoVisitante = "Egipto", Fecha = DateTime.Parse("2026-06-20"), Finalizado = false },
        new Partido { Id = 43, EquipoLocal = "PaisesBajos", EquipoVisitante = "Tunez", Fecha = DateTime.Parse("2026-06-20"), Finalizado = false },
        new Partido { Id = 44, EquipoLocal = "Suiza", EquipoVisitante = "Dinamarca", Fecha = DateTime.Parse("2026-06-21"), Finalizado = false },
        new Partido { Id = 45, EquipoLocal = "Camerun", EquipoVisitante = "Chile", Fecha = DateTime.Parse("2026-06-21"), Finalizado = false },
        new Partido { Id = 46, EquipoLocal = "Espana", EquipoVisitante = "ArabiaSaudita", Fecha = DateTime.Parse("2026-06-21"), Finalizado = false },
        new Partido { Id = 47, EquipoLocal = "Uruguay", EquipoVisitante = "CaboVerde", Fecha = DateTime.Parse("2026-06-21"), Finalizado = false },
        new Partido { Id = 48, EquipoLocal = "Francia", EquipoVisitante = "Irak", Fecha = DateTime.Parse("2026-06-22"), Finalizado = false },
        new Partido { Id = 49, EquipoLocal = "Argentina", EquipoVisitante = "Austria", Fecha = DateTime.Parse("2026-06-23"), Finalizado = false },
        new Partido { Id = 50, EquipoLocal = "Jordania", EquipoVisitante = "Argelia", Fecha = DateTime.Parse("2026-06-23"), Finalizado = false },
        new Partido { Id = 51, EquipoLocal = "Australia", EquipoVisitante = "Mexico", Fecha = DateTime.Parse("2026-06-24"), Finalizado = false },
        new Partido { Id = 52, EquipoLocal = "Sudafrica", EquipoVisitante = "CoreaDelSur", Fecha = DateTime.Parse("2026-06-24"), Finalizado = false },
        new Partido { Id = 53, EquipoLocal = "Ecuador", EquipoVisitante = "Canada", Fecha = DateTime.Parse("2026-06-24"), Finalizado = false },
        new Partido { Id = 54, EquipoLocal = "Nigeria", EquipoVisitante = "Italia", Fecha = DateTime.Parse("2026-06-24"), Finalizado = false },
        new Partido { Id = 55, EquipoLocal = "Marruecos", EquipoVisitante = "Haiti", Fecha = DateTime.Parse("2026-06-25"), Finalizado = false },
        new Partido { Id = 56, EquipoLocal = "Escocia", EquipoVisitante = "Brasil", Fecha = DateTime.Parse("2026-06-25"), Finalizado = false },
        new Partido { Id = 57, EquipoLocal = "Turquia", EquipoVisitante = "EstadosUnidos", Fecha = DateTime.Parse("2026-06-25"), Finalizado = false },
        new Partido { Id = 58, EquipoLocal = "Bolivia", EquipoVisitante = "Paraguay", Fecha = DateTime.Parse("2026-06-25"), Finalizado = false },
        new Partido { Id = 59, EquipoLocal = "Egipto", EquipoVisitante = "Alemania", Fecha = DateTime.Parse("2026-06-26"), Finalizado = false },
        new Partido { Id = 60, EquipoLocal = "Curazao", EquipoVisitante = "Belgica", Fecha = DateTime.Parse("2026-06-26"), Finalizado = false },
        new Partido { Id = 61, EquipoLocal = "Tunez", EquipoVisitante = "Japon", Fecha = DateTime.Parse("2026-06-26"), Finalizado = false },
        new Partido { Id = 62, EquipoLocal = "PaisesBajos", EquipoVisitante = "Japon", Fecha = DateTime.Parse("2026-06-26"), Finalizado = false },
        new Partido { Id = 63, EquipoLocal = "Chile", EquipoVisitante = "Suiza", Fecha = DateTime.Parse("2026-06-27"), Finalizado = false },
        new Partido { Id = 64, EquipoLocal = "Camerun", EquipoVisitante = "Dinamarca", Fecha = DateTime.Parse("2026-06-27"), Finalizado = false },
        new Partido { Id = 65, EquipoLocal = "ArabiaSaudita", EquipoVisitante = "Uruguay", Fecha = DateTime.Parse("2026-06-27"), Finalizado = false },
        new Partido { Id = 66, EquipoLocal = "Espana", EquipoVisitante = "Iran", Fecha = DateTime.Parse("2026-06-27"), Finalizado = false },
        new Partido { Id = 67, EquipoLocal = "Irak", EquipoVisitante = "Noruega", Fecha = DateTime.Parse("2026-06-28"), Finalizado = false },
        new Partido { Id = 68, EquipoLocal = "Senegal", EquipoVisitante = "Francia", Fecha = DateTime.Parse("2026-06-28"), Finalizado = false },
        new Partido { Id = 69, EquipoLocal = "Austria", EquipoVisitante = "Jordania", Fecha = DateTime.Parse("2026-06-28"), Finalizado = false },
        new Partido { Id = 70, EquipoLocal = "Argelia", EquipoVisitante = "Argentina", Fecha = DateTime.Parse("2026-06-28"), Finalizado = false },
        new Partido { Id = 71, EquipoLocal = "Uzbekistan", EquipoVisitante = "Colombia", Fecha = DateTime.Parse("2026-06-29"), Finalizado = false },
        new Partido { Id = 72, EquipoLocal = "RDCongo", EquipoVisitante = "Portugal", Fecha = DateTime.Parse("2026-06-29"), Finalizado = false },
        new Partido { Id = 73, EquipoLocal = "Italia", EquipoVisitante = "CoreaDelSur", Fecha = DateTime.Parse("2026-07-01"), Finalizado = false },
        new Partido { Id = 74, EquipoLocal = "Ecuador", EquipoVisitante = "Sudafrica", Fecha = DateTime.Parse("2026-07-01"), Finalizado = false },
        new Partido { Id = 75, EquipoLocal = "Brasil", EquipoVisitante = "Paraguay", Fecha = DateTime.Parse("2026-07-02"), Finalizado = false },
        new Partido { Id = 76, EquipoLocal = "Marruecos", EquipoVisitante = "EstadosUnidos", Fecha = DateTime.Parse("2026-07-02"), Finalizado = false },
        new Partido { Id = 77, EquipoLocal = "Alemania", EquipoVisitante = "Tunez", Fecha = DateTime.Parse("2026-07-03"), Finalizado = false },
        new Partido { Id = 78, EquipoLocal = "Belgica", EquipoVisitante = "Japon", Fecha = DateTime.Parse("2026-07-03"), Finalizado = false },
        new Partido { Id = 79, EquipoLocal = "Suiza", EquipoVisitante = "Espana", Fecha = DateTime.Parse("2026-07-03"), Finalizado = false },
        new Partido { Id = 80, EquipoLocal = "Camerun", EquipoVisitante = "Uruguay", Fecha = DateTime.Parse("2026-07-04"), Finalizado = false },
        new Partido { Id = 81, EquipoLocal = "Francia", EquipoVisitante = "Austria", Fecha = DateTime.Parse("2026-07-04"), Finalizado = false },
        new Partido { Id = 82, EquipoLocal = "Senegal", EquipoVisitante = "Argentina", Fecha = DateTime.Parse("2026-07-04"), Finalizado = false },
        new Partido { Id = 83, EquipoLocal = "Portugal", EquipoVisitante = "Ghana", Fecha = DateTime.Parse("2026-07-05"), Finalizado = false },
        new Partido { Id = 84, EquipoLocal = "Colombia", EquipoVisitante = "Inglaterra", Fecha = DateTime.Parse("2026-07-05"), Finalizado = false },
        new Partido { Id = 85, EquipoLocal = "Mexico", EquipoVisitante = "Nigeria", Fecha = DateTime.Parse("2026-07-05"), Finalizado = false },
        new Partido { Id = 86, EquipoLocal = "Canada", EquipoVisitante = "Egipto", Fecha = DateTime.Parse("2026-07-06"), Finalizado = false },
        new Partido { Id = 87, EquipoLocal = "Croacia", EquipoVisitante = "Chile", Fecha = DateTime.Parse("2026-07-06"), Finalizado = false },
        new Partido { Id = 88, EquipoLocal = "Panama", EquipoVisitante = "Dinamarca", Fecha = DateTime.Parse("2026-07-07"), Finalizado = false },
        new Partido { Id = 89, EquipoLocal = "Italia", EquipoVisitante = "Brasil", Fecha = DateTime.Parse("2026-07-09"), Finalizado = false },
        new Partido { Id = 90, EquipoLocal = "Ecuador", EquipoVisitante = "Marruecos", Fecha = DateTime.Parse("2026-07-09"), Finalizado = false },
        new Partido { Id = 91, EquipoLocal = "Alemania", EquipoVisitante = "Suiza", Fecha = DateTime.Parse("2026-07-10"), Finalizado = false },
        new Partido { Id = 92, EquipoLocal = "Belgica", EquipoVisitante = "Uruguay", Fecha = DateTime.Parse("2026-07-10"), Finalizado = false },
        new Partido { Id = 93, EquipoLocal = "Francia", EquipoVisitante = "Portugal", Fecha = DateTime.Parse("2026-07-11"), Finalizado = false },
        new Partido { Id = 94, EquipoLocal = "Argentina", EquipoVisitante = "Inglaterra", Fecha = DateTime.Parse("2026-07-11"), Finalizado = false },
        new Partido { Id = 95, EquipoLocal = "Mexico", EquipoVisitante = "Croacia", Fecha = DateTime.Parse("2026-07-12"), Finalizado = false },
        new Partido { Id = 96, EquipoLocal = "Canada", EquipoVisitante = "Dinamarca", Fecha = DateTime.Parse("2026-07-12"), Finalizado = false },
        new Partido { Id = 97, EquipoLocal = "Brasil", EquipoVisitante = "Alemania", Fecha = DateTime.Parse("2026-07-15"), Finalizado = false },
        new Partido { Id = 98, EquipoLocal = "Ecuador", EquipoVisitante = "Uruguay", Fecha = DateTime.Parse("2026-07-16"), Finalizado = false },
        new Partido { Id = 99, EquipoLocal = "Francia", EquipoVisitante = "Inglaterra", Fecha = DateTime.Parse("2026-07-17"), Finalizado = false },
        new Partido { Id = 100, EquipoLocal = "Mexico", EquipoVisitante = "Canada", Fecha = DateTime.Parse("2026-07-18"), Finalizado = false },
        new Partido { Id = 101, EquipoLocal = "Brasil", EquipoVisitante = "Francia", Fecha = DateTime.Parse("2026-07-21"), Finalizado = false },
        new Partido { Id = 102, EquipoLocal = "Uruguay", EquipoVisitante = "Mexico", Fecha = DateTime.Parse("2026-07-22"), Finalizado = false },
        new Partido { Id = 103, EquipoLocal = "Francia", EquipoVisitante = "Uruguay", Fecha = DateTime.Parse("2026-07-25"), Finalizado = false },
        new Partido { Id = 104, EquipoLocal = "Brasil", EquipoVisitante = "Mexico", Fecha = DateTime.Parse("2026-07-26"), Finalizado = false }
    };

    // Pronósticos precargados para los otros usuarios (así la Tabla de Posiciones tiene variedad)
    public List<Pronostico> Pronosticos { get; set; } = new()
    {
        new Pronostico { Username = "Carlos", PartidoId = 1, GolesLocalPredichos = 2, GolesVisitantePredichos = 0 },
        new Pronostico { Username = "Carlos", PartidoId = 2, GolesLocalPredichos = 2, GolesVisitantePredichos = 1 },
        new Pronostico { Username = "Maria", PartidoId = 1, GolesLocalPredichos = 1, GolesVisitantePredichos = 0 },
        new Pronostico { Username = "Maria", PartidoId = 2, GolesLocalPredichos = 3, GolesVisitantePredichos = 1 },
        new Pronostico { Username = "Andres", PartidoId = 1, GolesLocalPredichos = 0, GolesVisitantePredichos = 2 },
        new Pronostico { Username = "Andres", PartidoId = 2, GolesLocalPredichos = 2, GolesVisitantePredichos = 1 },
        new Pronostico { Username = "Sofia", PartidoId = 1, GolesLocalPredichos = 2, GolesVisitantePredichos = 0 },
        new Pronostico { Username = "Sofia", PartidoId = 3, GolesLocalPredichos = 1, GolesVisitantePredichos = 1 },
        new Pronostico { Username = "Luis", PartidoId = 2, GolesLocalPredichos = 1, GolesVisitantePredichos = 1 }
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

    // Evalúa e inserta automáticamente insignias al usuario según sus pronósticos
    public List<string> VerificarYOtorgarInsignias(string username)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (usuario == null) return new List<string>();

        var cantidadPronosticos = Pronosticos.Count(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        var nuevasInsignias = new List<string>();

        // Regla 1: Primer pronóstico
        if (cantidadPronosticos >= 1 && !usuario.Insignias.Any(i => i.Id == 1))
        {
            var ins = InsigniasDisponibles.First(i => i.Id == 1);
            usuario.Insignias.Add(ins);
            nuevasInsignias.Add($"{ins.Icono} {ins.Nombre}");
        }

        // Regla 2: 5 o más pronósticos
        if (cantidadPronosticos >= 5 && !usuario.Insignias.Any(i => i.Id == 2))
        {
            var ins = InsigniasDisponibles.First(i => i.Id == 2);
            usuario.Insignias.Add(ins);
            nuevasInsignias.Add($"{ins.Icono} {ins.Nombre}");
        }

        // Regla 3: 10 o más pronósticos
        if (cantidadPronosticos >= 10 && !usuario.Insignias.Any(i => i.Id == 3))
        {
            var ins = InsigniasDisponibles.First(i => i.Id == 3);
            usuario.Insignias.Add(ins);
            nuevasInsignias.Add($"{ins.Icono} {ins.Nombre}");
        }

        return nuevasInsignias;
    }
}