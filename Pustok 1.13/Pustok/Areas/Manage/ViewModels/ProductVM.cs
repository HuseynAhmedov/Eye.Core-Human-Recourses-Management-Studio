using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.ViewModels
{
    public class ProductVM
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Category> Categories { get; set; }
        public PageNationVM pageNation { get; set; }
    }
}
