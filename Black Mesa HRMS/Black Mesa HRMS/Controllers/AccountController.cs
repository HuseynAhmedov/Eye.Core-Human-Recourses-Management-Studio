using AspNetCoreHero.ToastNotification.Abstractions;
using Black_Mesa_HRMS.Hepler;
using Black_Mesa_HRMS.Models;
using Black_Mesa_HRMS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Black_Mesa_HRMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly INotyfService _notyf;

        public AccountController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager, IWebHostEnvironment env , INotyfService notyf)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _env = env;
            _notyf = notyf;
        }

        public async Task<ActionResult> Profile()
        {
            EmployeeFormInfoVM formInfoVM = new EmployeeFormInfoVM();
            if (User.Identity.Name == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return StatusCode(404);
            }
            formInfoVM.Employee = _context.Employees.Include(x => x.Nationality).FirstOrDefault(x => x.AppUser == user);
            if (formInfoVM.Employee == null)
            {
                return StatusCode(404);
            }
            formInfoVM.SalaryAmount = _context.Salaries.FirstOrDefault(x => x.Employee == formInfoVM.Employee && x.UntilDate == null).Amount;
            if (_context.Salaries.Where(x => x.Employee.Id == formInfoVM.Employee.Id).Where(x=> x.UntilDate != null).Count() != 0)
            {
                Salary pastSalary = _context.Salaries.Where(x => x.Employee == formInfoVM.Employee && x.UntilDate != null).OrderBy(x => x.UntilDate).First();
                formInfoVM.SalaryLastModifiedDate = pastSalary.UntilDate;
            }
            List<Bonus> bonusList = _context.Bonuses.Where(x => x.Employee == formInfoVM.Employee).OrderBy(x => x.DateGiven).ToList();
            if (bonusList.Count() != 0)
            {
                formInfoVM.LastBonus = bonusList[0].Amount;
                foreach (Bonus item in bonusList)
                {
                    formInfoVM.TotalBonus += item.Amount;
                }
            }
            JobPosition jobposition = _context.JobPositions.FirstOrDefault(x => x.Id == formInfoVM.Employee.JobPositionId);
            Job job = _context.Jobs.FirstOrDefault(x => x.Id == jobposition.JobId);
            Position position = _context.Positions.FirstOrDefault(x => x.Id == jobposition.PositionId);
            Department department = _context.Departments.Include(x => x.Sector).FirstOrDefault(x => x.Id == job.DepartmentId);
            Sector sector = _context.Sectors.FirstOrDefault(x => x.Id == department.Sector.Id);
            formInfoVM.JobPositionName = position.Name;
            formInfoVM.JobName = job.Name;
            formInfoVM.DepartmentName = department.Name;
            formInfoVM.SectorName = sector.Name;
            formInfoVM.AttendanceDateFor = DateTime.UtcNow;
            formInfoVM.AttendancesList = _context.Attendances.Where(x => x.Employee == formInfoVM.Employee && x.DateFor > DateTime.UtcNow.AddDays(-DateTime.UtcNow.Day) && x.DateFor < DateTime.UtcNow.AddMonths(1).AddDays(-DateTime.UtcNow.Day)).OrderBy(x => x.DateFor).ToList();
            return View(formInfoVM);
        }
        
        public async Task<ActionResult> Edit()
        {
            if(User.Identity.Name == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            if (_context.Employees.FirstOrDefault(x => x.AppUser == user) != null)
            {
                Employee dataBaseEmployee = _context.Employees.FirstOrDefault(x => x.AppUser == user);
                ProfileEditVM EditModel = new ProfileEditVM();
                EditModel.Id = dataBaseEmployee.Id;
                EditModel.Name = dataBaseEmployee.Name;
                EditModel.Surname = dataBaseEmployee.Surname;
                EditModel.Email = dataBaseEmployee.Email;
                EditModel.UserName = User.Identity.Name;
                EditModel.PhoneNumber = dataBaseEmployee.PhoneNumber;
                EditModel.HomeNumber = dataBaseEmployee.HomeNumber;
                EditModel.ZipCode = dataBaseEmployee.ZipCode;
                EditModel.Address = dataBaseEmployee.Address;
                EditModel.Gender = dataBaseEmployee.Gender;
                EditModel.ImageName = dataBaseEmployee.Image;
                return View(EditModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProfileEditVM profileEdit)
        {
            if (User.Identity.Name == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(profileEdit.Email))
            {
                TempData["Showtab"] = 4;
                ModelState.AddModelError("Employee.Email", "Email is required");
                return View(profileEdit);
            }
            if(!string.IsNullOrWhiteSpace(profileEdit.CurrentPassword))
            {
                
                var result = await _userManager.CheckPasswordAsync(user, profileEdit.CurrentPassword);
                if (result == false)
                {
                    ModelState.AddModelError("CurrentPassword", "Invalid password");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(profileEdit.NewPassword))
                    {
                        ModelState.AddModelError("NewPassword", "New password cannot be emty");
                    }
                    else if(profileEdit.NewPassword == profileEdit.CurrentPassword)
                    {
                        ModelState.AddModelError("NewPassword", "New password cannot be same as your old one");
                    }
                    if (string.IsNullOrWhiteSpace(profileEdit.ConfirmPassword))
                    {
                        ModelState.AddModelError("ConfirmPassword", "Repeat password cannot be emty");
                    }
                    else if(profileEdit.NewPassword != profileEdit.ConfirmPassword)
                    {
                        ModelState.AddModelError("ConfirmPassword", "Confirm password does not match with new password");
                    }
                    return View(profileEdit);
                    var passwordResult = await _userManager.ChangePasswordAsync(user, profileEdit.CurrentPassword, profileEdit.NewPassword);
                    if (!passwordResult.Succeeded)
                    {
                        foreach (var item in passwordResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(profileEdit);
                    }
                }
            }
            if(!string.IsNullOrWhiteSpace(profileEdit.CurrentPassword) || !string.IsNullOrWhiteSpace(profileEdit.CurrentPassword) )
            {
                ModelState.AddModelError("CurrentPassword", "Current password is required");
            }
            if (!ModelState.IsValid)
            {
                return View(profileEdit);
            }
            Employee baseEmployee = _context.Employees.FirstOrDefault(x => x.AppUser == user);
            baseEmployee.Email = profileEdit.Email;
            baseEmployee.PhoneNumber = profileEdit.PhoneNumber;
            baseEmployee.HomeNumber = profileEdit.HomeNumber;
            baseEmployee.ZipCode = profileEdit.ZipCode;
            baseEmployee.Address = profileEdit.Address;
            _context.SaveChanges();
            _notyf.Success("Account updated successfully",5);
            return RedirectToAction("Profile","Account");
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(LoginVM loginInput)
        {
            if (ModelState.IsValid == false) return View(loginInput);
            AppUser user = await _userManager.FindByNameAsync(loginInput.SignInId);
            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginInput.Password, false, false);
            if (!result.Succeeded)
            {
               ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
               return View();
            }

            if (user.LastPasswordChangeDate == null)
            {
                TempData["Password"] = loginInput.Password;
                return RedirectToAction("FirstTimeSignIn" , new { userName = loginInput.SignInId });
            }
            user.LastConnectDate = DateTime.UtcNow;
            _context.SaveChanges();

            var roleList = await _userManager.GetRolesAsync(user);

            if (roleList.Contains("Admin") || roleList.Contains("SuperAdmin"))
            {
                return RedirectToAction("index", "home");
            }
            else if (roleList.Contains("HumanResources"))
            {
                return RedirectToAction("index", "home");
            }
            else if (roleList.Contains("Employee"))
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                return NotFound();
            }
        }
        public ActionResult FirstTimeSignIn(string userName)
        {
            FirstTimeSignInVM firstTimeSignInVM = new FirstTimeSignInVM();
            firstTimeSignInVM.UserName = userName;
            firstTimeSignInVM.CurrentPassword = TempData["Password"].ToString();
            return View(firstTimeSignInVM);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordVM forgotPassword)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByEmailAsync(forgotPassword.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "User not found");
                return View();
            }
            //else if(user.EmailConfirmed == false)
            //{
            //    ModelState.AddModelError("Email", "This email is not confirmed yet");
            //    return View();
            //}

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("resetpassword", "account", new { email = user.Email, token = token }, Request.Scheme);
            string bodyHtml = System.IO.File.ReadAllText(_env.WebRootPath + "/html/_PasswordReset.html");
            bodyHtml = bodyHtml.Replace("{{ResetPasswordLink}}", url);
            try
            {
                EmailManager.Email(user.Email, bodyHtml, "Reset password Request");
            }
            catch (Exception)
            {
                _notyf.Error("Something went wrong , please try again in a few minutes", 10);
                return View();
            }
            _notyf.Custom("Check your email for a reset password link", 10, "ghostwhite", "fa fa-envelope");
            return View();
        }
        public async Task<ActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null || !(await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetPasswordVM.Token)))
            {
                _notyf.Error("Something went wrong , please try again in a few minutes", 10);
                return RedirectToAction("SignIn");
            }
            return View(resetPasswordVM);
        }
        public async Task<IActionResult> ChangePassword(ResetPasswordVM resetPasswordVM)
        {
            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null) return RedirectToAction("SignIn");
            if (!ModelState.IsValid) return View("ResetPassword", resetPasswordVM);
            if (string.IsNullOrWhiteSpace(resetPasswordVM.Password) || resetPasswordVM.Password.Length > 25)
            {
                ModelState.AddModelError("", "Password must be less than 26 character");
                return View("ResetPassword", resetPasswordVM);
            }
            if (resetPasswordVM.Password != resetPasswordVM.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "Confirm password doesn't match New password");
                return View("ResetPassword", resetPasswordVM);

            }
            var PasswordChkresult = await _userManager.CheckPasswordAsync(user, resetPasswordVM.Password);
            if (PasswordChkresult == true)
            {
                ModelState.AddModelError("Password", "New password cannot be same as your old one");
                return View("ResetPassword", resetPasswordVM);

            }
            var ResetPasswordresult = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);
            if (!ResetPasswordresult.Succeeded)
            {
                foreach (var item in ResetPasswordresult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("ResetPassword", resetPasswordVM);
            }
            user.LastPasswordChangeDate = DateTime.UtcNow;
            _context.SaveChanges();
            _notyf.Success("Password Changed Successfully", 10);
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FirstTimeChangePassword(FirstTimeSignInVM firstTimeUser)
        {
            AppUser user = await _userManager.FindByNameAsync(firstTimeUser.UserName);
            string currentPassword = firstTimeUser.CurrentPassword;
            if (!ModelState.IsValid)
            {
                return View(firstTimeUser);
            }
            if (string.IsNullOrWhiteSpace(firstTimeUser.NewPassword) || firstTimeUser.NewPassword.Length > 25)
            {
                ModelState.AddModelError("", "Password must be less than 26 character");
                return View(firstTimeUser);
            }
            if (firstTimeUser.NewPassword != firstTimeUser.NewPasswordRepeat)
            {
                ModelState.AddModelError("NewPassword", "Confirm password doesn't match New password");
                return View(firstTimeUser);
            }
            var result = await _userManager.CheckPasswordAsync(user, firstTimeUser.NewPassword);
            if (result == true)
            {
                ModelState.AddModelError("NewPassword", "New password cannot be same as your old one");
                return View(firstTimeUser);
            }
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, currentPassword, firstTimeUser.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var item in changePasswordResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(firstTimeUser);
            }
            user.LastPasswordChangeDate = DateTime.UtcNow;
            _context.SaveChanges();
            _notyf.Success("Password Changed Successfully", 10);
            return RedirectToAction("SignIn");
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Account");
        }
    }
}
