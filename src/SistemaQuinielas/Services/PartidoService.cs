using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SistemaQuinielas.Models;

namespace SistemaQuinielas.Services;

public class PartidoService
{
    private readonly string RutaPartidos = Path.Combine(
        Application.StartupPath, "Data", "partidos.csv"
    );

    public List<Partido> ObtenerPartidos()
    {
        List<Partido> partidos = new List<Partido>();

        if (!File.Exists(RutaPartidos)) return partidos;

        using StreamReader lector = new StreamReader(RutaPartidos);
        lector.ReadLine(); // Ignorar encabezado

        while (!lector.EndOfStream)
        {
            string? linea = lector.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] datos = linea.Split(';');
            if (datos.Length < 6) continue;

            Partido partido = new Partido
            {
                Id = int.Parse(datos[0]),
                EquipoLocal = datos[1],
                EquipoVisitante = datos[2],
                Fecha = DateTime.Parse(datos[3]),
                GolesLocal = int.Parse(datos[4]),
                GolesVisitante = int.Parse(datos[5]),
                Estado = EstadoPartido.Pendiente,
                Grupo = string.Empty
            };

            // Validar estado
            if (datos.Length >= 7 && Enum.TryParse(datos[6], out EstadoPartido estado))
            {
                partido.Estado = estado;
            }

            // Validar grupo
            if (datos.Length >= 8)
            {
                partido.Grupo = datos[7];
            }

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
            string fechaFormato = p.Fecha.ToString("yyyy-MM-dd");
            escritor.WriteLine($"{p.Id};{p.EquipoLocal};{p.EquipoVisitante};{fechaFormato};{p.GolesLocal};{p.GolesVisitante};{p.Estado};{p.Grupo}");
        }
    }

    public void FinalizarPartido(int idPartido)
    {
        List<Partido> partidos = ObtenerPartidos();
        Partido? partidoEncontrado = null;

        foreach (Partido p in partidos)
        {
            if (p.Id == idPartido)
            {
                partidoEncontrado = p;
                break;
            }
        }

        if (partidoEncontrado == null)
        {
            throw new Exception("El partido no existe.");
        }

        partidoEncontrado.Estado = EstadoPartido.Finalizado;
        GuardarPartidos(partidos);
    }

    public List<PosicionEquipo> ObtenerTablaPosiciones(string grupo)
    {
        List<Partido> todosLosPartidos = ObtenerPartidos();
        Dictionary<string, PosicionEquipo> tabla = new Dictionary<string, PosicionEquipo>();

        // Filtrar partidos del grupo que estén finalizados
        foreach (Partido p in todosLosPartidos)
        {
            if (p.Grupo != grupo || p.Estado != EstadoPartido.Finalizado) continue;

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

        List<PosicionEquipo> listaPosiciones = new List<PosicionEquipo>();
        foreach (PosicionEquipo equipo in tabla.Values)
        {
            equipo.Diferencia = equipo.GolesFavor - equipo.GolesContra;
            listaPosiciones.Add(equipo);
        }

        // Ordenamiento por Puntos y luego por Diferencia de goles (Bubble Sort tradicional)
        for (int i = 0; i < listaPosiciones.Count - 1; i++)
        {
            for (int j = 0; j < listaPosiciones.Count - i - 1; j++)
            {
                bool cambiar = false;

                if (listaPosiciones[j].Puntos < listaPosiciones[j + 1].Puntos)
                {
                    cambiar = true;
                }
                else if (listaPosiciones[j].Puntos == listaPosiciones[j + 1].Puntos)
                {
                    if (listaPosiciones[j].Diferencia < listaPosiciones[j + 1].Diferencia)
                    {
                        cambiar = true;
                    }
                }

                if (cambiar)
                {
                    PosicionEquipo temp = listaPosiciones[j];
                    listaPosiciones[j] = listaPosiciones[j + 1];
                    listaPosiciones[j + 1] = temp;
                }
            }
        }

        // Asignar los primeros 2 como clasificados
        for (int i = 0; i < listaPosiciones.Count; i++)
        {
            listaPosiciones[i].Clasificado = i < 2 ? "Clasificado" : "Eliminado";
        }

        return listaPosiciones;
    }

    private void AgregarSiNoExiste(Dictionary<string, PosicionEquipo> tabla, string equipo)
    {
        if (!tabla.ContainsKey(equipo))
        {
            tabla[equipo] = new PosicionEquipo { Equipo = equipo };
        }
    }
}