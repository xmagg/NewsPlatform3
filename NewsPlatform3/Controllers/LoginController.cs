using Microsoft.AspNetCore.Mvc;
using NewsPlatform3.Models;

namespace NewsPlatform3.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        }
    }
}
