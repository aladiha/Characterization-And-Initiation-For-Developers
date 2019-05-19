using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class manege

    {

        public string Description { get; set; }

        [Key]
        public string Id { get; set; }

    }
}