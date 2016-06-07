namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicSubjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AvailableAnswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        AnswerString = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionString = c.String(),
                        TestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: true)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AcademicSubjectID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CountQuestions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AcademicSubjects", t => t.AcademicSubjectID, cascadeDelete: true)
                .Index(t => t.AcademicSubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TestID", "dbo.Tests");
            DropForeignKey("dbo.Tests", "AcademicSubjectID", "dbo.AcademicSubjects");
            DropForeignKey("dbo.AvailableAnswers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.Tests", new[] { "AcademicSubjectID" });
            DropIndex("dbo.Questions", new[] { "TestID" });
            DropIndex("dbo.AvailableAnswers", new[] { "QuestionID" });
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.AvailableAnswers");
            DropTable("dbo.AcademicSubjects");
        }
    }
}
