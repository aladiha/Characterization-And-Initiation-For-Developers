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
            TempData["Id"] = int.Parse(Request.QueryString.Get("projectid"));

            return View();

        } 
        public ActionResult UploadPage()
        {
            TempData["Id"] = int.Parse(Request.QueryString.Get("projectid"));

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase postedFile)
        {

            string path = Server.MapPath("~/Uploads/"+ TempData["Id"]+"/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var dir =new DirectoryInfo(path);
            FileInfo []filename = dir.GetFiles("*.*");
            foreach( var x in filename)
            {
                x.Delete();
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
            string proid = Request.QueryString.Get("projectid");
            string path = Server.MapPath("~/Uploads/" + proid + "/");
            var dir = new DirectoryInfo(path);
            FileInfo[] filename = dir.GetFiles("*.*");

            var FileVirtualPath = path + filename[0];
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));

        }

        public ActionResult CheckRadio(FormCollection frm)
        {
            String[] choises = new String[35];

            for (int i = 1; i < 36; i++) {
                choises[i-1] = frm["g"+i.ToString()].ToString();
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
            for (int i = 0; i < 35; i++) {
                if (choises[i] == "Yes") {
                    lastform.Add(questions[i]);
                }
            }
            ViewBag.value = lastform;
            return View();
        }

        public ActionResult Submit() {

           Aspose.Words.Document doc = new Aspose.Words.Document();

        
           DocumentBuilder builder = new DocumentBuilder(doc);
            var dal = new ProjectsDal();
            var proj = dal.GetPrijectByPrjectId(int.Parse(TempData["Id"].ToString()));

           String dataDir = "C:/"+ proj.ProjectName+"_"+proj.UserName+ ".docx";


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

            foreach (String q in ques) {
                builder.Writeln(q);
            }
            doc.Save(dataDir);
            ViewBag.File = dataDir;
            string path = Server.MapPath("~/Uploads/"+ TempData["Id"].ToString() + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            doc.Save(path+proj.ProjectName+"_"+proj.UserName+".docx");
            ////////////////////////////////////////////////////////////////

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
            return View();
        }


        public ActionResult EditPermistions()
        {
            var membdal = new PrivateProjectsDal();
            string projectid = Request.QueryString.Get("projectid");

            ViewBag.membs = membdal.GetMemberByProjectId(int.Parse(projectid));
            TempData["Count"] = (ViewBag.membs).Count;
            TempData["projectId"] = projectid;
            return View();
        }

        public ActionResult UpdatePermissions(FormCollection frm)
        {
            var membdal = new PrivateProjectsDal();
            
            int size = int.Parse(TempData["Count"].ToString());
            string[] s = new string[size];

            for (int i = 0; i < size; i++)
            {
                s[i] = frm[(i+1).ToString()].ToString();
            }
            membdal.UpdatedPermissions(s, int.Parse(TempData["projectId"].ToString()));

            return View();

        }

    }

}




       

   





