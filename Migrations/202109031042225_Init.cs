namespace BotTelegramDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsRight = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        QuestionScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        NameGroup = c.String(),
                        ListGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.ListGroups", t => t.ListGroupId, cascadeDelete: true, name:"FKListGroupId")
                .Index(t => t.ListGroupId);
            
            CreateTable(
                "dbo.ListGroups",
                c => new
                    {
                        ListGroupId = c.Int(nullable: false, identity: true),
                        NameGroupFromList = c.String(),
                    })
                .PrimaryKey(t => t.ListGroupId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserInfoID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        GroupName = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserInfoID)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "ListGroupId", "dbo.ListGroups");
            DropForeignKey("dbo.Groups", "FKListGroupId");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.UserInfoes", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "ListGroupId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.ListGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
