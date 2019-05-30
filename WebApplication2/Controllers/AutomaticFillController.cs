using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class AutomaticFillController : Controller
    {
        // GET: AutomaticFill
        public ActionResult Start()
        {
           
            return View();
        }


        public ActionResult GetChoise(FormCollection frm)
        {
            string ba;
            ba=frm["App"].ToString();

            if (ba == "Ios")
                return View("Ios");
            else if (ba == "Web")
                return View("Web");
            else
                return View("Android");
        }

        public ActionResult Database(string submit)
        {
            String path = TempData["pa"].ToString();
            switch (submit)
            {
               
                case "SQLite":
                    Console.WriteLine("1");
                    break;
                case "Mysql":
                    Console.WriteLine("1");
                    // Do something
                    break;
                case "Realm":
                    Console.WriteLine("1");
                    // Do something
                    break;
                case "CoreData":
                    Console.WriteLine("1");
                    // Do something
                    break;
                case "FireBase":
                    Console.WriteLine("1");
                    // Do something
                    break;
                case "Server":
                    Console.WriteLine("1");
                    // Do something
                    break;
                case "Access":
                    Console.WriteLine("1");
                    // Do something
                    break;
                default:
                    throw new Exception();
                    
            }
            return View();
        }

    }
}