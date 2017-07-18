namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Controller", c => c.String());
            AddColumn("dbo.Menus", "Action", c => c.String());
            DropColumn("dbo.Menus", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Path", c => c.String());
            DropColumn("dbo.Menus", "Action");
            DropColumn("dbo.Menus", "Controller");
        }
    }
}
