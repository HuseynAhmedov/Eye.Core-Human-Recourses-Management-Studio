using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Department
    {
        public int Id { get; set; }
        public Sector Sector { get; set; }
        public int SectortId { get; set; }
        [StringLength(maximumLength: 100)]

        public string Name { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile FormImage { get; set; }
    }
}
