using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class ShopController : Controller
    {
        DataContext _context;
        public ShopController(DataContext context )
        {
            this._context = context;
        }

        public ActionResult Index()
        {
            List<Brand> brands = _context.brands.ToList();
            ViewBag.brands = brands;
            if ( Convert.ToInt32(TempData["filterID"]) == 0)
            {
                ShopVM shopVM = new ShopVM
                {
                    categoriesList = _context.categories.Include(x => x.productsList).ToList(),
                    productsList = _context.products.Include(x => x.productImageList).ToList(),
                    productImagesList = _context.productImages.ToList()
                };
                return View(shopVM); 
            }
            else
            {
                ShopVM shopVM = new ShopVM
                {
                    categoriesList = _context.categories.Include(x => x.productsList).ToList(),
                    productsList = _context.products.Where(x=> x.categoryId == Convert.ToInt32(TempData["filterID"])).Include(x=> x.productImageList).ToList(),
                    productImagesList = _context.productImages.ToList()
                };
                return View(shopVM);
            }
        }
        public ActionResult Filter(int id)
        {
            TempData["filterID"] = id;
           return RedirectToAction("Index");
        }
    }
}
