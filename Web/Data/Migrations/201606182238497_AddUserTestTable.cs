namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTests",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    UserID = c.Int(nullable: false),
                    TestID = c.Int(nullable: false),
                    DateAssigned = c.DateTime(nullable: false),
                    DateCompleted = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.TestID);

            CreateTable(
                "dbo.UserTestAnswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserTestID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        AnswerID = c.Int(),
                        DateAssigned = c.DateTime(nullable: false),
                        DateCompleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AvailableAnswers", t => t.AnswerID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: false)
                .ForeignKey("dbo.UserTests", t => t.UserTestID, cascadeDelete: false)
                .Index(t => t.UserTestID)
                .Index(t => t.QuestionID)
                .Index(t => t.AnswerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTestAnswers", "UserTestID", "dbo.UserTests");
            DropForeignKey("dbo.UserTests", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserTests", "TestID", "dbo.Tests");
            DropForeignKey("dbo.UserTestAnswers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.UserTestAnswers", "AnswerID", "dbo.AvailableAnswers");
            DropIndex("dbo.UserTests", new[] { "TestID" });
            DropIndex("dbo.UserTests", new[] { "UserID" });
            DropIndex("dbo.UserTestAnswers", new[] { "AnswerID" });
            DropIndex("dbo.UserTestAnswers", new[] { "QuestionID" });
            DropIndex("dbo.UserTestAnswers", new[] { "UserTestID" });
            DropTable("dbo.UserTests");
            DropTable("dbo.UserTestAnswers");
        }
    }
}
