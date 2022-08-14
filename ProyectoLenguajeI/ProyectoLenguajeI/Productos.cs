using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguajeI
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        string operacion = string.Empty;
        BindingList<Producto> listaProductos = new BindingList<Producto>();
        Producto producto;

        private void ListarProductos()
        {
            ProductosDataGridView.DataSource = null;
            ProductosDataGridView.DataSource = listaProductos;
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
            ExistenciaTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;

        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ExistenciaTextBox.Clear();
            PrecioTextBox.Clear();
        }

        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DeshabilitarControles();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            ListarProductos();
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

            producto = new Producto(CodigoTextBox.Text, NombreTextBox.Text,
                    Convert.ToInt32(ExistenciaTextBox.Text), Convert.ToDecimal(PrecioTextBox.Text));

            if (operacion == "Nuevo")
            {
                listaProductos.Add(producto);
                ListarProductos();

                LimpiarControles();
                DeshabilitarControles();

            }
            else if (operacion == "Modificar")
            {
                foreach (Producto item in listaProductos)
                {
                    if (item.Codigo == CodigoTextBox.Text)
                    {
                        item.Nombre = NombreTextBox.Text;
                        item.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
                        item.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                        break;
                    }
                }
                ListarProductos();
                LimpiarControles();
                DeshabilitarControles();

            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();
                CodigoTextBox.Enabled = false;

                CodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ExistenciaTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();


            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                foreach (var prod in listaProductos)
                {
                    if (prod.Codigo == ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString())
                    {
                        listaProductos.Remove(prod);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListarProductos();
        }
    }
}
