using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_project.Models
{
    public class CheckoutViewModel
    {
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
        public List<CartViewModel> CartItems { get; set; }  // Đảm bảo CartItems là List<CartViewModel>
        public decimal TotalAmount { get; set; }
        public string ReceiverName { get; set; }
        public string PhoneNumber { get; set; }
    }
}