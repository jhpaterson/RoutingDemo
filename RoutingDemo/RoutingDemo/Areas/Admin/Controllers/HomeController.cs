using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingDemo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Acme Inc. Admin Area";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}
