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

            return View(new ChangePassword());
        }
        public ActionResult Update_Password(ChangePassword cs)
        {
            if (ModelState.IsValid)
            {
                var dal = new UserDal();
                bool res = false; ;

                if (cs.newPassword.Equals(cs.varifynewPassword))
                {
                    res = dal.UpdatePassword(Session["UserId"].ToString(), cs);
                    if(res==false)

                    {
                        TempData["Message"] =  "Wrong old password\n";
                        return View("ChangePassword",cs);
                    }
                    return View("ChangedPasswordDone");
                }
                else
                {
                    TempData["Message"] = "New password not matched with ReEntered password\n";
                    return View("ChangePassword",cs);
                }
            }


            return View("ChangePassword", cs);
        }


        public ActionResult DeleteAccount()
        {
            return View();
        }
        public ActionResult Delete_Account()
        {
            
            string VafifiyPassword= Request.Form["VarifiyPassword"];
            var usdal = new UserDal();
            
            if(usdal.VarifyPassword(Session["UserId"].ToString(),VafifiyPassword))
            {
                usdal.DeleteUser(Session["UserId"].ToString());
                Session["UserId"] = "";
                return RedirectToAction("DeleteAccountCompleteMassage", "Home");

            }
            else
            {
                TempData["CheckPass"]="Uncureect Password!";
                return RedirectToAction("DeleteAccount", "Login");
            }
        }


    }

}