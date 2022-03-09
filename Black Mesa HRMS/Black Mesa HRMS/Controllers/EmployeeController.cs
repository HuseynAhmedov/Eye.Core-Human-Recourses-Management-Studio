using Black_Mesa_HRMS.Helper;
using Black_Mesa_HRMS.Hepler;
using Black_Mesa_HRMS.Models;
using Black_Mesa_HRMS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Black_Mesa_HRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager , IWebHostEnvironment env , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _env = env;
            _roleManager = roleManager;
        }
        public ActionResult index()
        {
            return View();
        }
        public ActionResult Create()
        {
            TempData["Showtab"] = 1;
            CreateEmployeeVM createEmployeeVM = new CreateEmployeeVM();
            return View(createEmployeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeVM newEmployee)
        {
            if (newEmployee.Employee.FormImage != null)
            {
                if (newEmployee.Employee.FormImage.Length > 3145728)
                {
                    ModelState.AddModelError("FormImage", "Image size cannot be higher than 3MB");
                }
                else if (newEmployee.Employee.FormImage.ContentType != "image/jpeg" && newEmployee.Employee.FormImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("FormImage", "Invalid image format ");
                }
            }
            if (string.IsNullOrEmpty(newEmployee.Employee.Email))
            {
                TempData["Showtab"] = 4;
                ModelState.AddModelError("Employee.Email", "Email is required");
                return View(newEmployee);
            }
            if(newEmployee.SalaryAmount == null)
            {
                TempData["Showtab"] = 2;
                ModelState.AddModelError("SalaryAmount", "Salary Amount is required");
                return View(newEmployee);
            }
            if ( newEmployee.SectorId == null  || _context.Sectors.FirstOrDefault(x=> x.Id == newEmployee.SectorId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("SectorId", "Select employee sector");
                return View(newEmployee);
            }
            if( newEmployee.DepartmentId == null ||  _context.Departments.FirstOrDefault(x => x.Id == newEmployee.DepartmentId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("DepartmentId", "Select employee department");
                return View(newEmployee);
            }
            if( newEmployee.JobId == null || _context.Jobs.FirstOrDefault(x => x.Id == newEmployee.JobId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("JobId", "Select employee Job");
                return View(newEmployee);
            }
            if ( newEmployee.JobPositionId == null || _context.JobPositions.FirstOrDefault(x => x.Id == newEmployee.JobPositionId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("JobPositionId", "Select employee Job Position");
                return View(newEmployee);
            }
            if(newEmployee.ExpireDate != null && newEmployee.BirthDate != null)
            {
                if(DateTime.Compare((DateTime)newEmployee.ExpireDate, (DateTime)newEmployee.BirthDate) < 0)
                {
                    TempData["Showtab"] = 1;
                    ModelState.AddModelError("ExpireDate", "Expire Date cannot be earlier than Birth Date");
                    ModelState.AddModelError("BirthDate", "Birth Date cannot be later than Expire Date");
                    return View(newEmployee);
                }
                if (DateTime.Compare((DateTime)newEmployee.ExpireDate, (DateTime)newEmployee.BirthDate) == 0)
                {
                    TempData["Showtab"] = 1;
                    ModelState.AddModelError("ExpireDate", "Expire Date and Birth Date cannot be at the same date");
                    ModelState.AddModelError("BirthDate", "Birth Date and Expire Date cannot be at the same date");
                    return View(newEmployee);
                }
            }
            if (!ModelState.IsValid)
            {
                TempData["Showtab"] = 1;
                return View(newEmployee);
            }
            if (newEmployee.Employee.Name.Length == 1)
            {
                TempData["Showtab"] = 1;
                ModelState.AddModelError("Employee.Name", "Name cannot be 1 letter long");
                return View(newEmployee);
            }
            if (newEmployee.Employee.Surname.Length == 1)
            {
                TempData["Showtab"] = 1;
                ModelState.AddModelError("Employee.Surname", "Surname cannot be 1 letter long");
                return View(newEmployee);
            }

            RandomGeneratorManager randomGenerator = new RandomGeneratorManager();
            StringBuilder signInIdBuilder = new StringBuilder();
            Random randomGen = new Random();
            signInIdBuilder.Append(_context.Sectors.FirstOrDefault(x => x.Id == newEmployee.SectorId).Name);
            signInIdBuilder.Append(_context.Departments.FirstOrDefault(x => x.Id == newEmployee.DepartmentId).Name.Substring(0, 2));
            signInIdBuilder.Append(_context.Jobs.FirstOrDefault(x => x.Id == newEmployee.JobId).Name.Substring(0, 2));
            signInIdBuilder.Append(newEmployee.Employee.Name.Substring(0, 1));
            signInIdBuilder.Append(newEmployee.Employee.Surname.Substring(0, 1));
            signInIdBuilder.Append(DateTime.Now.Year.ToString());
            signInIdBuilder.Append(randomGen.Next(1000, 99999999).ToString());

            string signInId = signInIdBuilder.ToString();
            while (_context.AppUsers.FirstOrDefault(x => x.SignInID == signInId) != null)
            {
                signInId = signInId.Remove(11);
                signInId += randomGen.Next(1000, 9999999).ToString();
            }

            newEmployee.Employee.Name = newEmployee.Employee.Name.Trim();
            newEmployee.Employee.Surname = newEmployee.Employee.Surname.Trim();
            newEmployee.Employee.Email = newEmployee.Employee.Email.Trim();
            newEmployee.Employee.Name = char.ToUpper(newEmployee.Employee.Name[0]) + newEmployee.Employee.Name.Substring(1);
            newEmployee.Employee.Surname = char.ToUpper(newEmployee.Employee.Surname[0]) + newEmployee.Employee.Surname.Substring(1);
            Employee employee = newEmployee.Employee;
            if (newEmployee.Employee.FormImage != null) employee.Image = FileManager.Save(_env.WebRootPath, "upload/userImage", newEmployee.Employee.FormImage);
            employee.JobPositionId =(int)newEmployee.JobPositionId;
            employee.ExpireDate = (DateTime)newEmployee.ExpireDate;
            employee.BirthDate = (DateTime)newEmployee.BirthDate;
            employee.EmployedDate = DateTime.Today.Date;
            employee.NationalityID = (int)newEmployee.NationalityId;
            _context.Employees.Add(employee);
            _context.SaveChanges();

            AppUser appUser = new AppUser
            {
                FullName = employee.Name + " " + employee.Surname,
                SignInID = signInId,
                UserName = employee.Name + employee.Surname,
                SignInEmail = signInId + "@gmail.com"
            };

            var result = await _userManager.CreateAsync(appUser, randomGenerator.RandomPasswordBuilder(18));


            return View(newEmployee);
        }

        public ActionResult GetDepartments(int Id)
        {
            List<Department> departments = _context.Departments.Where(x => x.Sector.Id == Id).ToList();
            if(departments == null || departments.Count == 0 )
            {
                return StatusCode(404);
            }
            return StatusCode(200, departments);
        }
        public ActionResult GetJobs(int Id)
        {
            List<Job> Jobs = _context.Jobs.Where(x => x.DepartmentId == Id).ToList();
            if (Jobs == null || Jobs.Count == 0)
            {
                return StatusCode(404);
            }
            return StatusCode(200, Jobs);
        }
        public ActionResult GetJobPositions(int Id)
        {
            List<JobPosition> JobPositions = _context.JobPositions.Where(x => x.JobId == Id).Include(x => x.Position).ToList();
            if (JobPositions == null || JobPositions.Count == 0)
            {
                return StatusCode(404);
            }
            return StatusCode(200, JobPositions);
        }

        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Employee");
        //    IdentityRole role4 = new IdentityRole("HumanResources");


        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);
        //    await _roleManager.CreateAsync(role4);
        //    return Ok();
        //}
    }
}
