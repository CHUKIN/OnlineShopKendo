namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Language_Id = c.Int(),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.Language_Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Language_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuLanguages", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Menus", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuLanguages", "Language_Id", "dbo.Languages");
            DropIndex("dbo.Menus", new[] { "Menu_Id" });
            DropIndex("dbo.MenuLanguages", new[] { "Menu_Id" });
            DropIndex("dbo.MenuLanguages", new[] { "Language_Id" });
            DropTable("dbo.Menus");
            DropTable("dbo.MenuLanguages");
        }
    }
}
