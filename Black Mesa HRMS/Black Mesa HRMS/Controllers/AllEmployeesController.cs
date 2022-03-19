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
        public async Task<ActionResult> Index(AllEmployeesVM allEmployees , int page = 1)
        {
            PageNationVM pageNationVM = new PageNationVM();
            AllEmployeesVM allEmployeesVM = new AllEmployeesVM();
            List<AllEmployeesTM> allEmployeesTMList = new List<AllEmployeesTM>();
            List<Employee> employees = new List<Employee>();
            if (allEmployees.SortBy == null)
            {
                allEmployees.SortBy = 1;
            }

            if(string.IsNullOrWhiteSpace(allEmployees.KeyWord))
            {
                if(allEmployees.SortDescending == true)
                {
                    switch (allEmployees.SortBy)
                    {
                        case 1: //id
                            employees = await _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).OrderByDescending(x => x.Id).Skip((page - 1) * 2).Take(2).ToListAsync();
                            break;
                        case 2:
                            employees = await _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).OrderByDescending(x => x.Id).Skip((page - 1) * 2).Take(2).ToListAsync();
                            break;
                        case 3:
                            employees = await _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).OrderByDescending(x => x.Id).Skip((page - 1) * 2).Take(2).ToListAsync();
                            break;
                        case 4:
                            employees = await _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).OrderByDescending(x => x.Id).Skip((page - 1) * 2).Take(2).ToListAsync();
                            break;
                        case 5:
                            employees = await _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).OrderByDescending(x => x.Id).Skip((page - 1) * 2).Take(2).ToListAsync();
                            break;
                        default:
                            break;
                    }
                }
            }
            employees = await _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).OrderByDescending(x => x.Id).Skip((page - 1) * 2).Take(2).ToListAsync();

            if (employees.Count == 0)
            {
                return NotFound();
            }
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
            pageNationVM.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Employees.Count()) / 2);
            pageNationVM.PageSelected = page;
            allEmployeesVM.PageNation = pageNationVM;
            allEmployeesVM.KeyWord = allEmployees.KeyWord;
            allEmployeesVM.SortBy = allEmployees.SortBy;
            allEmployeesVM.SortDescending = allEmployees.SortDescending;
            return View(allEmployeesVM);
        }
    }
}
