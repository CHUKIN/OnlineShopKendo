namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Languages", "Language_Id", "dbo.Languages");
            DropIndex("dbo.Languages", new[] { "Language_Id" });
            AddColumn("dbo.Languages", "Code", c => c.String());
            DropColumn("dbo.Items", "Text");
            DropColumn("dbo.Languages", "Language_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Languages", "Language_Id", c => c.Int());
            AddColumn("dbo.Items", "Text", c => c.String());
            DropColumn("dbo.Languages", "Code");
            CreateIndex("dbo.Languages", "Language_Id");
            AddForeignKey("dbo.Languages", "Language_Id", "dbo.Languages", "Id");
        }
    }
}
