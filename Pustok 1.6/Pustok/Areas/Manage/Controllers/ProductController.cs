using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        DataContext _context;

        public ProductController(DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            ProductVM productVM = new ProductVM();
            productVM.Products = _context.Products.Include(x=> x.Author).Include(y=> y.Genre).Include(a=> a.Category).Skip((page - 1) * 4).Take(4).ToList();
            
            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Products.Count()) / 4);
            pageNation.PageSelected = page;
            productVM.pageNation = pageNation;

            return View(productVM);
        }

        public ActionResult Info(int id)
        {
            Product product = _context.Products.Include(x => x.Author).Include(y => y.Genre).Include(a => a.Category).Include(w=> w.ProductImages).Include(x => x.ProductTags).ThenInclude(pr => pr.Tag).FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        public ActionResult Create()
        {
            ProductVM productVM = new ProductVM
            {
                Genres = _context.Genres.ToList(),
                Categories = _context.Categories.ToList(),
                Authors = _context.Authors.ToList()
            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewProduct(Product product)
        {
            if (!ModelState.IsValid) return RedirectToAction("Create");

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_context.Products.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product EditedProduct)
        {
            if (!ModelState.IsValid) return View();
            _context.Products.Update(EditedProduct);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Genres.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Product toDelete = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
