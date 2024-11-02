using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Text_Mining_Admin_Controller.Models;

namespace Text_Mining_Admin_Controller
{
    public class DashboardService
    {
        private readonly EcommerceContext _context;

        public DashboardService(EcommerceContext context)
        {
            _context = context;
        }

        // Phương thức tính tổng doanh thu
        public decimal GetTotalRevenue()
        {
            try
            {
                // Tính tổng doanh thu từ các đơn hàng trong database
                var totalRevenue = _context.Orders
                    .Where(o => o.Status == "Ordered") // Lọc các đơn hàng đã hoàn thành
                    .Sum(o => o.TotalAmount);

                return (decimal)totalRevenue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating total revenue: " + ex.Message);
                return 0; // Trả về 0 nếu có lỗi
            }
        }
        public int GetTotalCustomers()
        {
            return _context.Orders
                .Select(o => o.UserId)
                .Distinct()
                .Count();
        }
        // Hàm tính tổng số đơn hàng
        public int GetTotalOrders()
        {
            return _context.Orders.Count();
        }
        // Hàm tính giá trị trung bình mỗi đơn hàng
        public decimal GetAverageOrderValue()
        {
            return (decimal)_context.Orders.Average(o => o.TotalAmount);
        }
        // Phương thức tính doanh thu theo tháng
        public List<KeyValuePair<DateTime, decimal>> GetRevenueByMonth()
        {
            var orders = _context.Orders
                .Where(o => o.OrderDate.HasValue)
                .Select(o => new { o.OrderDate, o.TotalAmount })
                .ToList();

            return orders
                .GroupBy(o => new { o.OrderDate.Value.Year, o.OrderDate.Value.Month })
                .Select(g => new KeyValuePair<DateTime, decimal>(
                    new DateTime(g.Key.Year, g.Key.Month, 1), // Ngày đầu tiên của tháng
                    (decimal)g.Sum(o => o.TotalAmount)
                ))
                .OrderBy(entry => entry.Key)
                .ToList();
        }
        //Số lượng sản phẩm theo danh mục hàng
        public List<CategoryProductCount> GetProductCountByCategory()
        {
            var productCounts = (from od in _context.OrderDetails
                                 join p in _context.Products on od.ProductId equals p.ProductId
                                 join c in _context.ProductCategories on p.CategoryId equals c.CategoryId
                                 group od by c.CategoryName into g
                                 select new CategoryProductCount
                                 {
                                     CategoryName = g.Key,
                                     TotalQuantity = (int)g.Sum(od => od.Quantity)
                                 })
                                 .OrderBy(pc => pc.CategoryName)
                                 .ToList();

            return productCounts;
        }

        public List<KeyValuePair<DateTime, int>> GetOrderCountByMonth()
        {
            var orders = _context.Orders
                .Where(o => o.OrderDate.HasValue)
                .Select(o => o.OrderDate.Value)
                .ToList();

            return orders
                .GroupBy(o => new { o.Year, o.Month })
                .Select(g => new KeyValuePair<DateTime, int>(
                    new DateTime(g.Key.Year, g.Key.Month, 1), // Ngày đầu tiên của tháng
                    g.Count() // Đếm số lượng đơn hàng
                ))
                .OrderBy(entry => entry.Key)
                .ToList();
        }
    }
}
