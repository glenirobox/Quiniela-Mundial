using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaQuinielas.Models;
using System.Windows.Forms;

namespace SistemaQuinielas.Services
{
    public class InsigniaService
    {
        private readonly string RutaInsignias = Path.Combine(Application.StartupPath, "Data", "insignias.csv");
        private readonly UsuarioService servicioUsuarios = new UsuarioService();
        private readonly PartidoService servicioPartidos = new PartidoService();
        private readonly PronosticoService servicioPronosticos = new PronosticoService();
        private readonly QuinielaService servicioQuinielas = new QuinielaService();

        public List<Insignia> ObtenerInsignias()
        {
            List<Insignia> insignias = new List<Insignia>();

            if (!File.Exists(RutaInsignias))
            {
                return insignias;
            }

            using StreamReader lector = new StreamReader(RutaInsignias);
            lector.ReadLine();
            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(linea)) continue;

                string[] datos = linea.Split(';');
                if (datos.Length < 3) continue;

                Insignia i = new Insignia();
                i.Id = int.Parse(datos[0]);
                i.Nombre = datos[1];
                i.Descripcion = datos[2];

                insignias.Add(i);
            }
            return insignias;
        }

        // Recalcula todas las insignias desde cero y las reasigna
        public void CalcularYAsignarInsignias()
        {
            List<Usuario> usuarios = servicioUsuarios.ObtenerUsuarios();
            List<Partido> partidos = servicioPartidos.ObtenerPartidos();
            List<Pronostico> pronosticos = servicioPronosticos.ObtenerPronosticos();
            List<Quiniela> quinielas = servicioQuinielas.ObtenerQuinielas();

            if (usuarios.Count == 0) return;

            foreach (Usuario u in usuarios)
            {
                u.IdsInsignias = new List<int>();
            }

            // Insignia 1 y 2: primero y peor del ranking global
            Usuario? mejorGlobal = usuarios.OrderByDescending(u => u.Puntos).First();
            Usuario? peorGlobal = usuarios.OrderBy(u => u.Puntos).First();

            if (!mejorGlobal.IdsInsignias.Contains(1)) mejorGlobal.IdsInsignias.Add(1);
            if (!peorGlobal.IdsInsignias.Contains(2)) peorGlobal.IdsInsignias.Add(2);

            // Insignia 3: rey de los empates 
            var conteoEmpatesAcertados = usuarios.Select(u => new
            {
                Usuario = u,
                Aciertos = pronosticos.Count(p =>
                {
                    Partido? partido = partidos.FirstOrDefault(pt => pt.Id == p.IdPartido);
                    if (partido == null || partido.Estado != EstadoPartido.Finalizado) return false;
                    bool partidoEmpatado = partido.GolesLocal == partido.GolesVisitante;
                    bool acertoExacto = p.IdUsuario == u.Id && p.GolesLocal == partido.GolesLocal && p.GolesVisitante == partido.GolesVisitante;
                    return partidoEmpatado && acertoExacto;
                })
            }).Where(x => x.Aciertos > 0)
              .OrderByDescending(x => x.Aciertos)
              .FirstOrDefault();

            if (conteoEmpatesAcertados != null && !conteoEmpatesAcertados.Usuario.IdsInsignias.Contains(3))
            {
                conteoEmpatesAcertados.Usuario.IdsInsignias.Add(3);
            }

            // Insignia 4: racha de mas de 10 aciertos 
            foreach (Usuario u in usuarios)
            {
                int totalAciertos = pronosticos.Count(p =>
                {
                    if (p.IdUsuario != u.Id) return false;
                    Partido? partido = partidos.FirstOrDefault(pt => pt.Id == p.IdPartido);
                    if (partido == null || partido.Estado != EstadoPartido.Finalizado) return false;

                    bool marcadorExacto = p.GolesLocal == partido.GolesLocal && p.GolesVisitante == partido.GolesVisitante;
                    int resultadoReal = Math.Sign(partido.GolesLocal - partido.GolesVisitante);
                    int resultadoPronosticado = Math.Sign(p.GolesLocal - p.GolesVisitante);
                    return marcadorExacto || resultadoReal == resultadoPronosticado;
                });

                if (totalAciertos >= 10 && !u.IdsInsignias.Contains(4))
                {
                    u.IdsInsignias.Add(4);
                }
            }

            // Insignia 5 y 6: primero y peor de cada quiniela privada
            foreach (Quiniela q in quinielas.Where(q => q.EsPrivada && q.IdsUsuarios.Count > 1))
            {
                List<Usuario> miembros = usuarios.Where(u => q.IdsUsuarios.Contains(u.Id)).ToList();
                if (miembros.Count == 0) continue;

                Usuario mejorDeQuiniela = miembros.OrderByDescending(u => u.Puntos).First();
                Usuario peorDeQuiniela = miembros.OrderBy(u => u.Puntos).First();

                if (!mejorDeQuiniela.IdsInsignias.Contains(5)) mejorDeQuiniela.IdsInsignias.Add(5);
                if (!peorDeQuiniela.IdsInsignias.Contains(6)) peorDeQuiniela.IdsInsignias.Add(6);
            }

            servicioUsuarios.GuardarUsuarios(usuarios);
        }
    }
}