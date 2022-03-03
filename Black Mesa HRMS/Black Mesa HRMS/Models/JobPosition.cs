using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
    }
}
