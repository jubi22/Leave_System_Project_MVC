using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string Image { get; set; }
      
        
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeContactno { get; set; }
        public int RoleID { get; set; }
        public int RoleName { get; set; }

        public static implicit operator List<object>(EmployeeViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
