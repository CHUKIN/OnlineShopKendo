namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "Menu_Id" });
            DropColumn("dbo.Menus", "Menu_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Menu_Id", c => c.Int());
            CreateIndex("dbo.Menus", "Menu_Id");
            AddForeignKey("dbo.Menus", "Menu_Id", "dbo.Menus", "Id");
        }
    }
}
