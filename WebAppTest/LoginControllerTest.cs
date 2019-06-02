using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
using WebApplication2;
using System;
namespace WebAppTest
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void TestLoginPrivacy()
        {
            var loginPv = new LoginController();
            ViewResult res = loginPv.Privacy() as ViewResult;
            Assert.AreEqual("Your application description page.", loginPv.ViewBag.Message);
        }


        [TestMethod]
        public void Change_Password_not_matched()
        {
            var ch = new ChangePassword { newPassword = "123456", oldPassword = "123456", varifynewPassword = "65954654" };
            var log = new LoginController();

            var res = log.Update_Password(ch) as ViewResult;

            Assert.AreEqual(log.TempData["Message"], "New password not matched with ReEntered password\n");
        }


        [TestMethod]
        public void ChangePassword_Succeffully_Sunc_with_DataBase()
        {
            var dal = new UserDal();
            var ch = new ChangePassword { newPassword = "123456", oldPassword = "Tester", varifynewPassword = "123456" };
            var user = new User { UserName = "Tester", Password = "Tester", Email = "Tester@gmail.com" };
            var log = new LoginController();


            var x=dal.AddUser(user);

            dal.UpdatePassword(user.UserName, ch);
            var newuser = dal.GetUserByUserName(user.UserName);
            dal.DeleteUser(user.UserName);

            Assert.AreEqual(newuser[0].Password, ch.newPassword);

        }


        [TestMethod]
        public void DeleteAccount_Testing()
        {
            var dal = new UserDal();
            var user = new User { UserName = "Tester", Password = "Tester", Email = "Tester@gmail.com" };

            dal.AddUser(user);

            var result = dal.DeleteUser(user.UserName);
            Assert.AreEqual(result, true);
        }


        [TestMethod]
        public void Login_Contact()
        {
            var log = new LoginController();
            var x = log.Contact() as ViewResult;

            Assert.IsNotNull(x);
        }
    }
}
