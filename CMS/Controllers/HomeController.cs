using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private cms_2Entities db = new cms_2Entities();

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SiteInfo()
        {
            var siteconfig = db.SiteConfigs.First();

            ViewBag.SiteName = siteconfig.SiteName;
            ViewBag.SiteDesc = siteconfig.SiteDesc;

            return PartialView();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
