using Final_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_project.Controllers
{
    public class HomeController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();
        public ActionResult Index()
        {
            // Lấy 6 sản phẩm ngẫu nhiên đầu tiên
            var top6Products = db.Products.OrderBy(p => Guid.NewGuid()).Take(6).ToList();

            // Lấy 3 sản phẩm ngẫu nhiên khác
            var bottom3Products = db.Products.OrderBy(p => Guid.NewGuid()).Take(3).ToList();
            var bottom3nextProducts = db.Products.OrderBy(p => Guid.NewGuid()).Take(3).ToList();
            // Tạo ViewModel để chứa 3 danh sách
            var model = new HomeIndexViewModel
            {
                Top6Products = top6Products,
                Bottom3Products = bottom3Products,
                Bottom3nextProducts = bottom3nextProducts
            };

            return View(model); // Truyền ViewModel vào view
        }
    }
}