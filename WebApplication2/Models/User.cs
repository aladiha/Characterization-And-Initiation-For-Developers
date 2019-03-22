using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class User
    {
        [Key]
        [Required]
        //[StringLength(10, MinimumLength = 2, ErrorMessage = "leangth must be btween 2-10")]
        public string UserName { get; set; }

        [Required]
       // [RegularExpression("[a-zA-Z0-9]*[@][a-zA-Z].[a-zA-Z]", ErrorMessage = "age should be 2 digits  ")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

       
    }
}