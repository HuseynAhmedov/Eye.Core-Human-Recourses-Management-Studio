using Microsoft.AspNetCore.Mvc;
using purpleBuzz.Models;
using purpleBuzz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace purpleBuzz.Controllers
{
    public class HomeController : Controller
    {
        List<WorkModel> workListTemp = new List<WorkModel> 
        { 
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "UI/UX design", ImageSrc = "./assets/img/services-01.jpg" },
            new WorkModel { InfoText = "Lorem ipsum dolor sit amet, consectetur adipisicing", BtnText = "Social Media", ImageSrc = "./assets/img/services-08.jpg" },
        };

        List<HomeSliderModel> sliderListTemp = new List<HomeSliderModel> 
        { 
            new HomeSliderModel { Header = "Cupidatat non proident, sunt in culpa qui officia", InfoText = "You are not allowed to re-distribute this Purple Buzz HTML template as a downloadable ZIP file on any kind of Free CSS collection websites. This is strongly prohibited. Please" },
            new HomeSliderModel { Header = "HTML CSS Template with Bootstrap 5 Beta 1", InfoText = "You are not allowed to re-distribute this Purple Buzz HTML template as a downloadable ZIP file on any kind of Free CSS collection websites. This is strongly prohibited. Please" },
            new HomeSliderModel { Header = "Cupidatat non proident, sunt in culpa qui officia", InfoText = "You are not allowed to re-distribute this Purple Buzz HTML template as a downloadable ZIP file on any kind of Free CSS collection websites. This is strongly prohibited. Please" },
            new HomeSliderModel { Header = "HTML CSS Template with Bootstrap 5 Beta 1", InfoText = "You are not allowed to re-distribute this Purple Buzz HTML template as a downloadable ZIP file on any kind of Free CSS collection websites. This is strongly prohibited. Please" },
            new HomeSliderModel { Header = "Cupidatat non proident, sunt in culpa qui officia", InfoText = "You are not allowed to re-distribute this Purple Buzz HTML template as a downloadable ZIP file on any kind of Free CSS collection websites. This is strongly prohibited. Please" },
        };


        public ActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.workList = workListTemp;
            homeVM.sliderList = sliderListTemp;
            return View(homeVM);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}
