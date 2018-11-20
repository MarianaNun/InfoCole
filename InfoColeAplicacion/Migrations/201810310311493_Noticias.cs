namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Noticias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        NoticiaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 150),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.NoticiaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Noticias");
        }
    }
}
