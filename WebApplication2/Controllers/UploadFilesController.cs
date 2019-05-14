using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Upload(HttpPostedFileBase postedFile)
        {
            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(path + fileName);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }

            return View();
        }
    }
}