using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.ModelBinders
{
    public class UserBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)


        {
            HttpContextBase objContext = controllerContext.HttpContext;
           
            string password = objContext.Request.Form["psw"];
            string Name = objContext.Request.Form["usrnm"];
            string email = objContext.Request.Form["email"];

            User obj = new User
            {
                UserName = Name,

                Email = email,

                Password = password
            };
            return obj;
        }
   
    }
}