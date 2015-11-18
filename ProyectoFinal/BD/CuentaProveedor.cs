using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.BD
{
    public class CuentaProveedor
    {
        [Key]
        public int CuentaId { get; set; }
        public String Usuario { get; set; }
        public String Contrasena { get; set; }
    }
}
