namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fecha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "Fecha", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Facturas", "AsistenteAsistenteId");
            AddForeignKey("dbo.Facturas", "AsistenteAsistenteId", "dbo.Asistentes", "AsistenteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "AsistenteAsistenteId", "dbo.Asistentes");
            DropIndex("dbo.Facturas", new[] { "AsistenteAsistenteId" });
            DropColumn("dbo.Facturas", "Fecha");
        }
    }
}
