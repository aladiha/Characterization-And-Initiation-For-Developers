using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class PrivateProjects
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string User { get; set; }
        public bool IsPrivate { get; set; }
    }
}