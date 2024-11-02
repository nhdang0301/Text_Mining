using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Mining_Admin_Controller.Models;
using Microsoft.EntityFrameworkCore;

namespace Text_Mining_Admin_Controller
{
    internal class ProductService
    {
        private readonly EcommerceContext _context;

        public ProductService(EcommerceContext context)
        {
            _context = context;
        }

        // Phương thức lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .ToList();
        }
        // Phương thức tìm sản phẩm theo tên hoặc mã
        public List<Product> SearchProducts(string keyword)
        {
            return _context.Products
                           .Where(p => p.Name.Contains(keyword) || p.ProductId.ToString().Contains(keyword))
                           .Include(p => p.Category) // Bao gồm thông tin danh mục để có thể hiển thị đầy đủ
                           .ToList();
        }
        // Phương thức lấy tất cả danh mục
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId && !p.IsDeleted)
                .Include(p => p.Category)
                .ToList();
        }
        public List<ProductCategory> GetAllCategories()
        {
            return _context.ProductCategories.ToList();
        }
        // Phương thức thêm sản phẩm mới
        public bool AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding product: " + ex.Message);
                return false;
            }
        }
        // Phương thức chỉnh sửa sản phẩm
        public bool UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating product: " + ex.Message);
                return false;
            }
        }
        public void SoftDeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                product.IsDeleted = true; // Đánh dấu là đã xóa
                _context.SaveChanges();
            }
        }

        // Method to get a product by ID
        public Product GetProductById(int productId)
        {
            return _context.Products
                .Include(p => p.Category) // Include related data if necessary
                .FirstOrDefault(p => p.ProductId == productId);
        }
        public int GetNextProductId()
        {
            // Nếu chưa có sản phẩm nào, ID đầu tiên sẽ là 1
            return _context.Products.Any() ? _context.Products.Max(p => p.ProductId) + 1 : 1;
        }
        public bool CheckCategoryExists(int categoryId)
        {
            return _context.ProductCategories.Any(c => c.CategoryId == categoryId);
        }
    }
}
