namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Some : DbMigration
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
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: true)
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
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.QuestionID);
            
            AddColumn("dbo.Users", "GroupID", c => c.Int());
            CreateIndex("dbo.Users", "GroupID");
            AddForeignKey("dbo.Users", "GroupID", "dbo.Groups", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserToQuestions", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserToQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Users", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.GroupToTests", "TestID", "dbo.Tests");
            DropForeignKey("dbo.GroupToTests", "GroupID", "dbo.Groups");
            DropIndex("dbo.UserToQuestions", new[] { "QuestionID" });
            DropIndex("dbo.UserToQuestions", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "GroupID" });
            DropIndex("dbo.GroupToTests", new[] { "TestID" });
            DropIndex("dbo.GroupToTests", new[] { "GroupID" });
            DropColumn("dbo.Users", "GroupID");
            DropTable("dbo.UserToQuestions");
            DropTable("dbo.GroupToTests");
            DropTable("dbo.Groups");
        }
    }
}
