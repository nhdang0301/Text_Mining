using System;
using System.Collections.Generic;

namespace Text_Mining_Admin_Controller.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? AvatarUrl { get; set; }

    public string? ResetToken { get; set; }

    public DateTime? TokenExpiration { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
