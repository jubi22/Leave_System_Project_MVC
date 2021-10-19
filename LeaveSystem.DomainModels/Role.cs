using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveSystem.DomainModels
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        [MaxLength(250)]
        public string RoleName { get; set; }
    }
}