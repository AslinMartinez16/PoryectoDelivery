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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;
        BindingList<Cliente> listaClientes = new BindingList<Cliente>();
        Cliente client;

        private void ListarClientes()
        {
            ClientesDataGridView.DataSource = null;
            ClientesDataGridView.DataSource = listaClientes;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            DireccionTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            TelefonoTextBox.Enabled = true;

        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            DireccionTextBox.Clear();
            CorreoTextBox.Clear();
            TelefonoTextBox.Clear();
        }

        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            DireccionTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DeshabilitarControles();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (CodigoTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(CodigoTextBox, "Ingrese el código.");
                CodigoTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                errorProvider1.SetError(NombreTextBox, "Ingrese un nombre.");
                NombreTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            client = new Cliente();
            client.Codigo = CodigoTextBox.Text;
            client.Nombre = NombreTextBox.Text;
            client.Direccion = DireccionTextBox.Text;
            client.Correo = CorreoTextBox.Text;
            client.Telefono = TelefonoTextBox.Text;

            if (operacion == "Nuevo")
            {
                listaClientes.Add(client);
                ListarClientes();

                LimpiarControles();
                DeshabilitarControles();

            }
            else if (operacion == "Modificar")
            {
                foreach (Cliente item in listaClientes)
                {
                    if (item.Codigo == CodigoTextBox.Text)
                    {
                        item.Nombre = NombreTextBox.Text;
                        item.Direccion = DireccionTextBox.Text;
                        item.Correo = CorreoTextBox.Text;
                        item.Telefono = TelefonoTextBox.Text;
                    }
                }
                ListarClientes();
                LimpiarControles();
                DeshabilitarControles();

            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();
                CodigoTextBox.Enabled = false;

                CodigoTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                DireccionTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                CorreoTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                TelefonoTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();


            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                foreach (var client in listaClientes)
                {
                    if (client.Codigo == ClientesDataGridView.CurrentRow.Cells["Codigo"].Value.ToString())
                    {
                        listaClientes.Remove(client);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListarClientes();
        }
    }
}
