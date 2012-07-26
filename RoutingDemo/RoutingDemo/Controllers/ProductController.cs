using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingDemo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /product/

        public ActionResult List()
        {
            return View();
        }

        //
        // GET: /target/

        public ActionResult Summary(string target)
        {
            ViewBag.target = target;
            return View();
        }

        //
        // GET: /target/features
        // GET: /target/features-json

        public ActionResult Features(string target, string format)
        {
            ViewBag.target = target;
            ViewBag.format = format;   // would return different ActionResult type depending on format
            return View();
        }

        //
        // GET: /target/techspecs
        // GET: /target/techspecs-xml

        public ActionResult Techspecs(string target, string format)
        {
            ViewBag.target = target;
            ViewBag.format = format;
            return View();
        }

    }
}
