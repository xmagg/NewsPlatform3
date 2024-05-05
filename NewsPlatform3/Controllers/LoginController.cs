using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPlatform3.Models;

namespace NewsPlatform3.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["isLoggedin"] = 0; // 0 - not logged in, 1 - logged in 
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Login, string Passwd, Boolean isLogin)
        {
            ViewData["isLoggedin"] = "0";
            if (ModelState.IsValid)
            {
                using (var context = new DbNewsContext())
                {
                    var users = context.Users.ToList();
                    var newLogin = true;
                    var isPasswdOK = false;
                    foreach (var item in users)
                    {
                        if (Login.Equals(item.Login))
                        {
                            newLogin = false;
                            if (Passwd.Equals(item.Password))
                            {
                                isPasswdOK |= true;
                                ViewData["login"] = item.Login;
                                if(item.Level == 0)
                                    ViewData["level"] = "admin";
                                else if (item.Level > 9)
                                    ViewData["level"] = "advanced";
                                else
                                    ViewData["level"] = "basic";
                            }
                        }
                    }
                    if(isLogin)  // Login
                    {
                        if (isPasswdOK)  // Login OK
                        {
                            ViewData["isLoggedin"] = "1";

                            return View();
                        }
                        else // Login NOK
                        {
                            ViewData["isLoggedin"] = 0;
                            return View();
                        }
                    }
                    else // Register
                    {
                        if (newLogin)  // Reg OK
                        {
                            var user1 = new User()
                            {
                                Id = Guid.NewGuid(),
                                Login = Login,
                                Password = Passwd,
                                Level = 1   // 1st login
                            };
                            var u1 = context.Users.AddAsync(user1);
                            var result = context.SaveChangesAsync();
                            ViewData["isLoggedin"] = 1;
                            ViewData["login"] = Login;

                            return View();
                        }
                        else // Reg NOK
                        {
                            ViewData["isLoggedin"] = 0;
                            return View();
                        }
                    }
                }
            }
            else
            {
                Login = "";
                Passwd = "";
                return View();
            }
            return RedirectToAction("Login");
        }
    }
}
