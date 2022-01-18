using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using Pustok.ViewModels;
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
            ProductDetailVM productDetailVM = getData(id);
            if (productDetailVM == null)
            {
                return NotFound();
            }
            return View(productDetailVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Comment(Comment comment)
        {
            ProductDetailVM productDetailVM = getData(comment.ProductID);
            if (productDetailVM == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid == false)
            {
                TempData["error"] = "Something went wrong";
                return View("index",productDetailVM);
            }
            if (!_context.Products.Any(x => x.Id == comment.ProductID))
            {
                return View("index", productDetailVM);
            }

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            comment.AppUserId = user.Id;
            comment.FullName = user.FullName;
            comment.Email = user.Email;

            comment.Status = commentStatus.Pending;
            comment.TimeAdded = DateTime.UtcNow.AddHours(4);
            _context.Comments.Add(comment);
            _context.SaveChanges();
            TempData["Success"] = "Comment added successfully , awating confirmation";
            return RedirectToAction("index", new { Id = comment.ProductID });
        }

        private ProductDetailVM getData(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            product.ProductImages = _context.ProductImages.Where(x => x.ProductID == id).ToList();
            product.Comments = _context.Comments.Where(x => x.ProductID == id).ToList();

            ProductDetailVM productDetailVM = new ProductDetailVM();
            productDetailVM.Product = product;
            productDetailVM.Comment = new Comment();

            return productDetailVM;
        }
    }
}
