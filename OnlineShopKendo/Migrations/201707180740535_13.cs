namespace OnlineShopKendo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.People", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "City_Id" });
            DropIndex("dbo.People", new[] { "Team_Id" });
            DropColumn("dbo.Descriptions", "Code");
            DropColumn("dbo.Items", "Text");
            DropTable("dbo.Cities");
            DropTable("dbo.Teams");
            DropTable("dbo.People");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "Text", c => c.String());
            AddColumn("dbo.Descriptions", "Code", c => c.String());
            CreateIndex("dbo.People", "Team_Id");
            CreateIndex("dbo.Teams", "City_Id");
            AddForeignKey("dbo.People", "Team_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Teams", "City_Id", "dbo.Cities", "Id");
        }
    }
}
