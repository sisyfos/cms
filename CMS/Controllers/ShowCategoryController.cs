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

        public ActionResult Index()
        {
             
            // lista av kategorier från db =>
            var entities = db.Categories.Include("Texts").Include("Pictures");
            // lista som ska skickas till vyn =>
            var model = new List<CategoryModel>();

            // loopa igenom alla kategorier
            foreach(var entity in entities)
            {
                // fyll modellen med innehåll
                CategoryModel catModel = new CategoryModel();
                catModel.CatTitle = entity.CatName;               
                // etc...
                model.Add(catModel);
            }
            
            return View(model);
        }

    }
}
