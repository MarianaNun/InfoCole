namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertaTransito : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transitoes", "Tipo_ID", c => c.Int());
            CreateIndex("dbo.Transitoes", "Tipo_ID");
            AddForeignKey("dbo.Transitoes", "Tipo_ID", "dbo.TipoAlertas", "ID");
            DropColumn("dbo.Transitoes", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transitoes", "Tipo", c => c.String());
            DropForeignKey("dbo.Transitoes", "Tipo_ID", "dbo.TipoAlertas");
            DropIndex("dbo.Transitoes", new[] { "Tipo_ID" });
            DropColumn("dbo.Transitoes", "Tipo_ID");
        }
    }
}
