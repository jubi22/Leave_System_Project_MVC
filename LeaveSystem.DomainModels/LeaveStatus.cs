using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeaveSystem.DomainModels
{
    public class LeaveStatus
    {
        [Key]

        public int StatusID { get; set; }
        [MaxLength(250)]
        public string Status { get; set; }
    }
}
