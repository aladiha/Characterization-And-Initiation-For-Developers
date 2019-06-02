using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class PrivateProjectsDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PrivateProjects>().ToTable("PrivateProjects");

        }

        public DbSet<PrivateProjects> privateprojects { get; set; }

        public bool UpdatedPermissions(string[] perm, int projectid)
        {
            var membersss = GetMemberByProjectId(projectid);
            int i = 0;
            foreach (var x in membersss)
            {
                if (perm[i].Equals("Off"))
                {
                    x.IsPrivate = true;
                }
                else
                {
                    x.IsPrivate = false;

                }
                i++;

            }

            SaveChanges();
            return true;
        }

        public List<PrivateProjects> GetMemberByProjectId(int id)
        {
            var x = (from y in privateprojects
                     where y.ProjectId == id
                     select y).ToList<PrivateProjects>();
            return x;
        }

        public List<PrivateProjects> GetMemberInProjectWithPermission(int projid,string user)
        {
            var x = (from y in privateprojects
                     where y.User.Equals(user) && projid == y.ProjectId
                     select y).ToList<PrivateProjects>();
            return x;
        }

        public bool DeleteAllMembers(int projectId)
        {
            var x = (from y in privateprojects
                     where y.ProjectId == projectId
                     select y).ToList<PrivateProjects>();
            foreach( var k in x)
            {
                privateprojects.Remove(k);
            }
            SaveChanges();
            return true;
        }
     }
}