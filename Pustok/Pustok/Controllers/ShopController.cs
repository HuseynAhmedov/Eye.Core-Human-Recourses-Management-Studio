using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        DataContext _context;
        public ShopController(DataContext context )
        {
            this._context = context;
        }


        public ActionResult Index()
        {
            List<Brand> brands = _context.Brands.ToList();
            ViewBag.brands = brands;
            if ( Convert.ToInt32(TempData["filterID"]) == 0)
            {
                ShopVM shopVM = new ShopVM
                {
                    categoriesList = _context.Categories.Include(x => x.Products).ToList(),
                    productsList = _context.Products.Include(x => x.ProductImages).ToList(),
                    productImagesList = _context.ProductImages.ToList()
                };
                return View(shopVM); 
            }
            else
            {
                ShopVM shopVM = new ShopVM
                {
                    categoriesList = _context.Categories.Include(x => x.Products).ToList(),
                    productsList = _context.Products.Where(x=> x.CategoryId == Convert.ToInt32(TempData["filterID"])).Include(x=> x.ProductImages).ToList(),
                    productImagesList = _context.ProductImages.ToList()
                };
                return View(shopVM);
            }
        }
        public ActionResult Filter(int id)
        {
            TempData["filterID"] = id;
           return RedirectToAction("Index");
        }

        public ActionResult AddToBasket(int id)
        {
            if( _context.Products.FirstOrDefault(x=> x.Id == id) == null)
            {
                return NotFound();
            }

            List<BasketItemVM> basketItemList = new List<BasketItemVM>();
            string cookieStr = HttpContext.Request.Cookies["BasketItems"];
            if(cookieStr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(cookieStr);
            }

            BasketItemVM item = basketItemList.FirstOrDefault(x => x.product.Id == id);

            if (item == null)
            {
                item = new BasketItemVM
                {
                    product = _context.Products.FirstOrDefault(x => x.Id == id),
                    Id = id,
                    Count = 1
                };
                //item.product.productImageList = _context.productImages.Where(x => x.productID == id).ToList();
                basketItemList.Add(item);
            }
            else
            {
                item.Count++;
            }

            var bookIdsStr = JsonConvert.SerializeObject(basketItemList);

            HttpContext.Response.Cookies.Append("BasketItems", bookIdsStr);

            return Ok(basketItemList);
        }

        public ActionResult deleteBasket(int id)
        {
            if (_context.Products.FirstOrDefault(x => x.Id == id) == null)
            {
                return NotFound();
            }

            List<BasketItemVM> basketItemList = new List<BasketItemVM>();
            string cookieStr = HttpContext.Request.Cookies["BasketItems"];
            if (cookieStr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(cookieStr);
            }
            BasketItemVM basketItem = basketItemList.Find(x=> x.product.Id == id);
            basketItemList.Remove(basketItem);

            var bookIdsStr = JsonConvert.SerializeObject(basketItemList);
            HttpContext.Response.Cookies.Append("BasketItems", bookIdsStr);
            return Ok(basketItemList);
        }

        public ActionResult showBasket()
        {
            List<BasketItemVM> basketItemList = new List<BasketItemVM>();
            string cookieStr = HttpContext.Request.Cookies["BasketItems"];
            if (cookieStr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(cookieStr);
            }
            return Ok(basketItemList);
        }

    }
}
