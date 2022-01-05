using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public enum ObjectType
    {
        Image = 1,
        Text = 2
    }

    public class Setting
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public ObjectType Type { get; set; }
        public string Key { get; set; }
        [NotMapped]
        public IFormFile FormImage { get; set; }
    }
}
