using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Request
    {
        [Key]
        public int key { get; set; }
        public string from_user { get; set; }
        public string to_user { get; set; }
        public string discription { get; set; }
        public string Projectname { get; set; }
        public string request_type { get; set; }  

        public int status { get; set; }


        // if status 0: then the request not accepted or rejected -> in proccess
        // if status 1: then we accept the request
        // if status -1 then the request iss rejected
    }
}