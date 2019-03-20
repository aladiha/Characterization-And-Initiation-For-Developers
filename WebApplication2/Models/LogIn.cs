using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class LogIn
    {
        [Key]
        [Required]
        [StringLength(15, ErrorMessage = "user id length must be btween 4 and 15 characters.", MinimumLength = 4)]
        public string UserName { get; set; }



        [Required]
        [StringLength(15, ErrorMessage = "password length must be btween 5 and 20 characters.", MinimumLength = 5)]
        public string password { get; set; }
    }//kjhxvjhdbxjvbjdv
    //;lkhjgfxglhgcxv;hcmgn/.,fhj;uo,hvk
}