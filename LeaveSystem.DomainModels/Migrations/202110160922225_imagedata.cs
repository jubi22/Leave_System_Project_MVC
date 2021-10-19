namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagedata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Image");
        }
    }
}
