using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context; 
        public HomeController( DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index()
        {
            List<Brand> brands = _context.brands.ToList();
            ViewBag.brands = brands;
            HomeVM homeVM = new HomeVM { slidesList = _context.slides.ToList() };
            return View (homeVM);
        }
    }
}
