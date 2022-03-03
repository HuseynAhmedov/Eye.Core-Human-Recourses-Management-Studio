using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Event
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 30)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
