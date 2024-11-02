using System;
using System.Collections.Generic;

namespace Text_Mining_Admin_Controller.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? DiscountedAmount { get; set; }

    public string? Status { get; set; }

    public string? ShippingAddress { get; set; }

    public string? ReceiverName { get; set; }

    public string? PhoneNumber { get; set; }

    public decimal? ShippingFee { get; set; }

    public decimal? Discount { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();

    public virtual User? User { get; set; }
}
