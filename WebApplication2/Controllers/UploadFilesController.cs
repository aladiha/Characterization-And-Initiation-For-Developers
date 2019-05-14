using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UploadFilesController : Controller
    {
        // GET: UploadFiles
        public ActionResult UploadPage()
        {
            return View();
        }

        private bool CheckFileType(string type)
        {
            return type.Equals("ProjectFiles");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase insertfile)
        {
            return View();
        }
    }
}