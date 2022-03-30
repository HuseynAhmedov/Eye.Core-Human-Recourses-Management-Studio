using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly IWebHostEnvironment _env;
        private readonly INotyfService _notyf;

        public EmployeeController(UserManager<AppUser> userManager, DataContext context, IWebHostEnvironment env , INotyfService notyf)
        {
            _userManager = userManager;
            _context = context;
            _env = env;
            _notyf = notyf;
        }
        public ActionResult Index(int id )
        {
            EmployeeFormInfoVM formInfoVM = new EmployeeFormInfoVM();
            formInfoVM.Employee = _context.Employees.AsNoTracking().Include(x => x.Nationality).Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).FirstOrDefault(x => x.Id == id);
            if (formInfoVM.Employee == null)
            {
                return StatusCode(404);
            }
            Salary salary = _context.Salaries.FirstOrDefault(x => x.Employee == formInfoVM.Employee && x.UntilDate == null);
            if (salary != null)
            {
                formInfoVM.SalaryAmount = salary.Amount;
            }

            try
            {
                if (_context.Salaries.Where(x => x.Employee == formInfoVM.Employee && x.UntilDate != null) != null)
                {
                    Salary pastSalary = _context.Salaries.Where(x => x.Employee == formInfoVM.Employee && x.UntilDate != null).OrderByDescending(x => x.UntilDate).First();
                    formInfoVM.SalaryLastModifiedDate = pastSalary.UntilDate;
                }
            }
            catch (Exception)
            {
                formInfoVM.SalaryLastModifiedDate = null;
            }

            List<Bonus> bonusList = _context.Bonuses.Where(x => x.Employee == formInfoVM.Employee).OrderBy(x => x.DateGiven).ToList();
            if(bonusList.Count() != 0)
            {
                formInfoVM.LastBonus = bonusList[0].Amount;
                foreach (Bonus item in bonusList)
                {
                    formInfoVM.TotalBonus += item.Amount;
                }
            }
            
            formInfoVM.JobPositionName = _context.Positions.FirstOrDefault(x => x.Id == formInfoVM.Employee.JobPosition.PositionId).Name; ;
            formInfoVM.JobName = formInfoVM.Employee.JobPosition.Job.Name;
            formInfoVM.DepartmentName = formInfoVM.Employee.JobPosition.Job.Department.Name;
            formInfoVM.SectorName = formInfoVM.Employee.JobPosition.Job.Department.Sector.Name;
            formInfoVM.AttendanceDateFor = DateTime.UtcNow;
            formInfoVM.AttendancesList = _context.Attendances.Where(x => x.Employee == formInfoVM.Employee && x.DateFor > DateTime.UtcNow.AddDays(-DateTime.UtcNow.Day) && x.DateFor < DateTime.UtcNow.AddMonths(1).AddDays(-DateTime.UtcNow.Day)).OrderBy(x=> x.DateFor).ToList();
            return View(formInfoVM);
        }
        public ActionResult Create()
        {
            TempData["Showtab"] = 1;
            EmployeeFormVM createEmployeeVM = new EmployeeFormVM();
            return View(createEmployeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeFormVM newEmployee)
        {
            if (newEmployee.Employee.FormImage != null)
            {
                if (newEmployee.Employee.FormImage.Length > 3145728)
                {
                    ModelState.AddModelError("Employee.FormImage", "Image size cannot be higher than 3MB");
                    return View(newEmployee);
                }
                else if (newEmployee.Employee.FormImage.ContentType != "image/jpeg" && newEmployee.Employee.FormImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("Employee.FormImage", "Invalid image format ");
                    return View(newEmployee);
                }
            }
                
            if (string.IsNullOrEmpty(newEmployee.Employee.Email))
            {
                TempData["Showtab"] = 4;
                ModelState.AddModelError("Employee.Email", "Email is required");
                return View(newEmployee);
            }
            else if(_context.Employees.FirstOrDefault(x=> x.Email == newEmployee.Employee.Email) != null)
            {
                TempData["Showtab"] = 4;
                ModelState.AddModelError("Employee.Email", "This Email is already attached to a another employee");
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
            else if(_context.JobPositions.FirstOrDefault(x=> x.Id == newEmployee.JobPositionId).PostionCount <= _context.Employees.Where(x=> x.JobPositionId == newEmployee.JobPositionId).Count())
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("JobPositionId", "This job position is full");
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
            while (_context.AppUsers.FirstOrDefault(x => x.UserName == signInId) != null)
            {
                signInId = signInId.Remove(11);
                signInId += randomGen.Next(1000, 99999999).ToString();
            }
            AppUser appUser = new AppUser
            {
                FullName = newEmployee.Employee.Name + " " + newEmployee.Employee.Surname,
                UserName = signInId,
                Email = newEmployee.Employee.Email
            };
            var result = await _userManager.CreateAsync(appUser, randomGenerator.RandomPasswordBuilder(18));
            if (newEmployee.DepartmentId == 14)
            {
                var resultb = await _userManager.AddToRoleAsync(appUser, "HumanResources");
            }
            else
            {
                var resultt = await _userManager.AddToRoleAsync(appUser, "Employee");
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
            employee.AppUser = appUser;
            _context.Employees.Add(employee);
            Salary salary = new Salary();
            salary.Employee = employee;
            salary.Amount = (float)newEmployee.SalaryAmount;
            _context.Salaries.Add(salary);
            _context.SaveChanges();
            _notyf.Success("Employee added successfully", 5);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            if(_context.Employees.FirstOrDefault(x => x.Id == id) != null)
            {
                Employee dataBaseEmployee = _context.Employees.AsNoTracking().Include(x => x.JobPosition).ThenInclude(x => x.Job).ThenInclude(x => x.Department).ThenInclude(x => x.Sector).FirstOrDefault(x => x.Id == id);
                EmployeeFormVM EditModel = new EmployeeFormVM
                {
                    Employee = dataBaseEmployee,
                    BirthDate = dataBaseEmployee.BirthDate,
                    ExpireDate = dataBaseEmployee.ExpireDate,
                    JobPositionId = dataBaseEmployee.JobPositionId,
                    NationalityId = dataBaseEmployee.NationalityID,
                    JobId = dataBaseEmployee.JobPosition.Job.Id,
                    DepartmentId = dataBaseEmployee.JobPosition.Job.Department.Id,
                    SectorId = dataBaseEmployee.JobPosition.Job.Department.Sector.Id
                };
                Salary salary = _context.Salaries.FirstOrDefault(x => x.EmployeeId == dataBaseEmployee.Id && x.UntilDate == null);
                if (salary != null)
                {
                    EditModel.SalaryAmount = salary.Amount;
                }
                return View(EditModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeFormVM editEmployee)
        {

            if (_context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == editEmployee.Employee.Id) == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(editEmployee.Employee.Email))
            {
                TempData["Showtab"] = 4;
                ModelState.AddModelError("Employee.Email", "Email is required");
                return View(editEmployee);
            }
            else if (_context.Employees.FirstOrDefault(x => x.Email == editEmployee.Employee.Email && x.Id != editEmployee.Employee.Id) != null)
            {
                TempData["Showtab"] = 4;
                ModelState.AddModelError("Employee.Email", "This Email is already attached to a another employee");
                return View(editEmployee);
            }

            if (editEmployee.SalaryAmount == null)
            {
                TempData["Showtab"] = 2;
                ModelState.AddModelError("SalaryAmount", "Salary Amount is required");
                return View(editEmployee);
            }
            else if(_context.Salaries.AsNoTracking().FirstOrDefault(x => x.Amount == editEmployee.SalaryAmount && x.EmployeeId == editEmployee.Employee.Id ) == null)
            {
                Salary oldSalary = _context.Salaries.FirstOrDefault(x => x.Employee == editEmployee.Employee && x.UntilDate == null);
                if (oldSalary != null)
                {
                    oldSalary.UntilDate = DateTime.UtcNow;
                }
                Salary newSalary = new Salary
                {
                    Amount = (int)editEmployee.SalaryAmount,
                    UntilDate = null,
                    Employee = editEmployee.Employee
                };
                _context.Salaries.Add(newSalary);
            }

            if (editEmployee.SectorId == null || _context.Sectors.FirstOrDefault(x => x.Id == editEmployee.SectorId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("SectorId", "Select employee sector");
                return View(editEmployee);
            }

            if (editEmployee.DepartmentId == null || _context.Departments.FirstOrDefault(x => x.Id == editEmployee.DepartmentId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("DepartmentId", "Select employee department");
                return View(editEmployee);
            }

            if (editEmployee.JobId == null || _context.Jobs.FirstOrDefault(x => x.Id == editEmployee.JobId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("JobId", "Select employee Job");
                return View(editEmployee);
            }

            if (editEmployee.JobPositionId == null || _context.JobPositions.FirstOrDefault(x => x.Id == editEmployee.JobPositionId) == null)
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("JobPositionId", "Select employee Job Position");
                return View(editEmployee);
            }
            else if (_context.JobPositions.FirstOrDefault(x => x.Id == editEmployee.JobPositionId).PostionCount <= _context.Employees.Where(x => x.JobPositionId == editEmployee.JobPositionId).Count())
            {
                TempData["Showtab"] = 3;
                ModelState.AddModelError("JobPositionId", "This job position is full");
                return View(editEmployee);
            }

            if (editEmployee.ExpireDate != null && editEmployee.BirthDate != null)
            {
                if (DateTime.Compare((DateTime)editEmployee.ExpireDate, (DateTime)editEmployee.BirthDate) < 0)
                {
                    TempData["Showtab"] = 1;
                    ModelState.AddModelError("ExpireDate", "Expire Date cannot be earlier than Birth Date");
                    ModelState.AddModelError("BirthDate", "Birth Date cannot be later than Expire Date");
                    return View(editEmployee);
                }
                if (DateTime.Compare((DateTime)editEmployee.ExpireDate, (DateTime)editEmployee.BirthDate) == 0)
                {
                    TempData["Showtab"] = 1;
                    ModelState.AddModelError("ExpireDate", "Expire Date and Birth Date cannot be at the same date");
                    ModelState.AddModelError("BirthDate", "Birth Date and Expire Date cannot be at the same date");
                    return View(editEmployee);
                }
            }

            if (!ModelState.IsValid)
            {
                TempData["Showtab"] = 1;
                return View(editEmployee);
            }

            if (editEmployee.Employee.Name.Length == 1)
            {
                TempData["Showtab"] = 1;
                ModelState.AddModelError("Employee.Name", "Name cannot be 1 letter long");
                return View(editEmployee);
            }

            if (editEmployee.Employee.Surname.Length == 1)
            {
                TempData["Showtab"] = 1;
                ModelState.AddModelError("Employee.Surname", "Surname cannot be 1 letter long");
                return View(editEmployee);
            }

            if (editEmployee.Employee.FormImage != null)
            {
                if (editEmployee.Employee.FormImage.Length > 3145728)
                {
                    ModelState.AddModelError("Employee.FormImage", "Image size cannot be higher than 3MB");
                    return View(editEmployee);
                }
                else if (editEmployee.Employee.FormImage.ContentType != "image/jpeg" && editEmployee.Employee.FormImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("Employee.FormImage", "Invalid image format");
                    return View(editEmployee);
                }

                string imageName = FileManager.Save(_env.WebRootPath, "upload/userImage", editEmployee.Employee.FormImage);
                if (editEmployee.Employee.Image != null)
                {
                    bool imageDeleteResult = FileManager.Delete(_env.WebRootPath, "upload/userImage", editEmployee.Employee.Image);
                    if (imageDeleteResult != true)
                    {
                        FileManager.Delete(_env.WebRootPath, "upload/userImage", imageName);
                        ModelState.AddModelError("Employee.FormImage", "Something went wrong , please try again");
                        return View(editEmployee);
                    }
                }
                editEmployee.Employee.Image = imageName;
            }

            editEmployee.Employee.Name = editEmployee.Employee.Name.Trim();
            editEmployee.Employee.Surname = editEmployee.Employee.Surname.Trim();
            editEmployee.Employee.Email = editEmployee.Employee.Email.Trim();
            editEmployee.Employee.Name = char.ToUpper(editEmployee.Employee.Name[0]) + editEmployee.Employee.Name.Substring(1);
            editEmployee.Employee.Surname = char.ToUpper(editEmployee.Employee.Surname[0]) + editEmployee.Employee.Surname.Substring(1);
            editEmployee.Employee.JobPositionId = (int)editEmployee.JobPositionId;
            editEmployee.Employee.ExpireDate = (DateTime)editEmployee.ExpireDate;
            editEmployee.Employee.BirthDate = (DateTime)editEmployee.BirthDate;
            editEmployee.Employee.NationalityID = (int)editEmployee.NationalityId;
            _context.Employees.Update(editEmployee.Employee);
            _context.SaveChanges();
            _notyf.Success("Employee changes has been saved successfully", 5);
            return RedirectToAction("index", new { id = editEmployee.Employee.Id });
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
