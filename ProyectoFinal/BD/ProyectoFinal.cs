using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BD
{
    public class HelpMeApp : DbContext
    {
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Asistente> Asistente { get; set; }
        public DbSet<CuentaProveedor> CuentaProveedor { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Factura> Factura { get; set; }

    }
}
