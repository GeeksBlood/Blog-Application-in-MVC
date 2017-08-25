using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestBlog.Models
{
    public class UserDetails
    {
        [Required(ErrorMessage ="Please enter email address")]
        [Display(Name = "email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter valid password")]
        [Display(Name = "email")]
        public string pwd { get; set; }
        public int id { get; set; }
        public string role { get; set; }
    }
}