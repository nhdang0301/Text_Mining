﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Final_project
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
                name: "ProductPagination",
                url: "products/page/{page}",
                defaults: new { controller = "Product", action = "ListProductPage", page = UrlParameter.Optional }
);
            // Định nghĩa route cho sản phẩm với tên và ID trong URL
            routes.MapRoute(
                name: "ProductDetails",
                url: "Product/Details/{id}/{name}",
                defaults: new { controller = "Product", action = "Details", name = UrlParameter.Optional }
            );
        }
    }
}
