using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingDemo.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Search/target

        public ActionResult Results(string target)
        {
            ViewBag.target = target;
            return View();
        }

    }
}
