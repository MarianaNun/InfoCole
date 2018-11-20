namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Linea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lineas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Ramal = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Comentarios", "Linea_ID", c => c.Int());
            CreateIndex("dbo.Comentarios", "Linea_ID");
            AddForeignKey("dbo.Comentarios", "Linea_ID", "dbo.Lineas", "ID");
            DropColumn("dbo.Comentarios", "Linea");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comentarios", "Linea", c => c.String());
            DropForeignKey("dbo.Comentarios", "Linea_ID", "dbo.Lineas");
            DropIndex("dbo.Comentarios", new[] { "Linea_ID" });
            DropColumn("dbo.Comentarios", "Linea_ID");
            DropTable("dbo.Lineas");
        }
    }
}
