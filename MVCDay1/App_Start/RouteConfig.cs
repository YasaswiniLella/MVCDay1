using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDay1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    name: "AgebyDate",
            //    url: "{controller}/{action}/{dob}",
            //    defaults: new { controller = "Customer", action = "FindAge" }
            //    );
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "MoviesByNameandReleaseDate",
            //    url: "{controller}/{action}/{name}/{releaseDate}",
            //    defaults: new { controller = "Movies", action = "SearchMovie", releaseDate = UrlParameter.Optional }
            //    );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
