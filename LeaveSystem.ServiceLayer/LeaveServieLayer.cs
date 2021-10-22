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
    public class LeaveServieLayer:ILeaveServieLayer
    {
        private readonly ILeavesRepository ls;
        public LeaveServieLayer()
        {
            ls = new LeavesRepository();
        }


        public void UpdateLeave(EditLeaveViewModel evm)
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<EditLeaveViewModel, Leaves>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Leaves l = mapper.Map<EditLeaveViewModel, Leaves>(evm);
            ls.UpdateLeave(l);
        }
        public void ApplyLeaves(ApplyLeaveViewModel avm)
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<ApplyLeaveViewModel, Leaves>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Leaves l = mapper.Map<ApplyLeaveViewModel, Leaves>(avm);
            ls.ApplyLeaves(l);
        }
        public List<DTO.LeavesDTO> GetLeaves()
        {
            List<DTO.LeavesDTO> l = ls.GetLeaveDetails();
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Leaves, DTO.LeavesDTO>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<DTO.LeavesDTO> lvm = mapper.Map<List<DTO.LeavesDTO>, List<DTO.LeavesDTO>>(l);
            return lvm;
        }
        public List<DTO.LeavesDTO> GetLeaveByID(int ID)
        {
            
            List<DTO.LeavesDTO> l = ls.GetLeaveByID(ID);
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Leaves, DTO.LeavesDTO>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<DTO.LeavesDTO> lvm = mapper.Map<List<DTO.LeavesDTO>,
                List<DTO.LeavesDTO>>(l);
            return lvm;
        }
    }
}
