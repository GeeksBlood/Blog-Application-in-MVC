using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestBlog.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Please enter category name")]
        public string category { get; set; }
        public string description { get; set; }
    }
}