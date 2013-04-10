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
    public class CategoryController : Controller
    {
        private cms_2Entities db = new cms_2Entities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var categories = db.Categories.Include("Template");
            return View(categories.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(long id = 0)
        {
            Category category = db.Categories.Single(c => c.CatID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.TempID = new SelectList(db.Templates, "TempID", "TempName");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.AddObject(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TempID = new SelectList(db.Templates, "TempID", "TempName", category.TempID);
            return View(category);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Category category = db.Categories.Single(c => c.CatID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.TempID = new SelectList(db.Templates, "TempID", "TempName", category.TempID);
            return View(category);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(category);
                db.ObjectStateManager.ChangeObjectState(category, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TempID = new SelectList(db.Templates, "TempID", "TempName", category.TempID);
            return View(category);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Category category = db.Categories.Single(c => c.CatID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Category category = db.Categories.Single(c => c.CatID == id);
            db.Categories.DeleteObject(category);
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