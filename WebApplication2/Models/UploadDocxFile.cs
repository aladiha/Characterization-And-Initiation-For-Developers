using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;
namespace WebApplication2.Models
{
    public class UploadDocxFile
    {

            [Required(ErrorMessage = "Please select file.")]
            //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx)$", ErrorMessage = "Only Word Documents allowed.")]
            public HttpPostedFileBase PostedFile { get; set; }
    }
}