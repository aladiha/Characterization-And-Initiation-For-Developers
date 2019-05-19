using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class ProjectMembersDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectMembers>().ToTable("ProjectMembers");
        }
        public DbSet<ProjectMembers> projectMembers { get; set; }

        public bool IsNotExists(int projectid, string memb)
        {
            var result = (from x in projectMembers
                          where x.ProjectId == projectid && x.Member.Equals(memb)
                          select x).ToList<ProjectMembers>();
            if (result.Count == 0)
                return true;
            return false;
        }

        public bool AddMember(ProjectMembers mem)
        {
            if (IsNotExists(mem.ProjectId, mem.Member) == true)
            {
                projectMembers.Add(mem);
                var n = new PrivateProjects { ProjectId = mem.ProjectId, User = mem.Member, IsPrivate = false };
                var d = new PrivateProjectsDal();
                d.privateprojects.Add(n);
                d.SaveChanges();
                SaveChanges();
                return true;
            }
            return false;
        }

        public List<ProjectMembers> GetProjectMember(ProjectMembers pj)
        {
            var y = (from x in projectMembers
                     where x.Member.Equals(pj.Member)
                     && x.ProjectId.Equals(pj.ProjectId)
                     select x).ToList<ProjectMembers>();
            return y;
        }
        public bool DeleteMember(ProjectMembers ff)
        {

            var pj = GetProjectMember(ff);

            if (pj.Count == 0)
                return false;

            projectMembers.Remove(pj[0]);
            SaveChanges();
            return true;
        }

        public List<ProjectMembers> GetMemberByProjectId(int id)
        {
            var x = (from y in projectMembers
                     where y.ProjectId == id
                     select y).ToList<ProjectMembers>();
            return x;
        }
    }
}