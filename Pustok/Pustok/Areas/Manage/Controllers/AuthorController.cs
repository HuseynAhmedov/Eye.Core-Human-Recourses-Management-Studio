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

        public ActionResult Index()
        {
            AuthorVM authorVM = new AuthorVM();
            authorVM.Authors = _context.Authors.Include(x=> x.Products).ToList();
            return View(authorVM);
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
    }
}
