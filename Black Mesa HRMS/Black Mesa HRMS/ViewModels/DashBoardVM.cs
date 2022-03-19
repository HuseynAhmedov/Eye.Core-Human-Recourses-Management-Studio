using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class DashBoardVM
    {
        public Employee Employee { get; set; }
        public float TotalSalary { get; set; }
        public int EmployeeCount { get; set; }
        public int EmployeeCountNew { get; set; }
        public float Budget { get; set; }
        public float TotalScientistSalary { get; set; }
        public float TotalSecuritySalary { get; set; }
        public float TotalAdministrationSalary { get; set; }
        public float TotalMaintenanceSalary { get; set; }
        public float TotalSafetySalary { get; set; }
        public List<Todo> TodoList { get; set; }
    }
}
