namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupToTestsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserToQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.UserToQuestions", "UserID", "dbo.Users");
            DropIndex("dbo.UserToQuestions", new[] { "UserID" });
            DropIndex("dbo.UserToQuestions", new[] { "QuestionID" });
            AlterColumn("dbo.GroupToTests", "DateStart", c => c.DateTime());
            AlterColumn("dbo.GroupToTests", "DateEnd", c => c.DateTime());
            DropTable("dbo.UserToQuestions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserToQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.GroupToTests", "DateEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GroupToTests", "DateStart", c => c.DateTime(nullable: false));
            CreateIndex("dbo.UserToQuestions", "QuestionID");
            CreateIndex("dbo.UserToQuestions", "UserID");
            AddForeignKey("dbo.UserToQuestions", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserToQuestions", "QuestionID", "dbo.Questions", "ID", cascadeDelete: true);
        }
    }
}
