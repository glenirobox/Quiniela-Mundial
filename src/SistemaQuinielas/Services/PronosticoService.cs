using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SistemaQuinielas.Models;

namespace SistemaQuinielas.Services;

public class PronosticoService
{
    private readonly string RutaPronosticos = Path.Combine(
        Application.StartupPath, "Data", "pronosticos.csv"
    );

    private readonly UsuarioService servicioUsuarios = new UsuarioService();
    private readonly PartidoService servicioPartidos = new PartidoService();

    public List<Pronostico> ObtenerPronosticos()
    {
        List<Pronostico> pronosticos = new List<Pronostico>();

        if (!File.Exists(RutaPronosticos)) return pronosticos;

        using StreamReader lector = new StreamReader(RutaPronosticos);
        lector.ReadLine(); // Ignorar encabezado

        while (!lector.EndOfStream)
        {
            string? linea = lector.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] datos = linea.Split(';');
            if (datos.Length < 4) continue;

            Pronostico p = new Pronostico
            {
                IdUsuario = int.Parse(datos[0]),
                IdPartido = int.Parse(datos[1]),
                GolesLocal = int.Parse(datos[2]),
                GolesVisitante = int.Parse(datos[3])
            };

            pronosticos.Add(p);
        }

        return pronosticos;
    }

    public void GuardarPronostico(Pronostico nuevo)
    {
        List<Partido> partidos = servicioPartidos.ObtenerPartidos();
        Partido? partidoEncontrado = null;

        foreach (Partido p in partidos)
        {
            if (p.Id == nuevo.IdPartido)
            {
                partidoEncontrado = p;
                break;
            }
        }

        if (partidoEncontrado == null)
        {
            throw new Exception("El partido no existe.");
        }

        if (partidoEncontrado.Estado != EstadoPartido.Pendiente)
        {
            throw new Exception("Ya no se pueden hacer pronósticos para este partido porque ya inició o finalizó.");
        }

        List<Pronostico> pronosticos = ObtenerPronosticos();

        // Validar que el usuario no haya registrado pronóstico previo para este partido
        foreach (Pronostico p in pronosticos)
        {
            if (p.IdUsuario == nuevo.IdUsuario && p.IdPartido == nuevo.IdPartido)
            {
                throw new Exception("Ya existe un pronóstico de este usuario para este partido.");
            }
        }

        pronosticos.Add(nuevo);

        using StreamWriter escritor = new StreamWriter(RutaPronosticos, false);
        escritor.WriteLine("IdUsuario;IdPartido;GolesLocal;GolesVisitante");

        foreach (Pronostico p in pronosticos)
        {
            escritor.WriteLine($"{p.IdUsuario};{p.IdPartido};{p.GolesLocal};{p.GolesVisitante}");
        }
    }

    public void CalcularPuntosPorPartido(Partido partido)
    {
        List<Pronostico> todosLosPronosticos = ObtenerPronosticos();
        List<Usuario> usuarios = servicioUsuarios.ObtenerUsuarios();

        foreach (Pronostico p in todosLosPronosticos)
        {
            if (p.IdPartido != partido.Id) continue;

            Usuario? usuarioEncontrado = null;
            foreach (Usuario u in usuarios)
            {
                if (u.Id == p.IdUsuario)
                {
                    usuarioEncontrado = u;
                    break;
                }
            }

            if (usuarioEncontrado == null) continue;

            // Marcador exacto: 5 puntos
            bool marcadorExacto = p.GolesLocal == partido.GolesLocal && p.GolesVisitante == partido.GolesVisitante;

            // Tendencia (Ganador o Empate): 2 puntos
            bool acertoGanadorLocal = p.GolesLocal > p.GolesVisitante && partido.GolesLocal > partido.GolesVisitante;
            bool acertoGanadorVisitante = p.GolesLocal < p.GolesVisitante && partido.GolesLocal < partido.GolesVisitante;
            bool acertoEmpate = p.GolesLocal == p.GolesVisitante && partido.GolesLocal == partido.GolesVisitante;

            if (marcadorExacto)
            {
                usuarioEncontrado.Puntos += 5;
            }
            else if (acertoGanadorLocal || acertoGanadorVisitante || acertoEmpate)
            {
                usuarioEncontrado.Puntos += 2;
            }
        }

        servicioUsuarios.GuardarUsuarios(usuarios);
    }
}