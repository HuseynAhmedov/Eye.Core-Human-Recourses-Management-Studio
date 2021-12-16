using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace purpleBuzz.Controllers
{
    public class WorkController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Single()
        {
            return View();
        }
    }
}
