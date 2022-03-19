using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Black_Mesa_HRMS.ViewModels
{
    public class EmployeeFormVM
    {
        public Employee Employee { get; set; }
        [Required(ErrorMessage = "Sector is Requried")]
        public int? SectorId { get; set; }
        [Required(ErrorMessage = "Department is Requried")]
        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "Job is Requried")]
        public int? JobId { get; set; }
        [Required(ErrorMessage = "Job Position is Requried")]
        public int? JobPositionId { get; set; }

        [Required(ErrorMessage = "Salary Amount is Requried")]
        public float? SalaryAmount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Birth Date is required")]
        public DateTime? BirthDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Expire Date is required")]
        public DateTime? ExpireDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nationality is required")]
        public int? NationalityId { get; set; }
    }
}
