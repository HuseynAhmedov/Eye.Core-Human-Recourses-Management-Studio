using AspNetCoreHero.ToastNotification.Abstractions;
using Black_Mesa_HRMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Black_Mesa_HRMS.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly INotyfService _notyf;

        public AttendanceController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager, IWebHostEnvironment env, INotyfService notyf)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _env = env;
            _notyf = notyf;
        }
        public ActionResult Index(int page = 1)
        {

            return View();
        }
    }
}
