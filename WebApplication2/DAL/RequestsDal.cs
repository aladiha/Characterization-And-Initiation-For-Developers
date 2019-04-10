using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class RequestsDal: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Request>().ToTable("Requests");
        }

        public DbSet<Request> requests { get; set; }

        public bool RequestIsNoExist(Request request)
        {
            var r = (from x in requests
                     where x.Projectname.Equals(request.Projectname) && x.from_user.Equals(request.from_user)
                     select x).ToList<Request>();
            if (r.Count == 0)
                return true;

            return false;

        }
        public bool AddRequest(Request request)
        {
            if(RequestIsNoExist(request)==true)
            {
                requests.Add(request);
                SaveChanges();
                return true;
            }
            return false;
        }
    }
}