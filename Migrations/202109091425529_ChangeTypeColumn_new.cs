namespace BotTelegramDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeColumn_new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "NumQuest", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "NumQuestion", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "NumQuestion");
            DropColumn("dbo.Answers", "NumQuest");
        }
    }
}
