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
                     where x.Projectname.Equals(request.Projectname)
                     && x.from_user.Equals(request.from_user)
                     && x.request_type.Equals(request.request_type)
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

        public bool Leaving_Project(string projmanager,string projectname,string username)
        {

            var prjmembDal = new ProjectMembersDal();
            return true;
        }
        
        public List<Request> GetAllRequestsSentByMe(string user)
        {
            var reqlist = (from x in requests
                           where x.from_user.Equals(user)
                           select x).ToList<Request>();
            return reqlist;
        }

        public List<Request> GetAllRequestsSentToMe(string user)
        {
            var reqlist = (from x in requests
                           where x.to_user.Equals(user)
                           select x).ToList<Request>();
            return reqlist;
        }

        public List<Request> GetAllRejectRequestsByUserName(string user)
        {
            var reqlist = (from x in requests
                           where (x.from_user.Equals(user) || x.to_user.Equals(user)) && (x.status==-1)
                           select x).ToList<Request>();
            return reqlist;
        }

        public List<Request> GetAllMemberShipRequests(string username)
        {
            var reqlist = (from x in requests
                           where x.request_type.Equals("Join_To_Project") && x.to_user.Equals(username)
                           select x).ToList<Request>();
            return reqlist;
        }
    }
}