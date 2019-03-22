using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Contact : User
    {

        public string Subject { get; set; }

        
        public string Massage { get; set; }

        
    }
}