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
            TempData["PositivityIndex"] = PositivityIndex(articles[id]);
            if (LoginController.thisLogin.isL)  // Login OK
            {
                TempData["isL"] = "y";
                TempData["login"] = LoginController.thisLogin.username;
                TempData["level"] = LoginController.thisLogin.level;
                TempData["nok"] = "";
                TempData["artId"] = id;

                using (var context = new DbNewsContext())
                {
                    var comments = context.Comments.Where(c => c.IdArticle == articles[id].Id).OrderByDescending(c => c.Content).ToList();
 
                    TempData["CommQty"] = comments.Count;   // number of comments
                    int i = 0;
                    foreach(var comment in comments)
                    {
                        TempData["Comm" + i.ToString()] = comments[i++].Content;
                    }
                }
                return View(articles[id]);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DelArticle(int id)
        {
            using (var context = new DbNewsContext())
            {
                articles = context.Articles.ToList();
                context.Articles.Remove(articles[id]);
                var result = context.SaveChanges();
            }
            return RedirectToAction("GetListArticle", "Articles");
        }

        [HttpGet]
        public ActionResult AddArticle() 
        {
            if (LoginController.thisLogin.isL)  // Login OK
            {
                TempData["isL"] = "y";
                TempData["login"] = LoginController.thisLogin.username;
                TempData["level"] = LoginController.thisLogin.level;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddArticle(string title, string content)
        {
            if (title == null || content == null)
            {
                TempData["nok"] = "Empty title or content is not allowed!";
                return View();
            }
            else
            { 
                using (var context = new DbNewsContext())
                {
                    var article = new Article()
                    {
                        Title = title,
                        Content = content
                    };
                    context.Articles.Add(article);
                    var result = context.SaveChanges();
                }
            return RedirectToAction("GetListArticle", "Articles");
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

        [HttpPost]
        public IActionResult AddComment(string yourComment)
        {
            DateTime saveNow = DateTime.Now;
            using (var context = new DbNewsContext())
            {
                var comment = new Comment()
                {
                    IdArticle = (int)TempData["ArticleID"],
                    IdUser = LoginController.thisLogin.Guid,
                    Content = saveNow.ToString("yyyy-MM-dd HH:mm") + " - " + LoginController.thisLogin.username + " - " + yourComment
                };
                var c1 = context.Comments.Add(comment);
                var result = context.SaveChanges();
            }
            return RedirectToAction("GetArticle", "Articles", new { id = TempData["artId"] });
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
