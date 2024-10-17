using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_project.Models
{
    public class WishlistViewModel
    {
        public int WishlistID { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ImageUrl { get; set; }
    }
}