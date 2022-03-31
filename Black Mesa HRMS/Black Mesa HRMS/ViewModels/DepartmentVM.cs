using Black_Mesa_HRMS.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class DepartmentVM
    {
        public List<DepartmentTM> Departments { get; set; }
        public PageNationVM PageNation { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Cannot be longer than 50 characters ")]
        public string KeyWord { get; set; }
    }
}
