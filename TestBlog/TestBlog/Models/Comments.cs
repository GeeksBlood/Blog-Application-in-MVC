using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBlog.Models
{
    public class Comments
    {
        public int postid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string comment { get; set; }
        public string date_time { get; set; }
    }
}