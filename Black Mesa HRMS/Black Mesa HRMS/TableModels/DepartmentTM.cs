using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.TableModels
{
    public class DepartmentTM
    {
        public Department Department { get; set; }
        public string SectorName { get; set; }
        public float AvgSalary { get; set; }
        public int EmployeeCount { get; set; }
        public float TotalSalary { get; set; }
        public string ImageName { get; set; }
    }
}
