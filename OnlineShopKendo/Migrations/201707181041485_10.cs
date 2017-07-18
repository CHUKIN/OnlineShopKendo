namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Path");
        }
    }
}
