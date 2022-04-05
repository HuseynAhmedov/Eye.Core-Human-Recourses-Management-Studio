using AspNetCoreHero.ToastNotification.Abstractions;
using Black_Mesa_HRMS.Models;
using Black_Mesa_HRMS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Black_Mesa_HRMS.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly INotyfService _notyf;
        public EmployeeSalaryController(DataContext context, IWebHostEnvironment env, INotyfService notyf)
        {
            _context = context;
            _env = env;
            _notyf = notyf;
        }
        public ActionResult Index()
        {
            EmployeeSalaryVM employeeSalaryVM = new EmployeeSalaryVM();
            PageNationVM pageNation = new PageNationVM();
            List<Employee> employeesList = _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).Include(x => x.JobPosition).ThenInclude(x => x.Position).ToList();
            List<Salary> salariesList = _context.Salaries.Include(x => x.Employee).ToList();
            return View();
        }
    }
}
