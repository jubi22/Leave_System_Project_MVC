using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.DomainModels
{
    public class Employee
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
        public string Image { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

    }
}