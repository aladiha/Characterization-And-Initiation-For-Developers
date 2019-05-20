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


        public Project GetPrijectByPrjectId(int id)
        {
            var x = (from y in projects where y.Id == id select y).ToList<Project>();
            return x[0];
        }
        public bool IsNotExists(Project p)
        {
            var ps = (from x in projects
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

        public int GetProjectId(Project p)
        {
            var us = (from x in projects
                      where x.UserName.Equals(p.UserName) && x.ProjectName.Equals(p.ProjectName)
                      select x).ToList<Project>();
            if (us.Count == 0)
            {
                return -1;
            }
            else
                return us[0].Id;
        }
        public bool DeleteProject(string UserName, string pname)
        {
            List<Project> us = GetProjectByUserName(UserName);
            // pname = "feras1";
            int i;
            //if (us.Count != 0)
            for (i = 0; i < us.Count; i++)
            {
                if (us[i].ProjectName == pname)
                {
                    projects.Remove(us[i]);
                    SaveChanges();
                    return true;

                }


            }

            return false;
        }

        public bool ExistProjectId(int id,string user)
        {
            var y = (from x in projects where x.Id == id  && x.UserName.Equals(user) select x).ToList<Project>();
            if (y.Count == 0)
                return false;
            return true;
        }

    }
}