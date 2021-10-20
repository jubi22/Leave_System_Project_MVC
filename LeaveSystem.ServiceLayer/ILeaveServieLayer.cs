using LeaveSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.ServiceLayer
{
    public interface ILeaveServieLayer
    {
        void ApplyLeaves(ApplyLeaveViewModel avm);
        List<LeaveDetailsViewModel> GetLeaves();
        void UpdateLeave(EditLeaveViewModel evm);
        List<LeaveDetailsViewModel> GetLeaveByID(int LeaveID);
    }
}
