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
    public class SiteConfigController : Controller
    {
        private cms_2Entities db = new cms_2Entities();

        //
        // GET: /SiteConfig/

        public ActionResult Index()
        {
            var siteconfigs = db.SiteConfigs.Include("Category");
            return View(siteconfigs.ToList());
        }

        //
        // GET: /SiteConfig/Details/5

        public ActionResult Details(long id = 0)
        {
            SiteConfig siteconfig = db.SiteConfigs.Single(s => s.SiteConfigID == id);
            if (siteconfig == null)
            {
                return HttpNotFound();
            }
            return View(siteconfig);
        }

        //
        // GET: /SiteConfig/Create

        public ActionResult Create()
        {
            ViewBag.SiteStartCatID = new SelectList(db.Categories, "CatID", "CatName");
            return View();
        }

        //
        // POST: /SiteConfig/Create

        [HttpPost]
        public ActionResult Create(SiteConfig siteconfig)
        {
            if (ModelState.IsValid)
            {
                db.SiteConfigs.AddObject(siteconfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SiteStartCatID = new SelectList(db.Categories, "CatID", "CatName", siteconfig.SiteStartCatID);
            return View(siteconfig);
        }

        //
        // GET: /SiteConfig/Edit/5

        public ActionResult Edit(long id = 0)
        {
            SiteConfig siteconfig = db.SiteConfigs.Single(s => s.SiteConfigID == id);
            if (siteconfig == null)
            {
                return HttpNotFound();
            }
            ViewBag.SiteStartCatID = new SelectList(db.Categories, "CatID", "CatName", siteconfig.SiteStartCatID);
            return View(siteconfig);
        }

        //
        // POST: /SiteConfig/Edit/5

        [HttpPost]
        public ActionResult Edit(SiteConfig siteconfig)
        {
            if (ModelState.IsValid)
            {
                db.SiteConfigs.Attach(siteconfig);
                db.ObjectStateManager.ChangeObjectState(siteconfig, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiteStartCatID = new SelectList(db.Categories, "CatID", "CatName", siteconfig.SiteStartCatID);
            return View(siteconfig);
        }

        //
        // GET: /SiteConfig/Delete/5

        public ActionResult Delete(long id = 0)
        {
            SiteConfig siteconfig = db.SiteConfigs.Single(s => s.SiteConfigID == id);
            if (siteconfig == null)
            {
                return HttpNotFound();
            }
            return View(siteconfig);
        }

        //
        // POST: /SiteConfig/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            SiteConfig siteconfig = db.SiteConfigs.Single(s => s.SiteConfigID == id);
            db.SiteConfigs.DeleteObject(siteconfig);
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