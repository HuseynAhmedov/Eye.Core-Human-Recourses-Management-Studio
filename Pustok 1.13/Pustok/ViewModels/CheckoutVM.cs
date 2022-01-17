using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class CheckoutVM
    {
        public List<CheckoutItemVM> CheckoutItems { get; set; }
        public Order Order { get; set; }
    }
}
