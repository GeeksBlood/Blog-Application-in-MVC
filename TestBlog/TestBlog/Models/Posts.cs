using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestBlog.Models
{
    public class Posts
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Please enter post title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        
        [Required(ErrorMessage = "Please enter post content")]
        [Display(Name = "PostContent")]
        [AllowHtml]
        public string PostContent { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
        public string Category{ get; set; }
        public int CategoryId { get; set; }
        public string Date { get; set; }
        public string User { get; set; }
        public bool Is_active { get; set; }
    }
}