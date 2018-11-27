namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuntosRutas3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PuntoMapas", "Long", c => c.String(nullable: false));
            AlterColumn("dbo.PuntoMapas", "Lat", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PuntoMapas", "Lat", c => c.String());
            AlterColumn("dbo.PuntoMapas", "Long", c => c.String());
        }
    }
}
