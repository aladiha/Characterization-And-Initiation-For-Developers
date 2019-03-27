using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2;
using System;

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

        

    }

}
