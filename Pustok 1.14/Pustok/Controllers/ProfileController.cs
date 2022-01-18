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
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, DataContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<ActionResult> Profile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            ProfileVM profileVM = new ProfileVM();
            profileVM.UserName = user.UserName;
            profileVM.FullName = user.FullName;
            profileVM.Email = user.Email;
            return View(profileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Profile(ProfileVM updatedProfile)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid == false)
            {
                return View(updatedProfile);
            }
            if (string.IsNullOrWhiteSpace(updatedProfile.Email))
            {
                ModelState.AddModelError("Email","Email cannot be emty");
            }
            else if (await _userManager.FindByEmailAsync(updatedProfile.Email) != null)
            {
                if (user.Email != updatedProfile.Email)
                {
                    ModelState.AddModelError("Email", "Account by this email already exits");
                }
            }
            if (string.IsNullOrWhiteSpace(updatedProfile.FullName))
            {
                ModelState.AddModelError("FullName", "FullName cannot be emty");
            }
            if (string.IsNullOrWhiteSpace(updatedProfile.UserName))
            {
                ModelState.AddModelError("UserName", "Username cannot be emty");
            }
            else if( await _userManager.FindByNameAsync(updatedProfile.UserName) != null)
            {
                if( User.Identity.Name != updatedProfile.UserName)
                {
                    ModelState.AddModelError("UserName", "This Username already exits");
                }
            }
            if (updatedProfile.CurrentPassword != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, updatedProfile.CurrentPassword);
                if (result == false)
                {
                    ModelState.AddModelError("CurrentPassword", "Invalid password");
                }
                else if(result == true)
                {
                    if (string.IsNullOrWhiteSpace(updatedProfile.NewPassword))
                    {
                        ModelState.AddModelError("NewPassword", "New password cannot be emty");
                    }
                    else if (string.IsNullOrWhiteSpace(updatedProfile.NewPasswordRepeat))
                    {
                        ModelState.AddModelError("NewPasswordRepeat", "Repeat password cannot be emty");
                    }
                    return View(updatedProfile);
                    var passwordResult = await _userManager.ChangePasswordAsync(user, updatedProfile.CurrentPassword, updatedProfile.NewPassword);
                    if (!passwordResult.Succeeded)
                    {
                        foreach (var item in passwordResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View();
                    }
                }
            }

            if (ModelState.IsValid == false)
            {
                return View(updatedProfile);
            }

            user.Email = updatedProfile.Email;
            user.FullName = updatedProfile.FullName;
            user.UserName = updatedProfile.UserName;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("index", "home");
        }

    }
}
