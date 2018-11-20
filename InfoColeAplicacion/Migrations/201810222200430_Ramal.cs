namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ramal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ramals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Linea_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lineas", t => t.Linea_ID)
                .Index(t => t.Linea_ID);
            
            AddColumn("dbo.Comentarios", "Ramal_ID", c => c.Int());
            CreateIndex("dbo.Comentarios", "Ramal_ID");
            AddForeignKey("dbo.Comentarios", "Ramal_ID", "dbo.Ramals", "ID");
            DropColumn("dbo.Lineas", "Ramal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lineas", "Ramal", c => c.String());
            DropForeignKey("dbo.Ramals", "Linea_ID", "dbo.Lineas");
            DropForeignKey("dbo.Comentarios", "Ramal_ID", "dbo.Ramals");
            DropIndex("dbo.Ramals", new[] { "Linea_ID" });
            DropIndex("dbo.Comentarios", new[] { "Ramal_ID" });
            DropColumn("dbo.Comentarios", "Ramal_ID");
            DropTable("dbo.Ramals");
        }
    }
}
