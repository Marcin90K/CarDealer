using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("", "Strona{page}",
                            new { controller = "Car", action = "List",
                            carType = (string)null },
                            new {page = @"\d+"});

            routes.MapRoute("", "{carType}",
                            new { controller = "Car", action = "List", page = 1 }
                            );

            routes.MapRoute("", "{carType}/Strona{page}",
                            new { controller = "Car", action = "List" },
                            new { page = @"\d+" }
                            );


            routes.MapRoute("", "{controller}/{carType}/Strona{page}",
                            new { controller = "Car", action = "List" },
                            new { page = @"\d+" }
                            );


            routes.MapRoute("", "{controller}/{action}/{id}",
                            new { controller = "Car", action = "CarDetails"},
                            new { id = @"\d+"}
                            );


            routes.MapRoute("StaticPages", "",
                            new { controller = "Home", action = "Index" }
                            );




            routes.MapRoute("Default", "{controller}/{action}",
                            new { controller = "Car", action = "List" });

            /*routes.MapRoute("", "Strona{page}",
                new { controller = "Car", action = "List" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Car", action = "List", id = UrlParameter.Optional }
            );*/
        }
    }
}
