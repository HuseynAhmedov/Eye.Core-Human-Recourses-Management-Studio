using Microsoft.AspNetCore.Hosting;
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
    public class CommentController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        public CommentController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNationVM = new PageNationVM();
            CommentVM commentVM = new CommentVM();
            commentVM.Comments = _context.Comments.OrderBy(x=> ((int)x.Status)).Skip((page - 1) * 8).Take(8).ToList();
            pageNationVM.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Comments.Count()) / 8);
            pageNationVM.PageSelected = page;
            commentVM.pageNation = pageNationVM;
            return View(commentVM);
        }

        public ActionResult Edit(int id)
        {
            Comment comment = _context.Comments.Include(x => x.AppUser).Include(x => x.Product).FirstOrDefault(x => x.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            Comment commentBase = _context.Comments.Include(x => x.AppUser).Include(x => x.Product).FirstOrDefault(x => x.Id == comment.Id);
            if (commentBase == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid == false)
            {
                return View(comment);
            }
            commentBase.Status = comment.Status;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            if (_context.Genres.FirstOrDefault(x => x.Id == id) == null) { return NotFound(); }
            Comment toDelete = _context.Comments.FirstOrDefault(x => x.Id == id);
            _context.Comments.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
