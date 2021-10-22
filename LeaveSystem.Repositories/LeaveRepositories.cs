using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.DomainModels;
using LeaveSystem.ViewModels;
namespace LeaveSystem.Repositories
{

    public class LeavesRepository : ILeavesRepository
    {
        private readonly ConnectDB dbcontext = new ConnectDB();

        public List<DTO.LeavesDTO> GetLeaveByID(int ID)
        {
            List<LeaveStatus> leaveStatuses = dbcontext.LeaveStatus.ToList();
            List<Employee> employees = dbcontext.Employees.ToList();
            List<Leaves> leaves = dbcontext.Leaves.Where(t => t.EmployeeID==ID).ToList();
            var temp = from l in leaves
                       join e in employees on
                        l.ApproverID equals e.EmployeeID into table1    
                        from e in table1.DefaultIfEmpty() join
                        ls in leaveStatuses on l.LeaveStatusID equals ls.StatusID into table2
                        from ls in table2
                       select new DTO.LeavesDTO
                       {
                           Employee = e,
                           Leaves = l,
                           LeaveStatus=ls
                       };
            return temp.ToList() ;
        }
        public void ApplyLeaves(Leaves leaves)
        {
            dbcontext.Leaves.Add(leaves);
            dbcontext.SaveChanges();
        }
        public List<DTO.LeavesDTO> GetLeaveDetails()
        {
            List<LeaveStatus> leaveStatuses = dbcontext.LeaveStatus.ToList();
            List<Employee> employees = dbcontext.Employees.ToList();
            List<Leaves> leaves = dbcontext.Leaves.ToList();
            var temp = from e in employees
                       join l in leaves
                        on e.EmployeeID equals l.EmployeeID into table1
                        from l in table1.ToList()
                        join ls in leaveStatuses on l.LeaveStatusID equals ls.StatusID into table2
                        from ls in table2.ToList()
                       select new DTO.LeavesDTO
                       {
                           Employee=e,
                           Leaves=l,
                           LeaveStatus=ls
                       };            
            
            return temp.ToList();
        }
        public void UpdateLeave(Leaves leaves)
        {
            Leaves l = dbcontext.Leaves.Where(t => t.LeaveID==leaves.LeaveID).FirstOrDefault();
            if (l != null)
            {
                l.ApproverID = leaves.ApproverID;
                //l.Status = leaves.Status;
                l.LeaveStatusID = leaves.LeaveStatusID;
                l.ApprovedDate = leaves.ApprovedDate;
             
                dbcontext.SaveChanges();
            }
        }
    }
}
