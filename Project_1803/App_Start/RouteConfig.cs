using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_1803
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "item",
                url: "{controller}/{rootid}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { rootid = @"[\d]+" },
                new string[] { "Project_1803.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "Project_1803.Controllers" }
            );
        }
    }
}
