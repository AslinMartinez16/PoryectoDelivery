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

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
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
    }
}
