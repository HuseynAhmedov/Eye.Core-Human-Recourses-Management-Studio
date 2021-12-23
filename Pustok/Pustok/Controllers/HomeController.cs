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
            List<Brand> brands = _context.brands.ToList();
            ViewBag.brands = brands;
            HomeVM homeVM = new HomeVM
            {
                slidesList = _context.slides.ToList(),
                FeaturedProductList = _context.products.Include(x => x.productImageList).Where(x => x.Featured == true).ToList(),
                NewProductList = _context.products.Include(x => x.productImageList).Where(x => x.New == true).ToList(),
                DiscountProductList = _context.products.Include(x => x.productImageList).Where(x => x.PriceDiscount > 0).ToList(),
                promotionBottomList = _context.bottomPromotions.ToList()
            };
            return View (homeVM);
        }

        public ActionResult Modal(int id )
        {
            Product product = _context.products.Include(x => x.productTags).ThenInclude(pr=> pr.tag).Include(x => x.productImageList).FirstOrDefault(x => x.Id == id);
            return PartialView("ProductModal", product);
        }


    }
}
