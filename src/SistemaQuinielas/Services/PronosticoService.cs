using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaQuinielas.Models;
using System.Windows.Forms;

namespace SistemaQuinielas.Services
{
    public class PronosticoService
    {
        private readonly string RutaPronosticos = Path.Combine(Application.StartupPath, "Data", "pronosticos.csv");
        private readonly UsuarioService servicioUsuarios = new UsuarioService();
        private readonly PartidoService servicioPartidos = new PartidoService();

        public List<Pronostico> ObtenerPronosticos()
        {
            List<Pronostico> pronosticos = new List<Pronostico>();

            if (!File.Exists(RutaPronosticos))
            {
                return pronosticos;
            }

            using StreamReader lector = new StreamReader(RutaPronosticos);
            lector.ReadLine();
            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(linea)) continue;

                string[] datos = linea.Split(';');
                if (datos.Length < 4) continue;

                Pronostico p = new Pronostico();
                p.IdUsuario = int.Parse(datos[0]);
                p.IdPartido = int.Parse(datos[1]);
                p.GolesLocal = int.Parse(datos[2]);
                p.GolesVisitante = int.Parse(datos[3]);

                pronosticos.Add(p);
            }
            return pronosticos;
        }

        public void GuardarPronostico(Pronostico nuevo)
        {
           
            Partido? partido = servicioPartidos.ObtenerPartidos().Find(p => p.Id == nuevo.IdPartido);

            if (partido == null)
            {
                throw new Exception("El partido no existe.");
            }

            if (partido.Estado != EstadoPartido.Pendiente)
            {
                throw new Exception("Ya no se pueden hacer pronósticos para este partido, porque ya inició o finalizó.");
            }

            List<Pronostico> pronosticos = ObtenerPronosticos();

            bool yaExiste = pronosticos.Any(p => p.IdUsuario == nuevo.IdUsuario && p.IdPartido == nuevo.IdPartido);
            if (yaExiste)
            {
                throw new Exception("Ya existe un pronóstico de este usuario para este partido.");
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
            List<Pronostico> pronosticos = ObtenerPronosticos()
                .Where(p => p.IdPartido == partido.Id)
                .ToList();

            List<Usuario> usuarios = servicioUsuarios.ObtenerUsuarios();

            foreach (Pronostico p in pronosticos)
            {
                Usuario? usuario = usuarios.Find(u => u.Id == p.IdUsuario);
                if (usuario == null) continue;

                bool marcadorExacto = p.GolesLocal == partido.GolesLocal && p.GolesVisitante == partido.GolesVisitante;

                int resultadoReal = Math.Sign(partido.GolesLocal - partido.GolesVisitante);
                int resultadoPronosticado = Math.Sign(p.GolesLocal - p.GolesVisitante);
                bool acertoGanadorOEmpate = resultadoReal == resultadoPronosticado;

                if (marcadorExacto)
                {
                    usuario.Puntos += 5;
                }
                else if (acertoGanadorOEmpate)
                {
                    usuario.Puntos += 2;
                }
            }

            servicioUsuarios.GuardarUsuarios(usuarios);
        }
    }
}