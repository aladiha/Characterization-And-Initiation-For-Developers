using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;

namespace WebApplication2.Controllers
{
    public class MangeProjectController : Controller
    {
        // GET: MangeProject
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartCreating()
        {
            return View();
        }



        public ActionResult CheckRadio(FormCollection frm)
        {
            String[] choises = new string[35];
            for (int i = 1; i < 36; i++) {
                choises[i - 1] = frm["g" + i.ToString()].ToString();
                Console.WriteLine("{0}", choises[i - 1]);
            }

            return View();
        }
        public ActionResult EditPermistions()
        {
            string projectid = Request.QueryString.Get("projectid");

            return View();
        }


      
    



    }
}





