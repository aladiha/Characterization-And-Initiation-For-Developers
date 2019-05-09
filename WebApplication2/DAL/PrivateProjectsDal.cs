using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;


namespace WebApplication2.DAL
{
    public class PrivateProjectsDal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PrivateProjects>().ToTable("PrivateProjects");
        }

        public DbSet<PrivateProjects> privateprojects { get; set; }

        public bool UpdatedPermissions(string [] perm,int projectid)
        {
            var membdal = new ProjectMembersDal();
            var membersss = membdal.GetMemberByProjectId(projectid);
            return true;
        }

        public List<PrivateProjects> GetMemberByProjectId(int id)
        {
            var x = (from y in privateprojects
                     where y.ProjectId == id
                     select y).ToList<PrivateProjects>();
            return x;
        }
    }
}