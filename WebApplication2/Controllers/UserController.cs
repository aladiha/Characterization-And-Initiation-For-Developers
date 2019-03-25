using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
using WebApplication2.ModelBinders;
using System.Web.Security;
using System.Web.Routing;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit([ModelBinder(typeof(UserBinder))] User user) { 

            UserDal udal = new UserDal();
            var x=udal.GetUserByUserName(user.UserName);
            if(x.Count!=0)
            {
                TempData["ExistUser"] = "The User "+user.UserName +"  Does Exists!";
                return RedirectToAction("Register","User");
            }
            udal.users.Add(user);

            udal.SaveChanges();

            return View("User", user);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult doLogin(LogIn U)
        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                //check if the user is in the users DB (not admin) 
               
                List<User> userValid = (from u in dal.users where ((u.Password == U.Password) && (u.UserName == U.UserName)) select u).ToList<User>();
                if (userValid.Count == 1)
                {
              
                    myRole.setUser(userValid[0].Email, "user", userValid[0].UserName);//set the user role 
                    FormsAuthentication.SetAuthCookie(U.UserName, true);

                    Session["UserId"] = userValid[0].UserName;
                    //Session["email"] = userValid[0].Email;
                    
                    return RedirectToAction("Index", "Login");
                }
               /* else
                {
                    //check if the user is admin in the librarian BD
                    List<librarian> adminValid = (from u in dal.librarians where (u.password == U.password) && (u.id == U.id) select u).ToList<librarian>();
                    if (adminValid.Count == 1)
                    {
                        myRole.setUser(U.id, "admin", adminValid[0].name);//set the user role  as admin 
                        FormsAuthentication.SetAuthCookie(U.id, true);
                        return RedirectToAction("Index", "Userpage");
                    }
                }*/

                ViewBag.result = "1-User name or password is inccorect!";            //the user inter invalid password or username
                ViewBag.signup = "2-this username is not exist, please sign up  ";   //or he is not a user 
                

            }

            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            myRole.setUser(null, null, null);//srt the role to null after the user logged out
            return RedirectToAction("Index","Home");//view the sign in page
        }



    }
}