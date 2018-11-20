namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Noticias2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Noticias", "FechaPublicacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Noticias", "FechaPublicacion");
        }
    }
}
