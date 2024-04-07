using Microsoft.AspNetCore.Mvc;

namespace NewsPlatform3.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
