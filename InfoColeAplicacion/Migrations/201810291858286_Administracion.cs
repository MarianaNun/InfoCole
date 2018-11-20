namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Administracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Habilitado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Habilitado");
        }
    }
}
