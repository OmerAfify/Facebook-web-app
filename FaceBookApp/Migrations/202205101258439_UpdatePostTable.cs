namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "commentsNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "commentsNumber");
        }
    }
}
