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
    [Authorize]
    public class AdminController : Controller
    {
        private cms_2Entities db = new cms_2Entities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            ViewBag.Message = "Configuration";
            return View();
        }

        public ActionResult Page()
        {
            ViewBag.Message = "Create pages";
            var selectList = new SelectList(db.Categories, "CatID", "CatName");
            return View(selectList);
        }

        public ActionResult Content()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category model)
        {
            model.TempID = 1;
            var redirectController = new CategoryController();
            return redirectController.Create(model);
        }
    }
}

