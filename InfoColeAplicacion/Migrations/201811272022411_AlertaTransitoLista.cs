namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertaTransitoLista : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transitoes", "Tipo_ID", "dbo.TipoAlertas");
            DropIndex("dbo.Transitoes", new[] { "Tipo_ID" });
            DropColumn("dbo.Transitoes", "Tipo_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transitoes", "Tipo_ID", c => c.Int());
            CreateIndex("dbo.Transitoes", "Tipo_ID");
            AddForeignKey("dbo.Transitoes", "Tipo_ID", "dbo.TipoAlertas", "ID");
        }
    }
}
