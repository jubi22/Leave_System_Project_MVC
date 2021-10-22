using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class LeaveDetailsViewModel
    {
        public int LeaveID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string LeaveDescription { get; set; }
        
        public int LeaveStatusID { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApproverID { get; set; }
        

    }
}
