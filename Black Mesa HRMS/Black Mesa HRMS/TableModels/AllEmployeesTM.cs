using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.TableModels
{
    public class AllEmployeesTM
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string JobName { get; set; }
        public string PositionName { get; set; }
        public string SectorName { get; set; }
    }
}
