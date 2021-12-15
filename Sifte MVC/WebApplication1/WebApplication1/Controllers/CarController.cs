using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {

        List<car> carList = new List<car>
        {   new car (1,"Mercedes","E200","black"),
            new car (2, "Mercedes", "E200", "grey"),
            new car(3, "Mercedes", "E200", "blue"),
            new car(4, "Mercedes", "E200", "white"),
            new car(5, "Mercedes", "E200", "yellow"),
            new car(6, "Mercedes", "E200", "brown")
        };
        public ActionResult Index()
        {

            ViewBag.carList = carList;

            return View();
        }

        public ActionResult Detail(int id)
        {
            car std = carList.Find(x => x.Id == id);
            ViewBag.carFind = std;

            return View();
        }
    }
}
