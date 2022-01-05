using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Manage.ViewModel;
using Portfolio.Helper;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfolioCardController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        public PortfolioCardController(DataContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public ActionResult Index()
        {
            PortfolioCardVM portfolioCardVM = new PortfolioCardVM();
            portfolioCardVM.PortfolioCards = _context.PortfolioCards.ToList();
            return View(portfolioCardVM);
        }

        public ActionResult Info(int id)
        {
            if (_context.PortfolioCards.FirstOrDefault(x => x.Id == id) == null)
            {
                return NotFound();
            }
            else
            {
                return View(_context.PortfolioCards.FirstOrDefault(x => x.Id == id));
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public ActionResult Create(PortfolioCard portfolioCard)
        {
            if (portfolioCard.FormImage == null)
            {
                ModelState.AddModelError("FormImage", "Slider Image is required");
            }
            else if (portfolioCard.FormImage.Length > 2097152)
            {
                ModelState.AddModelError("FormImage", "Image size cannot be higher than 2MB");
            }
            else if (portfolioCard.FormImage.ContentType != "image/jpeg" && portfolioCard.FormImage.ContentType != "image/png")
            {
                ModelState.AddModelError("FormImage", "Invalid image format ");
            }
            ModelState.Remove("Image");
            if (!ModelState.IsValid)
            {
                return View();
            }

            portfolioCard.Image = FileManager.Upload(_env.WebRootPath, "upload/PortfolioCard", portfolioCard.FormImage);

            _context.PortfolioCards.Add(portfolioCard);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            return View(_context.PortfolioCards.FirstOrDefault(x=> x.Id == id));
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public ActionResult Edit(PortfolioCard portfolioCard)
        {
            PortfolioCard portfolioCardBase = _context.PortfolioCards.FirstOrDefault(x => x.Id == portfolioCard.Id);
            if (portfolioCard.FormImage != null)
            {
                if (portfolioCard.FormImage.Length > 2097152)
                {
                    ModelState.AddModelError("FormImage", "Image size cannot be higher than 2MB");
                }
                else if (portfolioCard.FormImage.ContentType != "image/jpeg" && portfolioCard.FormImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("FormImage", "Invalid image format ");
                }
                ModelState.Remove("Image");
                if (!ModelState.IsValid)
                {
                    return View(_context.PortfolioCards.FirstOrDefault(x => x.Id == portfolioCard.Id));
                }
                var temp = portfolioCard.Image;
                portfolioCard.Image = FileManager.Upload(_env.WebRootPath, "upload/PortfolioCard", portfolioCard.FormImage);
                FileManager.Delete(_env.WebRootPath, temp);
            }

            portfolioCardBase.Image = portfolioCard.Image;
            portfolioCardBase.Article = portfolioCard.Article;
            portfolioCardBase.Header = portfolioCard.Header;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            PortfolioCard portfolioCard = _context.PortfolioCards.FirstOrDefault(x => x.Id == id);
            if (portfolioCard == null)
            {
                return NotFound();
            }
            FileManager.Delete(_env.WebRootPath, portfolioCard.Image);
            _context.PortfolioCards.Remove(portfolioCard);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
