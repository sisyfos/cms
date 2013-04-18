using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Create and design your own website!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Create and design your own website!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Create and design your own website!";

            return View();
        }
    }
}
