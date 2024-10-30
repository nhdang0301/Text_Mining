using Final_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_project.Controllers
{
    public class ProductController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();
        // GET: Product
        public ActionResult Details(int id, string name)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var reviews = db.Reviews
                .Where(r => r.ProductID == id)
                .Select(r => new ReviewViewModel
                {
                    ReviewID = r.ReviewID,
                    Rating = (int)r.Rating,
                    Content = r.Content,
                    CreatedAt = (DateTime)r.CreatedAt,
                    UserName = r.User.FirstName + " " + r.User.LastName,
                    UserAvatar = r.User.AvatarUrl
                })
                .ToList();

            var model = new ProductDetailsViewModel
            {
                ProductId = product.ProductID,
                Name = product.Name,
                Price = product.Price ?? 0,
                ImageUrl = product.ImageUrl,
                StockQuantity = product.StockQuantity ?? 0,
                Reviews = reviews
            };

            return View(model);
        }


        [HttpPost]
        public JsonResult SubmitReview(int ProductId, string Content, int Rating)
        {
            if (Session["UserID"] == null)
            {
                return Json(new { success = false, message = "Please log in to submit a review." });
            }

            int userId = (int)Session["UserID"];
            var user = db.Users.FirstOrDefault(u => u.UserID == userId);

            var review = new Review
            {
                ProductID = ProductId,
                UserID = userId,
                Content = Content,
                Rating = Rating,
                CreatedAt = DateTime.Now
            };

            db.Reviews.Add(review);
            db.SaveChanges();

            return Json(new
            {
                success = true,
                review = new
                {
                    UserName = $"{user.FirstName} {user.LastName}",
                    UserAvatar = user.AvatarUrl ?? "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg",
                    Content = review.Content,
                    Rating = review.Rating,
                    CreatedAt = review.CreatedAt?.ToString("yyyy-MM-dd")
                }
            });
        }

        public ActionResult FilterByPrice(string categoryName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1)
        {
            int pageSize = 9; // Số sản phẩm hiển thị trên mỗi trang

            // Thiết lập giá trị mặc định cho minPrice và maxPrice nếu chúng bị null
            decimal minPriceValue = minPrice ?? 0;
            decimal maxPriceValue = maxPrice ?? 2000;

            // Bắt đầu với tập sản phẩm cơ bản
            var filteredProducts = db.Products.AsQueryable();

            // Lọc sản phẩm theo danh mục nếu có
            if (!string.IsNullOrEmpty(categoryName))
            {
                filteredProducts = filteredProducts.Where(p => p.ProductCategory.CategoryName == categoryName);
            }

            // Lọc sản phẩm theo khoảng giá
            filteredProducts = filteredProducts.Where(p => p.Price >= minPriceValue && p.Price <= maxPriceValue)
                                               .OrderBy(p => p.ProductID); // Sắp xếp theo ProductID

            // Tính toán tổng số sản phẩm sau khi lọc
            int totalProducts = filteredProducts.Count();

            // Lấy sản phẩm cho trang hiện tại
            var paginatedProducts = filteredProducts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Lấy danh sách category từ database
            var categories = db.ProductCategories.ToList();

            // Cập nhật giá trị cho ViewBag để truyền cho view
            ViewBag.MinPrice = minPriceValue;
            ViewBag.MaxPrice = maxPriceValue;

            // Tạo đối tượng ViewModel
            var viewModel = new ProductCategoryViewModel
            {
                Products = paginatedProducts,
                Categories = categories,  // Hiển thị danh sách danh mục
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize),
                MinPrice = minPriceValue,
                MaxPrice = maxPriceValue,
                SelectedCategory = categoryName // Gán danh mục đã chọn nếu có
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