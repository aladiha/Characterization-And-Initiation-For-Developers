using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
//kk
namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {

            return View();
        }

        public ActionResult Submit()
        {
            User newUser = new User();
            newUser.UserName = Request.Form["usrnm"];
            newUser.Email = Request.Form["email"];
            newUser.Password = Request.Form["psw"];

            UserDal udal = new UserDal();
            udal.users.Add(newUser);
            udal.SaveChanges();

            return View("User", newUser);
        }

    }
}