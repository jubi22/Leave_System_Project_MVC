namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveStatus",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(maxLength: 250),
                        ApproverName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.StatusID);
            
            AddColumn("dbo.Leaves", "LeaveStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Leaves", "AprroverName", c => c.String(maxLength: 250));
            CreateIndex("dbo.Leaves", "LeaveStatusID");
            AddForeignKey("dbo.Leaves", "LeaveStatusID", "dbo.LeaveStatus", "StatusID", cascadeDelete: true);
            DropColumn("dbo.Leaves", "LeaveStatus");
            DropColumn("dbo.Leaves", "LeaveApproverID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaves", "LeaveApproverID", c => c.Int(nullable: false));
            AddColumn("dbo.Leaves", "LeaveStatus", c => c.String());
            DropForeignKey("dbo.Leaves", "LeaveStatusID", "dbo.LeaveStatus");
            DropIndex("dbo.Leaves", new[] { "LeaveStatusID" });
            DropColumn("dbo.Leaves", "AprroverName");
            DropColumn("dbo.Leaves", "LeaveStatusID");
            DropTable("dbo.LeaveStatus");
        }
    }
}
