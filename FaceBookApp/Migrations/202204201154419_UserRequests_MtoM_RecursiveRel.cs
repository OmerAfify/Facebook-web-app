namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRequests_MtoM_RecursiveRel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        requestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.userId, t.requestId })
                .ForeignKey("dbo.Users", t => t.requestId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .Index(t => t.userId)
                .Index(t => t.requestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRequests", "userId", "dbo.Users");
            DropForeignKey("dbo.UserRequests", "requestId", "dbo.Users");
            DropIndex("dbo.UserRequests", new[] { "requestId" });
            DropIndex("dbo.UserRequests", new[] { "userId" });
            DropTable("dbo.UserRequests");
        }
    }
}
