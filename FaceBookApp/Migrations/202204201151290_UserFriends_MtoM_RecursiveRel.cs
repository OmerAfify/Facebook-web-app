namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFriends_MtoM_RecursiveRel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        friendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.friendId })
                .ForeignKey("dbo.Users", t => t.friendId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .Index(t => t.userId)
                .Index(t => t.friendId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFriends", "userId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "friendId", "dbo.Users");
            DropIndex("dbo.UserFriends", new[] { "friendId" });
            DropIndex("dbo.UserFriends", new[] { "userId" });
            DropTable("dbo.UserFriends");
        }
    }
}
