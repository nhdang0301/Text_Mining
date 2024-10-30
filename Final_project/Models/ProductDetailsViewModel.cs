using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_project.Models
{
    public class ProductDetailsViewModel
    {
        // Thông tin sản phẩm
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }

        // Danh sách đánh giá của sản phẩm
        public List<ReviewViewModel> Reviews { get; set; }
    }

    public class ReviewViewModel
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UserAvatar { get; set; } // Thêm AvatarUrl

        // Tên người dùng viết đánh giá
        public string UserName { get; set; }
    }
}