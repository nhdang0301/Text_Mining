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
    public partial class AddProduct : Form
    {
        private string selectedImagePath = string.Empty; // Đường dẫn ảnh đã chọn
        private string imageDirectory = @"E:\Final_Project_Text_Mining\Final_project\Final_project\assets\images\shop\"; // Thư mục lưu ảnh
        private ProductService productService;
        public AddProduct()
        {
            InitializeComponent();
            productService = new ProductService(new EcommerceContext());
            // Lấy ProductID tiếp theo và hiển thị trong txtID
            int nextProductId = productService.GetNextProductId();
            txtID.Text = nextProductId.ToString();
            txtID.ReadOnly = true;
            UpdateNextProductId();
        }
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn ảnh
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    pictureBoxPreview.Image = Image.FromFile(selectedImagePath); // Hiển thị ảnh trong PictureBox
                    pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Khởi tạo ProductService
            ProductService productService = new ProductService(new EcommerceContext());

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtStockQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtCategoryID.Text) ||
                string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Please fill all fields and select an image.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra và chuyển đổi giá trị
            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtStockQuantity.Text, out int stockQuantity) ||
                !int.TryParse(txtCategoryID.Text, out int categoryID))
            {
                MessageBox.Show("Please enter valid data for Price, Stock Quantity, and Category ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tính hợp lệ của CategoryID
            var categoryExists = productService.CheckCategoryExists(categoryID); // Thêm phương thức kiểm tra

            if (!categoryExists)
            {
                MessageBox.Show("The specified Category ID does not exist. Please enter a valid Category ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo tên file ảnh mới
            string newFileName = "product" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
            string newFilePath = Path.Combine(imageDirectory, newFileName);

            // Copy ảnh vào thư mục đích
            try
            {
                File.Copy(selectedImagePath, newFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo sản phẩm mới
            var newProduct = new Product
            {
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Price = price,
                StockQuantity = stockQuantity,
                CategoryId = categoryID,
                ImageUrl = newFileName, // Lưu tên file ảnh, không phải đường dẫn đầy đủ
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };

            // Thêm sản phẩm vào cơ sở dữ liệu
            try
            {
                productService.AddProduct(newProduct);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Phương thức để làm mới form
        private void ResetForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtStockQuantity.Clear();
            txtCategoryID.Clear();
            selectedImagePath = string.Empty;
            pictureBoxPreview.Image = null; // Xóa ảnh xem trước
            UpdateNextProductId();
        }
        private void UpdateNextProductId()
        {
            // Lấy ProductID tiếp theo và hiển thị trong txtID
            int nextProductId = productService.GetNextProductId();
            txtID.Text = nextProductId.ToString();
            txtID.ReadOnly = true;
        }

    }
}
