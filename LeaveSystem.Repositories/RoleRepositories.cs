using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.DomainModels;
namespace LeaveSystem.Repositories
{
    public class RoleRepositories:IRoleRepositories
    {
        private readonly ConnectDB dbcontext = new ConnectDB();
        public List<Role> GetRoles()
        {
            List<Role> roles = dbcontext.Roles.ToList();
            return roles;
        }
    }
}
