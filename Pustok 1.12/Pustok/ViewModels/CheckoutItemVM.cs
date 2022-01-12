using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class CheckoutItemVM
    {
        public Product Product  { get; set; }
        public int Count { get; set; }
    }
}
