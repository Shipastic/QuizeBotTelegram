namespace BotTelegramDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteNameGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "NameListGroup", c => c.String());
            DropColumn("dbo.ListGroups", "NameGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListGroups", "NameGroup", c => c.String());
            DropColumn("dbo.Groups", "NameListGroup");
        }
    }
}
