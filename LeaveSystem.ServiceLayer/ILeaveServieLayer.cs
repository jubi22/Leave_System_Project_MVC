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
        List<DTO.LeavesDTO> GetLeaves();
        void UpdateLeave(EditLeaveViewModel evm);
        List<DTO.LeavesDTO> GetLeaveByID(int LeaveID);
    }
}
