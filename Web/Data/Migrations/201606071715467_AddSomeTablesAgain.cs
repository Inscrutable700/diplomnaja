namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeTablesAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupToTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        TestID = c.Int(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        QuestionCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: false)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: false)
                .Index(t => t.GroupID)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.UserToQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.QuestionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserToQuestions", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserToQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.GroupToTests", "TestID", "dbo.Tests");
            DropForeignKey("dbo.GroupToTests", "GroupID", "dbo.Groups");
            DropIndex("dbo.UserToQuestions", new[] { "QuestionID" });
            DropIndex("dbo.UserToQuestions", new[] { "UserID" });
            DropIndex("dbo.GroupToTests", new[] { "TestID" });
            DropIndex("dbo.GroupToTests", new[] { "GroupID" });
            DropTable("dbo.UserToQuestions");
            DropTable("dbo.GroupToTests");
            DropTable("dbo.Groups");
        }
    }
}
