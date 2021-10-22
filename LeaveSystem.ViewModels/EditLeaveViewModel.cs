using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class EditLeaveViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeEmail { get; set; }
        public int ApproverID { get; set; }
   
        public int LeaveID { get; set; }
        public string LeaveDescription { get; set; }
        public int LeaveStatusID { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }

    }
}
