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
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbRegistrodeUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtPaisFavorito.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }
            // crear el objeto usuario
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = txtNombre.Text.Trim();
            nuevoUsuario.Contrasena = txtContrasena.Text;
            nuevoUsuario.PaisFavorito = txtPaisFavorito.Text.Trim();

            UsuarioService servicioUsuarios = new UsuarioService();
            try
            {
                servicioUsuarios.RegistrarUsuario(nuevoUsuario);
                MessageBox.Show("Usuario registrado correctamente.");
                txtNombre.Clear();
                txtContrasena.Clear();
                txtPaisFavorito.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
