using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(LogIn Log)
        {
            //   LogInDal login = new LogInDal();
            //RegisterDal req = new RegisterDal();
            string userName = Request.Form["username"];
            string password = Request.Form["password"];
            //LogIn log = CheckLogIn(userName, password, login.loglst.ToList<LogIn>());
            //Register reg = CheckUser(userName, password, req.Registerlst.ToList<Register>());
            //if (log != null)
            //{
            //    Vmdata vmdata = new Vmdata();
            //    RegisterDal registerDal = new RegisterDal();
            //    LogInDal logInDal = new LogInDal();
            //    vmdata.registersList = registerDal.Registerlst.ToList<Register>();
            //    vmdata.loginList = logInDal.loglst.ToList<LogIn>();

            //    Session["username"] = log.UserName;
            //    Session["roll"] = "Admin";
            //    return View("../Manager/profile", vmdata);
            //}
            //else if (reg != null)
            //{
            //    Session["username"] = reg.Email;
            //    Session["roll"] = "User";
            //    return View("../Manager/profileuser");
            //}


            //return View(log);
            return View();
        }
    }
}