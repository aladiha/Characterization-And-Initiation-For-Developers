using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2;
using System;

namespace UnitTestProject
{
    [test]
    public class TestHomeController
    {
        [TestMethod]
        public void IndexTest()
        {
            var cont = new HomeController();
            var res = cont.Index() as ViewResult;
            Assert.IsNotNull(cont);
        }

        [TestMethod]
        public void TestPrivacyAction()
        {
            HomeController cont = new HomeController();
            ViewResult res = cont.Privacy() as ViewResult;
            Assert.IsNotNull(res);
        }
    }
}

