using System;
using System.Collections.Generic;

namespace Text_Mining_Admin_Controller.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public string? Content { get; set; }

    public int? Rating { get; set; }

    public string? Sentiment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
