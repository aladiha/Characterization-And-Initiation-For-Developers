using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using Aspose.Words;
using System.IO;
using System.Web.Routing;
using System.Drawing;
//



namespace WebApplication2.Controllers

{
    public class MangeProjectController : Controller

    {
        // GET: MangeProject
        private static int ProjectId;
        

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult firstPart()
        {
            string[] ss=new string[50];





            ProjectId = int.Parse(Request.QueryString.Get("projectid"));
            
            return View();
        }

        [HttpPost]
        public ActionResult Next()
        {
           
            Document doc = new Document();


            DocumentBuilder builder = new DocumentBuilder(doc);
            var dal = new ProjectsDal();
            var proj = dal.GetPrijectByPrjectId(ProjectId);


            String ProjectNameNOwner = proj.UserName + "_" + proj.ProjectName;


            List<String> ques = new List<String>();
            int i = 1;
            while (true)
            {
                if (Request.Form["i" + i.ToString()] != null)
                    ques.Add(Request.Form["i" + i.ToString()]);
                else
                    break;
                i++;
            }

            List<string> consff = new List<string>();
            consff.Add("לקוח\\מומחה יישום" + "^" + "" + "לקוח \\ משתמש עיקרי" + "@" + "מומחה(י) היישום" + "@" + "צוותי משתמשים");
            consff.Add("יעדים ומטרות" + "^" + "יעדים כלליים" + "@" + "מטרות מעשיות" + "@" + "מטרות עתידיות");
            consff.Add("בעיות" + "^" + "תמצית הבעיות במצב הקיים" + "@" + "בעיות שהמערכת פותרת/אמורה לפתור" + "@" + "בעיות שהמערכת יוצרת/עשויה ליצור" + "@" + "בעיות שיידחו");
            consff.Add("מאפיינים כלליים" + "^" + "מצב קיים" + "@" + "אופי המערכת וסוגה" + "@" + "אילוצים" + "@" + "מילון מונחים");
            consff.Add("תיחום פנימי" + "^" + "יאור כללי של המערכת" + "@" + "תתי-מערכת");
            consff.Add("תהליכים" + "^" + "שמות תהליכים" + "@" + "שמות תתי תהליכים");
            consff.Add("מודולים (תכניות)" + "^" + "תכניות מקור – SOURCE MODULES" + "@" + "תכניות ביצוע – EXECUTABLE MODULES");

            consff.Add("מהלכים (פרוצדורות במקרה)");
            consff.Add("מערכת הפעלה" + "^" + "בסיס הנתונים – DBMS" + "^" + "כלי פיתוח ותחזוקה");
            consff.Add("תוכנות מדף" + "^" + "תוכנות שירות" + "@" + "תוכנות יישום");
            consff.Add("כלי תפעול וייצור " + "^" + "כלים למפעיל ואחראי ייצור" + "@" + "כלי שליטה ובקרה למנהל המערכת");
            consff.Add("תקשורת" + "^" + "תקשורת פרטית מקומית" + "@" + "תקשורת פרטית רחבה" + "@" + "רשת ציבורית");
            consff.Add("נקודות פתוחות (וחליפות)");
            consff.Add("גורמים מעורבים" + "^" + "צוותים מקצועיים – צוותי הפיתוח" + "@" + "סיוע טכני" + "@" + "ספקים וגורמי חוץ");
            consff.Add("תכנית עבודה" + "^" + "שיטת הפיתוח" + "@" + "תכנית פיתוח כללית" + "@" + "תכנית פרטנית");

            consff.Add("שירות ותחזוקה" + "^" + "מרכז תמיכה) – HELPDESK (CALL CENTER" + "@" + "תחזוקת היישום" + "@" + "תחזוקת תשתית וטכנולוגיה" + "@" + "מימוש שוטף" + "@" + "עלויות שוטפות");
            consff.Add("השתלבות בארגון – הנעת המערכת" + "^" + "הטמעת המערכת" + "@" +  "הסבות(הגירה)"+ "@" + "או\"ש" + "@" + "מדריך למשתמש");
            consff.Add("חוסן ואמינות" + "^" + "תכנית בדיקה" + "@" + "זמינות ושרידות");

            builder.Font.NameBi="David";
            builder.Font.Name = "David";



            builder.ParagraphFormat.Bidi = true;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            builder.Font.SizeBi = 26;

            builder.Font.Bold = true;
            builder.Font.BoldBi = true;

            builder.Font.ItalicBi = true;
            builder.Font.Italic = true;
            builder.Writeln("מסמך איפיון וייזום");
            builder.Writeln();


            builder.Font.SizeBi = 18;
            builder.Font.Size = 18;
            builder.Font.ItalicBi = false;
            builder.Font.Italic = false;

            builder.Writeln(proj.ProjectName);
            builder.Writeln();
            builder.Writeln();

            builder.ParagraphFormat.Alignment = ParagraphAlignment.Justify;



            for (i = 0; i < consff.Count; i++)
            {


                
                string[] parser = consff[i].Split('^');
                string title = parser[0];

                builder.ListFormat.ApplyBulletDefault();
                builder.Font.SizeBi = 14;
                builder.Font.Size = 14;

                builder.Font.Underline = Underline.Single;
                builder.Font.Color = Color.Black;

                builder.Font.BoldBi = true;
                builder.Font.Bold = true;

                builder.Writeln(title);

                int l1;

                l1 = parser.Length;

                if (l1 == 2)
                {

                    string[] subtitle = parser[1].Split('@');

                    builder.ListFormat.ListIndent();

                    builder.Font.Underline = Underline.None;

                    builder.Font.Size = 12;
                    builder.Font.SizeBi = 12;

                    builder.Font.BoldBi = false;
                    builder.Font.Bold = false;

                    foreach (var x in subtitle)
                        builder.Writeln(x);
                    builder.ListFormat.ListOutdent();

                }
                else
                {
                    if (l1 != 1)
                    {
                        builder.Writeln(parser[1]);
                        builder.Writeln(parser[2]);
                    }
                }

                builder.Font.Color = Color.Blue;
                builder.ListFormat.List = null;
                
                builder.Font.Underline = Underline.None;

                builder.Font.Size = 12;
                builder.Font.SizeBi = 12;

                builder.Font.BoldBi = false;
                builder.Font.Bold = false;
                if(l1==2)
                {

                    String[] lines = ques[i].Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (var x in lines)
                    {
                            builder.Writeln("                     "+x + "                     ");
                    }

                }
                else
                {

                    String[] lines = ques[i].Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (var x in lines)
                    {
                        builder.Writeln("       "+x + "       ");
                    }

                }
                builder.Writeln();
            }
            //  doc.Save(dataDir);

            string path = Server.MapPath("~/Uploads/" + ProjectNameNOwner + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            doc.Save(path + ProjectNameNOwner + ".docx");
            TempData["doc"] = (path + ProjectNameNOwner + ".docx");
            return View("StartCreating");
        }

        public ActionResult StartCreating()
        {
            return View();
        }


        public ActionResult UploadPage()
        {
            ProjectId = int.Parse(Request.QueryString.Get("projectid"));

            return View();
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase postedFile)
        {
            var x = (new ProjectsDal()).GetPrijectByPrjectId(ProjectId);
            string path = Server.MapPath("~/Uploads/" + x.UserName+"_"+x.ProjectName + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var dir = new DirectoryInfo(path);

            FileInfo[] filename = dir.GetFiles("*.*");

            foreach (var ff in filename)
            {
                ff.Delete();
            }

            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(path + fileName);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }
            return View();
        }
        public FileResult Download()
        {
            ProjectId = int.Parse(Request.QueryString.Get("projectid"));

            var x = (new ProjectsDal()).GetPrijectByPrjectId(ProjectId);
            string path = Server.MapPath("~/Uploads/" + x.UserName + "_" + x.ProjectName + "/");

            var dir = new DirectoryInfo(path);

            FileInfo[] filename = dir.GetFiles("*.*");

            var FileVirtualPath = path + filename[0];
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));

        }

        public ActionResult CheckRadio(FormCollection frm)
        {
            String[] choises = new String[35];
            
            for (int i = 1; i < 36; i++)
            {
                choises[i - 1] = frm["g" + i.ToString()].ToString();
            }
            String[] questions = new String[35];
            questions[0] = "יעדי הארגון, אסטרטגיה";
            questions[1] = "תרשים ומבנה ארגוני";
            questions[2] = "השלכות או'ש";
            questions[3] = "אישור (סימוכין) תקציבי / עסקי // האם הפרויקט עסקי.";
            questions[4] = "תלות במערכות אחרות";
            questions[5] = "סיכונים - ישימות הפרויקט  // האם הפרויקט עסקי";
            questions[6] = "עלות/תועלת – ישימות עסקית";
            questions[7] = "תוצרים";
            questions[8] = "מועד נטישה";
            questions[9] = "משך חיי המערכת";
            questions[10] = "שגרות מקומיות";
            questions[11] = "שגרות ארגון";
            questions[12] = "שגרות צד שלישי";
            questions[13] = "טבלאות מקומיות";
            questions[14] = "טבלאות ארגון";
            questions[15] = "טבלאות חיצוניות";
            questions[16] = "כללי – מודל הנתונים";
            questions[17] = "קבצים לוגיים";
            questions[18] = "שדות מקומיים";
            questions[19] = "שדות ארגוניים";
            questions[20] = "שדות גלובליים";
            questions[21] = "קבוצת דחות";
            questions[22] = "הצלבות וחיתוכים";
            questions[23] = "נפחים עומסים וביצועים";
            questions[24] = "אינדקס ורשימה כללית";
            questions[25] = "ממשקים";
            questions[26] = "דרישות מיוחדות ";
            questions[27] = " (נקודות פתוחות (וחלופות";
            questions[28] = "דרישות עתידיות";
            questions[29] = "ציוד קצה ";
            questions[30] = "ציוד מיוחד";
            questions[31] = "ציוד מתכלה ";
            questions[32] = "אתר ראשי";
            questions[33] = "אתר גיבוי";
            questions[34] = " דרישות בטיחות (SAFETY)";


            List<String> lastform = new List<String>();
            for (int i = 0; i < 35; i++)
            {
                if (choises[i] == "Yes")
                {
                    lastform.Add(questions[i]);

                }
            }
            ViewBag.value = lastform;
            TempData["Qes"] = lastform;
            return View();
        }


        public ActionResult Submit()
        {

            String pa = TempData["doc"].ToString();
            Document doc =  new Document(pa);


            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.MoveToDocumentEnd();
            var dal = new ProjectsDal();
            var proj = dal.GetPrijectByPrjectId(ProjectId);
            String ProjectNameOwner = proj.UserName + "_" + proj.ProjectName;
                String dataDir = "C:/" + ProjectNameOwner + ".docx";
            // var proj = (new ProjectsDal()).GetPrijectByPrjectId(int.Parse(ProjectId.ToString()));
           

            List<String> ques = new List<String>();
            int i = 1;
            while (true)
            {
                if (Request.Form["q" + i.ToString()] != null)
                    ques.Add(Request.Form["q" + i.ToString()]);
                else
                    break;
                i++;
            }
            

            builder.Font.NameBi = "David";
            builder.Font.Name = "David";

            builder.ParagraphFormat.Bidi = true;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Justify;

            var x = (List<String>)TempData["Qes"];


            int ssss = x.Count;
            int ffff = ques.Count;
            
            for(i=0;i<ques.Count;i++)
            {
                // the qestions:

                builder.ListFormat.ApplyBulletDefault();
                builder.Font.SizeBi = 14;
                builder.Font.Size = 14;

                builder.Font.Underline = Underline.Single;
                builder.Font.Color = Color.Black;

                builder.Font.BoldBi = true;
                builder.Font.Bold = true;

                //builder.ListFormat.ApplyBulletDefault();


                builder.Writeln(x[i]);



                // the answer
                builder.Font.Color = Color.Blue;

                builder.ListFormat.List = null;
                builder.Font.Underline = Underline.None;

                builder.Font.Size = 12;
                builder.Font.SizeBi = 12;

                builder.Font.BoldBi = false;
                builder.Font.Bold = false;

                String[] lines = ques[i].Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    builder.Writeln("          " + line + "          ");
                }

                builder.Writeln();

            }

            ViewBag.File = dataDir;
            string path = Server.MapPath("~/Uploads/" + ProjectNameOwner + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            doc.Save(path + ProjectNameOwner + ".docx");

            TempData["pa"] = pa;
            return RedirectToAction("Start", "AutomaticFill");
        }


        public ActionResult EditPermistions()
        {
            var membdal = new PrivateProjectsDal();
            ProjectId = int.Parse(Request.QueryString.Get("projectid"));

            ViewBag.membs = membdal.GetMemberByProjectId(ProjectId);
            TempData["Count"] = (ViewBag.membs).Count;
            TempData["projectId"] = ProjectId;
            return View();
        }
        public ActionResult UpdatePermissions(FormCollection frm)
        {
            var membdal = new PrivateProjectsDal();

            int size = int.Parse(TempData["Count"].ToString());
            string[] s = new string[size];

            for (int i = 0; i < size; i++)
            {
                s[i] = frm[(i + 1).ToString()].ToString();
            }
            membdal.UpdatedPermissions(s, ProjectId);

            return View();
        }



    }

}












