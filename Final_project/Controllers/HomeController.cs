using Final_project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // Lấy 6 sản phẩm ngẫu nhiên đầu tiên với IsDeleted = 0
            var top6Products = db.Products
                                 .Where(p => p.IsDeleted == false)
                                 .OrderBy(p => Guid.NewGuid())
                                 .Take(6)
                                 .ToList();

            // Lấy 3 sản phẩm ngẫu nhiên khác với IsDeleted = 0
            var bottom3Products = db.Products
                                    .Where(p => p.IsDeleted == false)
                                    .OrderBy(p => Guid.NewGuid())
                                    .Take(3)
                                    .ToList();

            var bottom3nextProducts = db.Products
                                        .Where(p => p.IsDeleted == false)
                                        .OrderBy(p => Guid.NewGuid())
                                        .Take(3)
                                        .ToList();

            // Tạo ViewModel để chứa 3 danh sách
            var model = new HomeIndexViewModel
            {
                Top6Products = top6Products,
                Bottom3Products = bottom3Products,
                Bottom3nextProducts = bottom3nextProducts
            };

            return View(model); // Truyền ViewModel vào view
        }

        public ActionResult CategoryTabsPartial()
        {
            // Lấy danh sách các loại sản phẩm từ database
            var categories = db.ProductCategories.ToList();

            var products = new List<Product>();
            foreach (var category in categories.Take(6))
            {
                var productsByCategory = db.Products
                                           .Where(p => p.CategoryID == category.CategoryID && p.IsDeleted == false)
                                           .OrderBy(p => Guid.NewGuid())
                                           .Take(4)
                                           .ToList();
                products.AddRange(productsByCategory);
            }

            // Tạo ViewModel để chứa danh sách danh mục và sản phẩm
            var model = new ProductCategoryTestViewModel
            {
                Categories = categories,
                Products = products
            };

            return PartialView("_CategoryTabs", model);
        }
        public ActionResult ProductCategory()
        {
            // Lấy danh sách category từ database
            var categories = db.ProductCategories.ToList();

            // Tạo ProductCategoryViewModel
            var productCategoryViewModel = new ProductCategoryViewModel
            {
                Categories = categories,
                SelectedCategory = "", // Có thể xử lý để chọn category hiện tại nếu cần
                MinPrice = 0,
                MaxPrice = 2000
            };

            // Trả về PartialView trực tiếp với ProductCategoryViewModel
            return PartialView("_ProductCategoryPartial", productCategoryViewModel);
        }
    }
}