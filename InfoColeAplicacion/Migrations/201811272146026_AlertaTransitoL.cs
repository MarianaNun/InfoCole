namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertaTransitoL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alertas", "Tipo_ID", "dbo.TipoAlertas");
            RenameColumn(table: "dbo.Alertas", name: "Tipo_ID", newName: "Tipo_TipoID");
            RenameIndex(table: "dbo.Alertas", name: "IX_Tipo_ID", newName: "IX_Tipo_TipoID");
            DropPrimaryKey("dbo.TipoAlertas");
            DropColumn("dbo.TipoAlertas", "ID");
            AddColumn("dbo.TipoAlertas", "TipoID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Transitoes", "TipoID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TipoAlertas", "TipoID");
            CreateIndex("dbo.Transitoes", "TipoID");
            AddForeignKey("dbo.Transitoes", "TipoID", "dbo.TipoAlertas", "TipoID", cascadeDelete: true);
            AddForeignKey("dbo.Alertas", "Tipo_TipoID", "dbo.TipoAlertas", "TipoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TipoAlertas", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Alertas", "Tipo_TipoID", "dbo.TipoAlertas");
            DropForeignKey("dbo.Transitoes", "TipoID", "dbo.TipoAlertas");
            DropIndex("dbo.Transitoes", new[] { "TipoID" });
            DropPrimaryKey("dbo.TipoAlertas");
            DropColumn("dbo.Transitoes", "TipoID");
            DropColumn("dbo.TipoAlertas", "TipoID");
            AddPrimaryKey("dbo.TipoAlertas", "ID");
            RenameIndex(table: "dbo.Alertas", name: "IX_Tipo_TipoID", newName: "IX_Tipo_ID");
            RenameColumn(table: "dbo.Alertas", name: "Tipo_TipoID", newName: "Tipo_ID");
            AddForeignKey("dbo.Alertas", "Tipo_ID", "dbo.TipoAlertas", "ID");
        }
    }
}
