namespace Saphyr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gerente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Matricula = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shopping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Endereco = c.String(),
                        AreaTotal = c.Single(nullable: false),
                        NumeroPiso = c.Int(nullable: false),
                        GerenteResponsavelId = c.Int(),
                        Gerente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gerente", t => t.GerenteResponsavelId)
                .ForeignKey("dbo.Gerente", t => t.Gerente_Id)
                .Index(t => t.GerenteResponsavelId)
                .Index(t => t.Gerente_Id);
            
            CreateTable(
                "dbo.Loja",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CNPJ = c.String(nullable: false),
                        Localizacao = c.String(),
                        ShoppingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shopping", t => t.ShoppingId, cascadeDelete: true)
                .Index(t => t.ShoppingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shopping", "Gerente_Id", "dbo.Gerente");
            DropForeignKey("dbo.Loja", "ShoppingId", "dbo.Shopping");
            DropForeignKey("dbo.Shopping", "GerenteResponsavelId", "dbo.Gerente");
            DropIndex("dbo.Loja", new[] { "ShoppingId" });
            DropIndex("dbo.Shopping", new[] { "Gerente_Id" });
            DropIndex("dbo.Shopping", new[] { "GerenteResponsavelId" });
            DropTable("dbo.Loja");
            DropTable("dbo.Shopping");
            DropTable("dbo.Gerente");
        }
    }
}
