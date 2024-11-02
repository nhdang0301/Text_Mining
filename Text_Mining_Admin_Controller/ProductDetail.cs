using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Text_Mining_Admin_Controller.Models;

namespace Text_Mining_Admin_Controller
{
    public partial class ProductDetail : Form
    {
        private int _productId;
        private ProductService _productService;
        private string _imageDirectory = @"E:\Final_Project_Text_Mining\Final_project\Final_project\assets\images\shop\";
        public ProductDetail(int productId)
        {
            InitializeComponent();
            _productId = productId;
            _productService = new ProductService(new EcommerceContext());
            LoadProductDetails();
            txtID.ReadOnly = true;
        }

        private void LoadProductDetails()
        {
            // Lấy sản phẩm từ cơ sở dữ liệu
            var product = _productService.GetAllProducts().FirstOrDefault(p => p.ProductId == _productId);
            if (product != null)
            {
                // Nạp dữ liệu vào các điều khiển
                txtID.Text = product.ProductId.ToString();
                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.HasValue ? product.Price.Value.ToString("F2") : "0.00";
                txtStock.Text = product.StockQuantity.ToString();
                txtCatID.Text = product.CategoryId.ToString();

                // Hiển thị hình ảnh sản phẩm (chỉ ảnh hiện có, không cho phép chọn ảnh mới)
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    string imagePath = Path.Combine(_imageDirectory, product.ImageUrl);
                    if (File.Exists(imagePath))
                    {
                        using (var img = Image.FromFile(imagePath))
                        {
                            // Resize ảnh về 300x300
                            var resizedImage = new Bitmap(300, 300);
                            using (var graphics = Graphics.FromImage(resizedImage))
                            {
                                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                graphics.DrawImage(img, 0, 0, 300, 300);
                            }
                            pictureBoxProduct.Image = resizedImage;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Số lượng tồn kho không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var product = _productService.GetAllProducts().FirstOrDefault(p => p.ProductId == _productId);
            if (product != null)
            {
                // Cập nhật dữ liệu sản phẩm 
                product.Name = txtName.Text.Trim();
                product.Description = txtDescription.Text.Trim();
                product.Price = price;
                product.StockQuantity = stock;
                product.CategoryId = int.TryParse(txtCatID.Text.Trim(), out int categoryId) ? categoryId : (int?)null;
                _productService.UpdateProduct(product);
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
