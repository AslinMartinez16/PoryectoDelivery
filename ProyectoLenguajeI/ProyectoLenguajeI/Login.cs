using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Datos;

namespace ProyectoLenguajeI
{
    public partial class InicioFormulario : Form
    {
        public InicioFormulario()
        {
            InitializeComponent();
        }

        //Usuario user;
        string _nombreUsuario = "DEUNA";
        string _password = "1234";
        int contador = 0;

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            contador ++;
            if (contador == 3)
            {
                MessageBox.Show("Tiene tres intentos fallidos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if ( UsuarioTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese el nombre de usuario.");
                UsuarioTextBox.Focus();
                return;
            }
            errorProvider1.Clear();


            if (PasswordTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(PasswordTextBox, "Ingrese la contraseña");
                PasswordTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            //user = new Usuario(UsuarioTextBox.Text, PasswordTextBox.Text);

            UsuarioDatos userDatos = new UsuarioDatos();

            bool usuarioValido = userDatos.ValidarLogin(UsuarioTextBox.Text, PasswordTextBox.Text);
            if (usuarioValido)
            {
                Menu miMenu = new Menu();
                this.Hide();
                miMenu.Show();
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
