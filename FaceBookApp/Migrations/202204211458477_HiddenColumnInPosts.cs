namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HiddenColumnInPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "hidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "hidden");
        }
    }
}
