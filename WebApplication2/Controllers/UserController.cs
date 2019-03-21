using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
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
            
           

            return View("User",newUser);
        }

    }
}