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

        
        public List<User> GetUserByUserName(string id)
        {
            List<User> us =
                (from x in users
                 where x.UserName.Equals(id)
                 select x).ToList<User>();
            return us;
        }
/*
        public bool DeleteUser(string id)
        {
            List<User> us=GetUserByUserName(id);
            if (us.Count != 0)
            {
                users.
                SaveChanges();
                return true;

            }
                return false;
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