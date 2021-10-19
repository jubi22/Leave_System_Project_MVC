namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LeaveStatus", "ApproverName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeaveStatus", "ApproverName", c => c.String(maxLength: 250));
        }
    }
}
