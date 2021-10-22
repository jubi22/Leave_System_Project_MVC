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
        [Required(ErrorMessage ="Email is required")]
        public string EmployeeEmail { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        public string Image { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        
        public string EmployeeName { get; set; }
        public int IsSpecialPermission { get; set; }
    }
}
