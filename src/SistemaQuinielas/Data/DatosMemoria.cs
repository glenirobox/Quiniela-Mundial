using System;
using System.Collections.Generic;
using SistemaQuinielas.Models;

namespace SistemaQuinielas
{
    public static class DatosMemoria
    {
        // Listas globales que simulan las tablas de la Base de Datos
        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public static List<Partido> Partidos { get; set; } = new List<Partido>();
        public static List<Pronostico> Pronosticos { get; set; } = new List<Pronostico>();
        public static List<Insignia> Insignias { get; set; } = new List<Insignia>();

        // Usuario que tiene la sesión activa en el navegador
        public static Usuario? UsuarioLogueado { get; set; }

        // Carga de datos de prueba para trabajar de inmediato
        static DatosMemoria()
        {
            CargarDatosIniciales();
        }

        public static void CargarDatosIniciales()
        {
            // 1. Usuarios de prueba (Admin y Usuario regular)
            if (Usuarios.Count == 0)
            {
                Usuarios.Add(new Usuario
                {
                    Id = 1,
                    Nombre = "Admin",
                    Contrasena = "1234",
                    Rol = "Admin",
                    Activo = true
                });

                Usuarios.Add(new Usuario
                {
                    Id = 2,
                    Nombre = "Glen",
                    Contrasena = "1234",
                    Rol = "Usuario",
                    PaisFavorito = "Costa Rica",
                    Puntos = 10,
                    Activo = true
                });
            }

            // 2. Partidos de prueba
            if (Partidos.Count == 0)
            {
                Partidos.Add(new Partido
                {
                    Id = 1,
                    EquipoLocal = "Costa Rica",
                    EquipoVisitante = "Alemania",
                    Fecha = DateTime.Now.AddHours(5), // Partido dentro de las próximas 24h
                    Estado = EstadoPartido.Pendiente,
                    Grupo = "Grupo E"
                });

                Partidos.Add(new Partido
                {
                    Id = 2,
                    EquipoLocal = "España",
                    EquipoVisitante = "Japón",
                    Fecha = DateTime.Now.AddDays(2),
                    Estado = EstadoPartido.Pendiente,
                    Grupo = "Grupo E"
                });
            }
        }
    }
}
