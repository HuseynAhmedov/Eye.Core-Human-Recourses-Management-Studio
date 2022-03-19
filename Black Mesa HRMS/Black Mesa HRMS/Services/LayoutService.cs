using AspNetCoreHero.ToastNotification.Abstractions;
using Black_Mesa_HRMS.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Services
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly INotyfService _notyf;

        public LayoutService(UserManager<AppUser> userManager, DataContext context, INotyfService notyf)
        {
            _userManager = userManager;
            _context = context;
            _notyf = notyf;
        }
        public async Task<string> GetUserImage(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return "";
            }
            else
            {
                string imageName = _context.Employees.FirstOrDefault(x => x.AppUser == user).Image;
                return imageName;
            }
        }
    }
}
