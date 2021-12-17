using Eterna.Models;
using Eterna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context;
        public HomeController(DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index()
        {
            HomeVM homeVM = new HomeVM 
            { 
                ClientsList = _context.clients.ToList(),
                FeaturesList = _context.features.ToList(),
                SlidersList = _context.sliders.ToList(),
                ServicesList = _context.services.ToList(),
                AppItemList = _context.appItems.ToList(),
                AboutInfoList = _context.aboutLists.ToList(),
            };
            return View(homeVM);
        }
    }
}
