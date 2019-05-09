using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Words;


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
                choises[i-1] = frm["g"+i.ToString()].ToString();
                Console.WriteLine("{0}",choises[i - 1]);
            }
            

            // Initialize a Document.
            Document doc = new Document();

            // Use a document builder to add content to the document.
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.Writeln("Hello World!");

            String dataDir = "C:/haha.docx";
            // Save the document to disk.
            doc.Save(dataDir);
            return View();
        }

        public ActionResult EditPermistions()
        {
            string projectid = Request.QueryString.Get("projectid");

            return View();
        }

        public ActionResult DeleteProject()
        {
            string projectname = Request.QueryString.Get("Pname");
            string Username = Request.QueryString.Get("Mname");

            return View();
        }
    }
}