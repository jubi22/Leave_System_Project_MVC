namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "IsSpecialPermission", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "IsSpecialPermission", c => c.Int(nullable: false));
        }
    }
}
