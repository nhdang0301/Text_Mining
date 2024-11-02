using System;
using System.Collections.Generic;

namespace Text_Mining_Admin_Controller.Models;

public partial class Shipping
{
    public int ShippingId { get; set; }

    public int? OrderId { get; set; }

    public string? ShippingMethod { get; set; }

    public string? ShippingStatus { get; set; }

    public DateTime? EstimatedDelivery { get; set; }

    public DateTime? ActualDelivery { get; set; }

    public virtual Order? Order { get; set; }
}
