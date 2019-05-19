using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace WebApplication2.Models
{
    public partial class Project

    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        
    }

}
