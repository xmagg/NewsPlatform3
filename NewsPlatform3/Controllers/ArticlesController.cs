using Microsoft.AspNetCore.Mvc;
using NewsPlatform3.Models;

namespace NewsPlatform3.Controllers
{
    public class ArticlesController : Controller
    {

        public IActionResult GetArticle(int id)
        {
            var articles = new List<Article>()
            {
                new Article()
                {
                    Id = 0,
                    Title = "Are Bayern Munich heading towards their worst season for over a decade?",
                    Content = "Yet Bayern Munich find themselves on unfamiliar ground, 10 points adrift of Bundesliga leaders Bayer Leverkusen, as they chase a 12th consecutive German title. Outgoing manager Thomas Tuchel has reportedly singled out dissenting stars in what appears an unhappy dressing room and a second-leg rescue act will be required to advance past Lazio in the last 16 of the Champions League on Tuesday. The Bavarians also began the campaign with a German Super Cup defeat and were embarrassingly knocked out of the German Cup by third-tier Saarbrucken in November. And, in February, their Germany midfielder Leon Goretzka described the current campaign as being like \"a horror movie that won't end\". So are Germany's biggest club heading for their worst season for over a decade or is this a blip they can recover from? The statistics suggest that Bayern's domestic invincibility is about to come to an end. No team has ever made up a 10-point deficit to claim the German league title and it is a gap that, if anything, only appears to be widening, with Bayern having won only one of their past four matches. Bayern have averaged almost one loss in every four games (11 of 46) under Tuchel and recently slipped to defeat in three successive matches in all competitions for the first time in almost nine years. Tuchel's record of losing 24% of his matches as Bayern boss is also the worst percentage since Soren Lerby was at the helm (1991-92), with the Dane seeing his side defeated in 41% of his fixtures in charge.\r\nFormer Chelsea and Borussia Dortmund boss Tuchel also has the lowest win percentage (63%) since Louis van Gaal (2009-11) presided over team affairs and managed 61%. Under the 50-year-old, Bayern have also lost five and won one just once in knockout matches - an ominous sign before Tuesday's second leg with Lazio."

                },
                new Article()
                {
                    Id = 1,
                    Title = "Paul Tierney not selected as referee in next round of Premier League matches.",
                    Content = "However, he will be the video assistant referee (VAR) for Arsenal's home game with Brentford on Saturday. Tierney stopped play for a head injury to Reds defender Ibrahima Konate when Forest had possession in added time. He restarted play by giving Liverpool goalkeeper Caoimhin Kelleher the ball and Darwin Nunez scored moments later. The goal gave the visitors a 1-0 victory and came in the 99th minute - one minute and 50 seconds after the restart incident. International Football Association Board rules state the game should have restarted with Forest possession from where they had the ball outside the box. The decision did not lead directly to the goal, however, with Forest regaining possession before Nunez eventually scored the winner. Forest players and staff surrounded Tierney after full-time and coach Steven Reid was shown a red card. The City Ground club's owner Evangelos Marinakis also pursued the officials all the way to the referee's office."

                },
                new Article()
                {
                    Id = 2,
                    Title = "Jemma Reekie wins 800m silver after recovering from ‘a horrible place’.",
                    Content = "The nearly woman of British athletics finally has a medal around her neck. But while it wasn’t the colour Jemma Reekie had long wanted, it at least carried a silver lining. Afterwards the 25-year-old Scot talked bravely about how physically and mentally broken she had felt last year, due to a debilitating bout of glandular fever and a split from her coach Andy Young. And while she had no answer in the 800m final to the blistering finish of Ethiopian Tsige Duguma, she at least could reflect on how far she had come. “I have kept it quiet, but I was in a horrible place,” she said. “So, if you had told me 12 months ago, I would walk away with a silver, I’d have been very happy. It has been an emotional year,” she added. “A lot of people don’t see behind the scenes of what wobbles I have had, even the past few weeks, the tough times. It’s taken an army to get me back to where I am today and I can’t thank them enough.” Reekie had been the hot favourite going into the world indoor championships in Glasgow but it turned into a tactical race, where the athletes went through halfway in a dawdling 63.30sec. This played into the hands of Duguma, who used to be a 400m runner, and she flew home in 2:01:90, with Reekie nearly three-quarters of a second back. “We’ve got to put a smile on and be happy,” Reekie said. “I made some big mistakes but it’s another lesson learned.”"

                },
            };

            TempData["PositivityIndex"] = PositivityIndex(articles[id]);

            return View(articles[id]);
        }

        public IActionResult GetListArticle()
        {
            var articles = new List<Article>()
            {
                new Article()
                {
                    Id = 0,
                    Title = "Are Bayern Munich heading towards their worst season for over a decade?",
                    Content = "Yet Bayern Munich find themselves on unfamiliar ground, 10 points adrift of Bundesliga leaders Bayer Leverkusen, as they chase a 12th consecutive German title. Outgoing manager Thomas Tuchel has reportedly singled out dissenting stars in what appears an unhappy dressing room and a second-leg rescue act will be required to advance past Lazio in the last 16 of the Champions League on Tuesday. The Bavarians also began the campaign with a German Super Cup defeat and were embarrassingly knocked out of the German Cup by third-tier Saarbrucken in November. And, in February, their Germany midfielder Leon Goretzka described the current campaign as being like \"a horror movie that won't end\". So are Germany's biggest club heading for their worst season for over a decade or is this a blip they can recover from? The statistics suggest that Bayern's domestic invincibility is about to come to an end. No team has ever made up a 10-point deficit to claim the German league title and it is a gap that, if anything, only appears to be widening, with Bayern having won only one of their past four matches. Bayern have averaged almost one loss in every four games (11 of 46) under Tuchel and recently slipped to defeat in three successive matches in all competitions for the first time in almost nine years. Tuchel's record of losing 24% of his matches as Bayern boss is also the worst percentage since Soren Lerby was at the helm (1991-92), with the Dane seeing his side defeated in 41% of his fixtures in charge.\r\nFormer Chelsea and Borussia Dortmund boss Tuchel also has the lowest win percentage (63%) since Louis van Gaal (2009-11) presided over team affairs and managed 61%. Under the 50-year-old, Bayern have also lost five and won one just once in knockout matches - an ominous sign before Tuesday's second leg with Lazio."

                },
                new Article()
                {
                    Id = 1,
                    Title = "Paul Tierney not selected as referee in next round of Premier League matches.",
                    Content = "However, he will be the video assistant referee (VAR) for Arsenal's home game with Brentford on Saturday. Tierney stopped play for a head injury to Reds defender Ibrahima Konate when Forest had possession in added time. He restarted play by giving Liverpool goalkeeper Caoimhin Kelleher the ball and Darwin Nunez scored moments later. The goal gave the visitors a 1-0 victory and came in the 99th minute - one minute and 50 seconds after the restart incident. International Football Association Board rules state the game should have restarted with Forest possession from where they had the ball outside the box. The decision did not lead directly to the goal, however, with Forest regaining possession before Nunez eventually scored the winner. Forest players and staff surrounded Tierney after full-time and coach Steven Reid was shown a red card. The City Ground club's owner Evangelos Marinakis also pursued the officials all the way to the referee's office."

                },
                new Article()
                {
                    Id = 2,
                    Title = "Jemma Reekie wins 800m silver after recovering from ‘a horrible place’.",
                    Content = "The nearly woman of British athletics finally has a medal around her neck. But while it wasn’t the colour Jemma Reekie had long wanted, it at least carried a silver lining. Afterwards the 25-year-old Scot talked bravely about how physically and mentally broken she had felt last year, due to a debilitating bout of glandular fever and a split from her coach Andy Young. And while she had no answer in the 800m final to the blistering finish of Ethiopian Tsige Duguma, she at least could reflect on how far she had come. “I have kept it quiet, but I was in a horrible place,” she said. “So, if you had told me 12 months ago, I would walk away with a silver, I’d have been very happy. It has been an emotional year,” she added. “A lot of people don’t see behind the scenes of what wobbles I have had, even the past few weeks, the tough times. It’s taken an army to get me back to where I am today and I can’t thank them enough.” Reekie had been the hot favourite going into the world indoor championships in Glasgow but it turned into a tactical race, where the athletes went through halfway in a dawdling 63.30sec. This played into the hands of Duguma, who used to be a 400m runner, and she flew home in 2:01:90, with Reekie nearly three-quarters of a second back. “We’ve got to put a smile on and be happy,” Reekie said. “I made some big mistakes but it’s another lesson learned.”"

                },
            };

            return View(articles);
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
