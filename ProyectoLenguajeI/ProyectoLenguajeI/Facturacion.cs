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
    public partial class Facturacion : Form
    {
        public Facturacion()
        {
            InitializeComponent();
        }
        Producto producto;
        BindingList<DetalleFactura> detalles = new BindingList<DetalleFactura>();
        Factura factura = new Factura();

        decimal recargo = 0;
        decimal subTotal = 0;
        decimal descuento = 0;
        decimal total = 0;
        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Producto(CodigoProductoTextBox.Text, ProductoTextBox.Text, 15, 250);

              DetalleFactura detalle = new DetalleFactura();
                detalle.CodigoProducto = producto.Codigo;
                detalle.Descripcion = producto.Nombre;
                detalle.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
                detalle.Precio = producto.Precio;
                detalle.Total = producto.Precio * Convert.ToInt32(CantidadTextBox.Text);

                subTotal += detalle.Total;
                recargo = Convert.ToDecimal(RecargoTextBox.Text);
                total = subTotal + recargo - descuento;

                detalles.Add(detalle);
                FacturaDataGridView.DataSource = null;
                FacturaDataGridView.DataSource = detalles;


                SubTotalTextBox.Text = subTotal.ToString("N2");
                RecargoTextBox.Text = recargo.ToString("N2");
                TotalTextBox.Text = total.ToString("N2");

                ProductoTextBox.Clear();
                DescuentoTextBox.Clear();
                CantidadTextBox.Clear();
                ProductoTextBox.Focus();

            }
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            FacturaDataGridView.DataSource = detalles;
        }
    }
}
