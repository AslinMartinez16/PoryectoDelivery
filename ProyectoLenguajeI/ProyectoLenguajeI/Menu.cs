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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        Usuarios formularioUsuarios;
        Clientes formularioClientes;
        private void SalirToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ListaUsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            formularioUsuarios = new Usuarios();
            formularioUsuarios.MdiParent = this;
            formularioUsuarios.Show();
        }

        private void ClientesToolStripButton_Click(object sender, EventArgs e)
        {
            formularioClientes = new Clientes();
            formularioClientes.MdiParent = this;
            formularioClientes.Show();
        }
    }
}
