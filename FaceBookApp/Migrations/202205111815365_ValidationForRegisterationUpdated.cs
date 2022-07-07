namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationForRegisterationUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "confirmPassWord", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "country", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Users", "city", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Users", "mobileNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "mobileNo", c => c.Int());
            AlterColumn("dbo.Users", "city", c => c.String(maxLength: 15));
            AlterColumn("dbo.Users", "country", c => c.String(maxLength: 15));
            DropColumn("dbo.Users", "confirmPassWord");
        }
    }
}
