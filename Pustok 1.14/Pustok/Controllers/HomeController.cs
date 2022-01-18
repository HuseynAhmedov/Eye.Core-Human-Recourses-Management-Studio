using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<PustokHub> _hubContext;

        public HomeController( DataContext context , UserManager<AppUser> userManager , IHubContext<PustokHub> hubContext)
        {
            this._context = context;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        public async Task<ActionResult> Index()
        {
            List<Brand> brands = _context.Brands.ToList();
            ViewBag.brands = brands;
            HomeVM homeVM = new HomeVM
            {
                slidesList = _context.Slides.ToList(),
                FeaturedProductList = _context.Products.Include(x => x.ProductImages).Where(x => x.Featured == true).ToList(),
                NewProductList = _context.Products.Include(x => x.ProductImages).Where(x => x.New == true).ToList(),
                DiscountProductList = _context.Products.Include(x => x.ProductImages).Where(x => x.PriceDiscount > 0).ToList(),
                promotionBottomList = _context.BottomPromotions.ToList()
            };
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user.ConnectionId != null)
                {
                    PustokHub pustokHub = new PustokHub(_userManager);

                    List<AppUser> appUsers = _context.Users.ToList();
                    foreach (AppUser item in appUsers)
                    {
                        bool onlineStatus = true;
                        if (item.ConnectionId == null)
                        {
                            onlineStatus = false;
                        }
                        string userName = item.UserName;
                        await _hubContext.Clients.Client(user.ConnectionId).SendAsync("OnlineStatus", onlineStatus, userName);
                    }
                }
            }
            
            

            return View (homeVM);
        }

        public ActionResult Modal(int id )
        {
            Product product = _context.Products.Include(x => x.ProductTags).ThenInclude(pr=> pr.Tag).Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            return PartialView("ProductModal", product);
        } 


    }
}
