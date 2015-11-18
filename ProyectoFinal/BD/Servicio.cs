using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BD
{
    public class Servicio
    {
        public int ServicioId { get; set; }
        public String NombreServicio { get; set; }
        public float Precio { get; set; }

        public virtual int ProveedorProveedorId { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
