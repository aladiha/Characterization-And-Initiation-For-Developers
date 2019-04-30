using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class AccountInfo
    {
        public static string email//return the user id
        {
            get { return HttpContext.Current.Session["Email"] as string; }
            private set { }
        }
        public static bool isLoggedIn //if the user logged in return true else false
        {
            get { return (HttpContext.Current.Session["userId"] as string != null); }
            private set { }
        }
        public static string userRole //return the user role (admin or user) 
        {
            get { return HttpContext.Current.Session["userRole"] as string; }
            private set { }
        }

        public static string userName //return the user role (admin or user) 
        {
            get { return HttpContext.Current.Session["userName"] as string; }
            private set { }
        }
    }
}   