using Black_Mesa_HRMS.Enums;
using System;

namespace Black_Mesa_HRMS.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public LeaveRequestStatus Status { get; set; }


    }
}
