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
        [Required]
        public DateTime LeaveStartDate { get; set; }
        [Required]
        public DateTime LeaveEndDate { get; set; }
        [Required]
        public string LeaveDescription { get; set; }
        public string LeaveStatusID { get; set; }
        public string Days { get; set; }
        public string Leavetype { get; set; }
    }
}
