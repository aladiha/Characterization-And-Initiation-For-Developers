using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{
    public class Contact
    {
       
        public string name { get; set; }
     
        public string subject { get; set; }

        [Key]
        public string massage { get; set; }

        
    }
}