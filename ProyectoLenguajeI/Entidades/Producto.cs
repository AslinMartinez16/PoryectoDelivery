using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }

        public Producto()
        {
        }

        public Producto(string codigo, string nombre, int existencia, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Existencia = existencia;
            Precio = precio;
        }
    }
}
