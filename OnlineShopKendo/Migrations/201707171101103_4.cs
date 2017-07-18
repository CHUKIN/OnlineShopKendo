namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Item_Id = c.Int(),
                        Language_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Languages", t => t.Language_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Language_Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Language_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.Language_Id)
                .Index(t => t.Language_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Descriptions", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.Languages", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.Descriptions", "Item_Id", "dbo.Items");
            DropIndex("dbo.Languages", new[] { "Language_Id" });
            DropIndex("dbo.Descriptions", new[] { "Language_Id" });
            DropIndex("dbo.Descriptions", new[] { "Item_Id" });
            DropTable("dbo.Languages");
            DropTable("dbo.Descriptions");
        }
    }
}
