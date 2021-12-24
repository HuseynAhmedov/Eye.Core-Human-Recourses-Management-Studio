using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class ProductController : Controller
    {
        DataContext _context;
        public ProductController(DataContext context)
        {
            this._context = context;
        }
        public ActionResult Index( int id )
        {
            List<Brand> brands = _context.Brands.ToList();
            ViewBag.brands = brands;

            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            product.ProductImages = _context.ProductImages.Where(x => x.ProductID == id).ToList();
            product.Comments = _context.Comments.Where(x => x.ProductID == id).ToList();
            return View(product);
        }
    }
}
