using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBlog.Models;
using TestBlog.Security;

namespace TestBlog.Controllers
{
    [RoutePrefix("Admin")]
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        BlogEntities obj = new BlogEntities();
        // GET: Amdin
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<Posts> posts = from x in obj.t_posts join y in obj.t_category on x.categoryId equals y.id join z in obj.t_user on x.userid equals z.id orderby x.id descending select new Posts { id = x.id, Url=x.url,Category=y.category, Title =x.title,PostContent=x.postContent,User=z.username,Date=x.date_time, Is_active=x.is_active }  ;
            return View(posts);
        }
        [Route("DeletePosts/{id}")]
        public ActionResult DeletePosts(int id)
        {
            t_posts posts = obj.t_posts.Where(x => x.id.Equals(id)).SingleOrDefault();
            obj.t_posts.Remove(posts);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Route("EditPosts/{id}/{operation}")]
        public ActionResult Posts(int id,string operation)
        {
            Posts posts = (from x in obj.t_posts join y in obj.t_category on x.categoryId equals y.id join z in obj.t_user on x.userid equals z.id where x.id.Equals(id) select new Posts { id=x.id, Title = x.title, Url=x.url, PostContent = x.postContent,Tags=x.tags, User = z.username, Date = x.date_time,Category=y.category,CategoryId=x.categoryId, Is_active = x.is_active }).FirstOrDefault();
            ViewBag.categories= new SelectList(obj.t_category, "id", "category", posts.CategoryId);
            ViewBag.operation = operation;
            return View(posts);
        }

        [Route("EditPosts")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPosts(Posts editData)
        {
            t_posts posts = obj.t_posts.Where(x => x.id.Equals(editData.id)).SingleOrDefault();
            posts.title = editData.Title;
            posts.tags = editData.Tags;
            posts.url = editData.Url;
            posts.postContent = editData.PostContent;
            posts.categoryId = Convert.ToInt32(Request["categories"]);
            posts.is_active = editData.Is_active;
            obj.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Users")]
        public ActionResult Users()
        {
            IEnumerable<Users> users = (from x in obj.t_user join y in obj.t_userType on x.is_type equals y.id select new Users { id=x.id, username=x.username,email=x.email,mobile_no=x.mobile_no,city=x.city,usertype=y.is_type } ).ToList();
            return View(users);
        }

        [Route("UserDetails")]
        public ActionResult UserDetails(int id, string operation)
        {
            Users users = (from x in obj.t_user join y in obj.t_userType on x.is_type equals y.id where x.id.Equals(id) select new Users { id = x.id, username = x.username, email = x.email, mobile_no = x.mobile_no, city = x.city, usertype = y.is_type, usertypeID =x.is_type, is_active=x.is_active }).SingleOrDefault();
            ViewBag.UserType = new SelectList(obj.t_userType, "id", "is_type", users.usertypeID);
            ViewBag.Edit = operation;
            return View(users);
        }
        [Route("UserDetails")]
        [HttpPost]
        public ActionResult UserDetails(Users users)
        {
            t_user user= obj.t_user.Where(x => x.id.Equals(users.id)).SingleOrDefault();
            user.username = users.username;
            user.mobile_no = users.mobile_no;
            user.city = users.city;
            user.is_type =Convert.ToInt32(Request["UserType"]) ;
            user.is_active = users.is_active;
            obj.SaveChanges();
            return RedirectToAction("Users");
        }

        [Route("Category")]
        public ActionResult Category()
        {
            // IEnumerable<Category> category=(from );
            return View(obj.t_category.OrderBy(x => x.id).ToList());
        }
        [Route("AddCategory")]
        public ActionResult AddCategory()
        {
            return View();
        }
        [Route("AddCategory")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(t_category addCategory)
        {
            if (ModelState.IsValid)
            {
                t_category category = new t_category();
                obj.t_category.Add(addCategory);
                obj.SaveChanges();
                return RedirectToAction("Category");
            }

            return View();
        }
    }
}