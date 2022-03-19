using Black_Mesa_HRMS.Models;
using Black_Mesa_HRMS.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class AllEmployeesVM
    {
        public List<AllEmployeesTM> AllEmployeesTMs { get; set; }
        public PageNationVM PageNation { get; set; }
        public int? SortBy { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Cannot be longer than 50 characters ")]
        public string KeyWord { get; set; }
        public bool SortDescending { get; set; }
    }
}
