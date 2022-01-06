using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public string Source { get; set; }
        public bool MainImage { get; set; }
        public bool HoverImage { get; set; }
    }
}
