using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BD
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public String NombreServicio { get; set; }
        public virtual int IdProveedor { get; set; }
        public float Precio { get; set; }
    }
}
