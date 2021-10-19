namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "PMID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leaves", "PMID");
        }
    }
}
