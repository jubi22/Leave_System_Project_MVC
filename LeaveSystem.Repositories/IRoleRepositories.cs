using LeaveSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.Repositories
{
    public interface IRoleRepositories
    {
        List<Role> GetRoles();
    }
}
