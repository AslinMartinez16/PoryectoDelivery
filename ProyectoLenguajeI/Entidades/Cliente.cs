using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public Cliente ()
        {

        }

        public Cliente(string codigo, string nombre, string direccion, string correo, string telefono)
        {
            Codigo = codigo;
            Nombre = nombre;
            Direccion = direccion;
            Correo = correo;
            Telefono = telefono;
        }
    }
}
