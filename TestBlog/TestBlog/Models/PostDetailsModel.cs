using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestBlog.Models
{
    public class PostDetailsModel
    {
        public Posts posts { get; set; }
        
        public IEnumerable<Comments> comments { get; set; }
        
        public t_comment addcomment { get; set; }
    }
}