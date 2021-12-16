using purpleBuzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace purpleBuzz.ViewModel
{
    public class HomeVM
    {
        public List<WorkModel> workList { get; set; }
        public List<HomeSliderModel> sliderList { get; set; }
    }
}
