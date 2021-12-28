using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class BasketItemVM
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int Count { get; set; }
    }
}
