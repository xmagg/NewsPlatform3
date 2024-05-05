using Microsoft.AspNetCore.Mvc;
using NewsPlatform3.Models;
using System.Diagnostics;

namespace NewsPlatform3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Boolean firstTime = true;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (firstTime)
            {
                ViewData["isLoggedin"] = 0; // 0 - not,  1- is logged in
                firstTime = false;
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