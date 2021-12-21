using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int productId { get; set; }
        public Tag tag { get; set; }
        public int tagId { get; set; }
    }
}
