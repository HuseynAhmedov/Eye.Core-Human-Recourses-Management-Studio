using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModel
{
    public class HomeVM
    {
        public List<PortfolioCard>  portfolioCards { get; set; }
        public List<Setting> settings { get; set; }

    }
}
