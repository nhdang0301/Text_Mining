using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using Final_project.Models;


namespace Final_project.Controllers
{
    public class UserController : Controller
    {
        // GET: Image
        private CloudinaryService _cloudinaryService = new CloudinaryService();
        // GET: Image
        // POST: Image/UploadImage
        private ecommerceEntities db = new ecommerceEntities();

        // Phương thức xử lý upload avatar
        [HttpPost]
        public ActionResult UploadAvatar(HttpPostedFileBase avatar)
        {
            if (avatar != null && avatar.ContentLength > 0)
            {
                // Upload avatar lên Cloudinary
                var avatarUrl = _cloudinaryService.UploadImage(avatar);

                // Lấy thông tin người dùng từ session
                int userId = (int)Session["UserID"];
                var user = db.Users.Find(userId);

                if (user != null)
                {
                    // Lưu URL avatar vào cơ sở dữ liệu
                    user.AvatarUrl = avatarUrl;
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Avatar uploaded successfully!";
                }
            }

            // Điều hướng về trang profile
            return RedirectToAction("Profile");
        }
        // Phương thức hiển thị trang profile
        public ActionResult Profile()
        {
            if (Session["UserID"] == null)
            {
                // Lưu thông báo vào TempData
                TempData["ErrorMessage"] = "Please log in to access your profile.";

                // Điều hướng về trang đăng nhập
                return RedirectToAction("login", "auth");
            }

            int userId = (int)Session["UserID"];
            var user = db.Users.Find(userId);

            if (user == null)
            {
                // Nếu không tìm thấy người dùng, có thể trả về trang lỗi hoặc xử lý khác
                return HttpNotFound();
            }

            return View(user);
        }
        [HttpPost]
        public JsonResult AddToWishlist(int id)
        {
            if (Session["UserID"] == null)
            {
                return Json(new { success = false, message = "Please log in first." }, JsonRequestBehavior.AllowGet);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." }, JsonRequestBehavior.AllowGet);
            }

            int userId = (int)Session["UserID"];
            var wishlistItem = db.Wishlists.FirstOrDefault(w => w.ProductID == product.ProductID && w.UserID == userId);

            if (wishlistItem != null)
            {
                return Json(new { success = false, message = "Product is already in your wishlist." }, JsonRequestBehavior.AllowGet);
            }

            wishlistItem = new Wishlist
            {
                ProductID = product.ProductID,
                UserID = userId,
                CreatedAt = DateTime.Now
            };

            db.Wishlists.Add(wishlistItem);
            db.SaveChanges();

            return Json(new { success = true, message = "Product added to wishlist!" }, JsonRequestBehavior.AllowGet);
        }



        // Display wishlist
        public ActionResult Wishlist()
        {
            int userId = (int)Session["UserID"];

            // Kết hợp Wishlist với Products để lấy thông tin sản phẩm
            var wishlistItems = (from w in db.Wishlists
                                 join p in db.Products on w.ProductID equals p.ProductID
                                 where w.UserID == userId
                                 select new WishlistViewModel
                                 {
                                     WishlistID = w.WishlistID,
                                     CreatedAt = w.CreatedAt,
                                     ProductID = p.ProductID,
                                     ProductName = p.Name,
                                     Price = p.Price,
                                     ImageUrl = p.ImageUrl
                                 }).ToList();

            return View(wishlistItems);
        }

        public ActionResult RemoveFromWishlist(int id)
        {
            int userId = (int)Session["UserID"];
            var wishlistItem = db.Wishlists.FirstOrDefault(w => w.ProductID == id && w.UserID == userId);

            if (wishlistItem != null)
            {
                db.Wishlists.Remove(wishlistItem);
                db.SaveChanges();
            }

            return RedirectToAction("Wishlist");
        }

        // Add to Cart
        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            if (Session["UserID"] == null)
            {
                return Json(new { success = false, message = "Please log in first." }, JsonRequestBehavior.AllowGet);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." }, JsonRequestBehavior.AllowGet);
            }

            int userId = (int)Session["UserID"];
            var cartItem = db.Carts.FirstOrDefault(c => c.ProductID == product.ProductID && c.UserID == userId);

            if (cartItem != null)
            {
                cartItem.Quantity = (cartItem.Quantity ?? 0) + 1;
            }
            else
            {
                cartItem = new Cart
                {
                    ProductID = product.ProductID,
                    Quantity = 1,
                    UserID = userId,
                    CreatedAt = DateTime.Now
                };
                db.Carts.Add(cartItem);
            }

            db.SaveChanges();
            return Json(new { success = true, message = "Product added to cart!" }, JsonRequestBehavior.AllowGet);
        }

        // Hiển thị giỏ hàng
        public ActionResult Cart()
        {
            int userId = (int)Session["UserID"];

            // Kết hợp bảng Carts với Products để lấy thông tin sản phẩm
            var cartItems = (from c in db.Carts
                             join p in db.Products on c.ProductID equals p.ProductID
                             where c.UserID == userId
                             select new CartViewModel
                             {
                                 ProductID = c.ProductID ?? 0,
                                 ProductName = p.Name,      // Lấy thông tin từ bảng Products
                                 Price = p.Price ?? 0,           // Lấy thông tin từ bảng Products
                                 ImageUrl = p.ImageUrl,     // Lấy thông tin từ bảng Products
                                 Quantity = c.Quantity ?? 1 // Nếu Quantity null, đặt mặc định là 1
                             }).ToList();

            return View(cartItems);
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public ActionResult RemoveFromCart(int id)
        {
            int userId = (int)Session["UserID"];
            var cartItem = db.Carts.FirstOrDefault(c => c.ProductID == id && c.UserID == userId);
            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        // Update số lượng
        [HttpPost]
        public JsonResult UpdateCartQuantity(int id, int quantity)
        {
            if (Session["UserID"] == null)
            {
                return Json(new { success = false, message = "Please log in first." });
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            int userId = (int)Session["UserID"];
            var cartItem = db.Carts.FirstOrDefault(c => c.ProductID == product.ProductID && c.UserID == userId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                db.SaveChanges();  // Cập nhật cơ sở dữ liệu với số lượng mới
            }

            // Tính tổng giỏ hàng hiện tại
            var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();
            decimal total = (decimal)cartItems.Sum(item => item.Quantity * item.Product.Price);

            return Json(new { success = true, total = total });
        }



    }
}