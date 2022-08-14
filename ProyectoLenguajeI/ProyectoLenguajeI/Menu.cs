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
        Productos formularioProductos;
        Facturacion formularioFactura;
        private void SalirToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ListaUsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            if (formularioUsuarios == null)
            {
                formularioUsuarios = new Usuarios();
                formularioUsuarios.MdiParent = this;
                formularioUsuarios.FormClosed += FormularioUsuarios_FormClosed;
                formularioUsuarios.Show();
            }
            else
            {
                formularioUsuarios.Activate();
            }
            
        }

        private void FormularioUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioUsuarios= null;
        }

        private void ClientesToolStripButton_Click(object sender, EventArgs e)
        {
            if (formularioClientes == null)
            {
                formularioClientes = new Clientes();
                formularioClientes.MdiParent = this;
                formularioClientes.FormClosed += FormularioClientes_FormClosed;
                formularioClientes.Show();
            }
            else
            {
                formularioClientes.Activate();
            }
            
        }

        private void FormularioClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioClientes =null;
        }

        private void ProductosToolStripButton_Click(object sender, EventArgs e)
        {
            if (formularioProductos == null)
            {
                formularioProductos = new Productos();
                formularioProductos.MdiParent = this;
                formularioProductos.FormClosed += FormularioProductos_FormClosed;
                formularioProductos.Show();
            }
            else
            {
                formularioProductos.Activate();
            }
            
        }

        private void FormularioProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioProductos = null;
        }

        private void GenerarFacturaToolStripButton_Click(object sender, EventArgs e)
        {
            if (formularioFactura == null)
            {
                formularioFactura = new Facturacion();
                formularioFactura.MdiParent = this;
                formularioFactura.FormClosed += FormularioFactura_FormClosed;
                formularioFactura.Show();
            }
            else
            {
                formularioFactura.Activate();
            }
        }

        private void FormularioFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioFactura= null;
        }
    }
}
