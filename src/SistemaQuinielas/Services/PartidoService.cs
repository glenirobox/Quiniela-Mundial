using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaQuinielas.Models;
using System.Windows.Forms;

namespace SistemaQuinielas.Services
{
    public class PartidoService
    {
        private readonly string RutaPartidos =
            Path.Combine(Application.StartupPath, "Data", "partidos.csv");

        public List<Partido> ObtenerPartidos()
        {
            List<Partido> partidos = new List<Partido>();

            if (!File.Exists(RutaPartidos))
            {
                return partidos;
            }

            using StreamReader lector = new StreamReader(RutaPartidos);
            lector.ReadLine();

            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(linea)) continue;

                string[] datos = linea.Split(';');

                Partido partido = new Partido();
                partido.Id = int.Parse(datos[0]);
                partido.EquipoLocal = datos[1];
                partido.EquipoVisitante = datos[2];
                partido.Fecha = DateTime.Parse(datos[3]);
                partido.GolesLocal = int.Parse(datos[4]);
                partido.GolesVisitante = int.Parse(datos[5]);

                partido.Estado = datos.Length >= 7 && Enum.TryParse(datos[6], out EstadoPartido estado)
                    ? estado
                    : EstadoPartido.Pendiente;

                partido.Grupo = datos.Length >= 8 ? datos[7] : string.Empty;

                partidos.Add(partido);
            }

            return partidos;
        }

        public void GuardarPartidos(List<Partido> partidos)
        {
            using StreamWriter escritor = new StreamWriter(RutaPartidos, false);
            escritor.WriteLine("Id;EquipoLocal;EquipoVisitante;Fecha;GolesLocal;GolesVisitante;Estado;Grupo");

            foreach (Partido p in partidos)
            {
                escritor.WriteLine($"{p.Id};{p.EquipoLocal};{p.EquipoVisitante};{p.Fecha:yyyy-MM-dd};{p.GolesLocal};{p.GolesVisitante};{p.Estado};{p.Grupo}");
            }
        }

        public void FinalizarPartido(int idPartido)
        {
            List<Partido> partidos = ObtenerPartidos();
            Partido? partido = partidos.Find(p => p.Id == idPartido);

            if (partido == null)
            {
                throw new Exception("El partido no existe.");
            }

            partido.Estado = EstadoPartido.Finalizado;
            GuardarPartidos(partidos);
        }

        
        public List<PosicionEquipo> ObtenerTablaPosiciones(string grupo)
        {
            List<Partido> partidosDelGrupo = ObtenerPartidos()
                .Where(p => p.Grupo == grupo && p.Estado == EstadoPartido.Finalizado)
                .ToList();

            Dictionary<string, PosicionEquipo> tabla = new Dictionary<string, PosicionEquipo>();

            foreach (Partido p in partidosDelGrupo)
            {
                AgregarSiNoExiste(tabla, p.EquipoLocal);
                AgregarSiNoExiste(tabla, p.EquipoVisitante);

                PosicionEquipo local = tabla[p.EquipoLocal];
                PosicionEquipo visitante = tabla[p.EquipoVisitante];

                local.PartidosJugados++;
                visitante.PartidosJugados++;

                local.GolesFavor += p.GolesLocal;
                local.GolesContra += p.GolesVisitante;
                visitante.GolesFavor += p.GolesVisitante;
                visitante.GolesContra += p.GolesLocal;

                if (p.GolesLocal > p.GolesVisitante)
                {
                    local.Puntos += 3;
                }
                else if (p.GolesLocal < p.GolesVisitante)
                {
                    visitante.Puntos += 3;
                }
                else
                {
                    local.Puntos += 1;
                    visitante.Puntos += 1;
                }
            }

            foreach (PosicionEquipo equipo in tabla.Values)
            {
                equipo.Diferencia = equipo.GolesFavor - equipo.GolesContra;
            }

            List<PosicionEquipo> tablaOrdenada = tabla.Values
                .OrderByDescending(e => e.Puntos)
                .ThenByDescending(e => e.Diferencia)
                .ToList();

            for (int i = 0; i < tablaOrdenada.Count; i++)
            {
                tablaOrdenada[i].Clasificado = i < 2 ? "Clasificado" : "Eliminado";
            }

            return tablaOrdenada;
        }

        private void AgregarSiNoExiste(Dictionary<string, PosicionEquipo> tabla, string equipo)
        {
            if (!tabla.ContainsKey(equipo))
            {
                tabla[equipo] = new PosicionEquipo { Equipo = equipo };
            }
        }
    }
}