using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Services
{
    public class LayoutService 
    {
        private readonly IHttpContextAccessor _contextAccessor;

        DataContext _context;
        public LayoutService(IHttpContextAccessor contextAccessor , DataContext context)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public List<BasketItemVM> GetBasketItems()
        {
            List<BasketItemVM> basketItemList = new List<BasketItemVM>();
            string cookieStr = _contextAccessor.HttpContext.Request.Cookies["BasketItems"];
            if (cookieStr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BasketItemVM>>(cookieStr);
            }
            return basketItemList;
        }

        public  List<Brand> GetBrands()
        {
            List<Brand> brands = _context.Brands.ToList();
            return brands;
        }
    }
}
