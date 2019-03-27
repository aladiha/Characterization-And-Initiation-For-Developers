using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;

namespace UnitTest
{
    [TestClass]
    public class TestHomeController
    {
        [TestMethod]
        public void TestIndexAction()
        {
            var cont = new HomeController();
            var result = cont.Index as ViewIndex;
        }
    }
}
