using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string HeaderSub { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string BackgroundImg { get; set; }
        public int Order { get; set; }

        [NotMapped]
        public IFormFile FormImage { get; set; }
    }
}
