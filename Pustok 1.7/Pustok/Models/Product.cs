using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Author Author { get; set; }
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
        public Genre Genre { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Comment> Comments { get; set; }
        public  List<Tag> Tags { get; set; }
        public List<ProductTag> ProductTags { get; set; }

        [NotMapped]
        public IFormFile PosterImageFile { get; set; }
        [NotMapped]
        public IFormFile HoverImageFile { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }

    }
}
