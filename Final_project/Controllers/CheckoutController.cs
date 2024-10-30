using Final_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace Final_project.Controllers
{
    public class CheckoutController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // Action hiển thị giỏ hàng và thông tin đơn hàng
        public ActionResult Checkout()
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "auth");
            }

            // Lấy UserID từ session
            var userId = (int)Session["UserID"];

            // Lấy giỏ hàng từ cơ sở dữ liệu dựa trên bảng Cart và UserID
            var cartItems = db.Carts
                .Where(c => c.UserID == userId)
                .Select(c => new CartViewModel
                {
                    ProductID = c.ProductID ?? 0,
                    ProductName = c.Product.Name,
                    Price = c.Product.Price ?? 0,
                    Quantity = c.Quantity ?? 0,
                    ImageUrl = c.Product.ImageUrl
                }).ToList();

            if (!cartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Index", "Home"); // Chuyển về trang Home nếu giỏ hàng trống
            }

            // Tính tổng số tiền
            var totalAmount = cartItems.Sum(item => item.Price * item.Quantity);

            // Lấy địa chỉ giao hàng từ bảng Users
            var shippingAddress = db.Users.Where(u => u.UserID == userId).Select(u => u.Address).FirstOrDefault();

            // Tạo mô hình để truyền dữ liệu cho view
            var model = new CheckoutViewModel
            {
                UserId = userId,
                ShippingAddress = shippingAddress,
                CartItems = cartItems,
                TotalAmount = totalAmount
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult PlaceOrder(string receiverName, string phoneNumber, string paymentMethod)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "auth");
            }

            var userId = (int)Session["UserID"];

            // Lấy tất cả các sản phẩm trong giỏ hàng của người dùng
            var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();
            if (!cartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Index", "Home");
            }

            // Tính lại tổng số tiền và số tiền sau khi giảm giá
            var totalAmount = cartItems.Sum(item => item.Product.Price * item.Quantity);
            var shippingFee = 2.00M;
            var discount = 0.10M;
            var discountedAmount = totalAmount * (1 - discount) + shippingFee;

            // Kiểm tra xem có đơn hàng "Pending" nào của người dùng chưa, nếu có, cập nhật nó
            var existingOrder = db.Orders.FirstOrDefault(o => o.UserID == userId && o.Status == "Pending");
            if (existingOrder != null)
            {
                existingOrder.ReceiverName = receiverName;
                existingOrder.PhoneNumber = phoneNumber;
                existingOrder.ShippingAddress = db.Users.Where(u => u.UserID == userId).Select(u => u.Address).FirstOrDefault();
                existingOrder.OrderDate = DateTime.Now;
                existingOrder.TotalAmount = totalAmount; // Cập nhật TotalAmount
                existingOrder.DiscountedAmount = discountedAmount; // Cập nhật DiscountedAmount
                existingOrder.ShippingFee = shippingFee;
                existingOrder.Discount = discount;

                // Cập nhật phương thức thanh toán trong bảng Payment
                var payment = db.Payments.FirstOrDefault(p => p.OrderID == existingOrder.OrderID);
                if (payment != null)
                {
                    payment.PaymentMethod = paymentMethod;
                    db.SaveChanges();
                }

                return RedirectToAction("OrderConfirmation", new { orderId = existingOrder.OrderID });
            }

            // Nếu không có đơn hàng "Pending", tạo đơn hàng mới
            var newOrder = new Order
            {
                UserID = userId,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                DiscountedAmount = discountedAmount,
                Status = "Pending",
                ShippingAddress = db.Users.Where(u => u.UserID == userId).Select(u => u.Address).FirstOrDefault(),
                ReceiverName = receiverName,
                PhoneNumber = phoneNumber,
                ShippingFee = shippingFee,
                Discount = discount
            };

            db.Orders.Add(newOrder);
            db.SaveChanges();

            // Tạo bản ghi thanh toán cho đơn hàng mới
            var paymentRecord = new Payment
            {
                OrderID = newOrder.OrderID,
                PaymentMethod = paymentMethod,
                PaymentStatus = "Pending",
                PaymentDate = null
            };

            db.Payments.Add(paymentRecord);
            db.SaveChanges();

            // Chuyển thông tin đơn hàng và giỏ hàng vào trang Xác nhận Đơn hàng
            var model = new OrderConfirmationViewModel
            {
                Order = newOrder,
                PaymentMethod = paymentMethod,
                PaymentStatus = "Pending",
                PaymentDate = null,
                ReceiverName = receiverName,
                PhoneNumber = phoneNumber,
                ShippingAddress = newOrder.ShippingAddress,
                TotalAmount = (decimal)totalAmount,
                DiscountedAmount = (decimal)discountedAmount,
                ShippingFee = shippingFee,
                Discount = discount,
                OrderDetails = cartItems.Select(c => new OrderDetailViewModel
                {
                    ProductName = c.Product.Name,
                    Quantity = c.Quantity ?? 0,
                    Price = c.Product.Price ?? 0
                }).ToList()
            };

            return View("OrderConfirmation", model);
        }
        public ActionResult OrderConfirmation(int orderId)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "auth");
            }

            // Lấy thông tin đơn hàng dựa trên OrderID
            var order = db.Orders.FirstOrDefault(o => o.OrderID == orderId);

            if (order == null)
            {
                TempData["ErrorMessage"] = "Order not found or already confirmed.";
                return RedirectToAction("Index", "Home");
            }

            // Lấy thông tin thanh toán từ bảng Payments
            var payment = db.Payments.FirstOrDefault(p => p.OrderID == orderId);

            // Lấy danh sách sản phẩm từ giỏ hàng của người dùng nếu OrderDetails chưa được ghi vào cơ sở dữ liệu
            var cartItems = db.Carts
                .Where(c => c.UserID == order.UserID)
                .Select(c => new OrderDetailViewModel
                {
                    ProductName = c.Product.Name,
                    Quantity = (int)c.Quantity,
                    Price = c.Product.Price ?? 0
                }).ToList();

            // Nếu chưa có OrderDetails trong cơ sở dữ liệu, dùng dữ liệu từ Cart để hiển thị
            var orderDetails = order.OrderDetails.Any() ?
                order.OrderDetails.Select(d => new OrderDetailViewModel
                {
                    ProductName = d.Product.Name,
                    Quantity = (int)d.Quantity,
                    Price = (decimal)d.Price
                }).ToList() : cartItems;

            // Tạo ViewModel để truyền toàn bộ dữ liệu vào view
            var model = new OrderConfirmationViewModel
            {
                Order = order,
                PaymentMethod = payment?.PaymentMethod ?? "N/A",
                PaymentStatus = payment?.PaymentStatus ?? "Pending",
                PaymentDate = payment?.PaymentDate,
                ReceiverName = order.ReceiverName ?? "N/A",
                PhoneNumber = order.PhoneNumber ?? "N/A",
                ShippingAddress = order.ShippingAddress ?? "N/A",
                TotalAmount = order.TotalAmount ?? 0, // Tổng tiền trước khi giảm giá
                DiscountedAmount = order.DiscountedAmount ?? 0, // Tổng tiền sau khi giảm giá
                ShippingFee = order.ShippingFee ?? 2, // Giá trị mặc định nếu null
                Discount = order.Discount ?? 0.10M,   // Giá trị mặc định nếu null
                OrderDetails = orderDetails // Sử dụng Cart hoặc OrderDetails tùy theo tình huống
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult ConfirmPayment(int orderId)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "auth");
            }

            var order = db.Orders.FirstOrDefault(o => o.OrderID == orderId && o.Status == "Pending");

            if (order != null)
            {
                // Cập nhật trạng thái đơn hàng thành "Ordered"
                order.Status = "Ordered";

                // Cập nhật trạng thái thanh toán
                var payment = db.Payments.FirstOrDefault(p => p.OrderID == orderId);
                if (payment != null)
                {
                    payment.PaymentStatus = "Completed";
                    payment.PaymentDate = DateTime.Now;
                }

                // Chuyển các mục từ Cart vào OrderDetails
                var cartItems = db.Carts.Where(c => c.UserID == order.UserID).ToList();
                foreach (var cartItem in cartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderID = order.OrderID,
                        ProductID = cartItem.ProductID,
                        Quantity = cartItem.Quantity,
                        Price = cartItem.Product.Price ?? 0
                    };
                    db.OrderDetails.Add(orderDetail);
                }

                // Xóa các mục trong Cart sau khi chuyển sang OrderDetails
                db.Carts.RemoveRange(cartItems);
                db.SaveChanges();
            }

            return RedirectToAction("PaymentSuccess", new { orderId = orderId });
        }
        public ActionResult PaymentSuccess(int? orderId)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login", "auth");
            }

            if (orderId == null)
            {
                TempData["ErrorMessage"] = "Order not found.";
                return RedirectToAction("Index", "Home");
            }

            var userId = (int)Session["UserID"];
            var order = db.Orders
                .Where(o => o.OrderID == orderId && o.UserID == userId)
                .Select(o => new OrderConfirmationViewModel
                {
                    Order = o,
                    OrderDetails = o.OrderDetails.Select(d => new OrderDetailViewModel
                    {
                        ProductName = d.Product.Name,
                        Quantity = (int)d.Quantity,
                        Price = (decimal)d.Price
                    }).ToList(),
                    TotalAmount = (decimal)o.TotalAmount,
                    DiscountedAmount = (decimal)o.DiscountedAmount,
                    ShippingFee = (decimal)o.ShippingFee,
                    Discount = (decimal)o.Discount
                }).FirstOrDefault();

            if (order == null)
            {
                TempData["ErrorMessage"] = "Order not found.";
                return RedirectToAction("Index", "Home");
            }

            return View(order); // Trả về view PaymentSuccess với dữ liệu đơn hàng
        }
        public ActionResult DownloadInvoice(int orderId)
        {
            var order = db.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null) return RedirectToAction("PaymentSuccess");
            var payment = db.Payments.FirstOrDefault(p => p.OrderID == orderId);
            // Generate PDF invoice
            var invoiceFile = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, invoiceFile);
            document.Open();

            // Add logo
            var logoPath = Server.MapPath("~/assets/images/home/logo.png"); // Đường dẫn tới logo của bạn
            var logo = Image.GetInstance(logoPath);
            logo.ScaleAbsolute(75f, 22f); // Kích thước của logo
            logo.Alignment = Image.ALIGN_LEFT; // Căn trái
            logo.SetAbsolutePosition(document.LeftMargin, document.PageSize.Height - 50); // Vị trí góc trái trên cùng
            document.Add(logo);

            // Title
            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            var title = new Paragraph("E-shop Sale Invoice", titleFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            // Order Information
            var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var textFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
            document.Add(new Paragraph($"Order ID: {orderId}", headerFont));
            document.Add(new Paragraph($"Date: {DateTime.Now:MMMM dd, yyyy HH:mm:ss}", textFont));
            document.Add(new Paragraph($"Customer Name: {order.ReceiverName}", textFont));
            document.Add(new Paragraph($"Phone Number: {order.PhoneNumber}", textFont));
            document.Add(new Paragraph($"Shipping Address: {order.ShippingAddress}", textFont));
            document.Add(new Paragraph("\n"));

            // Title for the table
            var tableTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var tableTitle = new Paragraph("Order Details", tableTitleFont)
            {
                Alignment = Element.ALIGN_LEFT,
                SpacingAfter = 3f
            };
            document.Add(tableTitle);

            // Table for Order Details
            PdfPTable table = new PdfPTable(4)
            {
                WidthPercentage = 100,
                SpacingBefore = 10f,
                SpacingAfter = 10f
            };
            table.SetWidths(new float[] { 40f, 15f, 20f, 25f });

            // Header Row
            PdfPCell[] headerCells = {
            new PdfPCell(new Phrase("Product", headerFont)) { BackgroundColor = new BaseColor(230, 230, 250) },
            new PdfPCell(new Phrase("Quantity", headerFont)) { BackgroundColor = new BaseColor(230, 230, 250) },
            new PdfPCell(new Phrase("Unit Price", headerFont)) { BackgroundColor = new BaseColor(230, 230, 250) },
            new PdfPCell(new Phrase("Total", headerFont)) { BackgroundColor = new BaseColor(230, 230, 250) }
            };
            foreach (var cell in headerCells)
            {
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 8;
                table.AddCell(cell);
            }

            // Rows for Each Order Item
            var itemsFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            foreach (var item in order.OrderDetails)
            {
                table.AddCell(new PdfPCell(new Phrase(item.Product.Name, itemsFont)));
                table.AddCell(new PdfPCell(new Phrase(item.Quantity.ToString(), itemsFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase($"${item.Price:F2}", itemsFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase($"${item.Price * item.Quantity:F2}", itemsFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
            }
            document.Add(table);

            // Total, Discount, and Final Amount
            document.Add(new Paragraph("Payment Information:", headerFont));
            document.Add(new Paragraph($"Payment Method: {payment?.PaymentMethod ?? "N/A"}", textFont));
            document.Add(new Paragraph($"Payment Status: {payment?.PaymentStatus ?? "Pending"}", textFont));
            document.Add(new Paragraph($"Subtotal: ${order.TotalAmount:F2}", textFont));
            document.Add(new Paragraph($"Shipping Fee: ${order.ShippingFee:F2}", textFont));
            document.Add(new Paragraph($"Discount: {order.Discount:P1}", textFont));
            document.Add(new Paragraph($"Total Amount Due: ${order.DiscountedAmount:F2}", headerFont) { SpacingBefore = 6f, SpacingAfter = 20f });

            document.Close();
            writer.Close();

            return File(invoiceFile.ToArray(), "application/pdf", $"Invoice_{orderId}.pdf");
        }
    }
}