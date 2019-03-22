using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{
    public class Contact
    {
       
        public string Name { get; set; }
     
        public string Subject { get; set; }

        [Key]
        public string Message { get; set; }

        
    }
}