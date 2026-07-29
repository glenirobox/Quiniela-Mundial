using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using SistemaQuinielas.Models;
using System.Windows.Forms;
using System.Linq;

namespace SistemaQuinielas.Services
{
    public class UsuarioService
    {
        private readonly string RutaUsuarios = Path.Combine(Application.StartupPath, "Data", "usuarios.csv");

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            if (!File.Exists(RutaUsuarios))
            {
                return usuarios;
            }

            using StreamReader lector = new StreamReader(RutaUsuarios);
            lector.ReadLine();
            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }

                string[] datos = linea.Split(';');

                if (datos.Length >= 5)
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = int.Parse(datos[0]);
                    usuario.Nombre = datos[1];
                    usuario.Contrasena = datos[2];
                    usuario.PaisFavorito = datos[3];
                    usuario.Puntos = int.Parse(datos[4]);

                    usuario.IdsQuinielas = datos.Length >= 6 && !string.IsNullOrWhiteSpace(datos[5])
                        ? datos[5].Split(',').Select(int.Parse).ToList()
                        : new List<int>();

                    usuario.IdsInsignias = datos.Length >= 7 && !string.IsNullOrWhiteSpace(datos[6])
                        ? datos[6].Split(',').Select(int.Parse).ToList()
                        : new List<int>();

                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }

        public void RegistrarUsuario(Usuario nuevoUsuario)
        {
            int nuevoId = 1;

            List<Usuario> usuarios = ObtenerUsuarios();

            if (usuarios.Count > 0)
            {
                nuevoId = usuarios.Max(u => u.Id) + 1;
            }

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Nombre.Equals(nuevoUsuario.Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("El nombre de usuario ya existe.");
                }
            }

            nuevoUsuario.Id = nuevoId;
            nuevoUsuario.Puntos = 0;

            usuarios.Add(nuevoUsuario);
            GuardarUsuarios(usuarios);
        }

        public void GuardarUsuarios(List<Usuario> usuarios)
        {
            using StreamWriter escritor = new StreamWriter(RutaUsuarios, false);

            escritor.WriteLine("Id;Nombre;Contrasena;PaisFavorito;Puntos;IdsQuinielas;IdsInsignias");

            foreach (Usuario u in usuarios)
            {
                string quinielas = string.Join(",", u.IdsQuinielas);
                string insignias = string.Join(",", u.IdsInsignias);

                escritor.WriteLine($"{u.Id};{u.Nombre};{u.Contrasena};{u.PaisFavorito};{u.Puntos};{quinielas};{insignias}");
            }
        }
    }
}
