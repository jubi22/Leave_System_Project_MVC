namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringdata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leaves", "ApproverID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leaves", "ApproverID", c => c.String());
        }
    }
}
