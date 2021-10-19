namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Leaves", "AproveID");
            DropColumn("dbo.Leaves", "PMID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaves", "PMID", c => c.Int());
            AddColumn("dbo.Leaves", "AproveID", c => c.Int());
        }
    }
}
