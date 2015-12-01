namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "ServicioServicioId", "dbo.Servicios");
            DropIndex("dbo.Facturas", new[] { "ServicioServicioId" });
            AddColumn("dbo.Facturas", "ProveedorIdProveedor", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "Servicio_ServicioId", c => c.Int());
            AddColumn("dbo.Facturas", "Servicio_ServicioId1", c => c.Int());
            CreateIndex("dbo.Facturas", "Servicio_ServicioId");
            CreateIndex("dbo.Facturas", "Servicio_ServicioId1");
            AddForeignKey("dbo.Facturas", "Servicio_ServicioId", "dbo.Servicios", "ServicioId");
            AddForeignKey("dbo.Facturas", "Servicio_ServicioId1", "dbo.Servicios", "ServicioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Servicio_ServicioId1", "dbo.Servicios");
            DropForeignKey("dbo.Facturas", "Servicio_ServicioId", "dbo.Servicios");
            DropIndex("dbo.Facturas", new[] { "Servicio_ServicioId1" });
            DropIndex("dbo.Facturas", new[] { "Servicio_ServicioId" });
            DropColumn("dbo.Facturas", "Servicio_ServicioId1");
            DropColumn("dbo.Facturas", "Servicio_ServicioId");
            DropColumn("dbo.Facturas", "ProveedorIdProveedor");
            CreateIndex("dbo.Facturas", "ServicioServicioId");
            AddForeignKey("dbo.Facturas", "ServicioServicioId", "dbo.Servicios", "ServicioId", cascadeDelete: true);
        }
    }
}
