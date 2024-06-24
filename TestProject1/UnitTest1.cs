using NewsPlatform3;
using NewsPlatform3.Controllers;
using NewsPlatform3.Models;
using NUnit.Framework.Internal;

namespace TestProject1
{
    public class Test1
    {
        private User _user = new User();

        [SetUp]
        public void Setup()
        {
            using (var context = new DbNewsContext())
            {
                _user = context.Users.FirstOrDefault(u => u.Level == 0);
            }
        }

        [Test]
        public void adminTest()
        {
            Assert.AreEqual("admin", _user.Login);
        }
    }

    public class Test2
    {
        private LogoutController testController = new LogoutController();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void controllerTest()
        {
            
           Assert.AreEqual(null, testController.Response);
        }
    }
}