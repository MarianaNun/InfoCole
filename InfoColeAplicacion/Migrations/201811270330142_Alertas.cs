namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alertas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alertas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contenido = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EstadoLineas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contenido = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Tipo = c.String(),
                        Linea_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lineas", t => t.Linea_ID)
                .Index(t => t.Linea_ID);
            
            CreateTable(
                "dbo.Transitoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contenido = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstadoLineas", "Linea_ID", "dbo.Lineas");
            DropIndex("dbo.EstadoLineas", new[] { "Linea_ID" });
            DropTable("dbo.Transitoes");
            DropTable("dbo.EstadoLineas");
            DropTable("dbo.Alertas");
        }
    }
}
