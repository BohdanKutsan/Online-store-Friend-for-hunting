﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnimalStore2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Dogs",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Dogs", action = "List", type = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{type}",
                new { controller = "Dogs", action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{type}/Page{page}",
                new { controller = "Dogs", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dogs", action = "List", id = UrlParameter.Optional });
        }
    }
}
