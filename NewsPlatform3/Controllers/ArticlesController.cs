using Microsoft.AspNetCore.Mvc;
using NewsPlatform3.Models;

namespace NewsPlatform3.Controllers
{
    public class ArticlesController : Controller
    {
        public List<Article> articles;
        public ArticlesController() {
            using (var context = new DbNewsContext())
            {
                articles = context.Articles.ToList();
            }
        }

        public IActionResult GetArticle(int id)
        {

            TempData["PositivityIndex"] = PositivityIndex(articles[id-1]);
            if (LoginController.thisLogin.isL)  // Login OK
            {
                TempData["isL"] = "y";
                TempData["login"] = LoginController.thisLogin.username;
                TempData["level"] = LoginController.thisLogin.level;
                TempData["nok"] = "";
                return View(articles[id-1]);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult GetListArticle()
        {
            
            if (LoginController.thisLogin.isL)  // Login OK
            {
                TempData["isL"] = "y";
                TempData["login"] = LoginController.thisLogin.username;
                TempData["level"] = LoginController.thisLogin.level;
                TempData["nok"] = "";
               
                return View(articles);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        private int PositivityIndex(Article article)
        {
            string[] _negativeWords = { "worst", "bad", "unfamiliar", "unhappy" };
            string[] _positiveWords = { "win", "won"};
            int _positivityIndex = 0;

            foreach (string word in _negativeWords)
            {
                if (article.Title.Contains(word))
                {
                    _positivityIndex--;
                }
                if (article.Content.Contains(word))
                {
                    _positivityIndex--;
                }
            }

            foreach (string word in _positiveWords)
            {
                if (article.Title.Contains(word))
                {
                    _positivityIndex++;
                }
                if (article.Content.Contains(word))
                {
                    _positivityIndex++;
                }
            }

            return _positivityIndex;
        }
    }
}
