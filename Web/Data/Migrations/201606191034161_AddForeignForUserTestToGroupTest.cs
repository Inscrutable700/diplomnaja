namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignForUserTestToGroupTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTests", "GroupToTestID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserTests", "GroupToTestID");
            AddForeignKey("dbo.UserTests", "GroupToTestID", "dbo.GroupToTests", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTests", "GroupToTestID", "dbo.GroupToTests");
            DropIndex("dbo.UserTests", new[] { "GroupToTestID" });
            DropColumn("dbo.UserTests", "GroupToTestID");
        }
    }
}
