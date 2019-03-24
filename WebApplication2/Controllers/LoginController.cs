using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
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
            return View();
        }

        public ActionResult Submit()
        {

            Contact newContact = new Contact();

            newContact.name = Request.Form["name"];
            newContact.subject = Request.Form["subject"];
            newContact.massage = Request.Form["massage"];


            ContactDal cdal = new ContactDal();
            cdal.contacts.Add(newContact);
            cdal.SaveChanges();



            return View("Thanks");
        }


        //[Authorize(Roles = "user")]
        //[Authorize()]
        //show the user or admin page after he logged in  
        public ActionResult Look()
        {
            return View();
        }

        public ActionResult Profile()
        {

            return View();
        }

        public ActionResult ChangePassword()
        {

            return View();
        }

        public ActionResult DeleteAccount()
        {

            return View();
        }


    }

}