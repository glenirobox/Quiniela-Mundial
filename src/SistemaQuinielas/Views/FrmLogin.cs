using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;
using SistemaQuinielas.Utils;
namespace SistemaQuinielas.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            UsuarioService servicioUsuarios = new UsuarioService();

            List<Usuario> usuarios = servicioUsuarios.ObtenerUsuarios();

            string nombre = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            Usuario? usuarioEncontrado = usuarios.Find(u => u.Nombre == nombre && u.Contrasena == contrasena);

            if (usuarioEncontrado != null)
            {
                SesionActual.UsuarioActual = usuarioEncontrado;

                MessageBox.Show("Inicio de sesión exitoso.");

                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                menu.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FrmRegistro registro = new FrmRegistro();
            registro.ShowDialog();
        }
    }
}
