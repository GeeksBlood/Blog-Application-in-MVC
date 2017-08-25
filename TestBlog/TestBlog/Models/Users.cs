using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBlog.Models
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string mobile_no { get; set; }
        public string city { get; set; }
        public string usertype { get; set; }
        public int is_type { get; set; }
        public int usertypeID { get; set; }
        public bool is_active { get; set; }
    }
}