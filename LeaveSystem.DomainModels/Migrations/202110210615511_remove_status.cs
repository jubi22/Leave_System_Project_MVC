namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_status : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Leaves", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaves", "Status", c => c.String());
        }
    }
}
