using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using System.IO;

enum WebSecurty {Wapiti=1,Wfuzz,ZedAttackProxy};
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
            Document doc = new Document(path);
            int ProjectId= int.Parse(TempData["Idp"].ToString());
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.MoveToDocumentEnd();
            var dal = new ProjectsDal();
            var proj = dal.GetPrijectByPrjectId(ProjectId);
            String ProjectNameOwner = proj.UserName + "_" + proj.ProjectName;
            String dataDir = "C:/" + ProjectNameOwner + ".docx";

            // Word design
            builder.Font.NameBi = "David";
            builder.Font.Name = "David";
            builder.ParagraphFormat.Bidi = true;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Justify;

            // the qestions:

            builder.ListFormat.ApplyBulletDefault();
            builder.Font.SizeBi = 14;
            builder.Font.Size = 14;

            builder.Font.Underline = Underline.Single;
            builder.Font.Color = Color.Black;

            builder.Font.BoldBi = true;
            builder.Font.Bold = true;

            builder.Writeln("השתמשות בבסיס נתונים Data Base");

            builder.Font.Color = Color.Blue;

            builder.ListFormat.List = null;
            builder.Font.Underline = Underline.None;

            builder.Font.Size = 12;
            builder.Font.SizeBi = 12;

            builder.Font.BoldBi = false;
            builder.Font.Bold = false;

        

            switch (submit)
            {
               
                case "SQLite":
                    builder.Writeln("SQLite DataBase");
                    builder.Writeln("No dependencies, is included with Android and iOS");
                    builder.Writeln("Developers can define exactly the data schema they want");
                    builder.Writeln("Developers have full control, e.g. handwritten SQL queries");
                    builder.Writeln("Debuggable data: developers can grab the database file and analyze it");
                    break;
                case "MySql":
                    builder.Writeln("MySql DataBase");
                    builder.Writeln("MySQL is the #1 open source database for Web-based applications, used by Facebook, Twitter, YouTube and virtually all the largest Web properties and successful startups. In this white paper, we will help you better understand how MySQL can help you drive digital transformation initiatives delivering modern Web, mobile and Cloud-based applications.");
                    break;

                case "Realm":

                    builder.Writeln("Realm DataBase");
                    builder.Writeln("provides results relatively faster than SQLite, and is much more performance minded.");
                    builder.Writeln("simple to use, thanks to it being an object database. By just creating a class that extends RealmObject class, you are all set.");
                    builder.Writeln("can  be used across platforms like iOS, Xamarin and React Native too.");
                    builder.Writeln("Easy creating and storing of data while on the move");
                    break;
                case "CoreData":
                    builder.Writeln("CoreData DataBase");
                    builder.Writeln("store contents of an object which is represented by a class in Objective-C.");
                    builder.Writeln("Fast in fetching records"); 
                    break;
                case "FireBase":
                    builder.Writeln("FireBase DataBase");
                    builder.Writeln(" Firebase provides fast, secure, static, and production-grade hosting for developers. It allows developers to efficiently deploy web apps and static content to a CDN(Content Delivery Network).");
                    break;
                case "Server":
                    builder.Writeln("Microsoft SQL Server Express DataBase");
                    builder.Writeln("The MS SQL server has built-in transparent data compression feature along with encryption. Users don’t need to modify programs in order to encrypt the data. The MS SQL server has access control coupled with efficient permission management tools. Further, it offers an enhanced performance when it comes to data collection.נתונים בבסיס השמשות");
                    break;
                case "Access":
                    builder.Writeln("Microsoft Access DataBase");
                    builder.Writeln("Convenient storage capacity – A Microsoft Access database can hold up to 2 GB of data.");
                    builder.Writeln("Multi-user support – About ten users in a network can use an Access application.");
                    builder.Writeln("Importing data — Microsoft Access makes it easy to import data.");
                    break;
                default:
                    throw new Exception();
                    
            }

            builder.Writeln();
            ViewBag.File = dataDir;
            string paths = Server.MapPath("~/Uploads/" + ProjectNameOwner + "/");
            if (!Directory.Exists(paths))
            {
                Directory.CreateDirectory(paths);
            }
            doc.Save(paths + ProjectNameOwner + ".docx");

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

            return View();//
        }
        public ActionResult AutoFillDataSecurty()
        {
            return View();
        }

    }
}