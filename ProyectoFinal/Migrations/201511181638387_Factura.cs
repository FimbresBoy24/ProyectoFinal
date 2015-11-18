namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Factura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistentes",
                c => new
                    {
                        AsistenteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsistenteId);
            
            CreateTable(
                "dbo.CuentaProveedors",
                c => new
                    {
                        CuentaId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Contrasena = c.String(),
                    })
                .PrimaryKey(t => t.CuentaId);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        AsistenteAsistenteId = c.Int(nullable: false),
                        ServicioServicioId = c.Int(nullable: false),
                        Proveedor_ProveedorId = c.Int(),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Proveedors", t => t.Proveedor_ProveedorId)
                .ForeignKey("dbo.Servicios", t => t.ServicioServicioId, cascadeDelete: true)
                .Index(t => t.ServicioServicioId)
                .Index(t => t.Proveedor_ProveedorId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(),
                        Direccion = c.String(),
                        Giro = c.String(),
                    })
                .PrimaryKey(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        ServicioId = c.Int(nullable: false, identity: true),
                        NombreServicio = c.String(),
                        Precio = c.Single(nullable: false),
                        ProveedorProveedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioId)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorProveedorId, cascadeDelete: true)
                .Index(t => t.ProveedorProveedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicios", "ProveedorProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Facturas", "ServicioServicioId", "dbo.Servicios");
            DropForeignKey("dbo.Facturas", "Proveedor_ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Servicios", new[] { "ProveedorProveedorId" });
            DropIndex("dbo.Facturas", new[] { "Proveedor_ProveedorId" });
            DropIndex("dbo.Facturas", new[] { "ServicioServicioId" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Facturas");
            DropTable("dbo.CuentaProveedors");
            DropTable("dbo.Asistentes");
        }
    }
}
