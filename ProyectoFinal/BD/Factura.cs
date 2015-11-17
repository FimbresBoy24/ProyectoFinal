using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BD
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public virtual int IdProveedor { get; set; }
        public virtual int IdAsistente { get; set; }
    }
}
