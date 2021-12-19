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
            List<Brand> brands = _context.brands.ToList();
            ViewBag.brands = brands;

            Product product = _context.products.FirstOrDefault(x => x.Id == id);
            product.productImageList = _context.productImages.Where(x => x.productID == id).ToList();
            product.commentsList = _context.comments.Where(x => x.productID == id).ToList();
            return View(product);
        }
    }
}
