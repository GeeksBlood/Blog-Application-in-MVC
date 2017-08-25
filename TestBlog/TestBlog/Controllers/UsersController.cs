using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TestBlog.Models;
using TestBlog.Security;

namespace TestBlog.Controllers
{
    
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        BlogEntities obj = new BlogEntities();
        // GET: Users
        [CustomAuthorize(Roles = "Author")]
        public ActionResult Index()
        {
            return View(obj.t_posts.ToList());
        }

        [CustomAuthorize(Roles = "Admin,Author")]
        [Route("CreatePosts")]
        public ActionResult CreatePosts()
        {
            ViewBag.Category = new SelectList(obj.t_category, "id", "category");
            return View();
        }
        [CustomAuthorize(Roles = "Admin,Author")]
        [Route("CreatePosts")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePosts(Posts posts)
        {
            if (ModelState.IsValid)
            {
                t_posts tposts = new t_posts();
                tposts.title = posts.Title;
                tposts.url = string.IsNullOrEmpty(posts.Url) ? GenerateURL(posts.Title) : GenerateURL(posts.Url);//posts.Url;
                tposts.postContent = posts.PostContent;
                tposts.tags = posts.Tags;
                tposts.categoryId=Convert.ToInt32(Request["Category"]) ;
                tposts.date_time =System.DateTime.Now.ToString("yyyy-MM-dd");
                tposts.userid = ((UserDetails)Session["userdetails"]).id;
                obj.t_posts.Add(tposts);
                obj.SaveChanges();
                if(((UserDetails)Session["userdetails"]).role=="Admin")
                    return RedirectToAction("Index","Admin");

                return RedirectToAction("CreatePosts");
            }
            ViewBag.Category = new SelectList(obj.t_category, "id", "category");
            return View();
        }

        public string GenerateURL(string url)
        {
            return Regex.Replace(url, @"[^A-Za-z0-9_\.~]+", "-");
        }
    }
}