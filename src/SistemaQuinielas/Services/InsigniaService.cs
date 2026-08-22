using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SistemaQuinielas.Models;

namespace SistemaQuinielas.Services;

public class InsigniaService
{
    private readonly string RutaInsignias = Path.Combine(
        Application.StartupPath, "Data", "insignias.csv"
    );

    private readonly UsuarioService servicioUsuarios = new UsuarioService();
    private readonly PartidoService servicioPartidos = new PartidoService();
    private readonly PronosticoService servicioPronosticos = new PronosticoService();
    private readonly QuinielaService servicioQuinielas = new QuinielaService();

    public List<Insignia> ObtenerInsignias()
    {
        List<Insignia> insignias = new List<Insignia>();

        if (!File.Exists(RutaInsignias)) return insignias;

        using StreamReader lector = new StreamReader(RutaInsignias);
        lector.ReadLine(); // Ignorar encabezado

        while (!lector.EndOfStream)
        {
            string? linea = lector.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] datos = linea.Split(';');
            if (datos.Length < 3) continue;

            Insignia i = new Insignia
            {
                Id = int.Parse(datos[0]),
                Nombre = datos[1],
                Descripcion = datos[2]
            };

            insignias.Add(i);
        }

        return insignias;
    }

    // Recalcula todas las insignias asignadas a los usuarios
    public void CalcularYAsignarInsignias()
    {
        List<Usuario> usuarios = servicioUsuarios.ObtenerUsuarios();
        List<Partido> partidos = servicioPartidos.ObtenerPartidos();
        List<Pronostico> pronosticos = servicioPronosticos.ObtenerPronosticos();
        List<Quiniela> quinielas = servicioQuinielas.ObtenerQuinielas();

        if (usuarios.Count == 0) return;

        // Reiniciar insignias de cada usuario
        foreach (Usuario u in usuarios)
        {
            u.IdsInsignias = new List<int>();
        }

        // Insignias 1 y 2: Mejor y peor del ranking global
        Usuario mejorGlobal = usuarios[0];
        Usuario peorGlobal = usuarios[0];

        foreach (Usuario u in usuarios)
        {
            if (u.Puntos > mejorGlobal.Puntos) mejorGlobal = u;
            if (u.Puntos < peorGlobal.Puntos) peorGlobal = u;
        }

        if (!mejorGlobal.IdsInsignias.Contains(1)) mejorGlobal.IdsInsignias.Add(1);
        if (!peorGlobal.IdsInsignias.Contains(2)) peorGlobal.IdsInsignias.Add(2);

        // Insignia 3: Rey de los empates
        Usuario? reyEmpates = null;
        int maxEmpates = 0;

        foreach (Usuario u in usuarios)
        {
            int empatesAcertados = 0;

            foreach (Pronostico p in pronosticos)
            {
                if (p.IdUsuario != u.Id) continue;

                // Buscar partido correspondiente
                Partido? partido = null;
                foreach (Partido pt in partidos)
                {
                    if (pt.Id == p.IdPartido)
                    {
                        partido = pt;
                        break;
                    }
                }

                if (partido == null || partido.Estado != EstadoPartido.Finalizado) continue;

                bool partidoEmpatado = partido.GolesLocal == partido.GolesVisitante;
                bool acertoExacto = p.GolesLocal == partido.GolesLocal && p.GolesVisitante == partido.GolesVisitante;

                if (partidoEmpatado && acertoExacto)
                {
                    empatesAcertados++;
                }
            }

            if (empatesAcertados > maxEmpates)
            {
                maxEmpates = empatesAcertados;
                reyEmpates = u;
            }
        }

        if (reyEmpates != null && maxEmpates > 0 && !reyEmpates.IdsInsignias.Contains(3))
        {
            reyEmpates.IdsInsignias.Add(3);
        }

        // Insignia 4: Racha de 10 o mas aciertos
        foreach (Usuario u in usuarios)
        {
            int totalAciertos = 0;

            foreach (Pronostico p in pronosticos)
            {
                if (p.IdUsuario != u.Id) continue;

                Partido? partido = null;
                foreach (Partido pt in partidos)
                {
                    if (pt.Id == p.IdPartido)
                    {
                        partido = pt;
                        break;
                    }
                }

                if (partido == null || partido.Estado != EstadoPartido.Finalizado) continue;

                bool marcadorExacto = p.GolesLocal == partido.GolesLocal && p.GolesVisitante == partido.GolesVisitante;
                bool acertoGanadorLocal = p.GolesLocal > p.GolesVisitante && partido.GolesLocal > partido.GolesVisitante;
                bool acertoGanadorVisitante = p.GolesLocal < p.GolesVisitante && partido.GolesLocal < partido.GolesVisitante;
                bool acertoEmpate = p.GolesLocal == p.GolesVisitante && partido.GolesLocal == partido.GolesVisitante;

                if (marcadorExacto || acertoGanadorLocal || acertoGanadorVisitante || acertoEmpate)
                {
                    totalAciertos++;
                }
            }

            if (totalAciertos >= 10 && !u.IdsInsignias.Contains(4))
            {
                u.IdsInsignias.Add(4);
            }
        }

        // Insignias 5 y 6: Primero y peor de cada quiniela privada
        foreach (Quiniela q in quinielas)
        {
            if (!q.EsPrivada || q.IdsUsuarios.Count <= 1) continue;

            List<Usuario> miembros = new List<Usuario>();
            foreach (Usuario u in usuarios)
            {
                if (q.IdsUsuarios.Contains(u.Id))
                {
                    miembros.Add(u);
                }
            }

            if (miembros.Count == 0) continue;

            Usuario mejorDeQuiniela = miembros[0];
            Usuario peorDeQuiniela = miembros[0];

            foreach (Usuario m in miembros)
            {
                if (m.Puntos > mejorDeQuiniela.Puntos) mejorDeQuiniela = m;
                if (m.Puntos < peorDeQuiniela.Puntos) peorDeQuiniela = m;
            }

            if (!mejorDeQuiniela.IdsInsignias.Contains(5)) mejorDeQuiniela.IdsInsignias.Add(5);
            if (!peorDeQuiniela.IdsInsignias.Contains(6)) peorDeQuiniela.IdsInsignias.Add(6);
        }

        servicioUsuarios.GuardarUsuarios(usuarios);
    }
}