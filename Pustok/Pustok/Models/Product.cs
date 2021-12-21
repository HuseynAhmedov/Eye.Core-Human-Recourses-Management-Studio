using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category category { get; set; }
        public int categoryId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public float Price { get; set; }
        public float PriceOld { get; set; }
        public float PriceDiscount { get; set; }
        public int StarCount { get; set; }
        public bool Availability { get; set; }
        public int RewardPoint { get; set; }
        public string Code { get; set; }
        public bool Featured { get; set; }
        public bool New { get; set; }
        public string Brand { get; set; }
        public List<ProductImage> productImageList { get; set; }
        public List<Comment> commentsList { get; set; }
        public  List<Tag> TagsList { get; set; }
        public List<ProductTag> productTags { get; set; }

    }
}
