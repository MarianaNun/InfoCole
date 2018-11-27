namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuntosRutas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PuntoMapas",
                c => new
                    {
                        PuntoMapaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Long = c.String(),
                        Lat = c.String(),
                        TipoPuntoMapaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PuntoMapaId)
                .ForeignKey("dbo.TipoPuntoMapas", t => t.TipoPuntoMapaId, cascadeDelete: true)
                .Index(t => t.TipoPuntoMapaId);
            
            CreateTable(
                "dbo.TipoPuntoMapas",
                c => new
                    {
                        TipoPuntoMapaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPuntoMapaId);
            
            CreateTable(
                "dbo.Rutas",
                c => new
                    {
                        RutaId = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RutaId)
                .ForeignKey("dbo.Lineas", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.PuntoRutas",
                c => new
                    {
                        PuntoMapaId = c.Int(nullable: false, identity: true),
                        RutaId = c.Int(nullable: false),
                        Long = c.String(),
                        Lat = c.String(),
                    })
                .PrimaryKey(t => t.PuntoMapaId)
                .ForeignKey("dbo.Rutas", t => t.RutaId, cascadeDelete: true)
                .Index(t => t.RutaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PuntoRutas", "RutaId", "dbo.Rutas");
            DropForeignKey("dbo.Rutas", "ID", "dbo.Lineas");
            DropForeignKey("dbo.PuntoMapas", "TipoPuntoMapaId", "dbo.TipoPuntoMapas");
            DropIndex("dbo.PuntoRutas", new[] { "RutaId" });
            DropIndex("dbo.Rutas", new[] { "ID" });
            DropIndex("dbo.PuntoMapas", new[] { "TipoPuntoMapaId" });
            DropTable("dbo.PuntoRutas");
            DropTable("dbo.Rutas");
            DropTable("dbo.TipoPuntoMapas");
            DropTable("dbo.PuntoMapas");
        }
    }
}
