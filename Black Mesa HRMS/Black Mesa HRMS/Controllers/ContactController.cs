using AspNetCoreHero.ToastNotification.Abstractions;
using Black_Mesa_HRMS.Models;
using Black_Mesa_HRMS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Black_Mesa_HRMS.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly INotyfService _notyf;

        public ContactController(DataContext context, IWebHostEnvironment env, INotyfService notyf)
        {
            _context = context;
            _env = env;
            _notyf = notyf;
        }
        public ActionResult Index(string sortBy = "1", string kewWord = "", string sortDescending = "False", int page = 1)
        {
            ContactVM contactVM = new ContactVM();
            PageNationVM pageNation = new PageNationVM();
            if (_context.Employees.ToList() == null)
            {
                return NotFound();
            }
            contactVM.Contacts = _context.Employees.Skip((page - 1) * 10).Take(10).ToList();
            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(contactVM.Contacts.Count()) / 10);
            pageNation.PageSelected = page;
            contactVM.PageNation = pageNation;
            return View(contactVM);
        }
        public ActionResult Filter(ContactVM contactVM)
        {
            return RedirectToAction("Index", new { page = 1, sortBy = contactVM.SortBy, keyWord = contactVM.KeyWord, sortDescending = contactVM.SortDescending });
        }
    }
}
