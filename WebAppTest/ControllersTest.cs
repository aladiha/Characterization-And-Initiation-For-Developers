using WebApplication2.Controllers;
using System.Web.Mvc;

namespace WebAppTest
{
    [TestClass]
    public class ControllersTest
    {
        
        [TestMethod]
        public void TestIndexAction()
        {
            HomeController cont = new HomeController();
            ViewResult res = cont.Index() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestPrivacyAction()
        {
            HomeController cont = new HomeController();
            ViewResult res = cont.Privacy() as ViewResult;
            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void TestDeleteAccountCompleteMassageAction()
        {
            HomeController cont = new HomeController();
            ViewResult res = cont.DeleteAccountCompleteMassage() as ViewResult;
            Assert.IsNotNull(res);
        }

        //[TestMethod]
      //  public void TestDeleteAccountCompleteMassageActi

    }

}
