using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_project.Models
{
    public class OrderConfirmationViewModel
    {
        public Order Order { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ReceiverName { get; set; }
        public string PhoneNumber { get; set; }
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; } // Tổng tiền trước khi giảm giá
        public decimal DiscountedAmount { get; set; } // Tổng tiền sau khi giảm giá
        public decimal ShippingFee { get; set; }
        public decimal Discount { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}