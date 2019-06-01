﻿using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using System.IO;
using Google.Apis.Customsearch;

enum WebSecurty {ParrotSecurity=1,ZedAttackProxy, Cisco };
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
        public ActionResult GetChoise1(FormCollection frm)
        {
            string ba;
            ba = frm["App1"].ToString();
            String path = TempData["pa2"].ToString();
            Document doc = new Document(path);
            int ProjectId = int.Parse(TempData["al"].ToString());
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

            builder.Writeln("תיחום חיצוני, משתמשים, מערכות משיקות");

            builder.Font.Color = Color.Blue;

            builder.ListFormat.List = null;
            builder.Font.Underline = Underline.None;

            builder.Font.Size = 12;
            builder.Font.SizeBi = 12;

            builder.Font.BoldBi = false;
            builder.Font.Bold = false;

            if (ba == "Gaming")
            {
                builder.Writeln();
                builder.Writeln("Our Users ages are not specific");
                builder.Writeln();
                builder.Writeln("gaming users and profit encrease as the time pass:");
                builder.Writeln();
                Image image = Image.FromFile(Server.MapPath("~/img/gaming2.png"));
                builder.InsertImage(image);
                builder.Writeln();
                builder.Writeln();
                builder.Writeln("Statistics involve our App:");
                builder.Writeln();
                image = Image.FromFile(Server.MapPath("~/img/gaming.jpg"));
                builder.InsertImage(image);

            }
            else if (ba == "Social")
            {
                builder.Writeln();
                builder.Writeln("Our Users ages are 13+");
                builder.Writeln();
                builder.Writeln("Social Media users encrease as the time pass:");
                builder.Writeln();
                Image image = Image.FromFile(Server.MapPath("~/img/social2.png"));
                builder.InsertImage(image);
                builder.Writeln();
                builder.Writeln();
                builder.Writeln("Statistics involve our App:");
                builder.Writeln();
                image = Image.FromFile(Server.MapPath("~/img/social.jpg"));
                builder.InsertImage(image);
            }
            else {
                builder.Writeln();
                builder.Writeln("Our Users ages are 8+");
                builder.Writeln();
                builder.Writeln("for example wechat messaging application users encrease as the time pass:");
                builder.Writeln();
                Image image = Image.FromFile(Server.MapPath("~/img/mess.png"));
                builder.InsertImage(image);
                builder.Writeln();
                builder.Writeln();
                builder.Writeln("Statistics involve our App:");
                builder.Writeln();
                image = Image.FromFile(Server.MapPath("~/img/messeging.png"));
                builder.InsertImage(image);

            }
            builder.Writeln();
            ViewBag.File = dataDir;
            string paths = Server.MapPath("~/Uploads/" + ProjectNameOwner + "/");
            if (!Directory.Exists(paths))
            {
                Directory.CreateDirectory(paths);
            }
            doc.Save(paths + ProjectNameOwner + ".docx");
            return View();
        }


        public ActionResult Database(string submit)
        {
            String path = TempData["pa"].ToString();
            TempData["pa2"] = path;
            Document doc = new Document(path);
            String al = TempData["Idp"].ToString();
            int ProjectId= int.Parse(al);
            TempData["al"] = al;
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


            builder.ListFormat.ApplyBulletDefault();
            builder.Font.SizeBi = 14;
            builder.Font.Size = 14;

            builder.Font.Underline = Underline.Single;
            builder.Font.Color = Color.Black;

            builder.Font.BoldBi = true;
            builder.Font.Bold = true;

            builder.Writeln("אבטחת מידע");

            builder.Font.Underline = Underline.None;

            builder.Font.Size = 12;
            builder.Font.SizeBi = 12;

            builder.Font.BoldBi = false;
            builder.Font.Bold = false;

            List<String> Part1 = new List<String>();
            List<String> Part2 = new List<String>();
            List<String> Part3 = new List<String>();

            if(TempData["Is3ske"].ToString()!=null)
                Part3.Add("בגלל שהפרויקט הוא פרויקט עסקי - כלומר אפשרי דרכו לקבל כסף , אז התוקף יכול לפרוץ חשבון של משתמשים ולקבל את הפרטים שלהם ");
            Part3.Add("Phishing - כלומק שליחת מייל המשתמש כאילנו אנחנו החברה או האחראים על האפליקצייה/אתר שבתוך ההודעה מתבקש להכביס את הפרטים שלו בכדי לגנוב אותם.");

            if (platform.Equals("Web"))
            {
                Random random = new Random();
                int generaterandom = random.Next(1,4);  // randrom form 1 to 3.

                switch (generaterandom)
                {

                    case (int)WebSecurty.ParrotSecurity:
                        Part1.Add("פארוט סקיוריטי-Parrot Security");


                        Part2.Add("המיועדת לבדיקות חדירה ופגיעויות, לגלישה אנונימית ולזיהוי פלילי דיגיטלי.");
                        Part2.Add("הוא כולל ארסנל נייד מלא עבור אבטחת IT וניתוח פלילי דיגיטלי, אבל זה כולל גם את כל מה שאתה צריך כדי לפתח תוכניות משלך או להגן על הפרטיות שלך תוך גלישה באינטרנט.");

                        break;
                    

                    case (int)WebSecurty.ZedAttackProxy:
                        Part1.Add("Zed Attack Proxy(ZAP)");

                        Part2.Add("Active Scan-כללי סריקה התוקפים את הרשת");
                        Part2.Add("Alerts - אזהרות לגבי פגיעויות העשויות להימצא באתר ודרגת החומרה שלהן.");


                        break;

                    default:
                            break;

                      
                }
                Part3.Add("פרצות אבטחה – באגים במערכות הפעלה ובתוכנות אשר עלולות להיות מנוצלות על ידי פורצים. כשפגיעות כזו מתפרסמת, מתחיל מרוץ נגד השעון: ההאקרים מפתחים פיסות קוד שמטרתן לחדור דרכה (נוצלות – Exploits), בעוד המתכנתים מנסים להפיץ תיקון כדי לסגור את פרצת האבטחה.");
                Part3.Add("SQL Injection Attack - זריקת קוד זדוני לשרת כדי לגשת לתאך מאגר הנתונים");

                Part3.Add("MITM - התוקף/הפורץ הירה את הבאקיטים העוברים בין השרת למשתמש והוא יכול לעשות את התקפת MITM כדי לקחת את הנתונים הללו.");


            }
            else if(platform.Equals("Ios"))
            {

            }
            else
            {

            }


            builder.Writeln("סיכוני אבטחת מידע:");


            foreach (var x in Part3)
                builder.Writeln(x);


            // fill sesion

            builder.Writeln("אמצעי אבחטת מידע:");

            foreach (var x in Part1)
                builder.Writeln(x);


            // fill sesion
            builder.Writeln("ניהול אבטחת המידע:");

            foreach (var x in Part2)
                builder.Writeln(x);

            // fill sesion



            ViewBag.File = dataDir;

            paths = Server.MapPath("~/Uploads/" + ProjectNameOwner + "/");
            if (!Directory.Exists(paths))
            {
                Directory.CreateDirectory(paths);
            }
            doc.Save(paths + ProjectNameOwner + ".docx");

            return View();//
        }
        public ActionResult AutoFillDataSecurty()
        {
            return View();
        }

    }
}