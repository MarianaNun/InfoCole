namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoAlerta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoAlertas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Alertas", "Tipo_ID", c => c.Int());
            CreateIndex("dbo.Alertas", "Tipo_ID");
            AddForeignKey("dbo.Alertas", "Tipo_ID", "dbo.TipoAlertas", "ID");
            DropColumn("dbo.Alertas", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alertas", "Tipo", c => c.String());
            DropForeignKey("dbo.Alertas", "Tipo_ID", "dbo.TipoAlertas");
            DropIndex("dbo.Alertas", new[] { "Tipo_ID" });
            DropColumn("dbo.Alertas", "Tipo_ID");
            DropTable("dbo.TipoAlertas");
        }
    }
}
