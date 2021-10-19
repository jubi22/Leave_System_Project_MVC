using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.DomainModels
{
    public class Leaves
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public int Days { get; set; }
        public string Leavetype { get; set; }
        public int LeaveStatusID { get; set; }
        public string Status { get; set; }
        [MaxLength(250)]
        public string LeaveDescription { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApproverID { get; set; }
      


        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("LeaveStatusID")]
        public virtual LeaveStatus LeaveStatus { get; set; }
    }
}
