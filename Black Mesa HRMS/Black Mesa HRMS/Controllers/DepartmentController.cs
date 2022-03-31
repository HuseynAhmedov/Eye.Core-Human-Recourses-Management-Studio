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

namespace Black_Mesa_HRMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly INotyfService _notyf;

        public DepartmentController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager, IWebHostEnvironment env, INotyfService notyf)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _env = env;
            _notyf = notyf;
        }
        public ActionResult Index(string keyWord = "", int page = 1)
        {
            DepartmentVM departmentVM = new DepartmentVM();
            PageNationVM pageNation = new PageNationVM();
            List<Department> dbDepartments = _context.Departments.Include(x => x.Sector).ToList();
            List<Employee> dbEmployees = _context.Employees.Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ToList();
            List<Salary> dbSalaries = _context.Salaries.Include(x => x.Employee).ThenInclude(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ToList();
            List<DepartmentTM> listDepartmentTM = new List<DepartmentTM>();
            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                dbDepartments = dbDepartments.Where(x => x.Name.Contains(keyWord)).ToList();
            }

            foreach (Department department in dbDepartments)
            {
                DepartmentTM departmentTM = new DepartmentTM();
                departmentTM.EmployeeCount = 0;
                departmentTM.TotalSalary = 0;
                departmentTM.AvgSalary = 0;

                departmentTM.SectorName = department.Sector.Name;
                departmentTM.Department = department;
                if (dbEmployees.Where(x => x.JobPosition.Job.Department.Id == department.Id) != null)
                {
                    departmentTM.EmployeeCount = dbEmployees.Where(x => x.JobPosition.Job.Department.Id == department.Id).Count();
                }

                if (dbSalaries.Where(x => x.Employee.JobPosition.Job.Department.Id == department.Id) != null)
                {
                    dbSalaries = dbSalaries.Where(x => x.Employee.JobPosition.Job.Department.Id == department.Id).ToList();
                    dbSalaries.ForEach(x => departmentTM.TotalSalary += x.Amount);
                }

                if (departmentTM.TotalSalary != 0 && departmentTM.EmployeeCount != 0)
                {
                    departmentTM.AvgSalary = departmentTM.TotalSalary / departmentTM.EmployeeCount;
                }

                listDepartmentTM.Add(departmentTM);
            }

            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(listDepartmentTM.Count()) / 10);
            pageNation.PageSelected = page;
            departmentVM.PageNation = pageNation;
            departmentVM.Departments = listDepartmentTM.Skip((page - 1) * 10).Take(10).ToList();
            departmentVM.KeyWord = keyWord;
            return View(departmentVM);
        }

        public ActionResult Filter(AllEmployeesVM allEmployees)
        {
            return RedirectToAction("Index", new { keyWord = allEmployees.KeyWord, page = 1 });
        }
    }
}
