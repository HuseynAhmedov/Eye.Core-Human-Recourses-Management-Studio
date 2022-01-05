using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class PortfolioCard
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Header is required.")]
        [StringLength(30)]
        public string Header { get; set; }
        [StringLength(500)]
        public string Article { get; set; }
        [NotMapped]
        public IFormFile FormImage { get; set; }

    }
}
