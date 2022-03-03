using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime UntilDate { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
