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
            Contact newContact = new Contact();//aaaaaaaaaa
            newContact.Name = Request.Form["Name"];
            newContact.Subject = Request.Form["Subject"];
            newContact.Message = Request.Form["Message"];
 




            ContactDal cdal = new ContactDal();
            cdal.contacts.Add(newContact);
          

                try
                { 

                cdal.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }


            return View("Index", newContact);

           
        }


    }
}