using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class HomeVM
    {
        public List<Slide> slidesList { get; set; }
        public List<Product> FeaturedProductList { get; set; }
        public List<Product> NewProductList { get; set; }
        public List<Product> DiscountProductList { get; set; }
        public List<PromotionBottom> promotionBottomList { get; set; }

    }
}
