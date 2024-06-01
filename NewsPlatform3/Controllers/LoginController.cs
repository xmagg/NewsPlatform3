using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPlatform3.Models;

namespace NewsPlatform3.Controllers
{
    public class LoginController : Controller
    {
        public static Login thisLogin = new Login();
        
 //       public static Login LoginInstance
 //       { 
 //           get { return thisLogin; } 
 //       }

        [HttpGet]
        public IActionResult Login()
        {
            thisLogin.isL = false;
            return View();
        }

        [HttpPost]
        public  IActionResult Login(string Login, string Passwd, Boolean isLogin)
        {
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
                                isPasswdOK = true;
                                thisLogin.isL = true;
                                thisLogin.username = item.Login;
                                if (item.Level == 0)
                                    thisLogin.level = "admin";
                                else if (item.Level > 9)
                                    thisLogin.level = "advanced";
                                else
                                    thisLogin.level = "basic";
                                if (isLogin)  // Login
                                {
                                    TempData["isL"] = "y";
                                    TempData["login"] = thisLogin.username;
                                    TempData["level"] = thisLogin.level;
                                    TempData["nok"] = "";

                                    if (item.Level > 0)
                                    {
                                        item.Level++;
                                        var u1 = context.Users.Update(item);


                                        var result = context.SaveChanges();
                                    }
                                    return RedirectToAction("GetListArticle", "Articles");
                                }
                            }
                        }
                    }
                    if (isLogin)  // Login & Passwd NOK
                    {
                        TempData["isL"] = "n";
                        TempData["nok"] = "Login was not possible. Try again.";
                        return View();
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
                            TempData["isL"] = "n";
                            TempData["nok"] = "Registration completed. Please log in.";
                            return View();
                        }
                        else // Reg NOK
                        {
                            TempData["isL"] = "n";
                            TempData["nok"] = "Registration was not possible. Please try again.";
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
        }
    }
}
