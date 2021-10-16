namespace BotTelegramDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameGroupForListGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListGroups", "NameGroup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListGroups", "NameGroup");
        }
    }
}
