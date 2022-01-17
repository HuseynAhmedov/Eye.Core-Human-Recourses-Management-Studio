using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class ShopVM
    {
        public List<Category> categoriesList { get; set; }
        public List<Product> productsList { get; set; }

        public List<ProductImage> productImagesList { get; set; }

        public PageNationVM pageNation { get; set; }
    }
}
