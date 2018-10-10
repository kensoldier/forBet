using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace projectWith中佑
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{shopNumber}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, shopNumber =UrlParameter.Optional}
            );
        }
    }
}
