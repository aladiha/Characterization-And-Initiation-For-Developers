using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2
{
    public class myRole : RoleProvider
    {
        public static void setUser(string username, string myrole, string name)
        {
            HttpContext.Current.Session["userId"] = username;
            HttpContext.Current.Session["userRole"] = myrole;
            HttpContext.Current.Session["userName"] = name;
        }




        public override string[] GetAllRoles()
        {
            return new string[] { "admin", "user" };
        }

        public override string[] GetRolesForUser(string username)
        {
            if (HttpContext.Current.Session["userId"] as string == username)
                return new string[] { HttpContext.Current.Session["userRole"] as string };
            else
                return new string[] { };
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            if (username.Equals(HttpContext.Current.Session["userId"] as string) && username.Equals(HttpContext.Current.Session["userId"] as string))
                return true;
            else
                return false;
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }



        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

    }
}