using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BD
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public String NombreProveedor { get; set; }
        public String Direccion { get; set; }
        public String Giro { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
