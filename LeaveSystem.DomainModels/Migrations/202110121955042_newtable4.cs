namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsSpecialPermission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsSpecialPermission");
        }
    }
}
