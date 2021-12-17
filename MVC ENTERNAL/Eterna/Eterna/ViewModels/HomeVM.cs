using Eterna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna.ViewModels
{
    public class HomeVM
    {
        public List<FeaturesModel> FeaturesList { get; set; }
        public List<SliderModel> SlidersList { get; set; }
        public List<ServicesModel> ServicesList { get; set; }
        public List<ClientModel> ClientsList { get; set; }
        public List<AppitemModel> AppItemList { get; set; }
        public List<ListModel> AboutInfoList { get; set; }

    }
}
