namespace BotTelegramDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFioAndUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "UserID");
        }
    }
}
