namespace BotTelegramDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TGBOTLOGs",
                c => new
                    {
                        TGBOTLOGID = c.Int(nullable: false, identity: true),
                        DT = c.DateTime(nullable: false),
                        LOG_TEXT = c.String(),
                        LEVEL_ID = c.String(),
                        CLASS = c.String(),
                        STACK_TRACE = c.String(),
                    })
                .PrimaryKey(t => t.TGBOTLOGID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TGBOTLOGs");
        }
    }
}
