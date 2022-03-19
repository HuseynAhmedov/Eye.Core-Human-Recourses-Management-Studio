using Black_Mesa_HRMS.Enums;
using Black_Mesa_HRMS.Models;
using Black_Mesa_HRMS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(UserManager<AppUser> userManager, DataContext context, IWebHostEnvironment env , IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _context = context;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ActionResult> Index()
        {
            DashBoardVM dashBoardVM = new DashBoardVM();
            AppUser appUser = new AppUser();
            if ( User.Identity.Name == null )
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            dashBoardVM.Employee = _context.Employees.FirstOrDefault(x => x.AppUser.Id == appUser.Id);
            dashBoardVM.Budget = _context.Budgets.First().Amount;
            dashBoardVM.EmployeeCount = _context.Employees.ToList().Count;
            dashBoardVM.EmployeeCountNew = _context.Employees.Where(x => x.EmployedDate > DateTime.Now.AddMonths(-1)).ToList().Count;
            dashBoardVM.TodoList = _context.Todos.Where(x => x.EmployeeId == dashBoardVM.Employee.Id).ToList();
            List<Salary> salariesList = _context.Salaries.Include(x => x.Employee).ToList();
            foreach (var item in salariesList)
            {
                if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Administration)
                {
                    dashBoardVM.TotalAdministrationSalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Maintenance)
                {
                    dashBoardVM.TotalMaintenanceSalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Safety)
                {
                    dashBoardVM.TotalSafetySalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Scientist)
                {
                    dashBoardVM.TotalScientistSalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Security)
                {
                    dashBoardVM.TotalSecuritySalary += item.Amount;
                }
                dashBoardVM.TotalSalary += item.Amount;
            }
            return View(dashBoardVM);
        }
        public ActionResult GetSalaryByPercentage()
        {
            SortedList<string, int> percentageList = new SortedList<string, int>();
            List<Salary> salariesList = _context.Salaries.Include(x => x.Employee).ToList();

            float totalAdministrationSalary = 0;
            float totalMaintenanceSalary = 0;
            float totalSafetySalary = 0;
            float totalScientistSalary = 0;
            float totalSecuritySalary = 0;
            float totalSalary = 0;
            
            foreach (var item in salariesList)
            {
                if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Administration)
                {
                    totalAdministrationSalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Maintenance)
                {
                    totalMaintenanceSalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Safety)
                {
                    totalSafetySalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Scientist)
                {
                    totalScientistSalary += item.Amount;
                }
                else if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == JobType.Security)
                {
                    totalSecuritySalary += item.Amount;
                }
                totalSalary += item.Amount;
            }

            
            percentageList.Add("Administration", Convert.ToInt32((totalAdministrationSalary / totalSalary) * 100));
            percentageList.Add("Maintenance", Convert.ToInt32((totalMaintenanceSalary / totalSalary) * 100));
            percentageList.Add("Safety", Convert.ToInt32((totalSafetySalary / totalSalary) * 100));
            percentageList.Add("Scientist", Convert.ToInt32((totalScientistSalary / totalSalary) * 100));
            percentageList.Add("Security", Convert.ToInt32((totalSecuritySalary / totalSalary) * 100));

            return StatusCode(200, percentageList);
        }

        public ActionResult GetGenderCount()
        {
            SortedList<string, int> genderCountList = new SortedList<string, int>();
            int maleCount = 0;
            int femaleCount = 0;
            List<Employee> employeesList = _context.Employees.ToList();
            if (employeesList == null)
            {
                return StatusCode(404);
            }
            foreach (Employee employee in employeesList)
            {
                if (employee.Gender)
                {
                    maleCount++;
                }
                else
                {
                    femaleCount++;
                }
            }
            genderCountList.Add("Male", maleCount);
            genderCountList.Add("Female", femaleCount);
            return StatusCode(200, genderCountList);
        }


        //public ActionResult GetSalaryPerMonth(int jobtype , int yearfor)
        //{
        //    int[] salaryArr = {0};
        //    JobType jobType = (JobType)jobtype;
        //    DateTime yearFor = DateTime.MinValue.AddYears(yearfor-1);

        //    if()
        //    {

        //    }
        //    List<Salary> salariesList = _context.Salaries.Include(x => x.Employee).Where(x=> x.UntilDate ).ToList();

        //    foreach (var item in salariesList)
        //    {
        //        if (_context.Jobs.FirstOrDefault(x => x.Id == _context.JobPositions.FirstOrDefault(x => x.Id == item.Employee.JobPositionId).JobId).Type == jobType)
        //        {

        //        }
        //    }
        //    return Ok(salariesList);
        //}
        //public ActionResult GetSalaryPerYear()
        //{
        //    return Ok();
        //}
    }
}
