using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestBlog.Models;

namespace TestBlog.Controllers
{
    [RoutePrefix("Test")]
    public class TestController : Controller
    {
        private BlogEntities db = new BlogEntities();

        // GET: Test
        [Route("Index")]
        public ActionResult Index()
        {
            var t_posts = db.t_posts.Include(t => t.t_category).Include(t => t.t_user);
            return View(t_posts.ToList());
        }

        // GET: Test/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_posts t_posts = db.t_posts.Find(id);
            if (t_posts == null)
            {
                return HttpNotFound();
            }
            return View(t_posts);
        }

        // GET: Test/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.t_category, "id", "category");
            ViewBag.userid = new SelectList(db.t_user, "id", "username");
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userid,title,url,tags,categoryId,postContent,date_time")] t_posts t_posts)
        {
            if (ModelState.IsValid)
            {
                db.t_posts.Add(t_posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(db.t_category, "id", "category", t_posts.categoryId);
            ViewBag.userid = new SelectList(db.t_user, "id", "username", t_posts.userid);
            return View(t_posts);
        }

        [Route("Edit/{id}")]
        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_posts t_posts = db.t_posts.Find(id);
            if (t_posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.t_category, "id", "category", t_posts.categoryId);
            ViewBag.userid = new SelectList(db.t_user, "id", "username", t_posts.userid);
            return View(t_posts);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userid,title,url,tags,categoryId,postContent,date_time")] t_posts t_posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(db.t_category, "id", "category", t_posts.categoryId);
            ViewBag.userid = new SelectList(db.t_user, "id", "username", t_posts.userid);
            return View(t_posts);
        }

        [Route("Delete")]
        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_posts t_posts = db.t_posts.Find(id);
            if (t_posts == null)
            {
                return HttpNotFound();
            }
            return View(t_posts);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_posts t_posts = db.t_posts.Find(id);
            db.t_posts.Remove(t_posts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
