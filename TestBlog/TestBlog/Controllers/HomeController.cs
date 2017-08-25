using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBlog.Models;
using TestBlog.Security;
namespace TestBlog.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        BlogEntities obj = new BlogEntities();
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<Posts> posts = from x in obj.t_posts join y in obj.t_category on x.categoryId equals y.id join z in obj.t_user on x.userid equals z.id where x.is_active.Equals(true) select new Posts { id = x.id, Url = x.url, Category = y.category, Title = x.title, PostContent = x.postContent, User = z.username, Date = x.date_time };
            return View(posts);
        }

        [Route("PostDetails/{id}")]
        public ActionResult PostDetails(string id)
        {
            PostDetailsModel objPost = new PostDetailsModel();
            objPost.posts = (from x in obj.t_posts join y in obj.t_category on x.categoryId equals y.id join z in obj.t_user on x.userid equals z.id where x.is_active.Equals(true) && x.url.Equals(id) select new Posts { id = x.id, Url = x.url, Category = y.category, Title = x.title, PostContent = x.postContent, User = z.username, Date = x.date_time }).FirstOrDefault();
            objPost.comments = from x in obj.t_comment join y in obj.t_posts on x.postid equals y.id where y.url.Equals(id) select new Comments { username = x.username, comment = x.comment, date_time = x.date_time };
            return View(objPost);
        }

        [HttpPost]
        public ActionResult PostComment(PostDetailsModel postComment)
        {
            if (ModelState.IsValid)
            {
                t_comment objComments = new t_comment();
                objComments.username = postComment.addcomment.email;
                objComments.email = postComment.addcomment.email;
                objComments.postid = postComment.posts.id;
                objComments.comment = postComment.addcomment.comment;
                objComments.date_time = System.DateTime.Now.ToString("yyyy-MM-dd");
                obj.t_comment.Add(objComments);
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                    var result = from x in obj.t_user join y in obj.t_userType on x.is_type equals y.id where x.email.Equals(userDetails.email) && x.password.Equals(userDetails.pwd) select new UserDetails { id=x.id, email = x.email, role = y.is_type };
                    Session["userdetails"] = (UserDetails)result.FirstOrDefault();
                    return RedirectToAction("Index");
            }
            return View();
        }
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }
        [Route("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register reg)
        {
            if (ModelState.IsValid)
            {
                t_user users = new t_user();
                users.username = reg.username;
                users.email = reg.email;
                users.mobile_no = reg.mobile_no;
                users.city = reg.city;
                users.password = reg.password;
                users.is_type = Convert.ToInt32(reg.is_type);
                users.is_active = true;
                users.last_login = System.DateTime.Now.ToString("yyyy-MM-dd");
                users.reg_date = System.DateTime.Now.ToString("yyyy-MM-dd");
                obj.t_user.Add(users);
                obj.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}