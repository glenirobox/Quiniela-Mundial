using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaQuinielas.Models;
using System.Windows.Forms;

namespace SistemaQuinielas.Services
{
    public class NotificacionService
    {
        private readonly string RutaNotificaciones = Path.Combine(Application.StartupPath, "Data", "notificaciones.csv");
        private readonly UsuarioService servicioUsuarios = new UsuarioService();
        private readonly PartidoService servicioPartidos = new PartidoService();
        private readonly PronosticoService servicioPronosticos = new PronosticoService();
        private readonly QuinielaService servicioQuinielas = new QuinielaService();

        public List<Notificacion> ObtenerNotificaciones()
        {
            List<Notificacion> notificaciones = new List<Notificacion>();

            if (!File.Exists(RutaNotificaciones))
            {
                return notificaciones;
            }

            using StreamReader lector = new StreamReader(RutaNotificaciones);
            lector.ReadLine();
            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(linea)) continue;

                string[] datos = linea.Split(';');
                if (datos.Length < 3) continue;

                Notificacion n = new Notificacion();
                n.IdQuiniela = int.Parse(datos[0]);
                n.Mensaje = datos[1];
                n.Fecha = DateTime.Parse(datos[2]);

                notificaciones.Add(n);
            }
            return notificaciones;
        }

        public List<Notificacion> ObtenerNotificacionesPorQuiniela(int idQuiniela)
        {
            return ObtenerNotificaciones().Where(n => n.IdQuiniela == idQuiniela).ToList();
        }

        private Notificacion Crear(int idQuiniela, string mensaje)
        {
            Notificacion n = new Notificacion();
            n.IdQuiniela = idQuiniela;
            n.Mensaje = mensaje;
            n.Fecha = DateTime.Now;
            return n;
        }

        // Recalcula todas las notificaciones desde cero
        public void GenerarNotificaciones()
        {
            List<Quiniela> quinielas = servicioQuinielas.ObtenerQuinielas();
            List<Usuario> usuarios = servicioUsuarios.ObtenerUsuarios();
            List<Partido> partidos = servicioPartidos.ObtenerPartidos();
            List<Pronostico> pronosticos = servicioPronosticos.ObtenerPronosticos();

            List<Notificacion> resultado = new List<Notificacion>();

            foreach (Quiniela q in quinielas)
            {
                List<Usuario> miembros = usuarios.Where(u => q.IdsUsuarios.Contains(u.Id)).ToList();
                if (miembros.Count == 0) continue;

                Usuario lider = miembros.OrderByDescending(u => u.Puntos).First();
                Usuario peor = miembros.OrderBy(u => u.Puntos).First();

                resultado.Add(Crear(q.Id, $"Nuevo lider en la quiniela: {lider.Nombre} con {lider.Puntos} puntos"));

                if (miembros.Count > 1)
                {
                    resultado.Add(Crear(q.Id, $"La vergüenza de la quiniela: {peor.Nombre} con {peor.Puntos} puntos"));
                }

                // Un mensaje por cada acierto exacto de un miembro en un partido finalizado
                foreach (Pronostico p in pronosticos.Where(p => miembros.Any(m => m.Id == p.IdUsuario)))
                {
                    Partido? partido = partidos.FirstOrDefault(pt => pt.Id == p.IdPartido && pt.Estado == EstadoPartido.Finalizado);
                    if (partido == null) continue;

                    bool marcadorExacto = p.GolesLocal == partido.GolesLocal && p.GolesVisitante == partido.GolesVisitante;
                    if (!marcadorExacto) continue;

                    Usuario autor = miembros.First(m => m.Id == p.IdUsuario);
                    resultado.Add(Crear(q.Id, $"{autor.Nombre} acerto el marcador del partido {partido.EquipoLocal} vs {partido.EquipoVisitante}"));
                }
            }

            using StreamWriter escritor = new StreamWriter(RutaNotificaciones, false);
            escritor.WriteLine("IdQuiniela;Mensaje;Fecha");
            foreach (Notificacion n in resultado)
            {
                escritor.WriteLine($"{n.IdQuiniela};{n.Mensaje};{n.Fecha:yyyy-MM-dd HH:mm}");
            }
        }
    }
}
