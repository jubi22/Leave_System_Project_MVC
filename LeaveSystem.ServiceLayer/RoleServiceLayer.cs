using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.DomainModels;
using LeaveSystem.ViewModels;
using LeaveSystem.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
namespace LeaveSystem.ServiceLayer
{
    public class RoleServiceLayer:IRoleServiceLayer
    {
        private readonly IRoleRepositories rs = new RoleRepositories();
        public List<RoleViewModel> GetRoles()
        {
            List<Role> r = rs.GetRoles();
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Role, RoleViewModel>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<RoleViewModel> rvm = mapper.Map<List<Role>, List<RoleViewModel>>(r);
            return rvm;
        }
    }
}
