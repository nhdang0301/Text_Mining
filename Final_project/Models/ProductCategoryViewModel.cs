using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_project.Models
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        // Thông tin phân trang
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        // Lọc theo giá
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        // Lọc theo Danh mục
        public string SelectedCategory { get; set; }
    }
}