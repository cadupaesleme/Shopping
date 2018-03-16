namespace Saphyr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gerente : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Shopping", name: "GerenteResponsavelId", newName: "GerenteId");
            RenameIndex(table: "dbo.Shopping", name: "IX_GerenteResponsavelId", newName: "IX_GerenteId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Shopping", name: "IX_GerenteId", newName: "IX_GerenteResponsavelId");
            RenameColumn(table: "dbo.Shopping", name: "GerenteId", newName: "GerenteResponsavelId");
        }
    }
}
