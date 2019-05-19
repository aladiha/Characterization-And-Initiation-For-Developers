using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class RequestsViewModel
    {
        public List<Request> ListRequests = new List<Models.Request>();

        public void  ViewRequests()
        {
            var Req = new RequestsDal();
            foreach (Request p in (new RequestsDal()).requests.ToList<Request>())
            {
                ListRequests.Add(p);  



            }
        }


    }
}