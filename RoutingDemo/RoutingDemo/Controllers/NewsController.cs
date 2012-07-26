using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingDemo.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /News/123

        public ActionResult Story(int id)
        {
            ViewBag.id = id;
            return View();
        }


    }
}
