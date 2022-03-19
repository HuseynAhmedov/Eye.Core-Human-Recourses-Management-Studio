using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public int PostionCount { get; set; }
    }
}
