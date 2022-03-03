using Black_Mesa_HRMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateFor { get; set; }
        public AttendaceStatus Status { get; set; }
    }
}
