namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LikesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        postId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.postId })
                .ForeignKey("dbo.Posts", t => t.postId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .Index(t => t.userId)
                .Index(t => t.postId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "userId", "dbo.Users");
            DropForeignKey("dbo.Likes", "postId", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "postId" });
            DropIndex("dbo.Likes", new[] { "userId" });
            DropTable("dbo.Likes");
        }
    }
}
