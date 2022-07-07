namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAndPosts_1toM_RelationShip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "userId");
            AddForeignKey("dbo.Posts", "userId", "dbo.Users", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "userId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "userId" });
            DropColumn("dbo.Posts", "userId");
        }
    }
}
