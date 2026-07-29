// UsuarioController.cs
using System.Collections.Generic;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;

namespace SistemaQuinielas.Controllers
{
    public class UsuarioController
    {
        private readonly UsuarioService servicio = new UsuarioService();

        public List<Usuario> ObtenerUsuarios() => servicio.ObtenerUsuarios();
        public void RegistrarUsuario(Usuario usuario) => servicio.RegistrarUsuario(usuario);

        public Usuario? IniciarSesion(string nombre, string contrasena)
        {
            return servicio.ObtenerUsuarios().Find(u => u.Nombre == nombre && u.Contrasena == contrasena);
        }
    }
}