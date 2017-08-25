using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestBlog.Models
{
    public class Register
    {
        [Required(ErrorMessage ="Please Enter Username")]
        [Display(Name = "username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "username")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string email { get; set; }
        
        public string mobile_no { get; set; }
        public string city { get; set; }
        public string last_login { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "cpassword")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="Password and confirm password should be same")]
        public string cpassword { get; set; }
        public int is_type { get; set; }
        public bool is_active { get; set; }
    }

}