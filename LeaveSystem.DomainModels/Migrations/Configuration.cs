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
        }
    }
}
