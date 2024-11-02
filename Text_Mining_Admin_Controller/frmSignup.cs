using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Text_Mining_Admin_Controller.Models;

namespace Text_Mining_Admin_Controller
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }
        private void pictureBoxUnhide_Click(object sender, EventArgs e)
        {
            txtConfirmpassword.PasswordChar = '*';
            pictureBoxHide.Visible = true;
            pictureBoxUnhide.Visible = false;

        }
        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            // Hiển thị mật khẩu
            txtConfirmpassword.PasswordChar = '\0';
            pictureBoxHide.Visible = false; // Hide icon
            pictureBoxUnhide.Visible = true;  // Unhide icon
        }
        private void labelSignup_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.Show();
            this.Hide();
        }

        // Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                email = email.Trim();
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address.Equals(email, StringComparison.InvariantCultureIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void frmSignup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            AuthService authService = new AuthService(new EcommerceContext());

            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string email = txtEmailaddress.Text;
            string phoneNumber = txtPhonenumber.Text;
            string address = txtAddress.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmpassword.Text;

            // Kiểm tra xem các trường có được điền đầy đủ không
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all the required information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem mật khẩu và mật khẩu xác nhận có khớp không
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện đăng ký
            bool signUpSuccess = authService.SignUp(firstName, lastName, email, phoneNumber, address, email, password);

            if (signUpSuccess)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Có thể chuyển sang form đăng nhập hoặc form chính
            }
            else
            {
                MessageBox.Show("Username or email already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
