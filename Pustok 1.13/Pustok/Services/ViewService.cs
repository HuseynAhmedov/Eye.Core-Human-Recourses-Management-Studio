using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Services
{
    public class ViewService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        DataContext _context;
        public ViewService(IHttpContextAccessor contextAccessor, DataContext context)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(y=> y.Product).Include(x => x.AppUser).OrderByDescending(x => x.CreatedAt).ToList();
            return orders;
        }
    }
}
