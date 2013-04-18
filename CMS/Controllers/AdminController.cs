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
            var categories = db.Categories.Include("Template");
            return View(categories.ToList());
        }
    }
}

