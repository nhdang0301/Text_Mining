using System;
using System.Collections.Generic;

namespace Text_Mining_Admin_Controller.Models;

public partial class OrderHistory
{
    public int HistoryId { get; set; }

    public int? OrderId { get; set; }

    public string? Status { get; set; }

    public DateTime? StatusDate { get; set; }

    public virtual Order? Order { get; set; }
}
