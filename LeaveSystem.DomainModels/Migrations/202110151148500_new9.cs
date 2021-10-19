namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "ApproverID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leaves", "ApproverID");
        }
    }
}
