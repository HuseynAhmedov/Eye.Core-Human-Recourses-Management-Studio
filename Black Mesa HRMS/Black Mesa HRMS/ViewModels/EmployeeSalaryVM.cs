using Black_Mesa_HRMS.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class EmployeeSalaryVM
    {
        public List<EmployeeSalaryTM> EmployeeSalaryList { get; set; }
        public PageNationVM PageNationVM { get; set; }
    }
}
