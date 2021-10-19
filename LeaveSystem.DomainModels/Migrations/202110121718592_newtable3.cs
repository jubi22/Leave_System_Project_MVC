namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leaves", "Status");
        }
    }
}
