namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Permission", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetRoles", "Permission", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Permission");
            DropColumn("dbo.Menus", "Permission");
        }
    }
}
