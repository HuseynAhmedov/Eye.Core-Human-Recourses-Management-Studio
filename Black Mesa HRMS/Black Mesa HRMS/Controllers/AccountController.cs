using Microsoft.AspNetCore.Mvc;

namespace Black_Mesa_HRMS.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignIn()
        {
            return View();
        }
    }
}
