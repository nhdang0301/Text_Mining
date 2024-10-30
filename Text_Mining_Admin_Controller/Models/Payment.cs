﻿using System;
using System.Collections.Generic;

namespace Text_Mining_Admin_Controller.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Order? Order { get; set; }
}
