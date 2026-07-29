using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SistemaQuinielas.Models;
using SistemaQuinielas.Services;

namespace SistemaQuinielas.Views
{
    public partial class FrmGestionUsuarios : Form
    {   //una sola instancia de UsuarioService que puedo reutilizar desde los diferentes botones.
        private UsuarioService servicioUsuarios = new UsuarioService();
        public FrmGestionUsuarios()
        {

            InitializeComponent();
            CargarUsuarios(); // para q aparezcan los usuarios al abrir el formulario
        }
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = servicioUsuarios.ObtenerUsuarios();
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
        string.IsNullOrWhiteSpace(txtContrasena.Text) ||
        string.IsNullOrWhiteSpace(txtPaisFavorito.Text))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            Usuario nuevoUsuario = new Usuario();

            nuevoUsuario.Nombre = txtNombre.Text.Trim();
            nuevoUsuario.Contrasena = txtContrasena.Text;
            nuevoUsuario.PaisFavorito = txtPaisFavorito.Text.Trim();

            try
            {
                servicioUsuarios.RegistrarUsuario(nuevoUsuario);

                MessageBox.Show("Usuario registrado correctamente.");

                txtNombre.Clear();
                txtContrasena.Clear();
                txtPaisFavorito.Clear();

                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtContrasena.Clear();
            txtPaisFavorito.Clear();
        }
    }
}
