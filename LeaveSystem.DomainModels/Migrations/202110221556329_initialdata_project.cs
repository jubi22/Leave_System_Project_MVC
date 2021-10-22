namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdata_project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 250),
                        EmployeeEmail = c.String(maxLength: 250),
                        Password = c.String(maxLength: 250),
                        EmployeeContactNo = c.String(maxLength: 250),
                        RoleID = c.Int(nullable: false),
                        IsSpecialPermission = c.Int(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        LeaveStartDate = c.DateTime(nullable: false),
                        LeaveEndDate = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                        Leavetype = c.String(),
                        LeaveStatusID = c.Int(nullable: false),
                        LeaveDescription = c.String(maxLength: 250),
                        ApprovedDate = c.DateTime(),
                        ApproverID = c.Int(),
                    })
                .PrimaryKey(t => t.LeaveID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.LeaveStatus", t => t.LeaveStatusID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.LeaveStatusID);
            
            CreateTable(
                "dbo.LeaveStatus",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "LeaveStatusID", "dbo.LeaveStatus");
            DropForeignKey("dbo.Leaves", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "RoleID", "dbo.Roles");
            DropIndex("dbo.Leaves", new[] { "LeaveStatusID" });
            DropIndex("dbo.Leaves", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "RoleID" });
            DropTable("dbo.LeaveStatus");
            DropTable("dbo.Leaves");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
        }
    }
}
