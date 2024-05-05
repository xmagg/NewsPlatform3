using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace NewsPlatform3.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["isLoggedin"] = "0";
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
