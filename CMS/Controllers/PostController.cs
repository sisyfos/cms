using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class PostController : Controller
    {
        private cms_2Entities db = new cms_2Entities();

        //
        // GET: /Post/

        public ActionResult Index()
        {
            var posts = db.Posts.Include("Category").Include("Content");
            return View(posts.ToList());
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(long id = 0)
        {
            Post post = db.Posts.Single(p => p.PostID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName");
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ContentID");
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.AddObject(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName", post.CatID);
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ContentID", post.ContentID);
            return View(post);
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Post post = db.Posts.Single(p => p.PostID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName", post.CatID);
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ContentID", post.ContentID);
            return View(post);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Attach(post);
                db.ObjectStateManager.ChangeObjectState(post, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName", post.CatID);
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ContentID", post.ContentID);
            return View(post);
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Post post = db.Posts.Single(p => p.PostID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Post post = db.Posts.Single(p => p.PostID == id);
            db.Posts.DeleteObject(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}