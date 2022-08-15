using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public decimal Descuento { get; set; }
        public decimal Recargo { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public Factura()
        {

        }

        public Factura(int id, DateTime fecha, string cliente, string ciudad, string direccion, decimal descuento, decimal recargo, decimal subTotal, decimal total)
        {
            Id = id;
            Fecha = fecha;
            Cliente = cliente;
            Ciudad = ciudad;
            Direccion = direccion;
            Descuento = descuento;
            Recargo = recargo;
            SubTotal = subTotal;
            Total = total;
        }
    }
}
