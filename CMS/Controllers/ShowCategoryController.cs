using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class ShowCategoryController : Controller
    {
        private cms_2Entities db = new cms_2Entities();

        //
        // GET: /ShowCategory/

        public ActionResult Index(int? id)
        {
             
            var category = new Category();
            var entities = db.Categories.Include("Texts").Include("Pictures");

            if(id.HasValue)
            {
                category = db.Categories.Include("Texts").Include("Videos").Include("Links").Include("Pictures").First(c => c.CatID == id.Value);
                catModel.CatTitle = entity.CatName;               
            }
            
            return View(category);
        }

    }
}
