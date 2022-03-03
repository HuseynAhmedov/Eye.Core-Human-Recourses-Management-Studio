using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Job
    {
        public int Id { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
    }
}
