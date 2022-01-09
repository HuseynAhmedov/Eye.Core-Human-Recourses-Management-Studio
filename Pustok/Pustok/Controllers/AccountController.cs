using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager )
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
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

            var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }

            return RedirectToAction("index", "home");
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
