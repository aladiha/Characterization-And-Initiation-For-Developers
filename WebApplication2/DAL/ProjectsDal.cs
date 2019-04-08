using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;


namespace WebApplication2.DAL
{
    public class ProjectsDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                    base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Project>().ToTable("Projects");
            }

        public DbSet<Project> projects { get; set; }


        public bool IsNotExists(Project p)
        {
            List<Project> ps = (from x in projects
                                where x.ProjectName.Equals(p.ProjectName) && x.UserName.Equals(p.UserName)
                                select x).ToList<Project>();
            if (ps.Count == 0)
                return true;
            return false;
        }

        public bool AddProject(Project p)
        {
            if(IsNotExists(p)==true)
            {
                projects.Add(p);
                SaveChanges();
                return true;
            }

            return false;
        }
        public List<Project> GetProjectByUserName(string UserName)
        {
            List<Project> us =
                (from x in projects
                 where x.UserName.Equals(UserName)
                 select x).ToList<Project>();

            return us;
        }

    }
}