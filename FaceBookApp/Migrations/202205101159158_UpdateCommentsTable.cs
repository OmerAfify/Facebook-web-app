namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCommentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "userId");
            AddForeignKey("dbo.Comments", "userId", "dbo.Users", "id", cascadeDelete: false);
            DropColumn("dbo.Comments", "author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "author", c => c.String());
            DropForeignKey("dbo.Comments", "userId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "userId" });
            DropColumn("dbo.Comments", "userId");
        }
    }
}
