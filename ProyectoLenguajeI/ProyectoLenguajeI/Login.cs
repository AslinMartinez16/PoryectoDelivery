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


namespace ProyectoLenguajeI
{
    public partial class InicioFormulario : Form
    {
        public InicioFormulario()
        {
            InitializeComponent();
        }

        Usuario user;
        string _nombreUsuario = "DEUNA";
        string _password = "1234";

        private void AceptarButton_Click(object sender, EventArgs e)
        {
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
            user = new Usuario(UsuarioTextBox.Text, PasswordTextBox.Text);
            
            if (user.Codigo.ToUpper() == _nombreUsuario && user.Clave == _password)
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
    }
}
