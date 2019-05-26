using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;

namespace WebApplication2.Models
{
    public class PrivateProjects
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string User { get; set; }

        public bool IsPrivate { get; set; }

        public Project GetProject(String id)
        {
            var x = (new ProjectsDal()).GetPrijectByPrjectId(int.Parse(id));
            return x;
        }
    }
}