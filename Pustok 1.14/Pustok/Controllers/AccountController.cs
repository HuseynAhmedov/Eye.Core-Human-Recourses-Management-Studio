using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Pustok.Helper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;

namespace Pustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly IHubContext<PustokHub> _hubContext;

        public AccountController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager , IWebHostEnvironment env , IHubContext<PustokHub> hubContext)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _env = env;
            _hubContext = hubContext;
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVM newUser)
        {
            if (ModelState.IsValid == false) return View(newUser);

            if (await _userManager.FindByNameAsync(newUser.UserName) != null)
            {
                ModelState.AddModelError("UserName", "Username allready exits");
                return View(newUser);
            }
            if (await _userManager.FindByEmailAsync(newUser.Email.ToUpper()) != null)
            {
                ModelState.AddModelError("Email","Account already exits by this email");
                return View(newUser);
            }

            AppUser user = new AppUser();
            user.Email = newUser.Email;
            user.FullName = newUser.FullName;
            user.UserName = newUser.UserName;

            var result =  await _userManager.CreateAsync(user,newUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user,"Member");
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("index", "home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM loginUser)
        {
            if (ModelState.IsValid == false) return View(loginUser);
            AppUser user = await _userManager.FindByNameAsync(loginUser.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }
            else if (user.IsAdmin == true)
            {
                return RedirectToAction("login", "Account", new { area = "Manage" });
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }
            if (User.Identity.IsAuthenticated)
            {
                
                if (user.ConnectionId != null)
                {
                    PustokHub pustokHub = new PustokHub(_userManager);

                    List<AppUser> appUsers = _context.Users.ToList();
                    foreach (AppUser item in appUsers)
                    {
                        bool onlineStatus = true;
                        if (item.ConnectionId == null)
                        {
                            onlineStatus = false;
                        }
                        string userName = item.UserName;
                        await _hubContext.Clients.Client(user.ConnectionId).SendAsync("OnlineStatus", onlineStatus, userName);
                    }
                }
            }
            return RedirectToAction("index", "home");
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public  ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "User not found");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("resetpassword", "account", new { email = user.Email, token = token }, Request.Scheme);

            TempData["ResetUrl"] = url;
            string bodyHtml = System.IO.File.ReadAllText(_env.WebRootPath + "/html/_PasswordReset.html");
            bodyHtml = bodyHtml.Replace("{{UserName}}", user.UserName);
            bodyHtml = bodyHtml.Replace("{{ResetUrl}}", url);
            EmailManager.Email(user.Email, bodyHtml);
            TempData["Success"] = "Check your email for a reset password link";
            return RedirectToAction("index", "home");
        }

        public async Task<ActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null || !(await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetPasswordVM.Token)))
                return RedirectToAction("login");


            return View(resetPasswordVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ResetPasswordVM resetPasswordVM)
        {
            if (string.IsNullOrWhiteSpace(resetPasswordVM.Password) || resetPasswordVM.Password.Length > 25)
                ModelState.AddModelError("Password", "Password is required and must be less than 26 character");

            if (!ModelState.IsValid) return View("ResetPassword", resetPasswordVM);

            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null) return RedirectToAction("login");

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("ResetPassword", resetPasswordVM);
            }

            return RedirectToAction("login");       
        }

        

    }
}
