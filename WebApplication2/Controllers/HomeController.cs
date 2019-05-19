using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
using System.Data.Entity.Validation;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();//
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


        public ActionResult DeleteAccountCompleteMassage()
        {
            return View();
        }


    }
}