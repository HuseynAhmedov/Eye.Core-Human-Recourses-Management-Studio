using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class ShopController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;

        public ShopController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public ActionResult Index(int page = 1)
        {
            if ( Convert.ToInt32(TempData["filterID"]) == 0)
            {
                PageNationVM pageNation = new PageNationVM();
                ShopVM shopVM = new ShopVM
                {
                    categoriesList = _context.Categories.Include(x => x.Products).ToList(),
                    productsList = _context.Products.Include(x => x.ProductImages).Skip((page - 1) * 4).Take(4).ToList(),
                    productImagesList = _context.ProductImages.ToList()

                };

                pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Products.Count()) / 4);
                pageNation.PageSelected = page;
                shopVM.pageNation = pageNation;
                return View(shopVM); 
            }
            else
            {
                PageNationVM pageNation = new PageNationVM();
                ShopVM shopVM = new ShopVM
                {
                    categoriesList = _context.Categories.Include(x => x.Products).ToList(),
                    productsList = _context.Products.Where(x=> x.CategoryId == Convert.ToInt32(TempData["filterID"])).Include(x=> x.ProductImages).Skip((page - 1) * 4).Take(4).ToList(),
                    productImagesList = _context.ProductImages.ToList()
                };
                pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Products.Where(x => x.CategoryId == Convert.ToInt32(TempData["filterID"])).Count()) / 4);
                pageNation.PageSelected = page;
                shopVM.pageNation = pageNation;
                return View(shopVM);
            }
        }
        public ActionResult Filter(int id)
        {
            TempData["filterID"] = id;
           return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddToBasket(int id)
        {
            if( _context.Products.FirstOrDefault(x=> x.Id == id) == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated)
            {

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    return NotFound();
                }
                if (_context.BasketItems.FirstOrDefault(x => x.ProductId == id && x.AppUserId == user.Id) != null)
                {
                    _context.BasketItems.FirstOrDefault(x => x.ProductId == id && x.AppUserId == user.Id).Count++;
                }
                else
                {
                    BasketItem basketItem = new BasketItem();
                    basketItem.AppUserId = user.Id;
                    basketItem.ProductId = id;
                    basketItem.Count = 1;
                    _context.BasketItems.Add(basketItem);
                }

                _context.SaveChanges();

                BasketItemVM basketItemVM = new BasketItemVM();
                basketItemVM.basketItems = _context.BasketItems.Include(x=>x.Product).Where(x => x.AppUserId == user.Id).ToList();
                return Ok(basketItemVM);
            }
            else
            {
                BasketItemVM basketItemVM = new BasketItemVM();
                List<BasketItem> basketItems = new List<BasketItem>();
                basketItemVM.basketItems = basketItems;

                string cookieStr = HttpContext.Request.Cookies["BasketItems"];
                if (cookieStr != null)
                {
                    basketItemVM.basketItems = JsonConvert.DeserializeObject<List<BasketItem>>(cookieStr);
                }

                BasketItem item = basketItemVM.basketItems.FirstOrDefault(x => x.ProductId == id);

                if (item == null)
                {
                    item = new BasketItem
                    {
                        Product = _context.Products.FirstOrDefault(x => x.Id == id),
                        ProductId = id,
                        Count = 1
                    };
                    //item.product.productImageList = _context.productImages.Where(x => x.productID == id).ToList();
                    basketItemVM.basketItems.Add(item);
                }
                else
                {
                    item.Count++;
                }

                var bookIdsStr = JsonConvert.SerializeObject(basketItemVM.basketItems);

                HttpContext.Response.Cookies.Append("BasketItems", bookIdsStr);

                return Ok(basketItemVM);
            }
        }

        //
        //Under Maintenance (do not use)
        //
        public async Task<ActionResult> deleteBasket(int id)
        {
            if (_context.Products.FirstOrDefault(x => x.Id == id) == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    return NotFound();
                }
                BasketItemVM basketItemVM = new BasketItemVM();
                BasketItem basketItem = _context.BasketItems.FirstOrDefault(x => x.ProductId == id && x.AppUserId == user.Id);
                _context.BasketItems.Remove(basketItem);
                _context.SaveChanges();
                basketItemVM.basketItems = _context.BasketItems.Include(x=> x.Product).Where(x => x.AppUserId == user.Id).ToList();
                return Ok(basketItemVM);
            }
            else
            {
                BasketItemVM basketItemVM = new BasketItemVM();
                string cookieStr = HttpContext.Request.Cookies["BasketItems"];
                if (cookieStr != null)
                {
                    basketItemVM.basketItems = JsonConvert.DeserializeObject<List<BasketItem>>(cookieStr);
                }
                BasketItem basketItem = basketItemVM.basketItems.Find(x => x.ProductId == id);
                basketItemVM.basketItems.Remove(basketItem);

                var bookIdsStr = JsonConvert.SerializeObject(basketItemVM.basketItems);
                HttpContext.Response.Cookies.Append("BasketItems", bookIdsStr);
                return Ok(basketItemVM);
            }
        }


        public async Task<ActionResult> showBasket()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<BasketItem> basketItems = new List<BasketItem>();
                BasketItemVM basketItemVM = new BasketItemVM();
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    return NotFound();
                }
                basketItemVM.basketItems = _context.BasketItems.Include(x=> x.Product).Where(x => x.AppUserId == user.Id).ToList();
                return Ok(basketItemVM);
            }
            else
            {
                BasketItemVM basketItemVM = new BasketItemVM();
                string cookieStr = HttpContext.Request.Cookies["BasketItems"];
                if (cookieStr != null)
                {
                    basketItemVM.basketItems = JsonConvert.DeserializeObject<List<BasketItem>>(cookieStr);
                }
                return Ok(basketItemVM);
            }
        }
    }
}
