using LeaveSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LeavesDTO
    {
        public Employee Employee { get; set; }
        public Leaves Leaves { get; set; }
        public LeaveStatus LeaveStatus { get; set; }

    }
}
