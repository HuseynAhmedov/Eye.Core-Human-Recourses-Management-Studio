using System;
using System.ComponentModel.DataAnnotations;

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
