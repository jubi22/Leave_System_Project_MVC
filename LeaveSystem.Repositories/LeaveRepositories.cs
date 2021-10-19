using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.DomainModels;
using LeaveSystem.ViewModels;
namespace LeaveSystem.Repositories
{
    public interface ILeavesRepository
    {
        void ApplyLeaves(Leaves leaves);
        List<Leaves> GetLeaveDetails();
        void UpdateLeave(Leaves leaves);
        List<Leaves> GetLeaveByID(int ID);
      
       
  

    }
    public class LeavesRepository : ILeavesRepository
    {
        readonly ConnectDB dbcontext = new ConnectDB();

        public List<Leaves> GetLeaveByID(int ID)
        {
            
            List<Leaves> l = dbcontext.Leaves.Where(t => t.EmployeeID==ID).ToList();
            return l;
        }
        public void ApplyLeaves(Leaves leaves)
        {
            dbcontext.Leaves.Add(leaves);
            dbcontext.SaveChanges();
        }
        public List<Leaves> GetLeaveDetails()
        {
            
            List<Leaves> leaves = dbcontext.Leaves.ToList();
            
            return leaves;
        }
        public void UpdateLeave(Leaves leaves)
        {
            Leaves l = dbcontext.Leaves.Where(t => t.LeaveID==leaves.LeaveID).FirstOrDefault();
            if (l != null)
            {
                l.ApproverID = leaves.ApproverID;
                l.Status = leaves.Status;
                l.ApprovedDate = leaves.ApprovedDate;
             
                dbcontext.SaveChanges();
            }
        }
    }
}
