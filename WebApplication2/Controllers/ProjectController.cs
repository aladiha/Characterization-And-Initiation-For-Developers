using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.ModelBinders;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter() {

            return View();
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
    }
}