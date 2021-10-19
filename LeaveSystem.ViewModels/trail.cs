using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.ViewModels
{
    public class trail
    {
        public Employees employee { get; set; }
        public Leave leaves { get; set; }
    }
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        [MaxLength(250)]
        public string EmployeeName { get; set; }
        [MaxLength(250)]
        public string EmployeeEmail { get; set; }
        [MaxLength(250)]
        public string Password { get; set; }
        [MaxLength(250)]
        public string EmployeeContactNo { get; set; }
        public int RoleID { get; set; }
        public int? IsSpecialPermission { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

    }

    public class Leave
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
        public string ApproverID { get; set; }



        [ForeignKey("EmployeeID")]
        public virtual Employees Employee { get; set; }
        [ForeignKey("LeaveStatusID")]
        public virtual LeaveStatus LeaveStatus { get; set; }
    }

    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        [MaxLength(250)]
        public string RoleName { get; set; }
    }
    public class LeaveStatus
    {
        [Key]

        public int StatusID { get; set; }
        [MaxLength(250)]
        public string Status { get; set; }
    }
}
