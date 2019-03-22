using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
using WebApplication2.ModelBinders;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit([ModelBinder(typeof(UserBinder))] User user) { 

            UserDal udal = new UserDal();
            udal.users.Add(user);
            udal.SaveChanges();

            return View("User", user);
        }
    }
}