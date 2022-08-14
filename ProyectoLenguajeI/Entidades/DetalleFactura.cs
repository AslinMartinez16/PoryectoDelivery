using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public string CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public DetalleFactura()
        {

        }

        public DetalleFactura(int id, int idFactura, string codigoProducto, int cantidad, decimal precio, decimal total)
        {
            Id = id;
            IdFactura = idFactura;
            CodigoProducto = codigoProducto;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
        }
    }
}
