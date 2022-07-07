namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikesNavPropToPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "likesNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "likes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "likes", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "likesNumber");
        }
    }
}
