using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BD
{
    public class ProyectoFinal : DbContext
    {
        public DbSet<Proveedor> Proveedor { get; set; }

    }
}
