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
    public class ShowCssController : Controller
    {
        private cms_2Entities db = new cms_2Entities();

        public ActionResult Details(int? id)
        {
            var category = new Category();
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            return View(category);
        }


    }
}