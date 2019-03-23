using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;


namespace WebApplication2.DAL
{
    public class UserDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("UsersPJ");
        }
        public DbSet<User> users { get; set; }

        /*
        public List<User> GetUserById(string id)
        {
            
            return new List<User>();
        }

        public Bool DeleteUser(string id)
        {
            
            savechanges();
            return True;
        }

        public Bool UpdatePassword(string userid,string newpassword)
        {

            User us=GetUserBuId(string userid);
            us.password=newpassword;

          DeleteUser(string userid);
            savechagneds;  
        adduser(ur);
          savechangeds();
            return True;
           }
        */
    }
}