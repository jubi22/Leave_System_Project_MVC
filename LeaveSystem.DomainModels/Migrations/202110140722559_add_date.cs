namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "ApprovedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leaves", "ApprovedDate");
        }
    }
}
