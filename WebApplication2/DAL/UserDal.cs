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

        public bool DeleteUser(string id)
        {
            List<User> us=GetUserByUserName(id);
            if (us.Count != 0)
            {
                users.Remove(us[0]);
                SaveChanges();
                return true;
            }
                return false;
        }
        
        public bool UpdatePassword(string userid,string newpassword)
        {
            List<User> us = GetUserByUserName(userid);
            if(us.Count!=0)
            {
                us[0].Password = "" + newpassword;
                SaveChanges();
                return true;
            }
            return false;
        }
        
    }
}