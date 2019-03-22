using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;




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
            

            Contact newContact = new Contact();
            newContact.UserName = Request.Form["Name"];
            newContact.Email = Request.Form["Email"];
            newContact.Subject = Request.Form["Subject"];
            newContact.Massage = Request.Form["Message"];
 




            ContactDal cdal = new ContactDal();
            cdal.contacts.Add(newContact);
            cdal.SaveChanges();
        

            return View("Index", newContact);

           
        }


    }
}