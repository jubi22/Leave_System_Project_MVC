namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leaves", "AproveID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leaves", "AproveID", c => c.Int(nullable: false));
        }
    }
}
