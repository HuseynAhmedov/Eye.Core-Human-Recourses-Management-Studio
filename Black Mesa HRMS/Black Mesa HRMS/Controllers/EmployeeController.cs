﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult index()
        {
            return View();
        }
    }
}