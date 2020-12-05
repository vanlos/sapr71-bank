using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Deposit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Database", action = "Deposits", id = UrlParameter.Optional }
            );
           routes.MapRoute(
             name: "Credit",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Database", action = "Credits", id = UrlParameter.Optional }
       );
            routes.MapRoute(
             name: "CreditCalc",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "CreditCalc", id = UrlParameter.Optional }
       );
        }
    }
}
