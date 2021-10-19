namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Leaves", "testid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaves", "testid", c => c.Int(nullable: false));
        }
    }
}
