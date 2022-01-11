using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class BasketItemVM
    {
        public int Total { get; set; }
        public int Count { get; set; }
        public List<BasketItem> basketItems { get; set; }
    }
}
