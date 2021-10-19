namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latest5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Leaves", "AprroverName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaves", "AprroverName", c => c.String(maxLength: 250));
        }
    }
}
