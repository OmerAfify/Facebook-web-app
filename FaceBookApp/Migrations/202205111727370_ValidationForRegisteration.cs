namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationForRegisteration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "firstName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "lastName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "country", c => c.String(maxLength: 15));
            AlterColumn("dbo.Users", "city", c => c.String(maxLength: 15));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "password", c => c.String());
            AlterColumn("dbo.Users", "email", c => c.String());
            AlterColumn("dbo.Users", "city", c => c.String());
            AlterColumn("dbo.Users", "country", c => c.String());
            AlterColumn("dbo.Users", "lastName", c => c.String());
            AlterColumn("dbo.Users", "firstName", c => c.String());
        }
    }
}
