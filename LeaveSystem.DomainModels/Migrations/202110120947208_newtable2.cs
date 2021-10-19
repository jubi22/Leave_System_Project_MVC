namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "Days", c => c.Int(nullable: false));
            AddColumn("dbo.Leaves", "Leavetype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leaves", "Leavetype");
            DropColumn("dbo.Leaves", "Days");
        }
    }
}
