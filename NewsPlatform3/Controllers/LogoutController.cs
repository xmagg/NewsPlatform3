using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace NewsPlatform3.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            LoginController.thisLogin.isL = false;
            TempData["isL"] = "n";
            return RedirectToAction("Index", "Home");
        }
    }
}
