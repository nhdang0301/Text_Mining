using System;

using System.Security.Cryptography;
using System.Text;
using Text_Mining_Admin_Controller.Models;

namespace Text_Mining_Admin_Controller
{
    public class AuthService
    {
        private readonly EcommerceContext _context;

        public AuthService(EcommerceContext context)
        {
            _context = context;
        }

        // Phương thức đăng ký
        public bool SignUp(string firstName, string lastName, string email, string phoneNumber, string address, string username, string password, string role = "Admin")
        {
            try
            {
                // Kiểm tra xem email hoặc username đã tồn tại chưa
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.Email == username || u.Email == email);

                if (existingUser != null)
                {
                    // Username hoặc Email đã tồn tại
                    return false;
                }

                // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                var hashedPassword = HashPassword(password);

                // Tạo người dùng mới
                User newUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    PasswordHash = hashedPassword,
                    Role = role
                };

                // Thêm người dùng vào cơ sở dữ liệu
                _context.Users.Add(newUser);
                _context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu

                return true;  // Đăng ký thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during sign up: " + ex.Message);
                return false;  // Đăng ký thất bại
            }
        }

        // Phương thức đăng nhập
        public bool Login(string username, string password)
        {
            try
            {
                // Tìm người dùng dựa trên username
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == username);

                if (user == null)
                {
                    // Người dùng không tồn tại
                    return false;
                }

                // So sánh mật khẩu đã mã hóa
                if (VerifyPassword(password, user.PasswordHash))
                {
                    return true;  // Đăng nhập thành công
                }
                else
                {
                    return false;  // Mật khẩu không khớp
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex.Message);
                return false;
            }
        }

        // Hàm mã hóa mật khẩu (SHA-256)
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Hàm xác minh mật khẩu
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            var hashedPassword = HashPassword(enteredPassword);
            return hashedPassword == storedHashedPassword;
        }
    }
}
