using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class EditEmployeeDetailsViewModel
    {
       
        
        public string EmployeeName { get; set; }
        public string EmployeeContactNo { get; set; }
        public string EmployeeEmail { get; set; }
        public int EmployeeID { get; set; }
        public string RoleName { get; set; }
        public int RoleID { get; set; }
        public string Image { get; set; }
    }
}
