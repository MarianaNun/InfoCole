namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comentario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contenido = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Tipo = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comentarios", new[] { "User_Id" });
            DropTable("dbo.Comentarios");
        }
    }
}
