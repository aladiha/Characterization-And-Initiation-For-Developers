using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}