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
                           where x.to_user.Equals(user) && x.status==0
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

        public bool RespondRequest(string froom,string to , string type,string pn , int status) {

            var x = (from y in requests
                     where y.from_user.Equals(froom) && y.to_user.Equals(to) && y.Projectname.Equals(pn) && y.request_type.Equals(type) && y.status == 0
                     select y).ToList<Request>();  
            if (x.Count > 0) {
                x[0].status = status;
                SaveChanges();
                if (type == "Add Member")
                    return addMember(x[0]);
                else if (type == "Join To Project")
                    return joinProject(x[0]);
                return LeaveProject(x[0]);
            }
            return false;
        }

        private bool addMember(Request req) {

            var pdal = new ProjectsDal();
            int id = pdal.GetProjectId(new Project { ProjectName = req.Projectname, UserName = req.from_user });
            var pmember = new ProjectMembersDal();

            return pmember.AddMember(new ProjectMembers {ProjectId =id,Member=req.to_user});
        }

        private bool joinProject(Request req) {

            var pdal = new ProjectsDal();
            int id = pdal.GetProjectId(new Project { ProjectName = req.Projectname, UserName = req.from_user });
            var pmember = new ProjectMembersDal();

            return pmember.AddMember(new ProjectMembers { ProjectId = id, Member = req.to_user });
        }

        private bool LeaveProject(Request req)
        {

            var pdal = new ProjectsDal();
            int id = pdal.GetProjectId(new Project { ProjectName = req.Projectname, UserName = req.from_user });
            var pmember = new ProjectMembersDal();

            return pmember.DeleteMember(new ProjectMembers { ProjectId = id, Member = req.to_user });
        }
    }
}