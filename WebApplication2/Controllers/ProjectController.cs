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
            // List<Project> userValid = (from u in pdal.projects where select u).ToList<User>();


            if (project.ProjectName.Length>=1)
            {

                pdal.projects.Add(project);
                pdal.SaveChanges();
                return View("Project", project);

            }
            else
            {
                ViewBag.result = "Enter a Project Name!!!!!!!!!!!!!!!_!_ ";
                return View("Enter");
            }

        }
    }
}