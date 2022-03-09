using System;
using System.ComponentModel.DataAnnotations;

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
