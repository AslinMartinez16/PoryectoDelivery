using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Facturador
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public Facturador()
        {

        }

        public Facturador(int id, DateTime fecha, string cliente, decimal iSV, decimal descuento, decimal subTotal, decimal total)
        {
            Id = id;
            Fecha = fecha;
            Cliente = cliente;
            ISV = iSV;
            Descuento = descuento;
            SubTotal = subTotal;
            Total = total;
        }
    }
}
