namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rutas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lineas", "Nombre", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lineas", "Nombre", c => c.String());
        }
    }
}
