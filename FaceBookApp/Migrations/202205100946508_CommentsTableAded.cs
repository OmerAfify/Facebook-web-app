namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsTableAded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        postId = c.Int(nullable: false),
                        author = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.postId, cascadeDelete: true)
                .Index(t => t.postId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "postId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "postId" });
            DropTable("dbo.Comments");
        }
    }
}
