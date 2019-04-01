using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.ModelBinders
{
    public class ProjectBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;

            string Pname = objContext.Request.Form["ProjectName"];

            Project obj = new Project
            {
                ProjectName = Pname,
                UserName = HttpContext.Current.Session["userName"].ToString()

            };
            return obj;
        }
    }
}