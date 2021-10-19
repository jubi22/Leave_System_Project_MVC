using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        
        public string EmployeeName { get; set; }
        public int IsSpecialPermission { get; set; }
    }
}
