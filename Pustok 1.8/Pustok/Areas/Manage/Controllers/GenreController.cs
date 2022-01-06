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
    public class GenreController : Controller
    {
        DataContext _context;

        public GenreController(DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            GenreVM genreVM = new GenreVM();
            genreVM.Genres = _context.Genres.Include(x => x.Products).Skip((page - 1) * 4).Take(4).ToList();

            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Genres.Count()) / 4);
            pageNation.PageSelected = page;
            genreVM.pageNation = pageNation;

            return View(genreVM);
        }
        public ActionResult Info(int id)
        {
            Genre genre = _context.Genres.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
            return View(genre);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewGenre(Genre genre)
        {
            if (!ModelState.IsValid) return View();

            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_context.Genres.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre EditedGenre)
        {
            if (!ModelState.IsValid) return View();

            Genre genre = _context.Genres.FirstOrDefault(x => x.Id == EditedGenre.Id);
            genre.Name = EditedGenre.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Genres.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Genre toDelete = _context.Genres.FirstOrDefault(x => x.Id == id);
            _context.Genres.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
