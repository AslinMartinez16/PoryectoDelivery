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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;
        BindingList<Usuario> listaUsuarios = new BindingList<Usuario>();
        Usuario user;



        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = null;
            UsuariosDataGridView.DataSource = listaUsuarios;
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
            ClaveTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            TelefonoTextBox.Enabled = true;
        }


        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ClaveTextBox.Clear();
            CorreoTextBox.Clear();
            TelefonoTextBox.Clear();
        }

        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DeshabilitarControles();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            if (CodigoTextBox.Text== string.Empty)
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

            user= new Usuario();
            user.Codigo=CodigoTextBox.Text;
            user.Nombre=NombreTextBox.Text;
            user.Clave = ClaveTextBox.Text;
            user.Correo=CorreoTextBox.Text;
            user.Telefono=TelefonoTextBox.Text;


            if (operacion == "Nuevo")
            {
                listaUsuarios.Add(user);
                ListarUsuarios();

                LimpiarControles();
                DeshabilitarControles();

            }
            else if (operacion == "Modificar")
            {
                foreach (Usuario item in listaUsuarios)
                {
                    if (item.Codigo == CodigoTextBox.Text)
                    {
                        item.Nombre=NombreTextBox.Text;
                        item.Clave=ClaveTextBox.Text;
                        item.Correo = CorreoTextBox.Text;
                        item.Telefono = TelefonoTextBox.Text;
                    }
                }
                ListarUsuarios();
                LimpiarControles();
                DeshabilitarControles();

            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();
                CodigoTextBox.Enabled = false;

                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ClaveTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                CorreoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                TelefonoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();


            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                foreach (var user in listaUsuarios)
                {
                    if ( user.Codigo == UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString())
                    {
                        listaUsuarios.Remove(user);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListarUsuarios();
        }
    }
}
