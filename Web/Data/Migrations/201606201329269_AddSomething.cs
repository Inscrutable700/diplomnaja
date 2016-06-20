namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomething : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "RightAnswerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "RightAnswerID");
        }
    }
}
