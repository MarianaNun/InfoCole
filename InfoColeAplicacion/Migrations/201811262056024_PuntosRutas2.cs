namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuntosRutas2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PuntoMapas", "Descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PuntoMapas", "Descripcion");
        }
    }
}
