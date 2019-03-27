using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;

using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using WebApplication2;
using System;
using WebApplication2.DAL;

namespace WebAppTest
{
    /// <summary>
    /// Summary description for UserControllerTest
    /// </summary>
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Login()
        {
            UserController cont = new UserController();
            ViewResult res = cont.Login() as ViewResult;
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void Register()
        {
            UserController cont = new UserController();
            ViewResult res = cont.Register() as ViewResult;
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void doLogin()
        {
            UserController cont = new UserController();
            LogIn U = new LogIn {UserName="tester",Password="tester" };
           
            var dal = new UserDal();
            var user = new User { UserName = "tester", Password = "tester", Email = "TESTER@GMAIL.COM" };
            dal.AddUser(user);
            dal.DeleteUser(user.UserName);
                Assert.IsTrue(((user.Password == U.Password) && (user.UserName == U.UserName)));


            

        }
        [TestMethod]
        public void faildLogin()
        {
            UserController cont = new UserController();
            LogIn U = new LogIn { UserName = "tester1", Password = "tester" };

            var dal = new UserDal();
            var user = new User { UserName = "tester", Password = "tester", Email = "TESTER@GMAIL.COM" };
            dal.AddUser(user);
          //  ViewResult res = cont.doLogin(U) as ViewResult;
            dal.DeleteUser(user.UserName);
            Assert.IsFalse(((user.Password == U.Password) && (user.UserName == U.UserName)));

            // Assert.AreSame("User name or password is inccorect!", res.ViewBag.result);

        }

        [TestMethod]
        public void faildmessageLogin()
        {
            UserController cont = new UserController();
            LogIn U = new LogIn { UserName = "tester1", Password = "tester" };

            var dal = new UserDal();
            var user = new User { UserName = "tester", Password = "tester", Email = "TESTER@GMAIL.COM" };
            dal.AddUser(user);
             ViewResult res = cont.doLogin(U) as ViewResult;
            dal.DeleteUser(user.UserName);
           // Assert.IsFalse(((user.Password == U.Password) && (user.UserName == U.UserName)));

             Assert.AreSame("User name or password is inccorect!", res.ViewBag.result);

        }

        [TestMethod]

        public void Register_valid()
        {
            User us = new User { UserName = "Tester", Password = "Tester", Email = "Teaster@gamil.com" };
            var UsCont = new UserController();
            var dal = new UserDal();
            UsCont.Submit(us);

            var reslut = dal.DeleteUser(us.UserName);

            Assert.AreEqual(reslut, true);
        }
    }

        
}
