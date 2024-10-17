using Final_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_project.Controllers
{
    public class ProductController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();
        // GET: Product
        public ActionResult Details(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductID == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product); // Trả về một sản phẩm đơn lẻ, không phải danh sách
        }

        public ActionResult FilterByPrice(decimal minPrice = 0, decimal maxPrice = 600, int page = 1)
        {
            int pageSize = 9; // Số sản phẩm hiển thị trên mỗi trang

            // Lọc sản phẩm theo khoảng giá
            var filteredProducts = db.Products
                                    .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                                    .OrderBy(p => p.ProductID); // Sắp xếp theo ProductID

            // Tính toán tổng số sản phẩm sau khi lọc
            int totalProducts = filteredProducts.Count();

            // Lấy sản phẩm cho trang hiện tại
            var paginatedProducts = filteredProducts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Lấy danh sách category từ database (nếu cần cho View)
            var categories = db.ProductCategories.ToList();

            // Tạo đối tượng ViewModel
            var viewModel = new ProductCategoryViewModel
            {
                Products = paginatedProducts,
                Categories = categories,  // Nếu cần hiển thị categories
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize),
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };

            return View("ListProductPage", viewModel); // Trả về view với ViewModel
        }


        public ActionResult ProductCategory()
        {
            // Lấy danh sách category từ database
            var categories = db.ProductCategories.ToList();

            // Lấy danh sách sản phẩm từ database
            var products = db.Products.ToList();

            // Tạo đối tượng ViewModel và gán danh sách categories và products vào
            var viewModel = new ProductCategoryViewModel
            {
                Products = products,
                Categories = categories
            };

            // Trả về view với ViewModel
            return View(viewModel);
        }






    }
}