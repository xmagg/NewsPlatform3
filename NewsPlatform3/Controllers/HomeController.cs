using Microsoft.AspNetCore.Mvc;
using NewsPlatform3.Models;
using System.Diagnostics;

namespace NewsPlatform3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static Boolean firstTime = true;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (firstTime)
            {
                TempData["isL"] = "n";
                firstTime = false;
            }
            else
            {
                if (LoginController.thisLogin.isL)  // Login OK
                {
                    TempData["isL"] = "y";
                    TempData["login"] = LoginController.thisLogin.username;
                    TempData["level"] = LoginController.thisLogin.level;
                    TempData["nok"] = "";
                }
                else
                {
                    TempData["isL"] = "n";
                }
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}