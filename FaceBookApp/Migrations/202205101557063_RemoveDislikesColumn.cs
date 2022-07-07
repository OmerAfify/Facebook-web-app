namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDislikesColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "dislikes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "dislikes", c => c.Int(nullable: false));
        }
    }
}
