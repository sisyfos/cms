using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class MenuController : Controller
    {
        private cms_2Entities db = new cms_2Entities();
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            var categories = db.Categories.Include("Template");
            return View(categories.ToList());            
        }

    }
}
