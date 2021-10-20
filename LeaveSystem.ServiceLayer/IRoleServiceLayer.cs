using LeaveSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.ServiceLayer
{
    public interface IRoleServiceLayer
    {
        List<RoleViewModel> GetRoles();
    }
}
