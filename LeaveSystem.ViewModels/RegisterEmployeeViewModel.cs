using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class RegisterEmployeeViewModel
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage ="Name required")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage ="Email is required")]
        public string EmployeeEmail { get; set; }
        [Required(ErrorMessage ="Password required")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string EmployeeContactNo { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage ="Please assign a role")]
        public int RoleID { get; set; }
        public int IsSpecialPermission { get; set; }
        public string Image { get; set; }

    }
}
