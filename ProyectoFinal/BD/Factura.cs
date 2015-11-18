using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BD
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public virtual int AsistenteAsistenteId { get; set; }
        public virtual int ServicioServicioId { get; set; }
    }
}
