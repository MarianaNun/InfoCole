namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposDeNoticaAjustados : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Noticias", "Titulo", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Noticias", "Descripcion", c => c.String(nullable: false, maxLength: 115));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Noticias", "Descripcion", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Noticias", "Titulo", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
