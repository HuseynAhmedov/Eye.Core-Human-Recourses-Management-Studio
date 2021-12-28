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
    public class AuthorController : Controller
    {
        DataContext _context;

        public AuthorController(DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            AuthorVM authorVM = new AuthorVM();
            authorVM.Authors = _context.Authors.Include(x=> x.Products).Skip((page - 1) * 4).Take(4).ToList();

            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Authors.Count()) / 4);
            pageNation.PageSelected = page;
            authorVM.pageNation = pageNation;

            return View(authorVM);
        }
        public ActionResult Info(int id)
        {
            Author author = _context.Authors.Include(x=> x.Products).FirstOrDefault(x => x.Id == id);
            return View(author);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_context.Authors.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author Editedauthor)
        {
            if (!ModelState.IsValid) return View();

            Author author = _context.Authors.FirstOrDefault(x=> x.Id== Editedauthor.Id);
            author.Name = Editedauthor.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Authors.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Author toDelete = _context.Authors.FirstOrDefault(x => x.Id == id);
            _context.Authors.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
