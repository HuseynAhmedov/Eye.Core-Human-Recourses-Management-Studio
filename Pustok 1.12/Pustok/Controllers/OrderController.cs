﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;

namespace Pustok.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        IWebHostEnvironment _env;

        public OrderController(UserManager<AppUser> userManager, DataContext context, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _context = context;
            _env = env;
        }
        public async Task<ActionResult> Order()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            CheckoutVM checkoutVM = new CheckoutVM();
            checkoutVM.CheckoutItems = _getCheckoutItems(user);
            checkoutVM.Order = new Order(); 
            return View(checkoutVM);
        }

        private List<CheckoutItemVM> _getCheckoutItems(AppUser user)
        {
            List<CheckoutItemVM> checkoutItems = new List<CheckoutItemVM>();
            List<BasketItem> basketItems = _context.BasketItems.Include(x => x.Product).Where(x => x.AppUserId == user.Id).ToList();
            foreach (var item in basketItems)
            {
                CheckoutItemVM checkoutItem = new CheckoutItemVM
                {
                    Product = item.Product,
                    Count = item.Count
                };
                checkoutItems.Add(checkoutItem);
            }
            return checkoutItems;
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Order(Order newOrder)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            List<CheckoutItemVM> checkoutItems = _getCheckoutItems(user);
            if (checkoutItems.Count == 0)
                ModelState.AddModelError("", "There is not any selected product");
            if (!ModelState.IsValid)
            {
                return View(newOrder);
            }

            var lastOrder = _context.Orders.OrderByDescending(x => x.Id).FirstOrDefault();
            newOrder.Email = user.Email;
            newOrder.FullName = user.FullName;
            newOrder.CodePrefix = newOrder.FullName[0].ToString().ToUpper() + newOrder.Email[0].ToString().ToUpper();
            newOrder.CodeNumber = lastOrder == null ? 1001 : lastOrder.CodeNumber + 1;
            newOrder.CreatedAt = DateTime.UtcNow.AddHours(4);
            newOrder.Status = OrderStatus.Pending;
            newOrder.OrderItems = new List<OrderItem>();
            newOrder.AppUserId = user.Id;
            foreach (var item in checkoutItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    ProductId = item.Product.Id,
                    Count = item.Count,
                    CostPrice = (decimal)item.Product.PriceOld,
                    SalePrice = (decimal)item.Product.Price,
                    DiscountPercent = (decimal)item.Product.PriceDiscount
                };
                newOrder.TotalAmount += orderItem.DiscountPercent > 0
                    ? (orderItem.SalePrice * (1 - orderItem.DiscountPercent / 100)) * orderItem.Count
                    : orderItem.SalePrice * orderItem.Count;

                newOrder.OrderItems.Add(orderItem);
            }
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            List<BasketItem> basketItems = _context.BasketItems.Where(x => x.AppUserId == user.Id).ToList();
            foreach (BasketItem item in basketItems)
            {
                _context.BasketItems.Remove(item);
            }
            _context.SaveChanges();
            Email(user.Email , _env.WebRootPath + "/html/_OrderEmail.cshtml");
            return RedirectToAction("index","home");
        }

        public static void Email(string toEmail , string bodyPath)
        {
            string htmlString = System.IO.File.ReadAllText(bodyPath);
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("201906085@code.edu.az");
            message.To.Add(new MailAddress(toEmail));
            message.Subject = "Your Order";
            message.IsBodyHtml = true; 
            message.Body = htmlString;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; 
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("201906085@code.edu.az", "code505panzerspear");
            smtp.Send(message);
        }
    }
}
