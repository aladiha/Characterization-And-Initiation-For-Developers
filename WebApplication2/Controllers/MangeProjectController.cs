using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;
using Aspose.Words;
using Microsoft.Office.Interop.Word;
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

            Aspose.Words.Document doc = new Aspose.Words.Document();


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
                builder.Writeln("                     " + ques[i]+ "                     ");
                else
                builder.Writeln("          " + ques[i]+"           ");

                builder.Writeln();
                builder.Writeln();
                builder.Writeln();
            }
            //  doc.Save(dataDir);

            string path = Server.MapPath("~/Uploads/" + ProjectNameNOwner + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            doc.Save(path + ProjectNameNOwner + ".docx");
            TempData["doc"] = doc;
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
            return View();
        }


        public ActionResult Submit()
        {

            Aspose.Words.Document doc = (Aspose.Words.Document)TempData["doc"];


            DocumentBuilder builder = new DocumentBuilder(doc);
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

            builder.Bold = true;
            builder.Font.NameBi="David";

             builder.Font.Bold = true;
            // builder.Font.Name = "David";
          //  builder.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            builder.ParagraphFormat.Bidi = true;
            builder.Font.Bidi = true;



            foreach (String q in ques)
                {
                    builder.Writeln(q);
                }



            ViewBag.File = dataDir;

                string path = Server.MapPath("~/Uploads/" + ProjectNameOwner + "/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                doc.Save(path + ProjectNameOwner + ".docx");
            //////////////////////////////////////////////////////////////////

            /*  Application ap = new Application();

              try
              {


                  Microsoft.Office.Interop.Word.Document doc = ap.Documents.Open(@"C:\Users\Aladin\Desktop\Doc2.docx", ReadOnly: false, Visible: false);
                  doc.Activate();

                  Selection sel = ap.Selection;

                  if (sel != null)
                  {
                      switch (sel.Type)
                      {
                          case WdSelectionType.wdSelectionIP:
                              sel.TypeText(DateTime.Now.ToString());
                              sel.TypeParagraph();
                              break;

                          default:
                              Console.WriteLine("Selection type not handled; no writing done");
                              break;

                      }
                      // Remove all meta data.
                      doc.RemoveDocumentInformation(WdRemoveDocInfoType.wdRDIAll);

                      ap.Documents.Save(NoPrompt: true, OriginalFormat: true);

                  }
                  else
                  {
                      Console.WriteLine("Unable to acquire Selection...no writing to document done..");
                  }

                  ap.Documents.Close(SaveChanges: false, OriginalFormat: false, RouteDocument: false);

              }
              catch (Exception ex)
              {
                  Console.WriteLine("Exception Caught: " + ex.Message); // Could be that the document is already open (/) or Word is in Memory(?)
              }
              finally
              {
                  // Ambiguity between method 'Microsoft.Office.Interop.Word._Application.Quit(ref object, ref object, ref object)' and non-method 'Microsoft.Office.Interop.Word.ApplicationEvents4_Event.Quit'. Using method group.
                  // ap.Quit( SaveChanges: false, OriginalFormat: false, RouteDocument: false );
                  ((_Application)ap).Quit(SaveChanges: false, OriginalFormat: false, RouteDocument: false);
                  System.Runtime.InteropServices.Marshal.ReleaseComObject(ap);
              }*/
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












