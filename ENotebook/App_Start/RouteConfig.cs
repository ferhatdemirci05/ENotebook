using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ENotebook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
        name: "HomeMoveAndDelete",
        url: "Home/MoveAndDelete/{id}",
        defaults: new { controller = "Home", action = "MoveAndDelete", id = UrlParameter.Optional }
    );
            routes.MapRoute(
             name: "HomeDeleteNotebook",
             url: "Home/DeleteNotebook/{id}",
             defaults: new { controller = "Home", action = "DeleteNotebook", id = UrlParameter.Optional }
         );
            routes.MapRoute(
               name: "HomeEditNotebook",
               url: "Home/EditNotebook/{id}",
               defaults: new { controller = "Home", action = "EditNotebook", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Home",
                url: "Home/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
