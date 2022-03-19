using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
