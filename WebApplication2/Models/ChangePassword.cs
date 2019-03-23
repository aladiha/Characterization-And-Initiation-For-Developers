using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ChangePassword
    {
        [Required]
        [StringLength(15, ErrorMessage = "password length must be btween 5 and 20 characters.", MinimumLength = 5)]
        public string oldPassword { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "new password length must be btween 5 and 20 characters.", MinimumLength = 5)]
        public string newPassword { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "password length must be btween 5 and 20 characters.", MinimumLength = 5)]
        public string varifynewPassword { get; set; }
    }
}