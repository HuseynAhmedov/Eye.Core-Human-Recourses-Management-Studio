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
    public class TagController : Controller
    {
        DataContext _context;

        public TagController(DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            TagVM TagVM = new TagVM();
            TagVM.Tags = _context.Tags.Include(x => x.ProductTags).ThenInclude(pr => pr.Product).Skip((page - 1) * 4).Take(4).ToList();

            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Tags.Count()) / 4);
            pageNation.PageSelected = page;
            TagVM.pageNation = pageNation;

            return View(TagVM);
        }
        public ActionResult Info(int id)
        {
            Tag tag = _context.Tags.Include(x => x.ProductTags).ThenInclude(pr => pr.Product).FirstOrDefault(x => x.Id == id);
            return View(tag);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTag(Tag tag)
        {
            if (!ModelState.IsValid) return View();

            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_context.Tags.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag EditedTag)
        {
            if (!ModelState.IsValid) return View();

            Tag tags = _context.Tags.FirstOrDefault(x => x.Id == EditedTag.Id);
            tags.Name = EditedTag.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Tags.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Tag toDelete = _context.Tags.FirstOrDefault(x => x.Id == id);
            _context.Tags.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
