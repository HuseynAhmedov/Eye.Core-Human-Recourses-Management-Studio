using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Helper;
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
        IWebHostEnvironment _env;
        public AuthorController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            
            if (author.FormImage == null)
            {
                ModelState.AddModelError("FormImage", "Slider Image is required");
            }
            else if (author.FormImage.Length > 2097152)
            {
                ModelState.AddModelError("FormImage", "Image size cannot be higher than 2MB");
            }
            else if (author.FormImage.ContentType != "image/jpeg" && author.FormImage.ContentType != "image/png")
            {
                ModelState.AddModelError("FormImage", "Invalid image format ");
            }
            if (!ModelState.IsValid) return View();

            author.Image = FileManager.Save(_env.WebRootPath, "image/upload/author", author.FormImage);

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
            if (Editedauthor.FormImage == null)
            {
                ModelState.AddModelError("FormImage", "Slider Image is required");
            }
            else if (Editedauthor.FormImage.Length > 2097152)
            {
                ModelState.AddModelError("FormImage", "Image size cannot be higher than 2MB");
            }
            else if (Editedauthor.FormImage.ContentType != "image/jpeg" && Editedauthor.FormImage.ContentType != "image/png")
            {
                ModelState.AddModelError("FormImage", "Invalid image format ");
            }
            if (!ModelState.IsValid) return View(_context.Authors.FirstOrDefault(x => x.Id == Editedauthor.Id));

            Author author = _context.Authors.FirstOrDefault(x=> x.Id== Editedauthor.Id);

            if (author.Image == null)author.Image = "";

            FileManager.Delete(_env.WebRootPath, author.Image);
            Editedauthor.Image = FileManager.Save(_env.WebRootPath, "image/upload/author", Editedauthor.FormImage);
            
            author.Name = Editedauthor.Name;
            author.Image = Editedauthor.Image;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Authors.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Author toDelete = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (!string.IsNullOrWhiteSpace(toDelete.Image))
            {
                FileManager.Delete(_env.WebRootPath, toDelete.Image);
            }
            _context.Authors.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
