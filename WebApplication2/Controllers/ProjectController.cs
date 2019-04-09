using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.ModelBinders;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class ProjectController : Controller
    {
        private object dal;

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter() {

            return View();
        }
        public ActionResult imanagerp()
        {
            ProjectsDal pdal = new ProjectsDal();
            ProjectMv pm = new ProjectMv();
             pm.project = (from x in pdal.projects where (AccountInfo.userName).Equals(x.UserName) select x).ToList<Project>();
           
            return View(pm);
        }


        [HttpPost]
        public ActionResult Submit([ModelBinder(typeof(ProjectBinder))] Project project)
        {
            
            ProjectsDal pdal = new ProjectsDal();

            // if exists
            if (pdal.AddProject(project) == false)
            {
                TempData["ExistUser"] = "Your project does Exists in DataBase! try other project";
                return View("Enter");
            }


            // if not exists
            return View("Project", project);

        }

        public ActionResult Requests()
        {
            return View();
        }

        public ActionResult View_Requests()
        {
            return View();
        }

        public ActionResult Send_Requests()
        {
            return View();
        }
    }
}