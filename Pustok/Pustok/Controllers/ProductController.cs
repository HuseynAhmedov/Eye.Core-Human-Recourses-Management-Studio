using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;

        public ProductController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public ActionResult Index( int id )
        {
            List<Brand> brands = _context.Brands.ToList();
            ViewBag.brands = brands;

            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            product.ProductImages = _context.ProductImages.Where(x => x.ProductID == id).ToList();
            product.Comments = _context.Comments.Where(x => x.ProductID == id).ToList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Comment(Comment comment)
        {
            if (ModelState.IsValid == false)
            {
                return View(comment);
            }
            if (!_context.Products.Any(x => x.Id == comment.ProductID))
            {
                return NotFound();
            }
            if (!User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrWhiteSpace(comment.Email))
                {
                    return NotFound();
                }

                if (string.IsNullOrWhiteSpace(comment.FullName))
                {
                    return NotFound();
                }
            }
            else
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                comment.AppUserId = user.Id;
                comment.FullName = user.FullName;
                comment.Email = user.Email;
            }
            comment.Status = commentStatus.Pending;
            comment.TimeAdded = DateTime.UtcNow.AddHours(4);
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("index", new { Id = comment.ProductID });
        }
    }
}
