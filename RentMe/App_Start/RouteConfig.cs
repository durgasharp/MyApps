using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RentMe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Default1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "SearchRental",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tenent", action = "SearchRental", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tenent", action = "TenentMain", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Renter", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
