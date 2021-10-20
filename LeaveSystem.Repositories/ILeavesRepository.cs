using LeaveSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.Repositories
{
    public interface  ILeavesRepository
    {
        void ApplyLeaves(Leaves leaves);
        List<Leaves> GetLeaveDetails();
        void UpdateLeave(Leaves leaves);
        List<Leaves> GetLeaveByID(int ID);
    }
}
