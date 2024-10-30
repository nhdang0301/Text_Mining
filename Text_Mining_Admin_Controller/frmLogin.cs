using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Text_Mining_Admin_Controller.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Text_Mining_Admin_Controller {
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBoxUnhide_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            pictureBoxHide.Visible = true;
            pictureBoxUnhide.Visible = false;

        }
        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            // Hiển thị mật khẩu
            txtPassword.PasswordChar = '\0';
            pictureBoxHide.Visible = false; // Hide icon
            pictureBoxUnhide.Visible = true;  // Unhide icon
        }

        private void labelSignup_Click(object sender, EventArgs e)
        {
            frmSignup signupform = new frmSignup();
            signupform.Show();
            this.Hide();
        }
        // Đặt trong mỗi form
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthService authService = new AuthService(new EcommerceContext());
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra xem username và password đã được điền chưa
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(username))
            {
                MessageBox.Show("Invalid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện đăng nhập
            bool loginSuccess = authService.Login(username, password);

            if (loginSuccess)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Chuyển sang form chính của bạn
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();  // Kích hoạt sự kiện Click của nút Login
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();  // Kích hoạt sự kiện Click của nút Login
            }
        }
    }
}