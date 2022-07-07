namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dislikesColumnToPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "dislikes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "dislikes");
        }
    }
}
