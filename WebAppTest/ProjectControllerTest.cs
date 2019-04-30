using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;

using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using WebApplication2;
using System;
using WebApplication2.DAL;

namespace WebAppTest
{
    [TestClass]
    public class ProjectControllerTest
    {


        [TestMethod]
       public void Submit()
        {
            
            //sadasd
            ProjectController cont = new ProjectController();
            var project = new Project { Id = 22, UserName = "tester", ProjectName = "TESTE" };
            ViewResult res = cont.Submit(project) as ViewResult;
            Assert.IsNotNull(res);

        }

       
    }
}
