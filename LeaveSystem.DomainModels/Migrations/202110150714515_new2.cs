namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "AproveID", c => c.Int(nullable: false));
           
        }
        
        public override void Down()
        {
           
            DropColumn("dbo.Leaves", "AproveID");
        }
    }
}
