using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 200)]
        public string Reason { get; set; }
        public float Amount { get; set; }
        public DateTime DateGiven { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}
