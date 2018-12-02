namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertasUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alertas", "Tipo_TipoID", "dbo.TipoAlertas");
            DropForeignKey("dbo.EstadoLineas", "Linea_ID", "dbo.Lineas");
            DropIndex("dbo.Alertas", new[] { "Tipo_TipoID" });
            DropIndex("dbo.EstadoLineas", new[] { "Linea_ID" });
            RenameColumn(table: "dbo.Alertas", name: "Tipo_TipoID", newName: "TipoID");
            RenameColumn(table: "dbo.EstadoLineas", name: "Linea_ID", newName: "LineaID");
            AddColumn("dbo.EstadoLineas", "TipoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Alertas", "TipoID", c => c.Int(nullable: false));
            AlterColumn("dbo.EstadoLineas", "LineaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Alertas", "TipoID");
            CreateIndex("dbo.EstadoLineas", "TipoID");
            CreateIndex("dbo.EstadoLineas", "LineaID");
            AddForeignKey("dbo.EstadoLineas", "TipoID", "dbo.TipoAlertas", "TipoID", cascadeDelete: true);
            AddForeignKey("dbo.Alertas", "TipoID", "dbo.TipoAlertas", "TipoID", cascadeDelete: true);
            AddForeignKey("dbo.EstadoLineas", "LineaID", "dbo.Lineas", "ID", cascadeDelete: true);
            DropColumn("dbo.EstadoLineas", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EstadoLineas", "Tipo", c => c.String());
            DropForeignKey("dbo.EstadoLineas", "LineaID", "dbo.Lineas");
            DropForeignKey("dbo.Alertas", "TipoID", "dbo.TipoAlertas");
            DropForeignKey("dbo.EstadoLineas", "TipoID", "dbo.TipoAlertas");
            DropIndex("dbo.EstadoLineas", new[] { "LineaID" });
            DropIndex("dbo.EstadoLineas", new[] { "TipoID" });
            DropIndex("dbo.Alertas", new[] { "TipoID" });
            AlterColumn("dbo.EstadoLineas", "LineaID", c => c.Int());
            AlterColumn("dbo.Alertas", "TipoID", c => c.Int());
            DropColumn("dbo.EstadoLineas", "TipoID");
            RenameColumn(table: "dbo.EstadoLineas", name: "LineaID", newName: "Linea_ID");
            RenameColumn(table: "dbo.Alertas", name: "TipoID", newName: "Tipo_TipoID");
            CreateIndex("dbo.EstadoLineas", "Linea_ID");
            CreateIndex("dbo.Alertas", "Tipo_TipoID");
            AddForeignKey("dbo.EstadoLineas", "Linea_ID", "dbo.Lineas", "ID");
            AddForeignKey("dbo.Alertas", "Tipo_TipoID", "dbo.TipoAlertas", "TipoID");
        }
    }
}
