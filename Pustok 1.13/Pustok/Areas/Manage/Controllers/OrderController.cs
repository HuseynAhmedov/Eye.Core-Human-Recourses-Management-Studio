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
    public class OrderController : Controller
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            OrderVM orderVM = new OrderVM();
            orderVM.Orders = _context.Orders.Include(x => x.OrderItems).Include(x=> x.AppUser).Skip((page - 1) * 4).Take(4).OrderByDescending(x=> x.CreatedAt).ToList();

            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Orders.Count()) / 4);
            pageNation.PageSelected = page;
            orderVM.pageNation = pageNation;
            return View(orderVM);   
        }

        public ActionResult Edit(int id)
        {
            Order order = _context.Orders.Include(x=> x.OrderItems).ThenInclude(y=> y.Product).Include(x=> x.AppUser).FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid == false)
            {
                return View(order);
            }
            Order orderBase = _context.Orders.FirstOrDefault(x => x.Id == order.Id);
            if (orderBase == null)
            {
                return NotFound();
            }

            orderBase.Status = order.Status;
            orderBase.DeliveryStatus = order.DeliveryStatus;
            _context.SaveChanges();
            return RedirectToAction("index","order");
        }

        public ActionResult Delete(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Status = OrderStatus.Denied;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
