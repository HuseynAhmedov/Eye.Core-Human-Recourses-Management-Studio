using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Manage.ViewModel;
using Portfolio.Helper;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        public SettingController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public ActionResult Index()
        {
            SettingVM settingVM = new SettingVM();
            settingVM.Settings = _context.Settings.ToList();
            return View(settingVM);
        }

        public ActionResult Info(int id)
        {
            if (_context.Settings.FirstOrDefault(x => x.Id == id) == null)
            {
                return NotFound();
            }
            else
            {
                return View(_context.Settings.FirstOrDefault(x => x.Id == id));
            }
        }
        public ActionResult Edit(int id)
        {
            if (_context.Settings.FirstOrDefault(x => x.Id == id) == null)
            {
                return NotFound();
            }
            else
            {
                return View(_context.Settings.FirstOrDefault(x => x.Id == id));
            }
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public ActionResult Edit(Setting setting)
        {
            if (_context.Settings.FirstOrDefault(x => x.Id == setting.Id) !=null)
            {
                Setting settingBase = _context.Settings.FirstOrDefault(x => x.Id == setting.Id);
                setting.Type = settingBase.Type;
                if (setting.Type == ObjectType.Image)
                {
                    if (setting.FormImage != null)
                    {
                        if (setting.FormImage.Length > 2097152)
                        {
                            ModelState.AddModelError("FormImage", "Image size cannot be higher than 2MB");
                        }
                        else if (setting.FormImage.ContentType != "image/jpeg" && setting.FormImage.ContentType != "image/png" && setting.FormImage.ContentType != "image/svg+xml")
                        {
                            ModelState.AddModelError("FormImage", "Invalid image format ");
                        }
                        if (!ModelState.IsValid)
                        {
                            return View(_context.Settings.FirstOrDefault(x => x.Id == setting.Id));
                        }
                        var temp = setting.Source;
                        setting.Source = FileManager.Upload(_env.WebRootPath, "upload/Setting", setting.FormImage);
                        FileManager.Delete(_env.WebRootPath, temp);
                    }
                }

                settingBase.Source = setting.Source;

                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();
        }
    }
}
