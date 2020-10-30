using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoGupar.Models
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Entradas { get; set; }
        public decimal Salidas { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioCompraAlm1 { get; set; }
        public decimal PrecioCompraAlm2 { get; set; }
        public decimal PorcentajeVenta { get; set; }
        public decimal PrecioVentaAlm1 { get; set; }
        public decimal PrecioVentaAlm2 { get; set; }
        public decimal Ganancia { get; set; }
        public string Ubicacion { get; set; }
    }
}
