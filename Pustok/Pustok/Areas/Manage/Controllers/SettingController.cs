using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        DataContext _context;

        public SettingController(DataContext context)
        {
            this._context = context;
        }

        public ActionResult Index(int page = 1)
        {
            PageNationVM pageNation = new PageNationVM();
            SettingVM settingVM = new SettingVM();
            settingVM.Settings = _context.Settings.Skip((page - 1) * 4).Take(4).ToList();
            pageNation.PageCount = (int)Math.Ceiling(Convert.ToDouble(_context.Settings.Count()) / 4);
            pageNation.PageSelected = page;
            settingVM.pageNation = pageNation;
            return View(settingVM);
        }

        public ActionResult Info(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            return View(setting);
        }


        public ActionResult Edit(int id)
        {
            if(_context.Settings.FirstOrDefault(x => x.Id == id) == null)
            {
                return NotFound();
            }
            return View(_context.Settings.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Setting EditedSetting)
        {
            if (!ModelState.IsValid) return View();
            _context.Settings.Update(EditedSetting);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
