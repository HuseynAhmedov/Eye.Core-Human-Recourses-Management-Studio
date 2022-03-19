using Black_Mesa_HRMS.Enums;
using System.ComponentModel.DataAnnotations;

namespace Black_Mesa_HRMS.Models
{
    public class Job
    {
        public int Id { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public JobType Type { get; set; }
    }
}
