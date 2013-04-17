using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Controllers;
using System.IO;
using System.Web.Helpers;
using CMS.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Imagenew()
        {
            var model = new ImageModel()
            {
                Images = Directory.EnumerateFiles(Server.MapPath("~/images_upload/"))
                                  .Select(fn => "~/images_upload/" + Path.GetFileName(fn))
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Imagenew(ImageModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = Guid.NewGuid().ToString();
                string serverPath = Server.MapPath("~");
                string imagesPath = serverPath + "/images_upload";
                string thumbPath = imagesPath + "/images_upload";
                string fullPath = imagesPath + "/images_upload";
                ImageModel.ResizeAndSave(thumbPath, fileName, model.ImageUploaded.InputStream, 80, true);
                ImageModel.ResizeAndSave(fullPath, fileName, model.ImageUploaded.InputStream, 600, true);
            }
            return RedirectToAction("Imagenew");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
