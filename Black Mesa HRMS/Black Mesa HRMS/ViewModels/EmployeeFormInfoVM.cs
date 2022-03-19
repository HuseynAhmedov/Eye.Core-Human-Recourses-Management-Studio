using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class EmployeeFormInfoVM
    {
        public Employee Employee { get; set; }
        public float? SalaryAmount { get; set; }
        public float? LastBonus { get; set; }
        public float? TotalBonus { get; set; }
        public string SectorName { get; set; }
        public string DepartmentName { get; set; }
        public string JobName { get; set; }
        public string JobPositionName { get; set; }
        public DateTime AttendanceDateFor { get; set; }
        public DateTime? SalaryLastModifiedDate { get; set; }
        public List<Attendance> AttendancesList { get; set; }
    }
}
