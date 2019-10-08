using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FixedAssetsWebApp.Models;

namespace FixedAssetsWebApp.Controllers
{
    public class HomeController : Controller
    {
        // initialize variable contains assets database context
        public FixedAssetsWebAppContext db = new FixedAssetsWebAppContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// This controller is called to return JSON containing
        /// search restuls form AJAX call.
        /// </summary>

        public JsonResult SearchResults(string id)
        {
            var assets = from a in db.Assets select a;
            // check the string is not null or empty.
            // return asset description or status
            if (!String.IsNullOrEmpty(id))
            {
                assets = assets.Where(s => s.AssetDescription.Contains(id) || s.Status.Contains(id));
            }
            //Returns JSON containing search results
            return Json(assets.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}