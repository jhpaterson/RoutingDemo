using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoutingDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // route to custom handler - may have unintended consequences for outgoing routes generated 
            //routes.Add(new Route("SayHello",
            //    new RoutingDemo.Infrastructure.CustomHandlers.CustomeRouteHandler()));

            routes.MapRoute(
                "Search", // Route name
                "search", // Sample URL: /search
                new
                {
                    controller = "Search",
                    action = "Index"
                } // Parameter defaults
            );

            routes.MapRoute(
                "SearchResults", // Route name
                "searchresults", // Sample URL: /searchresults
                new
                {
                    controller = "Search",
                    action = "Results",
                }, // Parameter defaults
                new { httpMethod = new HttpMethodConstraint("POST") }  // Lab 2 Ex 2b
            );

            routes.MapRoute(
                "News", // Route name
                "news", // Sample URL: /news
                new
                {
                    controller = "News",
                    action = "Index"
                } // Parameter defaults
            );

            routes.MapRoute(
                "NewsStory", // Route name
                "news/{id}", // Sample URL: /news/123
                new
                {
                    controller = "News",
                    action = "Story",
                }, // Parameter defaults
                new
                {
                    id = @"^[0-9]{0,4}"
                } // Lab 2 Ex 2a
            );

            routes.MapRoute(
                "ProductList", // Route name
                "products", // Sample URL: /products
                new
                {
                    controller = "Product",
                    action = "List",
                } // Parameter defaults
            );

            routes.MapRoute(
                "ProductHome", // Route name
                "{target}", // Sample URL: /gizmo
                new
                {
                    controller = "Product",
                    action = "Summary",
                } // Parameter defaults
            );

            routes.MapRoute(
                "ProductDetails", // Route name
                "{target}/{action}", // Sample URL: /gizmo/features
                new
                {
                    controller = "Product",
                },// Parameter defaults
                new
                {
                    action = "^features$|^techspecs$"
                } // Constraints
            );

            routes.MapRoute(
                "ProductDetailsWithFormat", // Route name
                "{target}/{action}-{format}", // Sample URL: /gizmo/features-json
                new
                {
                    controller = "Product",
                },// Parameter defaults
                new
                {
                    action = "^features$|^techspecs$",
                    format = "^json$|^xml$"
                } // Constraints
            );

            routes.MapRoute(
              "Default", // Route name
              "{controller}/{action}/{id}", // Sample URL: Home/Index/3
              new
              {
                  controller = "Home",
                  action = "Index",
                  id = UrlParameter.Optional
              }, // Parameter defaults
              new
              {
                  controller = "^Home$|^Account$"
              }, // Constraints
              new[] { "RoutingDemo.Controllers" }
            );

            routes.MapRoute(
                "Catchall", // Route name
                "{*url}", // Sample URL: Home/Index/3/4
                new
                {
                    controller = "Home",
                    action = "PageNotFound"
                }, // Parameter defaults
                 new[] { "RoutingDemo.Controllers" }
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}