using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class ApplyLeaveViewModel
    {
        [Required]
        public int LeaveID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage ="Select Date")]
        public DateTime LeaveStartDate { get; set; }
        [Required(ErrorMessage = "Select Date")]
        public DateTime LeaveEndDate { get; set; }
        [Required(ErrorMessage ="Leave Reason is required!")]
        public string LeaveDescription { get; set; }
        public string LeaveStatusID { get; set; }
        [Required(ErrorMessage ="No. of Days is required")]
        public string Days { get; set; }
        [Required(ErrorMessage ="Choose any type")]
        public string Leavetype { get; set; }
        public int? ApproverID { get; set; }
    }
}
