namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Noticias90 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Noticias", "LinkNoticia", c => c.String());
            AddColumn("dbo.Noticias", "LinkImagen", c => c.String());
            DropColumn("dbo.Noticias", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Noticias", "Link", c => c.String());
            DropColumn("dbo.Noticias", "LinkImagen");
            DropColumn("dbo.Noticias", "LinkNoticia");
        }
    }
}
