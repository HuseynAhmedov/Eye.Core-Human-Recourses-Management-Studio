using Black_Mesa_HRMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime ScheduleFor { get; set; }
        public TodoStatus Status { get; set; }
    }
}
