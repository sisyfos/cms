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
    public class TemplateController : Controller
    {
        private cms_2Entities db = new cms_2Entities();

        //
        // GET: /Template/

        public ActionResult Index()
        {
            return View(db.Templates.ToList());
        }

        //
        // GET: /Template/Details/5

        public ActionResult Details(long id = 0)
        {
            Template template = db.Templates.Single(t => t.TempID == id);
            if (template == null)
            {
                return HttpNotFound();
            }
            return View(template);
        }

        //
        // GET: /Template/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Template/Create

        [HttpPost]
        public ActionResult Create(Template template)
        {
            if (ModelState.IsValid)
            {
                db.Templates.AddObject(template);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(template);
        }

        //
        // GET: /Template/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Template template = db.Templates.Single(t => t.TempID == id);
            if (template == null)
            {
                return HttpNotFound();
            }
            return View(template);
        }

        //
        // POST: /Template/Edit/5

        [HttpPost]
        public ActionResult Edit(Template template)
        {
            if (ModelState.IsValid)
            {
                db.Templates.Attach(template);
                db.ObjectStateManager.ChangeObjectState(template, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(template);
        }

        //
        // GET: /Template/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Template template = db.Templates.Single(t => t.TempID == id);
            if (template == null)
            {
                return HttpNotFound();
            }
            return View(template);
        }

        //
        // POST: /Template/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Template template = db.Templates.Single(t => t.TempID == id);
            db.Templates.DeleteObject(template);
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