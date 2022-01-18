using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    public class SlideController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        public SlideController(DataContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            SlideVM slideVM = new SlideVM();
            slideVM.Slides = _context.Slides.Skip((page - 1) * 4).Take(4).ToList();

            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Slides.Count()) / 4);
            pageNation.PageSelected = page;
            slideVM.pageNation = pageNation;

            return View(slideVM);
        }
        public ActionResult Info(int id)
        {
            Slide slide = _context.Slides.FirstOrDefault(x => x.Id == id);
            return View(slide);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slide slide)
        {
            if (slide.Header == slide.HeaderSub)
            {
                ModelState.AddModelError("HeaderSub","2nd header cannot be same as main header");
            }
            else if (slide.FormImage == null)
            {
                ModelState.AddModelError("FormImage", "Slider Image is required");
            }
            else if (slide.FormImage.Length > 2097152)
            {
                ModelState.AddModelError("FormImage", "Image size cannot be higher than 2MB");
            }
            else if (slide.FormImage.ContentType != "image/jpeg" && slide.FormImage.ContentType != "image/png")
            {
                ModelState.AddModelError("FormImage", "Invalid image format ");
            }
            if (!ModelState.IsValid) return View();

            slide.BackgroundImg = FileManager.Save(_env.WebRootPath, "image/upload/slide", slide.FormImage);

            _context.Slides.Add(slide);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_context.Slides.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slide EditedSlide)
        {
            if (EditedSlide.Header == EditedSlide.HeaderSub)
            {
                ModelState.AddModelError("HeaderSub", "2nd header cannot be same as main header");
            }
            else if (EditedSlide.FormImage == null)
            {
                ModelState.AddModelError("FormImage", "Author Image is required");
            }
            else if (EditedSlide.FormImage.Length > 2097152)
            {
                ModelState.AddModelError("FormImage", "Image size cannot be higher than 2MB");
            }
            else if (EditedSlide.FormImage.ContentType != "image/jpeg" && EditedSlide.FormImage.ContentType != "image/png")
            {
                ModelState.AddModelError("FormImage", "Invalid image format ");
            }
            if (!ModelState.IsValid) return View(_context.Slides.FirstOrDefault(x => x.Id == EditedSlide.Id));

            Slide slide = _context.Slides.FirstOrDefault(x => x.Id == EditedSlide.Id);
            FileManager.Delete(_env.WebRootPath, slide.BackgroundImg);
            EditedSlide.BackgroundImg = FileManager.Save(_env.WebRootPath, "image/upload/slide", EditedSlide.FormImage);

            slide.BackgroundImg = EditedSlide.BackgroundImg;
            slide.Header = EditedSlide.Header;
            slide.HeaderSub = EditedSlide.HeaderSub;
            slide.Title = EditedSlide.Title;
            slide.Price = EditedSlide.Price;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Slides.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Slide toDelete = _context.Slides.FirstOrDefault(x => x.Id == id);

            if (!string.IsNullOrWhiteSpace(toDelete.BackgroundImg))
            {
                FileManager.Delete(_env.WebRootPath,toDelete.BackgroundImg);
            }
            _context.Slides.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
