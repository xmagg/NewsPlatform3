using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPlatform3.Models;

namespace NewsPlatform3.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class LoginController : Controller
    {
        public static Login thisLogin = new Login();
        
 //       public static Login LoginInstance
 //       { 
 //           get { return thisLogin; } 
 //       }

        [HttpGet(Name = "Login")]
        //[Authorize]
        public IActionResult Login()
        {
            thisLogin.isL = false;
            return View();
        }

        [HttpPost]
        //[Authorize]
        public  IActionResult Login(string Login, string Passwd, Boolean isLogin)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DbNewsContext())
                {
                    DateTime saveNow = DateTime.Now;
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
                                thisLogin.Guid = item.Id;
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
                                    }
                                    
                                    var log = new Log()
                                    {
                                        Login = item.Login,
                                        Date = saveNow.ToString("yyyy-MM-dd HHmmss"),
                                        Description = "login OK"
                                    };
                                    var l1 = context.Logs.Add(log);
                                    var result = context.SaveChanges(); 
                                    
                                    return RedirectToAction("GetListArticle", "Articles");
                                }
                            }
                        }
                    }
                    if (isLogin)  // Login & Passwd NOK
                    {
                        TempData["isL"] = "n";
                        TempData["nok"] = "Login was not possible. Try again.";

                        var log = new Log()
                        {
                            Login = Login,
                            Date = saveNow.ToString("yyyy-MM-dd HHmmss"),
                            Description = "login NOK"
                        };
                        var l1 = context.Logs.Add(log);
                        var result = context.SaveChanges();

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
                            var u1 = context.Users.Add(user1);
                            var log = new Log()
                            {
                                Login = Login,
                                Date = saveNow.ToString("yyyy-MM-dd HHmmss"),
                                Description = "registr OK"
                            };
                            var l1 = context.Logs.Add(log);
                            var result = context.SaveChanges();
                            TempData["isL"] = "n";
                            TempData["nok"] = "Registration completed. Please log in.";
                            return View();
                        }
                        else // Reg NOK
                        {
                            TempData["isL"] = "n";
                            TempData["nok"] = "Registration was not possible. Please try again.";
                            var log = new Log()
                            {
                                Login = Login,
                                Date = saveNow.ToString("yyyy-MM-dd HHmmss"),
                                Description = "registr NOK"
                            };
                            var l1 = context.Logs.Add(log);
                            var result = context.SaveChanges();
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
