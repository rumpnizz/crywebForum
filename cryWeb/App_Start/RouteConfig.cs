using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cryWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                "ThreadDetails",
                "trood/{id}/{*query}",
                new { controller = "Home", action = "ThreadDetails", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                "CategoryDetails",
                "kategori/{id}/{*query}",
                new { controller = "Home", action = "CategoryDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Home/Index",
                "hem",
                new { controller = "Home", action = "Index" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}