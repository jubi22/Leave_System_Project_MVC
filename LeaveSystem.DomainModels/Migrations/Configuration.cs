namespace LeaveSystem.DomainModels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeaveSystem.DomainModels.ConnectDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeaveSystem.DomainModels.ConnectDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Employees.Add
                (
                new Employee()
                {
                    EmployeeName = "HR",
                    EmployeeEmail = "hr@gmail.com",
                    EmployeeContactNo = "+91 987878999",
                    Password = "ade42c8d8740e9cf379b703481b6663ee2f7cfcf22aba5a68fb811842e53f6ed",
                    RoleID = 2,
                    IsSpecialPermission = 0,

                }
                );
            context.Roles.Add(new Role() { RoleID = 1, RoleName = "PM" });
            context.Roles.Add(new Role() { RoleID = 2, RoleName = "HR" });
            context.Roles.Add(new Role() { RoleID = 3, RoleName = "Employee" });
            context.LeaveStatus.Add(new LeaveStatus() { StatusID = 1, Status = "Pending" });
            context.LeaveStatus.Add(new LeaveStatus() { StatusID = 2, Status = "Approved" });
            context.LeaveStatus.Add(new LeaveStatus() { StatusID = 3, Status = "Rejected" });

        }
    }
}
