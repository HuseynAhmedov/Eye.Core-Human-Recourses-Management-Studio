using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Brand> brands = _context.Brands.ToList();
            ViewBag.brands = brands;
            HomeVM homeVM = new HomeVM
            {
                slidesList = _context.Slides.ToList(),
                FeaturedProductList = _context.Products.Include(x => x.ProductImages).Where(x => x.Featured == true).ToList(),
                NewProductList = _context.Products.Include(x => x.ProductImages).Where(x => x.New == true).ToList(),
                DiscountProductList = _context.Products.Include(x => x.ProductImages).Where(x => x.PriceDiscount > 0).ToList(),
                promotionBottomList = _context.BottomPromotions.ToList()
            };
            return View (homeVM);
        }

        public ActionResult Modal(int id )
        {
            Product product = _context.Products.Include(x => x.ProductTags).ThenInclude(pr=> pr.Tag).Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            return PartialView("ProductModal", product);
        }


    }
}
