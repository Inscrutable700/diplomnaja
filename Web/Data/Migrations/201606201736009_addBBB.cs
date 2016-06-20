namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBBB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupToTests", "PointsForComplete", c => c.Int(nullable: false));
            AddColumn("dbo.UserTestAnswers", "Points", c => c.Double(nullable: false));
            AddColumn("dbo.UserTests", "Points", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTests", "Points");
            DropColumn("dbo.UserTestAnswers", "Points");
            DropColumn("dbo.GroupToTests", "PointsForComplete");
        }
    }
}
