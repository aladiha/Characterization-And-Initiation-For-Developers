using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

enum WebSecurty { Arachni = 1, Grabber, IronWasp, Nogotofail, SonarQube, SQLMap, W3af ,Wapiti,Wfuzz,ZedAttackProxy};
enum AndroidSecurty { Sat, Sun, Mon, Tue, Wed, Thu, Fri };
enum IosSecurty { Sat, Sun, Mon, Tue, Wed, Thu, Fri };

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
            TempData["Platform"] = ba;
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

            // Auto Filling of datasecury devends on key of platform of project
            String platform = TempData["Platform"].ToString();
            if(platform.Equals("Web"))
            {
                Random random = new Random();
                int generaterandom = random.Next(1,11);  // randrom form 1 to 10.
                List<String> Inputs = new List<String>();

                switch (generaterandom)
                {

                    case (int)WebSecurty.Wapiti:
                        {
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");

                            return View();
                        }

                    case (int)WebSecurty.Wfuzz:
                        {
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");

                            return View();
                        }
                    case (int)WebSecurty.ZedAttackProxy:
                        {
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");
                            Inputs.Add("");

                            return View();
                        }
                }
            }
            else if(platform.Equals("Ios"))
            {

            }
            else
            {

            }

            return View();
        }
        public ActionResult AutoFillDataSecurty()
        {
            return View();
        }

    }
}