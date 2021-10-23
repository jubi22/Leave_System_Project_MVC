using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class EditEmployeePasswordViewModel
    {
        [Required]
        public int EmployeeID { get; set; }
        public string EmployeeEmail { get; set; }
        [Required(ErrorMessage ="Password required")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
