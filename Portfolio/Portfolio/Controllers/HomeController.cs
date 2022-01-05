using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Models;
using Portfolio.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.settings = _context.Settings.ToList();
            homeVM.portfolioCards = _context.PortfolioCards.ToList();
            return View(homeVM);
        }

        public ActionResult Modal(int id)
        {
            if (_context.PortfolioCards.FirstOrDefault(x=> x.Id == id) !=null)
            {
                return PartialView("_Modal", _context.PortfolioCards.FirstOrDefault(x => x.Id == id));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
