using Microsoft.AspNetCore.Mvc;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class FeaturesController : Controller
    {
        DataContext _context;

        public FeaturesController(DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            FeaturesVM featuresVM = new FeaturesVM();
            featuresVM.Features = _context.Features.Skip((page - 1) * 4).Take(4).ToList();

            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Tags.Count()) / 4);
            pageNation.PageSelected = page;
            featuresVM.pageNation = pageNation;

            return View(featuresVM);
        }
        public ActionResult Info(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            return View(feature);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewFeature(Feature feature)
        {
            if (!ModelState.IsValid) return View();

            _context.Features.Add(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_context.Features.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Feature EditedFeature)
        {
            if (!ModelState.IsValid) return View();

            Feature feature = _context.Features.FirstOrDefault(x => x.Id == EditedFeature.Id);
            feature.Header = EditedFeature.Header;
            feature.Title = EditedFeature.Title;
            feature.Logo = EditedFeature.Logo;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Features.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Feature toDelete = _context.Features.FirstOrDefault(x => x.Id == id);
            _context.Features.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
