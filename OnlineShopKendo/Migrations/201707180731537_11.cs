namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Text", c => c.String());
        }
    }
}
