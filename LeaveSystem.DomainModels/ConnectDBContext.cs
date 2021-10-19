using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using LeaveSystem.DomainModels.Migrations;
namespace LeaveSystem.DomainModels
{
    public class ConnectDB : DbContext
    {
        public ConnectDB() : base("ConnectDBstring")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConnectDB, Configuration>());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leaves> Leaves { get; set; }
       
        public DbSet<Role> Roles { get; set; }
        public DbSet<LeaveStatus> LeaveStatus { get; set; }
  
    }
}