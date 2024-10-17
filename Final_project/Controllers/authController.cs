using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using Final_project.Models;
using System.Net.Mail;
using System.Net.Mail;

namespace Final_project.Controllers

{
    public class authController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();
        // GET: Login
        // GET: /auth/login
        [HttpGet]
        public ActionResult login()
        {
            if (Session["UserID"] != null)
            {
                // Nếu đã đăng nhập, chuyển hướng về trang Index hoặc bất kỳ trang nào bạn muốn
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hash mật khẩu để so sánh với mật khẩu đã lưu
                string inputPasswordHash = HashPassword(model.Password);

                // Kiểm tra xem email có tồn tại và mật khẩu có khớp hay không
                var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == inputPasswordHash);

                if (user != null)
                {
                    // Lưu thông tin người dùng vào Session
                    Session["UserID"] = user.UserID; // Lưu ID người dùng
                    Session["UserName"] = user.FirstName + " " + user.LastName; // Lưu tên người dùng

                    // Đăng nhập thành công
                    TempData["SuccessMessage"] = "Login successful!";

                    // Kiểm tra nếu có returnUrl trong session, chuyển hướng người dùng trở lại trang đó
                    if (Session["returnUrl"] != null)
                    {
                        string returnUrl = Session["returnUrl"].ToString();
                        Session["returnUrl"] = null; // Xóa returnUrl sau khi sử dụng
                        return Redirect(returnUrl); // Chuyển về trang mà người dùng đã truy cập trước đó
                    }

                    // Nếu không có returnUrl, chuyển hướng đến trang Home mặc định
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            return View(model);
        }


        // GET: /auth/signup
        [HttpGet]
        public ActionResult signup()
        {
            if (Session["UserID"] != null)
            {
                // Nếu đã đăng nhập, chuyển hướng về trang Index hoặc bất kỳ trang nào bạn muốn
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // POST: /auth/signup
        [HttpPost]
        public ActionResult signup(SignupViewModel model)
        {
            // Kiểm tra nếu model hợp lệ
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu hay chưa
                var existingUser = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    // Nếu email đã tồn tại, hiển thị thông báo lỗi
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(model);
                }
                // Tạo salt và băm mật khẩu trước khi lưu vào cơ sở dữ liệu
                string hashedPassword = HashPassword(model.Password);

                // Tạo đối tượng người dùng mới
                var newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    PasswordHash = hashedPassword, // Lưu mật khẩu đã băm
                    Role = "User", // Vai trò mặc định là User
                    CreatedAt = DateTime.Now
                };
                
                // Lưu người dùng vào cơ sở dữ liệu
                db.Users.Add(newUser); // Thêm vào bảng Users
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                // Thêm thông báo đăng ký thành công vào TempData
                TempData["SuccessMessage"] = "Registration successful! You can now log in.";

                // Điều hướng đến trang đăng nhập sau khi đăng ký thành công
                return RedirectToAction("login", "auth");
            }

            // Nếu có lỗi, quay lại biểu mẫu với thông báo lỗi
            return View(model);
        }
        // Hàm tạo salt (ngẫu nhiên)
        //private string CreateSalt()
        //{
        //    var rng = new RNGCryptoServiceProvider();
        //    var saltBytes = new byte[32];
        //    rng.GetBytes(saltBytes);
        //    return Convert.ToBase64String(saltBytes);
        //}

        // Hàm băm mật khẩu với salt
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Concat(password);
                var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                var hashedBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }
        public ActionResult logout()
        {
            Session.Clear(); // Xóa toàn bộ session
            TempData["SuccessMessage"] = "You have successfully logged out.";
            return RedirectToAction("login", "auth");
        }
        // GET: Forgot Password
        public ActionResult ForgotPassword()
        {
            return View();
        }
        // POST: Gửi link đặt lại mật khẩu
        [HttpPost]
        public ActionResult SendResetLink(string email)
        {
            // Tìm người dùng theo email trong cơ sở dữ liệu
            var user = db.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                ViewBag.ErrorMessage = "Email not found!";
                return View("ForgotPassword");
            }

            // Tạo mã xác nhận
            string resetToken = Guid.NewGuid().ToString();
            user.ResetToken = resetToken;
            user.TokenExpiration = DateTime.Now.AddHours(1); // Token có hạn 1 giờ
            db.SaveChanges();

            // Gửi email xác nhận
            SendEmail(user.Email, resetToken);

            ViewBag.Message = "A password reset link has been sent to your email.";
            return View("ForgotPassword");
        }

        private void SendEmail(string email, string resetToken)
        {
            // Tạo URL đặt lại mật khẩu
            string resetLink = Url.Action("ResetPassword", "auth", new { token = resetToken }, protocol: Request.Url.Scheme);

            // Gửi email với mã xác thực
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.Credentials = new System.Net.NetworkCredential("dangnh21416c@st.uel.edu.vn", "Nhdang0301");
            smtpClient.EnableSsl = true;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            MailMessage mail = new MailMessage("dangnh21416c@st.uel.edu.vn", email)
            {
                Subject = "Reset Your Password",
                Body = $"Click the link to reset your password: {resetLink}",
                IsBodyHtml = true
            };

            smtpClient.Send(mail);
        }
        // GET: Display Reset Password Form
        [HttpGet]
        public ActionResult ResetPassword(string token)
        {
            // Ensure ErrorMessage is set to an empty string initially
            ViewBag.ErrorMessage = "";

            var user = db.Users.FirstOrDefault(u => u.ResetToken == token && u.TokenExpiration > DateTime.Now);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid or expired token.";
                return View();
            }

            ViewBag.Token = token;
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(string token, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match.";
                ViewBag.Token = token; // Đảm bảo token được truyền lại vào view để giữ trạng thái
                return View();
            }

            // Tìm người dùng theo token
            var user = db.Users.FirstOrDefault(u => u.ResetToken == token && u.TokenExpiration > DateTime.Now);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid or expired token.";
                return View();
            }

            // Thay đổi mật khẩu
            user.PasswordHash = HashPassword(newPassword); // Giả định rằng bạn đã có phương thức băm mật khẩu
            user.ResetToken = null; // Xóa token sau khi sử dụng
            user.TokenExpiration = null;
            db.SaveChanges();

            // Chuyển hướng đến trang đăng nhập hoặc hiển thị thông báo thành công
            TempData["SuccessMessage"] = "Your password has been reset successfully.";
            return RedirectToAction("login", "auth");
        }

    }
}