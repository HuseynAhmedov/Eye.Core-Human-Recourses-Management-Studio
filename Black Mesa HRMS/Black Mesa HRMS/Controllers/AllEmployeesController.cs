using AspNetCoreHero.ToastNotification.Abstractions;
using Black_Mesa_HRMS.Models;
using Black_Mesa_HRMS.TableModels;
using Black_Mesa_HRMS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Controllers
{
    public class AllEmployeesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly INotyfService _notyf;

        public AllEmployeesController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager, IWebHostEnvironment env, INotyfService notyf)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _env = env;
            _notyf = notyf;
        }
        public ActionResult Index( string sortBy = "1" , string keyWord = "" , string sortDescending = "False", int page = 1 , int departmentId = 0 , bool requestFilter = false)
        {
            
            TempData["sortBy"] = sortBy;
            TempData["keyWord"] = keyWord;
            TempData["sortDescending"] = sortDescending;

            PageNationVM pageNationVM = new PageNationVM();
            AllEmployeesVM allEmployeesVM = new AllEmployeesVM();
            List<AllEmployeesTM> allEmployeesTMList = new List<AllEmployeesTM>();
            List<Employee> employees = new List<Employee>();
            

            allEmployeesVM.KeyWord = keyWord;
            allEmployeesVM.SortBy = Convert.ToInt32(sortBy);
            allEmployeesVM.SortDescending = Convert.ToBoolean(sortDescending);

            if (allEmployeesVM.SortBy == null)
            {
                allEmployeesVM.SortBy = 1;
            }

            employees = _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).Include(x => x.JobPosition).ThenInclude(x => x.Position).ToList();
            if (employees.Count == 0)
            {
                return NotFound();
            }

            if(requestFilter == true)
            {
                if(_context.Departments.FirstOrDefault(x => x.Id == departmentId) !=null)
                {
                    employees = employees.Where(x => x.JobPosition.Job.Department.Id == departmentId).ToList();
                }
                else
                {
                    return NotFound();
                }
            }

            if(!string.IsNullOrWhiteSpace(allEmployeesVM.KeyWord))
            {
                employees = employees.Where(x => x.Name.Contains(allEmployeesVM.KeyWord)).ToList();
                if (employees.Count == 0)
                {
                    return NotFound();
                }
            }

            switch (allEmployeesVM.SortBy)
            {
                case 1: //id
                    employees = employees.OrderBy(x => x.Id).ToList();
                    break;
                case 2://Name
                    employees = employees.OrderBy(x => x.Name).ToList();
                    break;
                case 3://Sector
                    employees = employees.OrderBy(x => x.JobPosition.Job.Department.Sector.Name).ToList();
                    break;
                case 4://Department
                    employees = employees.OrderBy(x => x.JobPosition.Job.Department.Name).ToList();
                    break;
                case 5://Job Title
                    employees = employees.OrderBy(x => x.JobPosition.Job.Name).ToList();
                    break;
                case 6://Job Position
                    employees = employees.OrderBy(x => x.JobPosition.Position.Name).ToList();
                    break;
                default:
                    employees = employees.OrderBy(x => x.Id).ToList();
                    break;
            }

            if(allEmployeesVM.SortDescending == true)
            {
                employees.Reverse();
            }

            

            employees = employees.Skip((page - 1) * 10).Take(10).ToList();

            foreach (Employee employee in employees)
            {
                AllEmployeesTM allEmployeesTM = new AllEmployeesTM
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name + " " + employee.Surname,
                    SectorName = employee.JobPosition.Job.Department.Sector.Name,
                    DepartmentName = employee.JobPosition.Job.Department.Name,
                    JobName = employee.JobPosition.Job.Name,
                };
                allEmployeesTM.PositionName = _context.Positions.FirstOrDefault(x => x.Id == employee.JobPosition.PositionId).Name;
                allEmployeesTMList.Add(allEmployeesTM);
            }
            allEmployeesVM.AllEmployeesTMs = allEmployeesTMList;
            pageNationVM.PageCount = (int)Math.Ceiling(Convert.ToDouble(allEmployeesVM.AllEmployeesTMs.Count()) / 10);
            pageNationVM.PageSelected = page;
            allEmployeesVM.PageNation = pageNationVM;

            return View(allEmployeesVM);
        }

        public ActionResult Filter ( AllEmployeesVM allEmployees)
        {
            return RedirectToAction("index", new { sortBy = allEmployees.SortBy, keyWord = allEmployees.KeyWord, sortDescending = allEmployees.SortDescending, page = 1 });
        }
    }
}
