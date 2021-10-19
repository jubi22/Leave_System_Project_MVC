namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latestdata2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "ProjectID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ProjectID", c => c.Int(nullable: false));
        }
    }
}
