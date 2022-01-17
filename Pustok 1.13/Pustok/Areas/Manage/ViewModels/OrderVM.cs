using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.ViewModels
{
    public class OrderVM
    {
        public List<Order> Orders { get; set; }

        public PageNationVM pageNation { get; set; }
    }
}
