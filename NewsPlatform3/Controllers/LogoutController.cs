using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPlatform3.Models;

namespace NewsPlatform3.Controllers
{
    public class LogoutController : Controller
    {
        [HttpGet(Name = "Logout")]
        public IActionResult Index()
        {
            LoginController.thisLogin.isL = false;
            TempData["isL"] = "n";
            using (var context = new DbNewsContext())
            {
                DateTime saveNow = DateTime.Now;
                var log = new Log()
                {
                    Login = LoginController.thisLogin.username,
                    Date = saveNow.ToString("yyyy-MM-dd HHmmss"),
                    Description = "logout OK"
                };
                var l1 = context.Logs.Add(log);
                var result = context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
