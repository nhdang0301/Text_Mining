using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Text_Mining_Admin_Controller.Models;

namespace Text_Mining_Admin_Controller
{
    public partial class ProductControl : UserControl
    {
        private int currentCategoryId = 0;
        private string currentSearchQuery = "";
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private ProductService _productService;
        private Dictionary<int, Image> imageCache = new Dictionary<int, Image>(); // Bộ nhớ cache cho ảnh đã tải
        private string currentSortOrder = "None";

        public ProductControl()
        {
            InitializeComponent();
            _productService = new ProductService(new EcommerceContext());
            currentCategoryId = 0;
            currentSearchQuery = "";
            LoadData(currentPage, currentCategoryId, currentSearchQuery, currentSortOrder);
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            dataGridViewListProduct.AutoGenerateColumns = false;
            // Thiết lập placeholder khi khởi tạo
            SetPlaceholder();
            LoadCategories();
            // Gắn sự kiện Enter và Leave cho txtSearch
            txtSearch.Enter += (s, e) => RemovePlaceholder();
            txtSearch.Leave += (s, e) => SetPlaceholder();
        }
        private void LoadData(int page, int categoryId = 0, string searchQuery = "", string sortOrder = "None")
        {
            ClearPreviousImages();

            string imageDirectory = @"E:\Final_Project_Text_Mining\Final_project\Final_project\assets\images\shop\";

            // Bắt đầu với danh sách sản phẩm ban đầu
            IEnumerable<Product> productsQuery = _productService.GetAllProducts();
            if (categoryId != 0)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == categoryId);
            }
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                productsQuery = productsQuery.Where(p =>
                    p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    p.ProductId.ToString() == searchQuery);
            }
            // **Apply sorting here before pagination**
            if (sortOrder == "Ascending")
            {
                productsQuery = productsQuery.OrderBy(p => p.Price);
            }
            else if (sortOrder == "Descending")
            {
                productsQuery = productsQuery.OrderByDescending(p => p.Price);
            }
            // **Calculate total records after filtering**
            totalRecords = productsQuery.Count();
            // Lấy dữ liệu sản phẩm và ảnh với phân trang
            var products = productsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDisplay
                {
                    ProductId = p.ProductId,
                    ProductImage = LoadImage(imageDirectory, p.ImageUrl), // Gán ảnh đã thay đổi kích thước vào ProductDisplay
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category?.CategoryName,
                    StockQuantity = p.StockQuantity,
                    Description = p.Description
                })
                .ToList();

            // Đặt DataSource mới cho DataGridView
            dataGridViewListProduct.DataSource = new BindingList<ProductDisplay>(products);

            // Xóa cột "ImageUrl" nếu nó tồn tại
            if (dataGridViewListProduct.Columns.Contains("ImageUrl"))
            {
                dataGridViewListProduct.Columns.Remove("ImageUrl");
            }

            // Đặt lại tên tiêu đề cột
            dataGridViewListProduct.Columns["ProductId"].HeaderText = "ID";
            dataGridViewListProduct.Columns["CategoryName"].HeaderText = "Category";
            dataGridViewListProduct.Columns["StockQuantity"].HeaderText = "Stock";
            dataGridViewListProduct.Columns["Description"].HeaderText = "Description";
            dataGridViewListProduct.Columns["ProductImage"].HeaderText = "Image";

            // Thêm cột "ProductImage" nếu chưa có
            if (!dataGridViewListProduct.Columns.Contains("ProductImage"))
            {
                var imageColumn = new DataGridViewImageColumn
                {
                    Name = "ProductImage",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Đặt chế độ Zoom
                };
                dataGridViewListProduct.Columns.Insert(1, imageColumn); // Chèn cột vào vị trí mong muốn

                // Đặt độ rộng cố định cho cột ảnh
                dataGridViewListProduct.Columns["ProductImage"].Width = 50; // Đặt độ rộng cột ảnh
            }

            // Đảm bảo cột "EditImage" nằm ở cuối cùng
            AddEditImageColumn();

            // Update pagination info
            int totalPages = (totalRecords + pageSize - 1) / pageSize;
            lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

            // Enable/disable navigation buttons
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }
        private void LoadCategories()
        {
            // Retrieve the list of categories from the database
            var categories = _productService.GetAllCategories();

            // Insert an "All" option at the beginning of the list
            categories.Insert(0, new ProductCategory { CategoryId = 0, CategoryName = "All" });

            // Bind the categories to the ComboBox
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = categories;
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCategoryId = (int)cmbCategory.SelectedValue;
            currentPage = 1; // Reset to the first page when the category changes
            LoadData(currentPage, currentCategoryId, currentSearchQuery, currentSortOrder);
        }
        private void AddEditImageColumn()
        {
            // Đảm bảo xóa cột "EditImage" nếu nó đã tồn tại, để tránh thêm trùng
            if (dataGridViewListProduct.Columns.Contains("EditImage"))
            {
                dataGridViewListProduct.Columns.Remove("EditImage");
            }

            // Tạo cột hình ảnh giống như nút "Edit"
            var editImageColumn = new DataGridViewImageColumn
            {
                Name = "EditImage",
                HeaderText = "Edit",
                Image = Image.FromFile(@"E:\Final_Project_Text_Mining\Final_project\Text_Mining_Admin_Controller\assets\icon\editbtn.png"), // Đường dẫn tới hình ảnh nút Edit
                ImageLayout = DataGridViewImageCellLayout.Zoom, // Đặt chế độ Zoom cho hình ảnh
                Width = 10 // Đặt độ rộng cột hình ảnh
            };

            dataGridViewListProduct.Columns.Add(editImageColumn); // Thêm cột vào vị trí cuối cùng
        }
        // Sự kiện xử lý khi nhấn vào ô chứa hình ảnh "Edit"
        private void dataGridViewListProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu nhấn vào cột "EditImage"
            if (e.ColumnIndex == dataGridViewListProduct.Columns["EditImage"].Index && e.RowIndex >= 0)
            {
                int productId = (int)dataGridViewListProduct.Rows[e.RowIndex].Cells["ProductId"].Value;

                // Mở ProductDetailForm và đợi kết quả
                using (var detailForm = new ProductDetail(productId))
                {
                    if (detailForm.ShowDialog() == DialogResult.OK)
                    {
                        // Reload dữ liệu sau khi cập nhật
                        LoadData(currentPage);
                    }
                }
            }
        }
        // Thay đổi con trỏ khi di chuột vào cột "EditImage"
        private void dataGridViewListProduct_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Check if "EditImage" column exists and if the mouse is over a valid cell
            if (dataGridViewListProduct.Columns.Contains("EditImage") &&
                e.ColumnIndex == dataGridViewListProduct.Columns["EditImage"].Index &&
                e.RowIndex >= 0)
            {
                dataGridViewListProduct.Cursor = Cursors.Hand; // Change cursor to hand
            }
            else
            {
                dataGridViewListProduct.Cursor = Cursors.Default; // Change cursor back to default
            }
        }
        // Trả con trỏ về mặc định khi rời khỏi cột "EditImage"
        private void dataGridViewListProduct_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewListProduct.Cursor = Cursors.Default; // Ensure cursor resets to default
        }
        // Hàm nạp ảnh đồng bộ và thay đổi kích thước ảnh trong LoadData
        private Image LoadImage(string imageDirectory, string imageUrl)
        {
            string fullPath = Path.Combine(imageDirectory, imageUrl);
            if (File.Exists(fullPath))
            {
                try
                {
                    using (var img = Image.FromFile(fullPath))
                    {
                        // Tạo kích thước mới cho ảnh 
                        int targetWidth = 40;
                        int targetHeight = 40;

                        // Tạo ảnh mới với kích thước đã thay đổi
                        var resizedImage = new Bitmap(targetWidth, targetHeight);
                        using (var graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            graphics.DrawImage(img, 0, 0, targetWidth, targetHeight);
                        }

                        return resizedImage; // Trả về ảnh đã thay đổi kích thước
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        // Giải phóng bộ nhớ cache cho ảnh trước khi nạp trang mới
        private void ClearPreviousImages()
        {
            foreach (var img in imageCache.Values)
            {
                img.Dispose();
            }
            imageCache.Clear();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (totalRecords + pageSize - 1) / pageSize;
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData(currentPage, currentCategoryId, currentSearchQuery, currentSortOrder);
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData(currentPage, currentCategoryId, currentSearchQuery, currentSortOrder);
            }
        }
        private void ProductControl_Load(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData(currentPage, currentCategoryId, currentSearchQuery, currentSortOrder);
            dataGridViewListProduct.CellClick += dataGridViewListProduct_CellClick; // Đăng ký sự kiện cho hình ảnh "Edit"
            dataGridViewListProduct.CellMouseEnter += dataGridViewListProduct_CellMouseEnter; // Đổi con trỏ khi vào
            dataGridViewListProduct.CellMouseLeave += dataGridViewListProduct_CellMouseLeave; // Đổi con trỏ lại khi ra
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedCount = dataGridViewListProduct.SelectedRows.Count; // Đếm số lượng dòng được chọn
            int deletedCount = 0; // Đếm số lượng sản phẩm đã xóa thành công

            if (selectedCount > 0) // Check if at least one row is selected
            {
                // Hiển thị thông báo xác nhận với số lượng sản phẩm được chọn
                var confirmResult = MessageBox.Show($"Are you sure you want to delete these {selectedCount} products?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    // Xóa từng sản phẩm được chọn
                    foreach (DataGridViewRow selectedRow in dataGridViewListProduct.SelectedRows)
                    {
                        int productId = (int)selectedRow.Cells["ProductId"].Value;
                        if (DeleteProduct(productId)) // Nếu xóa thành công, tăng số lượng đã xóa
                        {
                            deletedCount++;
                        }
                    }

                    // Tải lại dữ liệu sau khi xóa
                    LoadData(currentPage);

                    // Hiển thị thông báo tổng kết sau khi xóa xong
                    if (deletedCount > 0)
                    {
                        MessageBox.Show($"{deletedCount} products deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No products were deleted.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one product to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool DeleteProduct(int productId)
        {
            try
            {
                var product = _productService.GetAllProducts().FirstOrDefault(p => p.ProductId == productId && !p.IsDeleted);
                if (product != null)
                {
                    _productService.SoftDeleteProduct(productId); // Soft delete by ID
                    return true; // Xóa thành công
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false; // Xóa không thành công hoặc không tìm thấy sản phẩm
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Tạo và mở form thêm sản phẩm
            var addProductForm = new AddProduct();

            // Hiển thị form mà không đóng nó sau khi thêm sản phẩm
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadData(currentPage); // Tải lại danh sách sản phẩm sau khi thêm
            }
        }
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Product Name or ID";
                txtSearch.ForeColor = Color.Gray;
            }
        }
        private void RemovePlaceholder()
        {
            if (txtSearch.Text == "Product Name or ID")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            currentSearchQuery = txtSearch.Text.Trim();
            if (currentSearchQuery == "Product Name or ID")
            {
                currentSearchQuery = ""; // Treat placeholder as empty
            }

            currentPage = 1; // Reset to the first page when initiating a new search
            LoadData(currentPage, currentCategoryId, currentSearchQuery, currentSortOrder);
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e); // Gọi hàm tìm kiếm khi nhấn Enter
                e.Handled = true; // Ngăn không cho xử lý thêm
                e.SuppressKeyPress = true; // Ngăn phát ra âm thanh Enter mặc định
            }
        }
        private void cbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSortOrder.SelectedItem != null)
            {
                currentSortOrder = cbSortOrder.SelectedItem.ToString();
            }
            else
            {
                currentSortOrder = "None";
            }
            currentPage = 1; // Reset to the first page
            LoadData(currentPage, currentCategoryId, currentSearchQuery, currentSortOrder);
        }

    }
}