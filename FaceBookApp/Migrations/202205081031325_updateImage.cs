namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "profileImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "profileImage", c => c.Binary());
        }
    }
}
